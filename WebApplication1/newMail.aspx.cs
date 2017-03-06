﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace WebApplication1
{
    public partial class newMail : System.Web.UI.Page
    { //insert your own connection string
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename='C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\WebApplication1\\WebApplication1\\App_Data\\Database1.mdf';Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        string date;
        string id;
        public newMail()
        {
            con.Open();
            cmd.Connection = con;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var color = Request.Cookies["username"].Value;
            PageForm.Attributes.Add("bgcolor", color);

            if (Session["user"] == null)
            {
                Response.Redirect("loginPage.aspx");
            }

            //if replying to a message
            if (Session["id"] != null)
            { 
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
            // if the cc section is filled in send it to those too
            else if (Text2.Value != "")
            {
                string[] splittedEmail = Text2.Value.Replace(" ","").Split(',');
                foreach (string i in splittedEmail)
                {
                    
                    date = DateTime.Now.ToString("d");                   
                    cmd.CommandText = "INSERT INTO Emails([fromUser],[toUser],[subject],[text],[date],[status],[deleted]) Values ('" + Session["user"].ToString() + "','" + i + "','CC:" + Text3.Value.ToString() + "','" + TextArea1.Value + "','" + date + "','u','false');";
                    cmd.ExecuteNonQuery();

                }
                cmd.CommandText = "INSERT INTO Emails([fromUser],[toUser],[subject],[text],[date],[status],[deleted]) Values ('" + Session["user"].ToString() + "','" + Text1.Value.ToString() + "','" + Text3.Value.ToString() + "','" + TextArea1.Value + "','" + date + "','u','false');";
                cmd.ExecuteNonQuery();
                Response.Redirect("inbox.aspx");

            }

            //if the cc section is empty then lazy copy and paste
            else
            {
                date = DateTime.Now.ToString("d");

                cmd.CommandText = "INSERT INTO Emails([fromUser],[toUser],[subject],[text],[date],[status],[deleted]) Values ('" + Session["user"].ToString() + "','" + Text1.Value.ToString() + "','" + Text3.Value.ToString() + "','" + TextArea1.Value + "','" + date + "','u','false');";
                cmd.ExecuteNonQuery();
                Response.Redirect("inbox.aspx");
            }

        }
    }
}   