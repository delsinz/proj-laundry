using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry_Platypus
{
    public class Order
    {
        public string ID { get; set; }
        public string Date { get; set; }
        public string CustomerID { get; set; }
        public string State { get; set; }
        public string Comment { get; set; }
        public string Product { get; set; }
        public string UserID { get; set; }
        public Order(string id, string state, string date, string customerID, string userID)
        {
            ID = id;
            State = state;
            Date = date;
            CustomerID = customerID;
            UserID = userID;
        }
    }
}