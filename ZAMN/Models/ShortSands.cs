using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class ShortSands
  {
    private int _id;
    private string _name;

    public ShortSands(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public string Name { get => _name; set => _name = value; }

    public int GetId()
    {
      return _id;
    }

    public static List<ShortSands> GetAll()
    {
      List<ShortSands> allShortSands = new List<ShortSands>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        ShortSands newShortSands = new ShortSands(stylistName, stylistId);
        allShortSands.Add(newShortSands);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allShortSands;
    }

  }
}
