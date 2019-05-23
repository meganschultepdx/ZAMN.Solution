using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ZAMN.Models
{
  public class Login
  {

    public int _loginId { get; set; }
    public string _loginDescription { get; set; }

    public Login (string loginDescription)
    {
      // _loginId = loginId;
      _loginDescription = loginDescription;
    }

    public static List<Login> GetAll()
    {
      List<Login> allLogins = new List<Login> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT id, description FROM logins;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        // int clientId = rdr.GetInt32(0);
        // string clientName = rdr.GetString(1);
        // string clientPhone = rdr.GetString(2);

        Login newLogin = new Login(
          rdr.GetString(1)
        );
        newLogin._loginId = rdr.GetInt32(0);
        allLogins.Add(newLogin);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allLogins;
    }

    // public override bool Equals(System.Object otherLogin)
    // {
    //   if (!(otherLogin is Login))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Login newLogin = (Login) otherLogin;
    //     bool idEquality = this._loginId.Equals(newLogin._loginId);
    //     bool descriptionEquality = this._loginDescription.Equals(newLogin._loginDescription);
    //     return (idEquality && descriptionEquality);
    //   }
    // }
    //
    //
    // public int Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //
    //   cmd.CommandText = @"INSERT INTO logins (description) VALUES (@description);";
    //   cmd.Parameters.AddWithValue("@description", _loginDescription);
    //   cmd.ExecuteNonQuery();
    //   _loginId = (int) cmd.LastInsertedId;
    //
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //
    //   return _loginId;
    // }
    //
    // public static Login Find(int id)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //
    //   cmd.CommandText = @"SELECT * FROM logins WHERE id = (@searchId);";
    //
    //   MySqlParameter searchId = new MySqlParameter();
    //   searchId.ParameterName = "@searchId";
    //   searchId.Value = id;
    //   cmd.Parameters.Add(searchId);
    //
    //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   int loginId = 0;
    //   string loginDescription = "";
    //
    //   while(rdr.Read())
    //   {
    //     loginId = rdr.GetInt32(0);
    //     loginDescription = rdr.GetString(1);
    //   }
    //
    //   Login newLogin = new Login(loginDescription);
    //   newLogin._loginId = loginId;
    //
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newLogin;
    // }
    //
    // public void AddRestaurant(Restaurant newRestaurant)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //
    //   cmd.CommandText = @"INSERT INTO userinputs (restaurants_id, logins_id) VALUES (@RestaurantId, @LoginId);";
    //   cmd.Parameters.AddWithValue("@RestaurantId", newRestaurant._restaurantId);
    //   cmd.Parameters.AddWithValue("@LoginId", _loginId);
    //
    //   // MySqlParameter restaurants_id = new MySqlParameter();
    //   // restaurants_id.ParameterName = "@RestaurantId";
    //   // restaurants_id.Value = newRestaurant._id;
    //   // cmd.Parameters.Add(restaurants_id);
    //   // cmd.Parameters.AddWithValue("@RestaurantId", _loginName);
    //   //
    //   // MySqlParameter logins_id = new MySqlParameter();
    //   // logins_id.ParameterName = "@LoginId";
    //   // logins_id.Value = _loginId;
    //   // cmd.Parameters.Add(logins_id);
    //
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

    // public List<Restaurant> GetRestaurants()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //
    //   cmd.CommandText = @"SELECT restaurants.* FROM logins
    //       JOIN userinputs ON (logins.id = userinputs.logins_id)
    //       JOIN restaurants ON (userinputs.restaurants_id = restaurants.id)
    //       WHERE logins.id = @LoginId;";
    //
    //   MySqlParameter loginIdParameter = new MySqlParameter();
    //   loginIdParameter.ParameterName = "@LoginId";
    //   loginIdParameter.Value = _loginId;
    //   cmd.Parameters.Add(loginIdParameter);
    //
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //
    //   List<Restaurant> restaurants = new List<Restaurant>{};
    //   while(rdr.Read())
    //   {
    //     // int restaurantId = rdr.GetInt32(0);
    //     string restaurantName = rdr.GetString(1);
    //     string restaurantAddress = rdr.GetString(2);
    //     string restaurantType = rdr.GetString(3);
    //     string restaurantDescription = rdr.GetString(4);
    //     Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantType, restaurantDescription);
    //     restaurants.Add(newRestaurant);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return restaurants;
    // }
  }
}
