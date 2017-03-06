using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class loginPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = 'C:\\Users\\Administrator\\documents\\visual studio 2015\\Projects\\WebApplication1\\WebApplication1\\App_Data\\Database1.mdf'; Integrated Security = True");

            SqlCommand cmd = new SqlCommand();


        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
        }

        protected void login_click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                TextBox1.Text = "Please enter an email address here";
            }

           else if (TextBox2.Text == "")
            {
                TextBox2.Text = "Please enter a Password here";
            }

            else
            {
                cmd.CommandText = "Select EmailAddress,Password from Users where EmailAddress='" + TextBox1.Text + "';";
                using (SqlDataReader r = cmd.ExecuteReader())
                    while (r.Read())
                    {
                        if (TextBox2.Text==r["Password"].ToString())
                        {
                            Session["user"] = r["EmailAddress"];
                            Response.Redirect("inbox.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Incorrect Email and Password" + "');", true);
                        }
                    }
            }  

        }
    }
}