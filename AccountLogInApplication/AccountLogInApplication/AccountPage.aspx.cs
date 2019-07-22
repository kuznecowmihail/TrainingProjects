using System;
using System.Web;
using System.Linq;

namespace AccountLogInApplication
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];

            if (login != null && sign != null && sign.Value == GetterSign.GetSign(login.Value))
            {
                (UserProfile, string) user = HandlerSqlBD.GetHandler().GetAllusers().Where(t => t.Item2 == login.Value).FirstOrDefault();

                FistName.Text = user.Item1.FirstName;
                LastName.Text = user.Item1.LastName;
                Age.Text = user.Item1.Age.ToString();
                LeavingPlace.Text = user.Item1.LeavingPlace;
                Career.Text = user.Item1.Career;
            }
            else
            {
                Response.Redirect("StartPage.aspx");
            }
        }

        protected void QuitButton_Click(object sender, EventArgs e)
        {
            HttpCookie login = new HttpCookie("login", string.Empty);
            HttpCookie sign = new HttpCookie("sign", string.Empty);
            login.Expires = DateTime.Now.AddDays(-1);
            sign.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(login);
            Response.Cookies.Add(sign);
            Response.Redirect("StartPage.aspx");
        }

        protected void AllUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountsList.aspx?page=0");
        }
    }
}