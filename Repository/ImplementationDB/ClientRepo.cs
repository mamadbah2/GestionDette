using System;
using System.Collections.Generic;
using System.Data;
using GestionDette.Model;
using GestionDette.Repository;
using Npgsql;  // Bibliothèque pour se connecter à PostgreSQL

public class ClientRepo : IntClientRepo
{
    private readonly string _connectionString;

    public ClientRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Client> SelectAll()
    {
        var clients = new List<Client>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("SELECT * FROM clients", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                            // Ajouter d'autres propriétés ici en fonction de ta classe Client
                        });
                    }
                }
            }
        }

        return clients;
    }

    public Client? SelectById(int id)
    {
        Client? client = null;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("SELECT * FROM clients WHERE id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new Client
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                            // Ajouter d'autres propriétés ici
                        };
                    }
                }
            }
        }

        return client;
    }

    public void Insert(Client data)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("INSERT INTO clients (name) VALUES (@name)", connection))
            {
                command.Parameters.AddWithValue("@name", data.Name);
                // Ajouter d'autres paramètres ici

                command.ExecuteNonQuery();
            }
        }
    }

    public void Update(Client data)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("UPDATE clients SET name = @name WHERE id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", data.Id);
                command.Parameters.AddWithValue("@name", data.Name);
                // Ajouter d'autres paramètres ici

                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(Client data)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("DELETE FROM clients WHERE id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", data.Id);
                command.ExecuteNonQuery();
            }
        }
    }

    public Client? SelectByName(string name)
    {
        Client? client = null;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("SELECT * FROM clients WHERE name = @name", connection))
            {
                command.Parameters.AddWithValue("@name", name);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = new Client
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                            // Ajouter d'autres propriétés ici
                        };
                    }
                }
            }
        }

        return client;
    }
}
