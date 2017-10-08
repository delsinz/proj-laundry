using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry_Platypus
{
    public partial class ViewForm : System.Web.UI.Page
    {
        string customer_id=null;
        DataSet ds1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                DataSet ds = Datacon.getDataset("SELECT * FROM tb_User WHERE role_id = 4;", "Customers");

                CustomerDropList.DataSource = ds.Tables["Customers"].DefaultView;
                CustomerDropList.DataTextField = "user_name";
                CustomerDropList.DataValueField = "user_id";
                CustomerDropList.DataBind();
                Button2.Visible = false;
            }
                
            //DataSet ds1 = Datacon.getDataset("SELECT order_date,order_id,tb_User.first_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id  AND order_date BETWEEN '" + datebegin.Text + "' AND '" + dateend.Text + "' ORDER BY order_date; ", "Total");
            //rpTest.DataSource = ds1;
            //rpTest.DataBind();
            if (IsPostBack == true)
            {
                if (datebegin.Text != null && dateend.Text != null)
                {
                   
                    if (CheckBox1.Checked != true)
                    {//all show
                         ds1 = Datacon.getDataset("SELECT order_date,order_id,tb_User.user_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id  AND order_date BETWEEN '" + datebegin.Text + "' AND '" + dateend.Text + "' ORDER BY order_date; ", "Total");
                        rpTest.DataSource = ds1;
                        rpTest.DataBind();
                    }
                    else
                    {
                        ds1 = Datacon.getDataset("SELECT order_date,order_id,tb_User.user_name,total_price FROM tb_Order INNER JOIN tb_User WHERE tb_User.user_id = tb_Order.customer_id AND tb_Order.customer_id=" + CustomerDropList.SelectedValue + " AND order_date BETWEEN '" + datebegin.Text + "' AND '" + dateend.Text + "' ORDER BY order_date; ", "Total");
                        rpTest.DataSource = ds1;
                        rpTest.DataBind();
                    }
                    int total=0;
                    foreach (DataRow dr in ds1.Tables["Total"].Rows)
                    {
                        total = Int32.Parse(dr["total_price"].ToString()) + total;
                    }
                    Label1.Text = total.ToString();
                    Button2.Visible = true;
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            
            DataTable dt = ds1.Tables["Total"];
            StringWriter sw = new StringWriter();
            sw.WriteLine("OrderID,Customer,Amount");
            foreach (DataRow dr in dt.Rows)
            {
                sw.WriteLine(dr["order_id"] + "," + dr["user_name"] + "," + dr["total_price"]);
            }
            sw.Close();
            Response.AddHeader("Content-Disposition", "attachment; filename=Form.csv");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.Write(sw);
            Response.End();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

            DataTable dt = ds1.Tables["Total"];
            StringWriter sw = new StringWriter();
            sw.WriteLine("OrderID,Customer,Amount");
            foreach (DataRow dr in dt.Rows)
            {
                sw.WriteLine(dr["order_id"] + "," + dr["user_name"] + "," + dr["total_price"]);
            }
            sw.Close();
            Response.AddHeader("Content-Disposition", "attachment; filename=Form.csv");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.Write(sw);
            Response.End();
        }
    }
}