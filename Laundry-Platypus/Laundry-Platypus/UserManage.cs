using MySql.Data.MySqlClient;

namespace Laundry_Platypus
{
    public class UserManage
    {
        public UserManage()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static bool AddUser(string user_id, string user_name, string password, string question, string answer, string role)
        {
            if (Datacon.execSQL("INSERT INTO tb_User (user_id,user_name,password,question,answer,role,authority)VALUES ('" + user_id + "','" + user_name + "','" + password + "','" + question + "','" + answer + "','" + role + "',1)"))
            {
                return true;
            }
            return false;
        }
        public static MySqlDataReader GetUser(string username)
        {
            MySqlDataReader datard = Datacon.getRow("SELECT * FROM tb_User WHERE user_name='" + username + "';");
            return datard;
        }
        public static int Login(string username, string password)
        {
            int authority = Datacon.seleSQL("SELECT role_id FROM tb_User WHERE user_name='" + username + "'and password='" + password + "';");
            return authority;
        }
    }
}