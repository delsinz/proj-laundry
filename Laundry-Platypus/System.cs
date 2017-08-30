using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Laundry_Platypus
{
    //This is 
    public class System
    {
        private readonly static Lazy<System> _instance = new Lazy<System>(() => new System(GlobalHost.ConnectionManager.GetHubContext<ClientHub>().Clients));
        //private Orderlist orderlist;
        private readonly ConcurrentDictionary<string, Order> _orders = new ConcurrentDictionary<string, Order>();
        //public System() : this(Orderlist.Instance) { }

        public System()
        {

        }
        public static System Instance
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
        private System(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            // Remainder of constructor ...
            //Initial orderlist

        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _orders.Values;
        }

}
}