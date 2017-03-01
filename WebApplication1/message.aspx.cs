using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class message : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename='C:\\Users\\Administrator\\Documents\\Visual Studio 2015\\Projects\\WebApplication1\\WebApplication1\\App_Data\\Database1.mdf';Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            id = Request.QueryString["id"];
            Session["id"] = id;
            cmd.CommandText = "Select text,fromUser,subject from Emails where EmailId='" + id + "';";
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read())
                {
                    from.InnerHtml = r[1].ToString();
                    Session["fromUser"] = r[1].ToString();
                    subject.InnerHtml = r[2].ToString();
                    textmessage.InnerHtml = r[0].ToString();
                }

            cmd.CommandText = "Update Emails set status = 'r' where EmailId='"+id+"';";
            cmd.ExecuteNonQuery();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("inbox.aspx");
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("newMail.aspx");
        }
    }
}