using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //creates an expiration for the cookie
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
                
        }

        // redirects to a page based on which button was clicked
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("createAccount.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginPage.aspx");

        }

        //assigns a value to the cookie depending on the button
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedValue == "0")
            {
                Response.Cookies["userName"].Value = "Red";
                
            }
            else if (RadioButtonList1.SelectedValue == "1")
            {
                Response.Cookies["userName"].Value = "Green";
                
            }
            else if (RadioButtonList1.SelectedValue == "2")
                Response.Cookies["userName"].Value = "Yellow";
            
        }
    }
}