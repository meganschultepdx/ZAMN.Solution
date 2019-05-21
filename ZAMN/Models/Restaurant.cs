using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class Restaurant
  {

    public int _restaurantId { get; set; }
    public string _restaurantName { get; set; }
    public string _restaurantAddress { get; set; }
    public string _restaurantType { get; set; }

    public Restaurant (string restaurantName, string restaurantAddress, string restaurantType)
    {
      // _restaurantId = restaurantId;
      _restaurantName = restaurantName;
      _restaurantAddress = restaurantAddress;
      _restaurantType = restaurantType;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE * FROM restaurants;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT id, name, address, foodtype FROM restaurants;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        // int clientId = rdr.GetInt32(0);
        // string clientName = rdr.GetString(1);
        // string clientPhone = rdr.GetString(2);

        Restaurant newRestaurant = new Restaurant(
          rdr.GetString(1),
          rdr.GetString(2),
          rdr.GetString(3)
        );
        newRestaurant._restaurantId = rdr.GetInt32(0);
        allRestaurants.Add(newRestaurant);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRestaurants;
    }

    public override bool Equals(System.Object otherRestaurant)
    {
      if (!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool idEquality = this._restaurantId.Equals(newRestaurant._restaurantId);
        bool nameEquality = this._restaurantName.Equals(newRestaurant._restaurantName);
        return (idEquality && nameEquality);
      }
    }


    public int Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO restaurants (name, address, type) VALUES (@name, @address, @type);";
      cmd.Parameters.AddWithValue("@name", _restaurantName);
      cmd.Parameters.AddWithValue("@address", _restaurantAddress);
      cmd.Parameters.AddWithValue("@type", _restaurantType);
      cmd.ExecuteNonQuery();
      _restaurantId = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return _restaurantId;
    }

    public static Restaurant Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"SELECT * FROM restaurants WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int restaurantId = 0;
      string restaurantName = "";
      string restaurantAddress = "";
      string restaurantType = "";

      while(rdr.Read())
      {
        restaurantId = rdr.GetInt32(0);
        restaurantName = rdr.GetString(1);
        restaurantAddress = rdr.GetString(2);
        restaurantType = rdr.GetString(3);
      }

      Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantType);
      newRestaurant._restaurantId = restaurantId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newRestaurant;
    }

    // public void AddUser(User newUser)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //
    //   cmd.CommandText = @"INSERT INTO services (users_id, restaurants_id) VALUES (@UserId, @RestaurantId);";
    //   cmd.Parameters.AddWithValue("@UserId", newUser.GetId());
    //   cmd.Parameters.AddWithValue("@RestaurantId", _restaurantId);

      // MySqlParameter users_id = new MySqlParameter();
      // users_id.ParameterName = "@UserId";
      // users_id.Value = newUser._id;
      // cmd.Parameters.Add(users_id);
      // cmd.Parameters.AddWithValue("@UserId", _restaurantName);
      //
      // MySqlParameter restaurants_id = new MySqlParameter();
      // restaurants_id.ParameterName = "@RestaurantId";
      // restaurants_id.Value = _restaurantId;
      // cmd.Parameters.Add(restaurants_id);

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
    //   cmd.CommandText = @"SELECT users.* FROM restaurants
    //       JOIN services ON (restaurants.id = services.restaurants_id)
    //       JOIN users ON (services.users_id = users.id)
    //       WHERE restaurants.id = @RestaurantId;";
    //
    //   MySqlParameter restaurantIdParameter = new MySqlParameter();
    //   restaurantIdParameter.ParameterName = "@RestaurantId";
    //   restaurantIdParameter.Value = _restaurantId;
    //   cmd.Parameters.Add(restaurantIdParameter);
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

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants WHERE id = @RestaurantId; DELETE FROM services WHERE restaurants_id = @RestaurantId;";
      MySqlParameter restaurantIdParameter = new MySqlParameter();
      restaurantIdParameter.ParameterName = "@RestaurantId";
      restaurantIdParameter.Value = this._restaurantId;
      cmd.Parameters.Add(restaurantIdParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}
