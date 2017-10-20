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
        /**
        * This function is to initial the object
        * */
        public ClientHub(System_L system)
        {
            _system = system;
        }
        /**
        * This function is to provide a portal for system to authorention 
        * */
        public void login(string userid, string passwd)
        {
            person = _system.GetUser(userid, passwd);
        }
        /**
        * This function is to get the all of orders from system
        * */
        public IEnumerable<Order> GetAllOrder()
        {
            return _system.GetAllOrders();
            //return _system.GetAllOrders(person);
        }
        /**
        * This function is to get the all of orders from system according to their account
        * */
        public IEnumerable<Order> GetAllOrder(string useridpasswd)
        {
            string userid = useridpasswd.Split(';')[0];
            string passwd = useridpasswd.Split(';')[1];
            try
            {
                login(userid, passwd);
            }
            catch
            {
                person = null;
            }
            if (person != null)
            { return _system.GetAllOrders(person); }
            return null;
        }

    }

}