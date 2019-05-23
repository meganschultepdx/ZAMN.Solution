using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class Comment
  {

    public int _commentId { get; set; }
    public string _commentDescription { get; set; }
    public string _commentCreated { get; set; }

    public Comment (string commentDescription, string commentCreated)
    {
      // _commentId = commentId;
      _commentDescription = commentDescription;
      _commentCreated = commentCreated;
    }

    public static List<Comment> GetAll()
    {
      List<Comment> allComments = new List<Comment> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT id, description FROM comments;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        // int clientId = rdr.GetInt32(0);
        // string clientName = rdr.GetString(1);
        // string clientPhone = rdr.GetString(2);

        Comment newComment = new Comment(
          rdr.GetString(1),
          rdr.GetString(2)
        );
        newComment._commentId = rdr.GetInt32(0);
        allComments.Add(newComment);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allComments;
    }

    public override bool Equals(System.Object otherComment)
    {
      if (!(otherComment is Comment))
      {
        return false;
      }
      else
      {
        Comment newComment = (Comment) otherComment;
        bool idEquality = this._commentId.Equals(newComment._commentId);
        bool descriptionEquality = this._commentDescription.Equals(newComment._commentDescription);
        return (idEquality && descriptionEquality);
      }
    }


    public int Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO comments (description) VALUES (@description);";
      cmd.Parameters.AddWithValue("@description", _commentDescription);
      cmd.ExecuteNonQuery();
      _commentId = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return _commentId;
    }

    public static Comment Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"SELECT * FROM comments WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int commentId = 0;
      string commentDescription = "";
      string commentCreated = "";

      while(rdr.Read())
      {
        commentId = rdr.GetInt32(0);
        commentDescription = rdr.GetString(1);
        commentCreated = rdr.GetString(2);
      }

      Comment newComment = new Comment(commentDescription, commentCreated);
      newComment._commentId = commentId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newComment;
    }

    public void AddRestaurant(Restaurant newRestaurant)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO userinputs (restaurants_id, comments_id) VALUES (@RestaurantId, @CommentId);";
      cmd.Parameters.AddWithValue("@RestaurantId", newRestaurant._restaurantId);
      cmd.Parameters.AddWithValue("@CommentId", _commentId);

      // MySqlParameter restaurants_id = new MySqlParameter();
      // restaurants_id.ParameterName = "@RestaurantId";
      // restaurants_id.Value = newRestaurant._id;
      // cmd.Parameters.Add(restaurants_id);
      // cmd.Parameters.AddWithValue("@RestaurantId", _commentName);
      //
      // MySqlParameter comments_id = new MySqlParameter();
      // comments_id.ParameterName = "@CommentId";
      // comments_id.Value = _commentId;
      // cmd.Parameters.Add(comments_id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Restaurant> GetRestaurants()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"SELECT restaurants.* FROM comments
          JOIN userinputs ON (comments.id = userinputs.comments_id)
          JOIN restaurants ON (userinputs.restaurants_id = restaurants.id)
          WHERE comments.id = @CommentId;";

      MySqlParameter commentIdParameter = new MySqlParameter();
      commentIdParameter.ParameterName = "@CommentId";
      commentIdParameter.Value = _commentId;
      cmd.Parameters.Add(commentIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      List<Restaurant> restaurants = new List<Restaurant>{};
      while(rdr.Read())
      {
        // int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        string restaurantAddress = rdr.GetString(2);
        string restaurantType = rdr.GetString(3);
        string restaurantDescription = rdr.GetString(4);
        Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantType, restaurantDescription);
        restaurants.Add(newRestaurant);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return restaurants;
    }
  }
}
