using MySql.Data.MySqlClient;

namespace Laundry_Playtus
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
        public static MySqlDataReader GetUser(string userid)
        {
            MySqlDataReader datard = Datacon.getRow("SELECT * FROM tb_User WHERE user_id='" + userid + "';");
            return datard;
        }
        public static int Login(string userid, string password)
        {
            int authority = Datacon.seleSQL("SELECT role_id FROM tb_User WHERE user_id='" + userid + "'and password='" + password + "';");
            return authority;
        }
    }
}