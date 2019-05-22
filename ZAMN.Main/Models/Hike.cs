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
      // _hikeId = hikeId;
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
        // int clientId = rdr.GetInt32(0);
        // string clientName = rdr.GetString(1);
        // string clientPhone = rdr.GetString(2);

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

    // public void AddUser(User newUser)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //
    //   cmd.CommandText = @"INSERT INTO services (users_id, hikes_id) VALUES (@UserId, @HikeId);";
    //   cmd.Parameters.AddWithValue("@UserId", newUser.GetId());
    //   cmd.Parameters.AddWithValue("@HikeId", _hikeId);

      // MySqlParameter users_id = new MySqlParameter();
      // users_id.ParameterName = "@UserId";
      // users_id.Value = newUser._id;
      // cmd.Parameters.Add(users_id);
      // cmd.Parameters.AddWithValue("@UserId", _hikeName);
      //
      // MySqlParameter hikes_id = new MySqlParameter();
      // hikes_id.ParameterName = "@HikeId";
      // hikes_id.Value = _hikeId;
      // cmd.Parameters.Add(hikes_id);

    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

    // public List<User> GetUsers()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //
    //   cmd.CommandText = @"SELECT users.* FROM hikes
    //       JOIN services ON (hikes.id = services.hikes_id)
    //       JOIN users ON (services.users_id = users.id)
    //       WHERE hikes.id = @HikeId;";
    //
    //   MySqlParameter hikeIdParameter = new MySqlParameter();
    //   hikeIdParameter.ParameterName = "@HikeId";
    //   hikeIdParameter.Value = _hikeId;
    //   cmd.Parameters.Add(hikeIdParameter);
    //
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //
    //   List<User> users = new List<User>{};
    //   while(rdr.Read())
    //   {
    //     // int userId = rdr.GetInt32(0);
    //     string userName = rdr.GetString(1);
    //     string bio = rdr.GetString(2);
    //     // string userPrice = rdr.GetString(2);
    //     User newUser = new User(userName, bio);
    //     users.Add(newUser);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return users;
    // }

    // public void Delete()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"DELETE FROM hikes WHERE id = @HikeId; DELETE FROM services WHERE hikes_id = @HikeId;";
    //   MySqlParameter hikeIdParameter = new MySqlParameter();
    //   hikeIdParameter.ParameterName = "@HikeId";
    //   hikeIdParameter.Value = this._hikeId;
    //   cmd.Parameters.Add(hikeIdParameter);
    //   cmd.ExecuteNonQuery();
    //   if (conn != null)
    //   {
    //     conn.Close();
    //   }
    // }
  }
}
