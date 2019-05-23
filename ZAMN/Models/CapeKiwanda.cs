using System.Collections.Generic;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System;

namespace ZAMN.Models
{
  public class CapeKiwanda
  {
    private int _id;
    private string _name;
    private string _comment;
    private DateTime _timePost;

    public CapeKiwanda (string name, string comment, int id = 0)
    {
      _name = name;
      _comment = comment;
      _timePost = DateTime.Now;
      _id = id;
    }

    public CapeKiwanda (string name, string comment, DateTime timePost, int id = 0)
    {
      _name = name;
      _comment = comment;
      _timePost = timePost;
      _id = id;
    }

    public string Name { get => _name; set => _name = value; }
    public string Comment { get => _comment; set => _comment = value; }
    public DateTime PostTime { get => _timePost; set => _timePost = value; }

    public int GetId()
    {
      return _id;
    }

    public static List<CapeKiwanda> GetAll()
    {
      List<CapeKiwanda> allPosts = new List<CapeKiwanda>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM capekiwanda;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string userName = rdr.GetString(1);
        string userComment = rdr.GetString(2);
        DateTime timeStamp = rdr.GetDateTime(3);

        CapeKiwanda newPost = new CapeKiwanda(userName, userComment, timeStamp, id);
        allPosts.Add(newPost);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allPosts;
    }

    public static CapeKiwanda Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM capekiwanda WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int locationId = 0;
      string userName = "";
      string userComment = "";
      DateTime timeStamp = new DateTime(2000, 11, 11);

      while(rdr.Read())
      {
        locationId = rdr.GetInt32(0);
        userName = rdr.GetString(1);
        userComment = rdr.GetString(2);
        timeStamp = rdr.GetDateTime(3);

      }
      CapeKiwanda newPost = new CapeKiwanda(userName, userComment, timeStamp);
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
      cmd.CommandText = @"INSERT INTO capekiwanda (userName, comment, time) VALUES (@userName, @comment, @time)";
      MySqlParameter userName = new MySqlParameter();
      userName.ParameterName = "@userName";
      userName.Value = this._name;
      cmd.Parameters.Add(userName);

      MySqlParameter userComment = new MySqlParameter();
      userComment.ParameterName = "@comment";
      userComment.Value = this._comment;
      cmd.Parameters.Add(userComment);

      MySqlParameter postTime = new MySqlParameter();
      postTime.ParameterName = "@time";
      postTime.Value = this._timePost;
      cmd.Parameters.Add(postTime);

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
      cmd.CommandText = @"DELETE FROM capekiwanda WHERE id = @searchId;";
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

    public void Edit(string newName, string newComment, DateTime newTime)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE capekiwanda SET userName = @newName, comment = @newComment, time = @newTime WHERE id = @searchId;";

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

      MySqlParameter postTime = new MySqlParameter();
      postTime.ParameterName = "@newTime";
      postTime.Value = newName;
      cmd.Parameters.Add(postTime);

      cmd.ExecuteNonQuery();
      _name = newName;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherCapeKiwanda)
    {
      if (!(otherCapeKiwanda is CapeKiwanda))
      {
        return false;
      }
      else
      {
        CapeKiwanda newPost = (CapeKiwanda) otherCapeKiwanda;
        bool idEquality = this.GetId().Equals(newPost.GetId());
        bool nameEquality = this.Name.Equals(newPost.Name);
        bool commentEquality = this.Comment.Equals(newPost.Comment);
        bool timeEquality = this.PostTime.Equals(newPost.PostTime);
        return (idEquality && nameEquality && commentEquality && timeEquality);
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
      cmd.CommandText = @"DELETE FROM capekiwanda;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
