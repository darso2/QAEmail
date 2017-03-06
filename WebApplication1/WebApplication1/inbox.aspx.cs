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
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            useremail = Session["user"].ToString();
            cmd.Connection = con;
            inboxtable.InnerHtml += "<table border = \"1\"   >";

            inboxtable.InnerHtml +=  "<tr> <th class=\"auto-style2\">From</th> <th class=\"auto-style1\"> Subject</th> <th> Date</th></tr>";
            cmd.CommandText = "Select * from Emails where toUser='" + useremail + "';";
           



            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var from = r[1].ToString();
                    var subject = r[3].ToString();
                    var date = r[5].ToString();
                    inboxtable.InnerHtml += "<tr> <td> " + from + "</td> <td> <a href=\"message.aspx\">"+subject+"</a></td> <td> " + date+" </td><tr>  "; 
                }
            }
        }
    }
}