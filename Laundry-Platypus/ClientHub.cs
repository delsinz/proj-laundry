using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Laundry_Platypus
{
    public class ClientHub : Hub
    {
        
        private readonly System _system;

        public ClientHub() : this(System.Instance) { }

        public ClientHub(System system)
        {
            _system = system;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _system.GetAllOrders();
        }
    }
    
}