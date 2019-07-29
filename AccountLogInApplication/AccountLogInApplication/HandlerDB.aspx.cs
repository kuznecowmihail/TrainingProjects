using System;
using System.Threading.Tasks;
using System.Web;

namespace AccountLogInApplication
{
    public partial class HandlerDB : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];

            if(login != null && sign != null && sign.Value == GetterSign.GetSign(login.Value))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                await Task.Run(() => HandlerSqlBD.GetHandler().DeleteText(id));

                Response.Redirect("MessagePage.aspx", false);
            }
            else
            {
                Response.Redirect("StartPage.aspx", false);
            }
        }
    }
}