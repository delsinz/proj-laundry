using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry_Platypus
{
    public partial class ManageEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet myds4 = Datacon.getDataset("SELECT * FROM `tb_User` INNER JOIN `tb_Role` ON tb_User.role_id = tb_Role.role_id ORDER by user_id", "employee");
            DataList1.DataSource = myds4;
            DataList1.DataBind();
        }
        /**
        * This function is to save the information that have changed about Employee to the database
        * */
        protected void Save_Edit_Click(object sender, EventArgs e)
        {
            string get_user_id = null;
            get_user_id = Hidden1.Value;
            string get_role_id = edit_role_list.SelectedValue;
             
            if (EditNameTextBox.Text!=null) {
                Datacon.execSQL("UPDATE tb_User SET `user_name` = '" + EditNameTextBox.Text + "', `role_id` = '" + get_role_id +
                    "', `password` = '"+ EditPassTextBox.Text+"', `address` = '" + EditAddrTextBox.Text + "' WHERE `user_id` = " + get_user_id + "");
            }
            else {
                Response.Write("<script lanuage=javascript>alert('Please input required information');window.location.href='ManageEmployee.aspx'</script>");
            }
            Page_Load(sender, e);
        }
        /**
        * This function is to add new users to database
        * */
        protected void Add_Click(object sender, EventArgs e)
        {
            
            string add_role_id = add_role_list.SelectedValue;
            string add_status = add_status_list.SelectedValue;
            
            if (AddNameTextBox.Text != null)
            {   
                //default password is 123 for the new user
                Datacon.execSQL("INSERT INTO tb_User (user_name,role_id,user_active,password,address) VALUES ('" +
                   AddNameTextBox.Text + "','" + add_role_id +"','" + add_status + "', '"+AddPassTextBox.Text +"','" + AddAddrTextBox.Text +"');");
            }
            else {
                Response.Write("<script lanuage=javascript>alert('Please input required information');window.location.href='ManageEmployee.aspx'</script>");
            }

            Page_Load(sender, e);
        }
        /**
        * This function is to inactive the users 
        * */
        protected void Save_Inactive_Click(object sender, EventArgs e)
        {
            string get_user_id = null;
            get_user_id = Hidden1.Value;
             
            if (get_user_id != null)
            {
                Datacon.execSQL("UPDATE `tb_User` SET `user_active` = '0' WHERE `user_id` = " + get_user_id + "");
            }
            Page_Load(sender, e);
        }
        /**
        * This function is to active the user 
        * */
        protected void Save_Active_Click(object sender, EventArgs e)
        {
            string get_user_id = null;
            get_user_id = Hidden1.Value;

            if (get_user_id != null)
            {
                Datacon.execSQL("UPDATE `tb_User` SET `user_active` = '1' WHERE `user_id` = " + get_user_id + "");
            }
            Page_Load(sender, e);
        }
        
    }

}