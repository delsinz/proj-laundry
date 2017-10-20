using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Laundry_Platypus
{
    public class Datacon
    {
        static MySqlConnection con;
        //public static string Conn_string = "Database='laundry';Data Source='35.190.155.225:3306';User Id='testuser';Password='laundry123456';charset='utf8';pooling=true";
        static string connStr = "Server=127.0.0.1;Database=laundry;Uid=testuser;Pwd=laundry123456;CharSet=utf8;";
        //static MySqlConnection con;
        /**
        * This function is to execute the qurery and return the result 
        * */
        public static bool execSQL(string sql)
        {
            MySqlConnection con = createCon();
            
           
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(sql, con);
                int i = com.ExecuteNonQuery();
                if (i > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }



            }
            catch (Exception e)
            {
                con.Close();
                return false;
            }

        }
        /**
        * This function is to execute the qurery and return the result 
        * */
        //Check the record is exited
        public static int seleSQL(string sql)
        {
            MySqlConnection con = createCon();
            con.Open();
            MySqlCommand com = new MySqlCommand(sql, con);
            try
            {
                return Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception e)
            {
                con.Close();
                return 0;
            }


        }
        /**
        * This function is to return all the records about the qurery 
        * */
        //return all the records
        public static DataSet getDataset(string sql, string table)
        {

            MySqlConnection con = createCon();
            con.Open();
            DataSet ds;

            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            ds = new DataSet();
            sda.Fill(ds, table);
            return ds;



        }
        /**
        * This function is to return the first record of qurery 
        * */
        //return a record
        public static MySqlDataReader getRow(string sql)
        {
            MySqlConnection con = createCon();
            con.Open();
            MySqlCommand com = new MySqlCommand(sql, con);
            return com.ExecuteReader();


        }
        /**
        * This function is to open a connection between MySQL and web application 
        * */
        public static MySqlConnection createCon()
        {
            con = new MySqlConnection(connStr);
            return con;
        }
    }

}