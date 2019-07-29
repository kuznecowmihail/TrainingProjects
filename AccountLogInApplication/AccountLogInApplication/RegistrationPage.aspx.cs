using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AccountLogInApplication
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            List<TextBox> information = new List<TextBox>() { Login, Password, FirstName, LastName, Age, LeavingPlace, Career };
            List<Label> informationError = new List<Label>() { InformationLabel1, InformationLabel2, InformationLabel3, InformationLabel4, InformationLabel5, InformationLabel6, InformationLabel7 };

            for (int i = 0; i < information.Count; i++)
            {
                if (information[i].Text == string.Empty)
                {
                    informationError[i].Text = "The box need be filled!";
                }
            }

            var isNotExist = await Task.Run(() => HandlerSqlBD.GetHandler().IsNotExist(Login.Text) && Int32.TryParse(Age.Text, out int age));

            if (isNotExist)
            {
                HandlerSqlBD.GetHandler().AddUser(new User{
                    Login = Login.Text,
                    Password = Password.Text
                }, new UserProfile{
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Age = Convert.ToInt32(Age.Text),
                    LeavingPlace = LeavingPlace.Text,
                    Career = Career.Text
                });
                
                Response.Redirect("StartPage.aspx?error=created", false);
            }
            else
            {
                ErrorLabel.Text = "The First name exists, try any First name!";
            }

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("StartPage.aspx", false);
        }
    }
}