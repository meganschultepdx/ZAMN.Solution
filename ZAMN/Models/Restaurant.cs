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
    public string _restaurantDescription { get; set; }

    public Restaurant (string restaurantName, string restaurantAddress, string restaurantType, string restaurantDescription)
    {
      // _restaurantId = restaurantId;
      _restaurantName = restaurantName;
      _restaurantAddress = restaurantAddress;
      _restaurantType = restaurantType;
      _restaurantDescription = restaurantDescription;
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
      cmd.CommandText = @"SELECT id, name, address, type, description FROM restaurants;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        // int clientId = rdr.GetInt32(0);
        // string clientName = rdr.GetString(1);
        // string clientPhone = rdr.GetString(2);

        Restaurant newRestaurant = new Restaurant(
          rdr.GetString(1),
          rdr.GetString(2),
          rdr.GetString(3),
          rdr.GetString(4)
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

      cmd.CommandText = @"INSERT INTO restaurants (name, address, type, description) VALUES (@name, @address, @type, @description);";
      cmd.Parameters.AddWithValue("@name", _restaurantName);
      cmd.Parameters.AddWithValue("@address", _restaurantAddress);
      cmd.Parameters.AddWithValue("@type", _restaurantType);
      cmd.Parameters.AddWithValue("@description", _restaurantDescription);
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
      string restaurantDescription = "";

      while(rdr.Read())
      {
        restaurantId = rdr.GetInt32(0);
        restaurantName = rdr.GetString(1);
        restaurantAddress = rdr.GetString(2);
        restaurantType = rdr.GetString(3);
        restaurantDescription = rdr.GetString(4);
      }

      Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantType, restaurantDescription);
      newRestaurant._restaurantId = restaurantId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newRestaurant;
    }

    public void AddComment(string description)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO comments (description, restaurant_id) VALUES (@description, @RestaurantId);";

      cmd.Parameters.AddWithValue("@RestaurantId", _restaurantId);
      cmd.Parameters.AddWithValue("@description", description);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Comment> GetComments()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"
          SELECT comments.id, comments.description, cast(comments.created_date as char) AS created_date
          FROM restaurants
          JOIN comments ON comments.restaurant_id = restaurants.id
          WHERE restaurants.id = @RestaurantId;";

      cmd.Parameters.AddWithValue("@RestaurantId", _restaurantId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      List<Comment> comments = new List<Comment>{};
      while(rdr.Read())
      {
        int commentId = rdr.GetInt32(0);
        string commentDescription = rdr.GetString(1);
        string commentCreated = rdr.GetString(2);
        Comment newComment = new Comment(commentDescription, commentCreated);
        newComment._commentId = commentId;
        newComment._commentCreated = commentCreated;
        comments.Add(newComment);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return comments;
    }
  }
}
