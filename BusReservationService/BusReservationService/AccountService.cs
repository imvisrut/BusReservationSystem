using Jose;
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ServiceModel.Web;

namespace BusReservationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class AccountService : IAccountService
    {
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Login/")]
        public string Login(string username, string password)
        {
            if (username == "")
            {
                return "Username should not be empty.";
            }

            if (password == "")
            {
                return "Password should not be empty.";
            }


            using (SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username = @Username;", _con);
                cmd.Parameters.AddWithValue("@UserName", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt_Login = new DataSet();
                da.Fill(dt_Login, "table");
                if(dt_Login.Tables[0].Rows.Count == 0)
                {
                    return "Username doesn't Exist.";
                }
                DataRow dr = dt_Login.Tables[0].Rows[0];
                var _password = dr.ItemArray[2].ToString();
                if(_password == password)
                {
                    string secureToken = GetJwt(username, password);
                    return secureToken;
                }
                return "Password is wrong.";
            }
        }

        // [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string Register(User user)
        {
            if (user.UserName == "")
            {
                return "Username should not be empty.";
            }

            if (user.Email == "")
            {
                return "Email should not be empty.";
            }

            if (user.Password == "")
            {
                return "Password should not be empty.";
            }

            using (SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Username, Email, Password) VALUES(@UserName, @Email, @Password)", _con);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.ExecuteNonQuery();
                _con.Close();
            }

            return "";
        }

        private byte[] Base64UrlDecode(string arg)
        {
            string s = arg;
            s = s.Replace('-', '+');
            s = s.Replace('_', '/');
            switch (s.Length % 4)
            {
                case 0: break;
                case 2: s += "=="; break;
                case 3: s += "="; break;
                default:
                    throw new System.Exception(
                "Illegal base64url string!");
            }
            return Convert.FromBase64String(s);
        }

        public string GetJwt(string username, string password)
        {
            byte[] secretKey = Base64UrlDecode("Hi");
            // DateTime issued = DateTime.Now;
            var User = new Dictionary<string, object>() {
                {"username", username},
                {"password", password }
            };
            string token = JWT.Encode(User, secretKey, JwsAlgorithm.HS256);
            return token;
        }
    }
}
