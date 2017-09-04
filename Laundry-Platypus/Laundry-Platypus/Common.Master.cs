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
        protected void Page_Load(object sender, EventArgs e)
        {
            name.Text = Session["user_name"].ToString();
        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }
    }
}