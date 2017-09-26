using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.Collections;
using System.Configuration;
 
 
using System.Web.Security;
 
using System.Web.UI.HtmlControls;
 
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;




namespace Laundry_Platypus
{
    public partial class ManageItem : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet myds3 = Datacon.getDataset("SELECT * FROM `tb_Garment_type` WHERE `activate` = 1;", "garment");
            DataList1.DataSource = myds3;
            DataList1.DataBind();
        }

        // Edit garment
        protected void Save_Edit_Click(object sender, EventArgs e) {
            
            //Response.Write("<script lanuage=javascript>alert(" + Hidden1.Value + ");window.location.href='ManageItem.aspx'</script>");
          
            string get_item_id = null;
            get_item_id = Hidden1.Value;
            //Response.Write("<script lanuage=javascript>alert(" + get_item_id + ");window.location.href='ManageItem.aspx'</script>");
            //HttpCookie cook = new HttpCookie("testcook");
            //cook = Request.Cookies["itemId"];
            //var _list = RandomList.value;
            //get_item_id = cook.Value;
            //if (get_item_id != null)
            //{
            //    Response.Write("<script lanuage=javascript>alert('" + Hidden1.Value + "');window.location.href='ManageItem.aspx'</script>");
            //}
            //if (Request.Cookies["item_id"].ToString() != null)
            //{   
            //get_item_id = Request.Cookies["item_id"].ToString();

            //Datacon.execSQL("UPDATE tb_Garment_type SET `type_name` = '" + NameTextBox.Text
            //+ "' AND `abbreviation` = '"+ AddAbbrTextBox.Text+ "' WHERE `garment_id` = '" + get_item_id + "';");

            ////Response.Write("<script lanuage=javascript>alert('Please input username and password');window.location.href='ManageItem.aspx'</script>");
            //Datacon.execSQL("UPDATE tb_Garment_type SET `type_name` = '" + NameTextBox.Text + "', `abbreviation` = '" + AbbrTextBox.Text + "' WHERE `garment_id` = "+ get_item_id + "");


            if (NameTextBox.Text != null && AbbrTextBox.Text != null)
            {
                Datacon.execSQL("UPDATE tb_Garment_type SET `type_name` = '" + NameTextBox.Text + "', `abbreviation` = '" + AbbrTextBox.Text + "' WHERE `garment_id` = " + get_item_id + "");

            }
            else {
                Response.Write("<script lanuage=javascript>alert('Please input required information');window.location.href='ManageItem.aspx'</script>");
            }
             
            Page_Load(sender, e);
        }

        // Add garment 
        protected void Add_Click(object sender, EventArgs e)
        {
            //Datacon.execSQL("INSERT INTO tb_Garment_type (type_name, abbreviation) VALUES ('Short','STS');");
            if (AddNameTextBox != null && AddAbbrTextBox != null)
            {
                Datacon.execSQL("INSERT INTO tb_Garment_type (`type_name`,`abbreviation`,`activate`) VALUES ('" +
                    AddNameTextBox.Text + "','" + AddAbbrTextBox.Text + "', '1');");
            }
            else {
                Response.Write("<script lanuage=javascript>alert('Please input required information');window.location.href='ManageItem.aspx'</script>");
            }

            Page_Load(sender, e);

        }

        // Remove garment
        //protected void Remove_Click(object sender, EventArgs e)
        //{   
        // test modal button function 
        //Response.Write("<script lanuage=javascript>alert('Please input username and password'); window.location.href='ManageItem.aspx' </script>");


        //string get_item_id = null;
        //if (Request.Cookies["item_id"].ToString() != null)
        //{
        //get_item_id = Request.Cookies["item_id"].ToString();

        //Datacon.execSQL("UPDATE `tb_Garment_type` SET `activate` = `0`");
        //}

        //}

        protected void Save_Remove_Click(object sender, EventArgs e)
        {
            string get_item_id = null;
            get_item_id = Hidden1.Value;
            //Response.Write("<script lanuage=javascript>alert(" + Hidden1.Value + ");window.location.href='ManageItem.aspx'</script>");
            if (get_item_id != null) {
                Datacon.execSQL("UPDATE `tb_Garment_type` SET `activate` = '0' WHERE `garment_id` = " + get_item_id + "");
            }
            Page_Load(sender, e);

        }


        protected void Test(object sender, EventArgs e)
        {
            Response.Write("<script lanuage=javascript>alert('Please input username and password'); window.location.href='ManageItem.aspx' </script>");
        }
    }
}