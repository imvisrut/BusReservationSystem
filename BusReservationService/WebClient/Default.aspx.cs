using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var svc = new BusService.BusServiceClient();
            var buses = svc.GetBuses();
            BusList.DataSource = buses;
            BusList.DataBind();
        }

        protected void SearchClick(Object sender, EventArgs e)
        {
            var svc = new BusService.BusServiceClient();
            var searchInput = SearchInput.Text.ToString();
            var buses = svc.GetSearchedBus(searchInput);
            BusList.DataSource = buses;
            BusList.DataBind();
        }
    }
}