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

        private DataSet LoadGarmentTypes()
        {
            DataSet ds = null;
            try
            {
                ds = Datacon.getDataset("SELECT * FROM tb_Garment_type;", "Types");
            }
            catch (Exception ex)
            {
                Console.WriteLine("not reading");
            }
            return ds;
        }

        protected void return_click(object sender, EventArgs e)
        {
            Response.Redirect("AddOrder.aspx");

        }

        protected void save_click(object sender, EventArgs e)
        {
            //read data from session
            string time_id = (string)Session["order_id"];
            string order_date = (string)Session["order_date"];
            string customer_id = (string)Session["customer_id"];
            string assignee_id = (string)Session["assignee_id"];

            Datacon.execSQL("INSERT INTO tb_Order (`order_id`,`order_date`,`customer_id`,`user_id`,`order_state`) VALUES ('"
               + time_id + "','" + order_date + "','" + customer_id + "','" + assignee_id + "','1');");

            for (int i = 0; i < (int)Session["number_of_garments"]; i++)
            {
                //Datacon.execSQL();
            }

        }
    }
}