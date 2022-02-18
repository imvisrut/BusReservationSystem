using System;
using Newtonsoft.Json;

namespace WebClient
{
    public partial class Bus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            Session["busId"] = id.ToString();
            var svc = new BusService.BusServiceClient();
            var seats = svc.GetSeats(id);
            Seats.DataSource = seats;
            Seats.DataBind();
        }

        protected void BookSelectedSeats(Object sender, EventArgs e)
        {
            var svc = new BusService.BusServiceClient();
            int[] data = JsonConvert.DeserializeObject<int[]>(SeatData.Value.ToString());
            svc.BookSeats(data, Session["token"].ToString());
            Response.Redirect("/Bus?id=" + Session["busId"].ToString());
        }
    }
}