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

        public newMail()
        {
            con.Open();
            cmd.Connection = con;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
             var id = Session["id"].ToString();
            if (id != "")
            {
                cmd.CommandText = "SELECT fromUser,subject from Emails where EmailId='" + id + "';";
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    Text1.Value = r[0].ToString();
                    Text3.Value = r[1].ToString();
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
            else if (Text2.Value == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please enter a non-empty message" + "');", true);
                TextArea1.Focus();
            }
            else
                cmd.CommandText = "";
        }
    }
}   