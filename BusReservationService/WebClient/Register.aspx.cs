using System;

namespace WebClient
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterClick(Object sender, EventArgs e)
        {
            var svc = new AccountService.AccountServiceClient();
            var username = Username.Text;
            var password = Password.Text;
            var email = Email.Text;
            var user = new AccountService.User();
            user.UserName = username;
            user.Password = password;
            user.Email = email;
            svc.Register(user);
            Response.Redirect("/Login");
        }
    }
}