using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Models
{
    public class Stylist
    {
      private int _id;
      private string _name;
      private string _stylistDetails;

      public Stylist(string name, string stylistDetails, int Id = 0)
      {
        _id = Id;
        _stylistDetails = stylistDetails;
        _name = name;
      }
      public int GetStylistId()
      {
        return _id;
      }
      public void SetStylistId(int Id)
      {
        _id = Id;
      }
      public string GetStylistDetails()
      {
        return _stylistId;
      }
      public void SetStylistDeails(string stylistDetails)
      {
        _stylistDetails = stylistDetails;
      }
      public string GetStylistName()
      {
        return _name;
      }
      public void SetStylistName(string Name)
      {
        _name = Name;
      }

      public static List<Stylist> GetAll()
      {
          List<Stylist> allStylists = new List<Stylist> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM stylists;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int stylistId = rdr.GetInt32(0);
            string stylistName = rdr.GetString(1);
            string stylistDetails = rdr.GetString(2);
            Stylist newStylist = new Stylist(stylistName, stylistDetails, stylistId);
            allStylists.Add(newStylist);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allStylists;
      }

    }
}
