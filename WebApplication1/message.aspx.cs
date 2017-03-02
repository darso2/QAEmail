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
            cmd.CommandText = "Select text,fromUser,subject,deleted from Emails where EmailId='" + id + "';";
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read())
                {
                    from.InnerHtml = r[1].ToString();
                    Session["fromUser"] = r[1].ToString();
                    subject.InnerHtml = r[2].ToString();
                    textmessage.InnerHtml = r[0].ToString();
                  //  string confirm = r[3].ToString();
                  //  if (r[4].ToString() == "true")
                  //  {
                  //      delete.Visible = false;
                  //  }
                    string returnvalue = Request.QueryString["returnstring"].ToString();
                    if (!Page.IsPostBack)
                    {
                        if (returnvalue == "sent" | returnvalue == "deleted")
                        this.delete.Visible = false;
                    }
                    
                }

            cmd.CommandText = "Update Emails set status = 'r' where EmailId='"+id+"';";
            cmd.ExecuteNonQuery();

        }

        protected void back_Click(object sender, EventArgs e)
        {

            string returnvalue = Request.QueryString["returnstring"].ToString();
            Response.Redirect(returnvalue + ".aspx");
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("newMail.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "UPDATE Emails SET deleted = 'true' WHERE Emailid='" + id + "';";
            cmd.ExecuteNonQuery();
        }
    }
}