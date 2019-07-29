using System;
using System.Threading.Tasks;
using System.Web;

namespace AccountLogInApplication
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string error = Request.QueryString["error"];

            if (error == "1")
            {
                ErrorLabel.Text = "Incorrect login or password!!!";
            }
            
            if(error == "created")
            {
                ErrorLabel.Text = "Account created! Welcome:)";
            }
        }

        protected async void LogInButton_Click(object sender, EventArgs e)
        {
            var isData = await Task.Run(() => HandlerSqlBD.GetHandler().IsTrueData(LoginBox.Text, PasswordBox.Text));

            if (isData)
            {
                HttpCookie login = new HttpCookie("login", LoginBox.Text);
                HttpCookie sign = new HttpCookie("sign", GetterSign.GetSign(LoginBox.Text));
                Response.Cookies.Add(login);
                Response.Cookies.Add(sign);
                Response.Redirect("AccountPage.aspx");
            }
            Response.Redirect("StartPage.aspx?error=1", false);

        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationPage.aspx", false);
        }
    }
}