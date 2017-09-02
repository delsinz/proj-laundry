using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Laundry_Playtus
{
    [HubName("clientHub123")]
    public class ClientHub : Hub
    {
        //Person person;
        private readonly System_L _system;

        public ClientHub() : this(System_L.Instance) { }

        public ClientHub(System_L system)
        {
            _system = system;
        }
        //public void login(string userid, string passwd)
        //{
        //    person=_system.GetUser(userid, passwd);
        //}
        public IEnumerable<Order> GetAllOrder()
        {
            return _system.GetAllOrders();
            //return _system.GetAllOrders(person);
        }
        //public IEnumerable<Order> GetAllOrder(string userid, string passwd)
        //{
        //  person = _system.GetUser(userid, passwd);
        //return _system.GetAllOrders();
        //return _system.GetAllOrders(person);
        //}
    }
}