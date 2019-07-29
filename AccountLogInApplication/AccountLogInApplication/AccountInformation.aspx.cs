using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountLogInApplication
{
    public partial class AccountInformation : System.Web.UI.Page
    {
        const int rangeOfPage = 7;

        protected async void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];

            if (login != null && sign != null && sign.Value == GetterSign.GetSign(login.Value))
            {
                int numberInPage = Convert.ToInt32(Request.QueryString["id"]);
                int numberPage = Convert.ToInt32(Request.Cookies["numberPage"].Value);
                List<User> otherPeople = await Task.Run(() => HandlerSqlBD.GetHandler().GetAllusers().Where(t => t.Login != login.Value).ToList());

                int count = rangeOfPage * numberPage + (numberInPage == 0 ? 0 : numberInPage - 1);
                

                FistName.Text = otherPeople[count].UserProfile.FirstName;
                LastName.Text = otherPeople[count].UserProfile.LastName;
                Age.Text = otherPeople[count].UserProfile.Age.ToString();
                LeavingPlace.Text = otherPeople[count].UserProfile.LeavingPlace;
                Career.Text = otherPeople[count].UserProfile.Career;
            }
            else
            {
                Response.Redirect("StartPage.aspx", false);
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            int numberPage = Convert.ToInt32(Request.Cookies["numberPage"].Value);
            Response.Redirect($"AccountsList.aspx?id={numberPage}", false);
        }
    }
}