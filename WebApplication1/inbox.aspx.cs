using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string useremail;
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename='C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\WebApplication1\\WebApplication1\\App_Data\\Database1.mdf';Integrated Security = True");
        SqlCommand cmd = new SqlCommand();

        protected void make_click(object sender, EventArgs e)
        {
            Response.Redirect("makeMail.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            useremail = Session["user"].ToString();
            cmd.Connection = con;
            inboxtable.InnerHtml += "<table border = \"1\"   >";

            inboxtable.InnerHtml += "<tr> <th class=\"auto-style2\"></th> <th class=\"auto-style2\">From</th> <th class=\"auto-style1\"> Subject</th> <th> Date</th></tr>";
            cmd.CommandText = "Select * from Emails where toUser='" + useremail + "';";

            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var id = r[0].ToString();                    
                    var from = r[1].ToString();
                    var subject = r[3].ToString();               
                    var date = r[5].ToString();                    var a= date.Split();                    date = a[0];
                    var read = r[6].ToString();                    Session["read"] = read;
                    if (read == "u")
                        inboxtable.InnerHtml += "<tr><td> <input type=\"checkbox\"></td> <td><b> " + from + "</b></td> <td> <b><a href=\"message.aspx?id=" + id + "\">" + subject + "</a></b></td> <td> <b>" + date + " </b></td><tr> ";
                    
                    else
                    {
                        inboxtable.InnerHtml += "<tr><td> <input type=\"checkbox\"></td> <td> " + from + "</td> <td> <a href=\"message.aspx?id=" + id + "\">" + subject + "</a></td> <td> " + date + " </td><tr>";
                    }
                }
            }
        }
    }
}