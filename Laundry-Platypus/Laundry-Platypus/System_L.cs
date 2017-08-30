using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Data;

namespace Laundry_Platypus
{
    //This is ticker
    public class System_L
    {
        private readonly static Lazy<System_L> _instance = new Lazy<System_L>(() => new System_L(GlobalHost.ConnectionManager.GetHubContext<ClientHub>().Clients));
        //private Orderlist orderlist;
        private readonly ConcurrentDictionary<string, Order> _orders = new ConcurrentDictionary<string, Order>();
        //public System() : this(Orderlist.Instance) { }
        private readonly object _updateOrderLock = new object();
        private volatile bool _updatingOrder = false;
        
        public static System_L Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }
        private System_L(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            // Remainder of constructor ...
            //Initial orderlist
            //Order order_test = new Order("test_ID","test_state");
           // Order order_test = new Order("test_ID", "test_state");
            //_orders.TryAdd("test", order_test);
            //orderstate>0 means available, 0 means deactive -1 means done
            DataSet dataset = Datacon.getDataset("SELECT * FROM tb_Order WHERE order_state>0 ", "Order");
            foreach (DataRow pRow in dataset.Tables["Order"].Rows)
            {
                Order order_test = new Order(pRow["order_id"].ToString(), pRow["order_state"].ToString());
                _orders.TryAdd(pRow["order_id"].ToString(), order_test);
            }
            //System.Console.WriteLine("success");

        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _orders.Values;
        }
        private void UpdateOrder(object state)
        {
            lock (_updateOrderLock)
            {
                if (!_updatingOrder)
                {
                    _updatingOrder = true;

                    foreach (var order_t in _orders.Values)
                    {

                    }

                    _updatingOrder = false;
                }
            }
        }

    }
}