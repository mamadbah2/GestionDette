using GestionDette.Core;
using Npgsql;
using DotNetEnv;

namespace GestionDette.Repository.ImplementationDB;

public class Repo: IDataAccess
{
    private readonly string _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;
    private NpgsqlConnection? _connection;
    public void OpenConnection()
    {
        if (_connection == null)
            _connection = new NpgsqlConnection(_connectionString);
        try
        {
            _connection.Open();
            Console.WriteLine("Connection established");
        }
        catch (NpgsqlException npgsqlEx)
        {
            throw npgsqlEx;
        }
    }

    public void CloseConnection()
    {
        if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
        {
            _connection.Close();
            Console.WriteLine("Connection closed");
        }
    }

    public void ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
    {
        using var command = new NpgsqlCommand(sql, _connection);
        AddParameters(command, parameters);

        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to execute non-query: {ex.Message}");
        }
    }

    public List<Dictionary<string, object>> ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
    {
        using var command = new NpgsqlCommand(sql, _connection);
        AddParameters(command, parameters);

        var results = new List<Dictionary<string, object>>();
        try
        {
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }
                results.Add(row);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to execute query: {ex.Message}");
        }

        return results;
    }
    
    private void AddParameters(NpgsqlCommand command, Dictionary<string, object>? parameters)
    {
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
        }
    }
}