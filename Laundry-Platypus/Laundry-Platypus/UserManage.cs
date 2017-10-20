using MySql.Data.MySqlClient;

namespace Laundry_Platypus
{
    public class UserManage
    {
        public UserManage()
        {
         
        }
        /**
* This function is to add user and his information into database and system
* */
        public static bool AddUser(string user_id, string user_name, string password, string question, string answer, string role)
        {
            if (Datacon.execSQL("INSERT INTO tb_User (user_id,user_name,password,question,answer,role,authority)VALUES ('" + user_id + "','" + user_name + "','" + password + "','" + question + "','" + answer + "','" + role + "',1)"))
            {
                return true;
            }
            return false;
        }
        /**
* This function is to get user detail from database
* */
        public static MySqlDataReader GetUser(string username)
        {
            MySqlDataReader datard = Datacon.getRow("SELECT * FROM tb_User WHERE user_name='" + username + "';");
            return datard;
        }
        /**
* This function is to verify the username and password
* */
        public static int Login(string username, string password)
        {
            int authority = Datacon.seleSQL("SELECT role_id FROM tb_User WHERE user_name='" + username + "'and password='" + password + "';");
            return authority;
        }
    }
}