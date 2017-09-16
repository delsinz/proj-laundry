using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry_Platypus
{
    public partial class ManageItem : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet myds3 = Datacon.getDataset("SELECT * FROM `tb_Garment_type`;", "garment");
            DataList1.DataSource = myds3;
            DataList1.DataBind();
        }

        // Edit garment
        protected void Save_Edit_Click(object sender, EventArgs e) {
             
            string get_item_id = null;
            if (Request.Cookies["item_id"].ToString() != null)
            {
                get_item_id = Request.Cookies["item_id"].ToString();
                //Response.Write("<script lanuage=javascript>alert({get_item_id});window.location.href='ManageItem.aspx'</script>");
                if (NameTextBox.Text != null && AbbrTextBox.Text != null)
                {
                    Datacon.execSQL("UPDATE `tb_Garment_type` SET `type_name` = '" + NameTextBox.Text
                    + "' WHERE `garment_id` = '" + get_item_id + "';");
                    //add abbr
                }
            }

        }
        
        // Add garment 
        protected void Add_Click(object sender, EventArgs e)
        {
            if (AddNameTextBox!=null && AddAbbrTextBox!=null) {
                Datacon.execSQL("INSERT  INTO `tb_Garment_type` (`type_name`) VALUE ('" + 
                    AddNameTextBox.Text + "');");
            }

        }

        // Remove garment
        protected void Remove_Click(object sender, EventArgs e)
        {
            string get_item_id = null;
            if (Request.Cookies["item_id"].ToString() != null)
            {
                get_item_id = Request.Cookies["item_id"].ToString();

                Datacon.execSQL("UPDATE `tb_Garment_type` set `activated` = `false`");
            }

        }
    }
}