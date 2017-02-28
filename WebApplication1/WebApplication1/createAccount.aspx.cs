using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //email no spaces, email unique, passwords has to be the same
        protected void createbutt_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" | TextBox2.Text == "" | TextBox3.Text == "" | TextBox4.Text == "" | TextBox5.Text == "" | TextBox6.Text == "" )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please fill in ALL the entries');", true);
            }
            else
            {

            }
        }
    }
}