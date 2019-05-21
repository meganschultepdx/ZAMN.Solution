using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class User
  {
    private int _id;
    private string _name;

    public User(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public string UserName { get => _name; set => _name = value; }

    public int GetId()
    {
      return _id;
    }

    public static List<User> GetAll()
    {
      List<User> allUsers = new List<User>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM users;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int userId = rdr.GetInt32(0);
        string userName = rdr.GetString(1);
        User newUser = new User(userName, userId);
        allUsers.Add(newUser);
      }
      conn.Close();
      if(conn!=null)
      {
        conn.Dispose();
      }
      return allUsers;
    }

    public static User Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM users WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int userId = 0;
      string userName = "";
      while(rdr.Read())
      {
        userId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
      }

      User foundUser = new User(userName, userId);
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return foundUser;
      }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users (name) VALUES (@name)";
      MySqlParameter userName = new MySqlParameter();
      userName.ParameterName = "@name";
      userName.Value = _name;
      cmd.Parameters.Add(userName);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM users WHERE id = @searchId; DELETE FROM users_locations WHERE user_id = @searchId";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public List<SurfLocation> GetSurfLocation()
    // {
    //   List<SurfLocation> allSurfLocations = new List<SurfLocation>{};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = "SELECT * FROM locations JOIN users_locations ON (users_locations.location_id = locations.id) JOIN users ON (users.id = users_locations.user_id) WHERE users.id = @user_id;";
    //
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@user_id";
    //   searchId.Value = this._id;
    //   cmd.Parameters.Add(searchId);
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int locationId = rdr.GetInt32(0);
    //     string locationName = rdr.GetString(1);
    //     string locationComment = rdr.GetString(2);
    //
    //     SurfLocation newSurfLocation= new SurfLocation(locationName, locationId);
    //     allSurfLocations.Add(newSurfLocation);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allSurfLocations;
    // }

    public void AddSurfLocation (SurfLocation newSurfLocation)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users_locations (location_id, user_id) VALUES (@LocationId, @UserId);";
      MySqlParameter user_id = new MySqlParameter();
      user_id.ParameterName = "@UserId";
      user_id.Value = _id;
      cmd.Parameters.Add(user_id);
      MySqlParameter location_id = new MySqlParameter();
      location_id.ParameterName = "@SurfLocationId";
      location_id.Value = newSurfLocation.GetId();
      cmd.Parameters.Add(location_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherUser)
    {
      if (!(otherUser is User))
      {
        return false;
      }
      else
      {
        User newUser = (User) otherUser;
        bool idEquality = this.GetId().Equals(newUser.GetId());
        bool nameEquality = this.UserName.Equals(newUser.UserName);
        return (idEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM users;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
