using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace AccountLogInApplication
{
    public partial class AccountInformation : System.Web.UI.Page
    {
        const int rangeOfPage = 7;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];

            if (login != null && sign != null && sign.Value == GetterSign.GetSign(login.Value))
            {
                int numberInPage = Convert.ToInt32(Request.QueryString["id"]);
                int numberPage = Convert.ToInt32(Request.Cookies["numberPage"].Value);
                List<(UserProfile, string)> otherPeople = HandlerSqlBD.GetHandler().GetAllusers().Where(t => t.Item2 != login.Value).ToList();

                int count = rangeOfPage * numberPage + (numberInPage == 0 ? 0 : numberInPage - 1);
                

                FistName.Text = otherPeople[count].Item1.FirstName;
                LastName.Text = otherPeople[count].Item1.LastName;
                Age.Text = otherPeople[count].Item1.Age.ToString();
                LeavingPlace.Text = otherPeople[count].Item1.LeavingPlace;
                Career.Text = otherPeople[count].Item1.Career;
            }
            else
            {
                Response.Redirect("StartPage.aspx");
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            int numberPage = Convert.ToInt32(Request.Cookies["numberPage"].Value);
            Response.Redirect($"AccountsList.aspx?id={numberPage}");
        }
    }
}