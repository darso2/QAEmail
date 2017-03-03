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
        string id;

        protected void make_click(object sender, EventArgs e)
        {
            Response.Redirect("newMail.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var color = Request.Cookies["username"].Value;
            PageForm.Attributes.Add("bgcolor", color);
            if (Session["user"] == null)
            {
                Response.Redirect("loginPage.aspx");
            }
            con.Open();
            useremail = Session["user"].ToString();
            Session.Clear();
            Session["user"] = useremail;
            cmd.Connection = con;
            inboxtable.InnerHtml += " <table border = \"1\">";
            inboxtable.InnerHtml += "<tr> <th class=\"auto-style2\">From</th> <th class=\"auto-style1\"> Subject</th> <th> Date (Month/Day/Year) </th></tr>";
            cmd.CommandText = "Select * from Emails where toUser='" + useremail + "' and deleted='false';";

            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                     id = r[0].ToString();                    
                    var from = r[1].ToString();
                    var subject = r[3].ToString();               
                    var date = r[5].ToString();                    var a= date.Split();                    date = a[0];
                    var read = r[6].ToString();                    Session["read"] = read;
                    if (read == "u")
                        inboxtable.InnerHtml += "<tr><td><b> " + from + "</b></td> <td> <b><a href=\"message.aspx?id=" + id + "&returnstring=inbox\">" + subject + "</a></b></td> <td> <b>" + date + " </b></td><tr> ";
                    
                    else
                    {
                        inboxtable.InnerHtml += "<tr> <td> " + from + "</td> <td> <a href=\"message.aspx?id=" + id + "&returnstring=inbox\">" + subject + "</a></td> <td> " + date + " </td><tr>";
                    }
                }
            }

            cmd.CommandText = "select count(*) as abc from Emails where toUser='" + Session["user"] + "' and deleted = 'false';";
            using (SqlDataReader s = cmd.ExecuteReader())
            {
                while (s.Read())
                {
                    allmessage.InnerHtml += " (" + s["abc"] + ")";
                }
            }

            cmd.CommandText = "select count(deleted) from Emails where toUser='" + Session["user"] + "' and deleted ='true';";
            using (SqlDataReader t = cmd.ExecuteReader())
            {
                while (t.Read())
                {
                    deletemessage.InnerHtml += " (" + t[0] + ")";
                }
            }
            cmd.CommandText = "select count(*) from Emails where fromUser='" + Session["user"] + "';";
            using (SqlDataReader u = cmd.ExecuteReader())
            {
                while (u.Read())
                {
                    sentmessage.InnerHtml += " (" +u[0] + ")";
                }
            }
        }
    }
}