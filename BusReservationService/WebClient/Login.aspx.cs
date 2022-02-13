using System;
using System.Web;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginClick(Object sender, EventArgs e)
        {
            var svc = new AccountService.AccountServiceClient();
            var username = Username.Text;
            var password = Password.Text;
            var token = svc.Login(username, password);
            Session["token"] = token;
            Session["isAuth"] = "true";
            Response.Redirect("/");
        }
    }
}