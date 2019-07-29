using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace AccountLogInApplication
{
    public partial class AccountsList : System.Web.UI.Page
    {
        const int rangeOfPage = 7;

        protected async void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];
            
            if (login != null && sign != null && sign.Value == GetterSign.GetSign(login.Value))
            {
                int numberPage = Convert.ToInt32(Request.QueryString["page"]);
                HttpCookie numb = new HttpCookie("numberPage", Convert.ToString(numberPage));
                Response.Cookies.Add(numb);
                List<HyperLink> links = new List<HyperLink>() { HyperLink1, HyperLink2, HyperLink3, HyperLink4, HyperLink5, HyperLink6, HyperLink7, };

                int countLink = 0;

                List<User> users = await Task.Run(() => HandlerSqlBD.GetHandler().GetAllusers());

                foreach (var i in users.Where(t => t.Login != login.Value).Skip(numberPage*rangeOfPage).Take(rangeOfPage))
                {
                    links[countLink].Text = $"{i.UserProfile.FirstName} {i.UserProfile.LastName}";
                    countLink++;
                }

                foreach(var i in links.Where(t => t.Text == ""))
                {
                    i.Visible = false;
                }

                int count = await Task.Run(() => HandlerSqlBD.GetHandler().GetAllusers().Count() - 1);

                if (numberPage == 0)
                {
                    LeftButton.Enabled = false;
                    LeftButton.Visible = false;
                }

                if ((count % rangeOfPage == 0 && (numberPage + 1) == count / rangeOfPage) || ((numberPage + 1) * rangeOfPage > count))
                {
                    RightButton.Enabled = false;
                    RightButton.Visible = false;
                }
            }
            else
            {
                Response.Redirect("StartPage.aspx", false);
            }
        }

        protected void LeftButton_Click(object sender, EventArgs e)
        {
            int numberPage = Convert.ToInt32(Request.QueryString["page"]);
            Response.Redirect($"AccountsList.aspx?id={numberPage - 1}", false);
        }

        protected void RightButton_Click(object sender, EventArgs e)
        {
            int numberPage = Convert.ToInt32(Request.QueryString["page"]);
            Response.Redirect($"AccountsList.aspx?page={numberPage + 1}", false);
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountPage.aspx", false);
        }
    }
}