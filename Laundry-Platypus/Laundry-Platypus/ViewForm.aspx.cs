using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry_Platypus
{
    public partial class ViewForm : System.Web.UI.Page
    {
        string customer_id=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                DataSet ds = Datacon.getDataset("SELECT * FROM tb_User WHERE role_id = 4;", "Customers");

                CustomerDropList.DataSource = ds.Tables["Customers"].DefaultView;
                CustomerDropList.DataTextField = "first_name";
                CustomerDropList.DataValueField = "user_id";
                CustomerDropList.DataBind();
            }
                
            //DataSet ds1 = Datacon.getDataset("SELECT order_date,order_id,tb_User.first_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id  AND order_date BETWEEN '" + datebegin.Text + "' AND '" + dateend.Text + "' ORDER BY order_date; ", "Total");
            //rpTest.DataSource = ds1;
            //rpTest.DataBind();
            if (IsPostBack == true)
            {
                if (datebegin.Text != null && dateend.Text != null)
                {
                    DataSet ds1;
                    if (CheckBox1.Checked != true)
                    {//all show
                         ds1 = Datacon.getDataset("SELECT order_date,order_id,tb_User.first_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id  AND order_date BETWEEN '" + datebegin.Text + "' AND '" + dateend.Text + "' ORDER BY order_date; ", "Total");
                        rpTest.DataSource = ds1;
                        rpTest.DataBind();
                    }
                    else
                    {
                        ds1 = Datacon.getDataset("SELECT order_date,order_id,tb_User.first_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id AND tb_Order.customer_id=" + CustomerDropList.SelectedValue + " AND order_date BETWEEN '" + datebegin.Text + "' AND '" + dateend.Text + "' ORDER BY order_date; ", "Total");
                        rpTest.DataSource = ds1;
                        rpTest.DataBind();
                    }
                    int total=0;
                    foreach (DataRow dr in ds1.Tables["Total"].Rows)
                    {
                        total = Int32.Parse(dr["total_price"].ToString()) + total;
                    }
                    Label1.Text = total.ToString();
                    
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (datebegin.Text != null && dateend.Text != null)
            {
                if (CheckBox1.Checked != true)
                {//all show
                    DataSet dss = Datacon.getDataset("SELECT order_date,order_id,tb_User.first_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id  AND order_date BETWEEN '" + datebegin.Text + "' AND '" + dateend.Text + "' ORDER BY order_date; ", "Total");
                    rpTest.DataSource = dss;
                    rpTest.DataBind();
                }
                else
                {
                    DataSet dss=Datacon.getDataset("SELECT order_date,order_id,tb_User.first_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id AND tb_Order.customer_id="+CustomerDropList.SelectedValue+" AND order_date BETWEEN '"+datebegin.Text+ "' AND '" + dateend.Text + "' ORDER BY order_date; ","Total");
                    rpTest.DataSource = dss;
                    rpTest.DataBind();
                    customer_id = CustomerDropList.SelectedValue;
                }
            }
        }
    }
}