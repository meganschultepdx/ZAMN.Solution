using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class Hike
  {

    public int _hikeId { get; set; }
    public string _hikeName { get; set; }
    public string _hikeAddress { get; set; }
    public string _hikeType { get; set; }
    public string _hikeDescription { get; set; }

    public Hike (string hikeName, string hikeAddress, string hikeType, string hikeDescription)
    {
      _hikeName = hikeName;
      _hikeAddress = hikeAddress;
      _hikeType = hikeType;
      _hikeDescription = hikeDescription;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE * FROM hikes;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Hike> GetAll()
    {
      List<Hike> allHikes = new List<Hike> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT id, name, address, type, description FROM hikes;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {

        Hike newHike = new Hike(
          rdr.GetString(1),
          rdr.GetString(2),
          rdr.GetString(3),
          rdr.GetString(4)
        );
        newHike._hikeId = rdr.GetInt32(0);
        allHikes.Add(newHike);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allHikes;
    }

    public override bool Equals(System.Object otherHike)
    {
      if (!(otherHike is Hike))
      {
        return false;
      }
      else
      {
        Hike newHike = (Hike) otherHike;
        bool idEquality = this._hikeId.Equals(newHike._hikeId);
        bool nameEquality = this._hikeName.Equals(newHike._hikeName);
        return (idEquality && nameEquality);
      }
    }


    public int Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO hikes (name, address, type, description) VALUES (@name, @address, @type, @description);";
      cmd.Parameters.AddWithValue("@name", _hikeName);
      cmd.Parameters.AddWithValue("@address", _hikeAddress);
      cmd.Parameters.AddWithValue("@type", _hikeType);
      cmd.Parameters.AddWithValue("@description", _hikeDescription);
      cmd.ExecuteNonQuery();
      _hikeId = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return _hikeId;
    }

    public static Hike Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"SELECT * FROM hikes WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int hikeId = 0;
      string hikeName = "";
      string hikeAddress = "";
      string hikeType = "";
      string hikeDescription = "";

      while(rdr.Read())
      {
        hikeId = rdr.GetInt32(0);
        hikeName = rdr.GetString(1);
        hikeAddress = rdr.GetString(2);
        hikeType = rdr.GetString(3);
        hikeDescription = rdr.GetString(4);
      }

      Hike newHike = new Hike(hikeName, hikeAddress, hikeType, hikeDescription);
      newHike._hikeId = hikeId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newHike;
    }
  }
}
