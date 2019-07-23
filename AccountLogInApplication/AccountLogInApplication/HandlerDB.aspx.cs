using System;
using System.Web;

namespace AccountLogInApplication
{
    public partial class HandlerDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];

            if(login != null && sign != null && sign.Value == GetterSign.GetSign(login.Value))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                HandlerSqlBD.GetHandler().DeleteText(id);

                Response.Redirect("MessagePage.aspx");
            }
            else
            {
                Response.Redirect("StartPage.aspx");
            }
        }
    }
}