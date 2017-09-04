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
        protected void Page_Load(object sender, EventArgs e)
        {
            system_L = System_L.Instance;
            LoadGarmentTypes();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Order order_t=new Order(,,,,);
            //system_L.AddOrder(order_t);
            //if(customer_id.Text)
            //INSERT INTO `tb_Order` (`order_date`, `customer_id`, `user_id`, `order_state`) VALUES('2017-09-21', '4', '3', '2')
            MySqlDataReader name_reader = Datacon.getRow("SELECT user_id FROM tb_User WHERE first_name = '"
                + assignee.Text + "';");
            name_reader.Read();
            string assignee_id;
            assignee_id = name_reader["user_id"].ToString();

            name_reader = Datacon.getRow("SELECT user_id FROM tb_User WHERE first_name = '"
             + customer.Text + "';");
            name_reader.Read();
            string customer_id = name_reader["user_id"].ToString();

            if (Datacon.execSQL("INSERT INTO tb_Order (`order_date`,`customer_id`,`user_id`,`order_state`) VALUES ('"
                + date.Text + "','"+ customer_id+"','" + assignee_id + "','1');")){
                Console.WriteLine("inserted");
            }
            MySqlDataReader mysqlrd = Datacon.getRow("SELECT order_id FROM tb_Order WHERE order_date = '" +
                date.Text + "' and customer_id = '" + customer_id + "' and user_id = '" + assignee_id + "';");

            mysqlrd.Read();

            string order_id = mysqlrd["order_id"].ToString();
            if(Datacon.execSQL("INSERT INTO tb_Order_garments (`order_id`,`garment_id`,`amount`) VALUES ('"
                + order_id + "','" + garment_type.Text + "','" + amount.Text + "');"))
            {
                Console.WriteLine("garment inserted");
            }
        }

        private void LoadGarmentTypes()
        {

            try
            {
                DataSet ds = Datacon.getDataset("SELECT * FROM `tb_Garment_type`", "Types");

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

    }
}