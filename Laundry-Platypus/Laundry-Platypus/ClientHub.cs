using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Laundry_Platypus
{
    [HubName("clientHub")]
    public class ClientHub : Hub
    {
        Person person;
        private readonly System_L _system;

        public ClientHub() : this(System_L.Instance) { }

        public ClientHub(System_L system)
        {
            _system = system;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _system.GetAllOrders();
        }
    }
    
}