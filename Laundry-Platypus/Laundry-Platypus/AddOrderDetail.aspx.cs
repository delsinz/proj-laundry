using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry_Platypus
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int number_of_garment = 0;
        DataSet dataset;
        Table tb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                number_of_garment = Int32.Parse(Session["number_of_garments"].ToString());
                dataset = LoadGarmentTypes();
                DataTable dt = new DataTable();
                dt.Columns.Add("garment_number", Type.GetType("System.String"));
                for (int i = 0; i < number_of_garment; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["garment_number"] = 0;
                    dt.Rows.Add(dr);
                }
                DataList1.DataSource = dt;
                DataList1.DataBind();
                if (dataset != null)
                {
                    tb = new Table();

                    for (int i = 0; i < DataList1.Items.Count; i++)
                    {
                        DropDownList ddl = DataList1.Items[i].FindControl("DropDownList1") as DropDownList;
                        ddl.DataSource = dataset;
                        ddl.DataTextField = "type_name";
                        ddl.DataValueField = "garment_id";
                        ddl.DataBind();
                    }
                }
            }
        }
        /**
        * This function is to queary database about the garmenttypes, and load them into dropdown list
        * */
        private DataSet LoadGarmentTypes()
        {
            DataSet ds = null;
            try
            {
                ds = Datacon.getDataset("SELECT * FROM tb_Garment_type where activate='1';", "Types");
            }
            catch (Exception ex)
            {
                Console.WriteLine("not reading");
            }
            return ds;
        }
        /**
        * This function is to return the previous page
        * */
        protected void return_click(object sender, EventArgs e)
        {
            Response.Redirect("AddOrder.aspx");

        }
        /**
        * This function is to save the order details into database and real-time system
        * */
        protected void save_click(object sender, EventArgs e)
        {
            //read data from session
            string time_id =Session["order_id"].ToString();
            string order_date = Session["order_date"].ToString();
            string customer_id =Session["customer_id"].ToString();
           // string assignee_id = Session["assignee_id"].ToString();
            string price_t =price.Text;
            //Datacon.execSQL("INSERT INTO tb_Order (`order_id`,`order_date`,`customer_id`,`user_id`,`order_state`) VALUES ('"
            //  + time_id + "','" + order_date + "','" + customer_id + "','" + "0" + "','9');");
            string garment=null;
            foreach (DataListItem item in DataList1.Items)
            {
                DropDownList ddl = item.FindControl("DropDownList1") as DropDownList;
                string garment_id=ddl.SelectedValue;
                TextBox textb = item.FindControl("TextBox1") as TextBox;
                string garment_amount = textb.Text;
                garment = garment+garment_id + "," + garment_amount + ";";
            }
            if (Datacon.execSQL("INSERT INTO tb_Order (order_id,order_date,customer_id,user_id,order_state,garment,total_price,note) VALUES ('"
              + time_id + "','" + order_date + "','" + customer_id + "','0','9','" + garment + "','" + price_t + "','"+TextBox3.Text+"');"))
            {
                Order order = new Order(time_id,"0", order_date, customer_id,"0",garment);
                System_L.Instance.AddOrder(order);
                Response.Redirect("manager.aspx");
            }

        }
    }
}