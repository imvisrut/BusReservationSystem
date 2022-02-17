using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBusClick(Object sender, EventArgs e)
        {
            var svc = new BusService.BusServiceClient();
            svc.AddBus(BusName.Text, Source.Text, Destination.Text, Time.Text);
            Time.Text = "";
            Source.Text = "";
            BusName.Text = "";
            Destination.Text = "";
        }
    }
}