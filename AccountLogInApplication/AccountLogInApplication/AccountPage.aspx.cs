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
                User user = HandlerSqlBD.GetHandler().GetAllusers().Where(t => t.Login == login.Value).First();

                FistName.Text = user.UserProfile.FirstName;
                LastName.Text = user.UserProfile.LastName;
                Age.Text = user.UserProfile.Age.ToString();
                LeavingPlace.Text = user.UserProfile.LeavingPlace;
                Career.Text = user.UserProfile.Career;
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

        protected void WriteMessage_Click(object sender, EventArgs e)
        {
            SaveMessage.Visible = true;
            TextBox1.Visible = true;
        }

        protected void SaveMessage_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == null)
            {
                LabelInformation.Text = "Text area need be filled!";
            }

            HttpCookie login = Request.Cookies["login"];

            if (HandlerSqlBD.GetHandler().AddText(TextBox1.Text, login.Value))
            {
                LabelInformation.Text = "Message was save!";
            }
            else
            {
                LabelInformation.Text = "Error! Try again later!";
            }
            SaveMessage.Visible = false;
            TextBox1.Visible = false;
        }

        protected void ShowMessage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MessagePage.aspx");
        }
    }
}