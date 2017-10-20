using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry_Platypus
{
    public class Order
    {
        public string state;
        public string ID { get; set; }
        public string Date { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string State {
            get { return state; }
            set {
                MySqlDataReader reader = Datacon.getRow("SELECT * FROM tb_Order_state WHERE state_id ='" + value + "';");
                reader.Read();
                StateName = reader["state_name"].ToString(); ;
                state = value;
            }
        }
        public string StateName { get; set; }
        public string Comment { get; set; }
        public string Product { get; set; }
        public string UserID { get; set; }
        public string Garment { get; set; }
        public string Address { get; set; }
        /**
       * This function is to initial the object
       * */
        public Order(string id, string state, string date, string customerID, string userID, string customerName, string stateName,string garment)
        {
            ID = id;
            State = state;
            Date = date;
            CustomerID = customerID;
            UserID = userID;
            CustomerName = customerName;
            StateName = stateName;
            Garment =garment;
            MySqlDataReader reader= Datacon.getRow("SELECT address FROM tb_User WHERE user_id ='"+ customerID+ "';");
            reader.Read();
            Address=reader["address"].ToString();
        }
        /**
       * This function is to initial the object
       * */
        public Order(string id, string state, string date, string customerID, string userID, string garment)
        {
            ID = id;
            State = state;
            Date = date;
            CustomerID = customerID;
            UserID = userID;
            MySqlDataReader reader = Datacon.getRow("SELECT * FROM tb_User WHERE user_id ='" + customerID + "';");
            reader.Read();
            CustomerName = reader["user_name"].ToString();
           
            Garment = garment;
            Address = reader["address"].ToString();

            reader = Datacon.getRow("SELECT * FROM tb_Order_state WHERE state_id ='" + State + "';");
            reader.Read();
            StateName = reader["state_name"].ToString(); ;
        }
    }
}