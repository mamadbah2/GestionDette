﻿// See https://aka.ms/new-console-template for more information

using GestionDette.Model;
using GestionDette.Service;
using GestionDette.Service.Implementation;
using GestionDette.Views;
using GestionDette.Views.Implementation;

namespace GestionDette;

internal class Program
{
    public static void Main(string[] args)
    {
        IntClientView clientView = new ClientView();
        IntClientServ clientServ = new ClientServ();
        
        int choice = 0;
        do
        {
            choice = Menu();
            switch (choice)
            {
               case 1:
                   clientServ.AddClient(clientView.CreateNewClient());
                   break;
               case 2:
                   clientServ.UpdateClient(clientView.CreateNewClient());
                   break;
               case 3:
                   clientView.ShowClients(clientServ.GetClients());
                   clientServ.RemoveClient(clientServ.GetClientById(clientView.DeleteClient()));
                   break;
               case 4:
                   clientView.ShowClients(clientServ.GetClients());
                   break;
               case 0:
                   break;
                   
            }
        }  while (choice != 0);
    }

    public static int Menu()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Gestion dette");
            Console.WriteLine("1. Creer un Etudiant");
            Console.WriteLine("2. Modifer un Etudiant");
            Console.WriteLine("3. Supprimer un Etudiant");
            Console.WriteLine("4. Afficher tous les Etudiants");
            Console.WriteLine("0. Quitter");
            
            Console.WriteLine("Quel choix : ");
            choice = Convert.ToInt32(Console.ReadLine());
            
        } while(choice > 5 || choice < 0);

        return choice;
    }
}
