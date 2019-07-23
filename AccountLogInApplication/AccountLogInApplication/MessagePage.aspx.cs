using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AccountLogInApplication
{
    public partial class MessagePage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];

            if (login != null && sign != null && sign.Value == GetterSign.GetSign(login.Value)) { }
            else
            {
                Response.Redirect("StartPage.aspx");
            }
        }

        protected void GetMessages_Click(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            if (RadioButtonList1.SelectedItem.Text == "My messages")
            {
                var userNotes = HandlerSqlBD.GetHandler().GetAllNotes().Where(t => t.User.Login == login.Value);
                Table table = new Table()
                {
                    ID = "Table"
                };

                foreach (var message in userNotes)
                {
                    TableRow tableRow = new TableRow();
                    TableCell tableCellID = new TableCell()
                    {
                        Text = message.ID.ToString(),
                        Visible = false,
                    };
                    TableCell tableCell0 = new TableCell()
                    {
                        Text = $"{message.User.UserProfile.FirstName} {message.User.UserProfile.LastName}",
                    };
                    TableCell tableCell1 = new TableCell()
                    {
                        Text = message.Text
                    };
                    TableCell tableCell2 = new TableCell()
                    {
                        Text = message.DateTime.ToString()
                    };
                    TableCell tableCellDelete = new TableCell();
                    HyperLink hyperLink = new HyperLink()
                    {
                        Text = "Delete",
                        NavigateUrl = $"HandlerDB.aspx?id={message.ID}"
                    };
                    tableCellDelete.Controls.Add(hyperLink);
                    tableRow.Cells.Add(tableCellID);
                    tableRow.Cells.Add(tableCell1);
                    tableRow.Cells.Add(tableCell2);
                    tableRow.Cells.Add(tableCellDelete);

                    table.Rows.Add(tableRow);
                }
                PlaceHolder1.Controls.Add(table);
            }

            if (RadioButtonList1.SelectedItem.Text == "All messages")
            {
                var userNotes = HandlerSqlBD.GetHandler().GetAllNotes();
                Table table = new Table()
                {
                    ID = "Table"
                };

                foreach (var userNote in userNotes)
                {
                    TableRow tableRow = new TableRow();

                    TableCell tableCellID = new TableCell()
                    {
                        Text = userNote.ID.ToString(),
                        Visible = false
                    };
                    TableCell tableCell0 = new TableCell()
                    {
                        Text = $"{userNote.User.UserProfile.FirstName} {userNote.User.UserProfile.LastName}"
                    };
                    TableCell tableCell1 = new TableCell()
                    {
                        Text = userNote.Text
                    };
                    TableCell tableCell2 = new TableCell()
                    {
                        Text = userNote.DateTime.ToString()
                    };
                    tableRow.Cells.Add(tableCell0);
                    tableRow.Cells.Add(tableCell1);
                    tableRow.Cells.Add(tableCell2);

                    table.Rows.Add(tableRow);
                }
                PlaceHolder1.Controls.Add(table);
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountPage.aspx");
        }
    }
}