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
            number_of_garment = (int)Session["number_of_garments"];
            dataset = LoadGarmentTypes();
            if (dataset != null)
            {
                tb = new Table();

                for (int i = 0; i < number_of_garment; i++)
                {
                    TableRow row = new TableRow();


                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();

                    //Make dropdown list
                    DropDownList dpl = new DropDownList();
                    dpl.ID = i.ToString();

                    dpl.DataSource = dataset;
                    dpl.DataTextField = "type_name";
                    dpl.DataValueField = "garment_id";
                    dpl.DataBind();
                    tc1.Controls.Add(dpl);
                    TextBox textb = new TextBox();
                    //text
                    tc2.Controls.Add(textb);

                    //add to table
                    row.Cells.Add(tc1);
                    row.Cells.Add(tc2);
                    tb.Rows.Add(row);

                }
            }
        }

        private DataSet LoadGarmentTypes()
        {
            DataSet ds = null;
            try
            {
                ds = Datacon.getDataset("SELECT * FROM `tb_Garment_type`;", "Types");
            }
            catch (Exception ex)
            {
                Console.WriteLine("not reading");
            }
            return ds;
        }

        private void return_click()
        {
            Response.Redirect("AddOrder.aspx");

        }

        private void save_click()
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