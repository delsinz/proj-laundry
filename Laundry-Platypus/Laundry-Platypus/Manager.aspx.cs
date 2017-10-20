using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry_Platypus
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /**
       * This function is to redirect to addorder page
       * */
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddOrder.aspx");
        }
    }
}