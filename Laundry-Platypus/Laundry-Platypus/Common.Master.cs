using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry_Platypus
{
    public partial class Common : System.Web.UI.MasterPage
    {
        /**
        * This function is to redirect the pages according to users' role
        * */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            //{ UserName.Text = Session["user_name"].ToString(); }
            if (Session["role_id"].ToString() != "1")
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                
                    if (Session["role_id"].ToString() != "3")
                    { HyperLink1.NavigateUrl = "packeroverview.aspx"; }
                    if (Session["role_id"].ToString() != "2")
                    { HyperLink1.NavigateUrl = "driveroverview.aspx"; }
                }
            else {
                LinkButton1.Visible = true;
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
                    HyperLink1.NavigateUrl = "manager.aspx";
                }

        }
        /**
        * This function is to log out the system and clear the session
        * */
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}