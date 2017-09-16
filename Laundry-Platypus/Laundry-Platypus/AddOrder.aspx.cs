using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Laundry_Platypus
{
    public partial class AddOrder : System.Web.UI.Page
    {   
        
        System_L system_L = System_L.Instance;
        static int n_garment = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            system_L = System_L.Instance;
            LoadGarmentTypes();
            LoadCustomers();
            LoadDrivers();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Order order_t=new Order(,,,,);
            //system_L.AddOrder(order_t);
            //if(customer_id.Text)
            //INSERT INTO `tb_Order` (`order_date`, `customer_id`, `user_id`, `order_state`) VALUES('2017-09-21', '4', '3', '2')

            //Generate time as ID
            long time_id = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));

            Session["order_id"] = time_id;
            Session["order_date"] = date.Text;
            Session["customer_id"] = CustomerDropList.Text;
            Session["assignee_id"] = AssigneeDropList.Text;
            Session["number_of_garments"] = garment_number.Text;

            Response.Redirect("AddOrderDetail.aspx");


           //if ()
           //{
           //    Console.WriteLine("inserted");
           //}

        }

        protected void add_Click()
        {
            TableCell cel1 = new TableCell();
            TableCell cel2 = new TableCell();
            DropDownList droplist = new DropDownList();
            droplist.ID = Convert.ToString("");
        }

        private void LoadGarmentTypes()
        {

            try
            {
                DataSet ds = Datacon.getDataset("SELECT * FROM `tb_Garment_type`;", "Types");

                Console.WriteLine("reading data");
                garment_type.DataSource = ds.Tables["Types"];
                garment_type.DataTextField = "type_name";
                garment_type.DataValueField = "garment_id";
                garment_type.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("not reading");
            }
        }

        private void LoadCustomers()
        {

            try
            {
                DataSet ds = Datacon.getDataset("SELECT * FROM `tb_User` WHERE role_id = 4;", "Customers");

                garment_type.DataSource = ds.Tables["Customers"];
                garment_type.DataTextField = "first_name" + "last_name";
                garment_type.DataValueField = "user_id";
                garment_type.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("not reading");
            }

        }

        private void LoadDrivers()
        {

            try
            {
                DataSet ds = Datacon.getDataset("SELECT * FROM `tb_User` WHERE role_id = 2;", "Drivers");

                garment_type.DataSource = ds.Tables["Drivers"];
                garment_type.DataTextField = "first_name" + "last_name";
                garment_type.DataValueField = "user_id";
                garment_type.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("not reading");
            }

        }
    }
}