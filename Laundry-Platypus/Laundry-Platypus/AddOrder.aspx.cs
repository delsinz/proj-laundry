using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry_Platypus
{
    public partial class AddOrder : System.Web.UI.Page
    {
        System_L system_L = System_L.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            system_L = System_L.Instance;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Order order_t=new Order(,,,,);
            system_L.AddOrder(order_t);
        }
    }
}