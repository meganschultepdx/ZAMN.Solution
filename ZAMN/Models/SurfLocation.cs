using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class SurfLocation
  {
    private int _id;
    private string _name;
    private string _comment;

    public ShortSands(string name, string comment, int id = 0)
    {
      _name = name;
      _comment = comment;
      _id = id;
    }

    public string Name { get => _name; set => _name = value; }

    public string Comment { get => _comment; set => _comment = value; }

    public int GetId()
    {
      return _id;
    }

    public static List<SurfLocation> GetAll()
    {
      List<SurfLocation> allLocations = new List<SurfLocation>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM locations;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int locationId = rdr.GetInt32(0);
        string locationName = rdr.GetString(1);
        string locationComment = rdr.GetString(2);
        SurfLocation newLocation = new SurfLocation(locationName, locationComment, locationId);
        allLocations.Add(newLocation);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allLocations;
    }

    public static SurfLocation Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM locations WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int locationId = 0;
      string locationName = "";
      string locationComment = "";
      while(rdr.Read())
      {
        locationId = rdr.GetInt32(0);
        locationName = rdr.GetString(1);
        locationComment = rdr.GetString(2);
      }
      SurfLocation newLocation = new SurfLocation(locationName, locationComment, locationId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newLocation;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO locations (name) VALUES (@name)";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
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
      cmd.CommandText = @"DELETE FROM locations WHERE id = @searchId; DELETE FROM users WHERE location_id = @searchId";
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

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE locations SET name = @newName WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _name = newName;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM locations; DELETE FROM users; DELETE FROM users_locations;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherSurfLocation)
    {
      if (!(otherSurfLocation is SurfLocation))
      {
        return false;
      }
      else
      {
        SurfLocation newLocation = (SurfLocation) otherSurfLocation;
        bool idEquality = this.GetId().Equals(newLocation.GetId());
        bool nameEquality = this.Name.Equals(newLocation.Name);
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
      cmd.CommandText = @"DELETE FROM locations;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

 // --> adding a user comment to location
    public void AddUser(User newUser)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"INSERT INTO users_locations (location_id, user_id) VALUES (@location_id, @user_id);";
      MySqlParameter locationId = new MySqlParameter();
      locationId.ParameterName = "@location_id";
      locationId.Value = _id;
      cmd.Parameters.Add(locationId);
      MySqlParameter userId = new MySqlParameter();
      userId.ParameterName = "@user_id";
      userId.Value = newUser.GetId();
      cmd.Parameters.Add(userId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<User> GetUsers()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT users. * FROM locations
      JOIN users_locations ON (locations.id = users_locations.location_id)
      JOIN users ON (users_locations.user_id = user.id)
      WHERE locations.id = @locationId;";
      MySqlParameter locationIdParameter = new MySqlParameter();
      locationIdParameter.ParameterName = "@locationId";
      locationIdParameter.Value = _id;
      cmd.Parameters.Add(locationIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<User> locationUserComments = new List<User>{};
      while(rdr.Read())
      {
        int userId = rdr.GetInt32(0);
        string userName = rdr.GetString(1);
        User newUser = new User(userName, userId);
        locationUserComments.Add(newUser);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return locationUserComments;
    }
  }
}
