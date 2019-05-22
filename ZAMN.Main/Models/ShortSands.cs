using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class ShortSands
  {
    private int _id;
    private string _name;
    private string _comment;

    public ShortSands (string name, string comment, int id = 0)
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

    public static List<ShortSands> GetAll()
    {
      List<ShortSands> allPosts = new List<ShortSands>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM shortsands;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string userName = rdr.GetString(1);
        string userComment = rdr.GetString(2);

        ShortSands newPost = new ShortSands(userName, userComment, id);
        allPosts.Add(newPost);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allPosts;
    }

    public static ShortSands Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM shortsands WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int locationId = 0;
      string userName = "";
      string userComment = "";

      while(rdr.Read())
      {
        locationId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
        userComment = rdr.GetString(2);

      }
      ShortSands newPost = new ShortSands(userName, userComment);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newPost;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO shortsands (userName, comment) VALUES (@userName, @comment)";
      MySqlParameter userName = new MySqlParameter();
      userName.ParameterName = "@userName";
      userName.Value = this._name;
      cmd.Parameters.Add(userName);

      MySqlParameter userComment = new MySqlParameter();
      userComment.ParameterName = "@comment";
      userComment.Value = this._comment;
      cmd.Parameters.Add(userComment);

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
      cmd.CommandText = @"DELETE FROM shortsands WHERE id = @searchId;";
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

    public void Edit(string newName, string newComment)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE shortsands SET userName = @newName, comment = @newComment WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);

      MySqlParameter userName = new MySqlParameter();
      userName.ParameterName = "@newName";
      userName.Value = newName;
      cmd.Parameters.Add(userName);

      MySqlParameter userComment = new MySqlParameter();
      userComment.ParameterName = "@newComment";
      userComment.Value = newName;
      cmd.Parameters.Add(userComment);

      cmd.ExecuteNonQuery();
      _name = newName;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherShortSands)
    {
      if (!(otherShortSands is ShortSands))
      {
        return false;
      }
      else
      {
        ShortSands newPost = (ShortSands) otherShortSands;
        bool idEquality = this.GetId().Equals(newPost.GetId());
        bool nameEquality = this.Name.Equals(newPost.Name);
        bool commentEquality = this.Comment.Equals(newPost.Comment);
        return (idEquality && nameEquality && commentEquality);
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
      cmd.CommandText = @"DELETE FROM shortsands;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
