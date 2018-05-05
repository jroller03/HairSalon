using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Models
{
    public class Client
    {
      private int _id;
      private int _stylistId;
      private string _name;

      public Client(string name, int stylistId, int Id = 0)
      {
        _id = id;
        _stylistId = stylistId;
        _name = name;
      }

      public int GetClientId()
      {
        return _id;
      }
      public void SetClientId(int Id)
      {
        _id = Id;
      }
      public int GetStylistId()
      {
        return _stylistId;
      }
      public void SetStylistId(int StylistId)
      {
        _stylistId = stylistId;
      }
      public string GetName()
      {
        return _name;
      }
      public void SetName(string Name)
      {
        _name = Name;
      }

      public void Save()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@name, @stylist_id);";

          MySqlParameter name = new MySqlParameter();
          name.ParameterName = "@name";
          name.Value = this._name;
          cmd.Parameters.Add(name);

          MySqlParameter stylistId = new MySqlParameter();
          stylistId.ParameterName = "@stylist_id";
          stylistId.Value = this._stylistId;
          cmd.Parameters.Add(stylistId);


          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }

      public static List<Client> GetAll()
      {
          List<Client> allClients = new List<Client> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM clients;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int clientId = rdr.GetInt32(0);
            string clientName = rdr.GetString(1);
            int stylistId = rdr.GetInt32(2);
            Client newClient = new Client(clientName, stylistId, clientId);
            allClients.Add(newClient);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allClients;
      }

      public static void DeleteAll()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM clients;";
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }

    }
}
