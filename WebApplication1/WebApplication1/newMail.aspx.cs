using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace WebApplication1
{
    public partial class newMail : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename='C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\WebApplication1\\WebApplication1\\App_Data\\Database1.mdf';Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        string date;
        string id;
        public newMail()
        {
            con.Open();
            cmd.Connection = con;
            var color = Request.Cookies["username"].Value;
            PageForm.Attributes.Add("bgcolor", color);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("loginPage.aspx");
            }
            id = Session["id"].ToString();
            cmd.CommandText = "SELECT fromUser,subject from Emails where EmailId='" + id + "';";

            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Text1.Value = r[0].ToString();
                    Text3.Value = "Re:" + r[1].ToString();
                }
            }
        }
    


        protected void sendMail_Click(object sender, EventArgs e)
        {
            if (Text1.Value == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please enter a recipient email address" + "');", true);
                Text1.Focus();
            }
            else if (TextArea1.Value == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please enter a non-empty message" + "');", true);
                TextArea1.Focus();
            }
            else if 

            else
            {
                date = DateTime.Now.ToString("d");
                
                cmd.CommandText = "INSERT INTO Emails([fromUser],[toUser],[subject],[text],[date],[status],[deleted]) Values ('" + Session["user"].ToString() + "','" + Text1.Value.ToString() + "','" + Text3.Value.ToString() + "','" + TextArea1.Value + "','" + date + "','u','n');";
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Your email has been sent." + "');", true);
                Response.Redirect("inbox.aspx");
            }

        }
    }
}   