using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace BusService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BusService : IBusService
    {
        public void AddBus(string busName, string src, string dest, string time)
        {
            using (SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Bus] (BusName, Source, Destination, Time) VALUES (@BusName, @Source, @Destination, @Time)", _con);
                cmd.Parameters.AddWithValue("@BusName", busName);
                cmd.Parameters.AddWithValue("@Source", src);
                cmd.Parameters.AddWithValue("@Destination", dest);
                cmd.Parameters.AddWithValue("@Time", time);
                cmd.ExecuteNonQuery();
            }

            using (SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Bus] WHERE BusName = @BusName;", _con);
                cmd.Parameters.AddWithValue("@BusName", busName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt_Login = new DataSet();
                da.Fill(dt_Login, "table");
                DataRow dr = dt_Login.Tables[0].Rows[0];
                var bus_id = dr.ItemArray[0].ToString();

                for (int i = 0; i < 60; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO [Seat] (BusId, IsAvailable) VALUES (@BusId, @IsAvailable)", _con);
                    cmd2.Parameters.AddWithValue("@BusId", bus_id);
                    cmd2.Parameters.AddWithValue("@IsAvailable", 1);
                    cmd2.ExecuteNonQuery();
                }
            }
        }

        public List<Seat> BookSeat(int seatId, string userToken)
        {
            throw new System.NotImplementedException();
        }

        public List<Bus> GetBuses()
        {
            using (SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Bus];", _con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt_Login = new DataSet();
                da.Fill(dt_Login, "table");
                
                List<Bus> buses = new List<Bus>();
                for(int i = 0; i < dt_Login.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt_Login.Tables[0].Rows[i];
                    var busId = int.Parse(dr[0].ToString());
                    var busName = dr[1].ToString();
                    var src = dr[2].ToString();
                    var dest = dr[3].ToString();
                    var time = dr[4].ToString();
                    buses.Add(new Bus(busId, busName, src, dest, time));
                }
                return buses;
            }
        }

        public List<Seat> GetSeats(int busId)
        {
            using (SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Seat] WHERE BusId = @busId;", _con);
                cmd.Parameters.AddWithValue("@BusId", busId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt_Login = new DataSet();
                da.Fill(dt_Login, "table");

                List<Seat> seats = new List<Seat>();
                for (int i = 0; i < dt_Login.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt_Login.Tables[0].Rows[i];
                    var seatId = int.Parse(dr[0].ToString());
                    var isAvailable = bool.Parse(dr[2].ToString());
                    seats.Add(new Seat(seatId, busId, isAvailable));
                }
                return seats;
            }
        }
    }
}
