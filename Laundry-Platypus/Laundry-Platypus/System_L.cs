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
        private readonly ConcurrentDictionary<string, Person> _users = new ConcurrentDictionary<string, Person>();
        //public System() : this(Orderlist.Instance) { }
        private readonly object _updateOrderLock = new object();
        private volatile bool _updatingOrder = false;
        private Controler controler;
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
        /**
        * This function is to initial the System_L object
        * */
        private System_L(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            // Remainder of constructor ...
            //Initial orderlist
            //Order order_test = new Order("test_ID","test_state");
            // Order order_test = new Order("test_ID", "test_state");
            //_orders.TryAdd("test", order_test);
            //orderstate>0 means available, 0 means deactive -1 means done
            DataSet dataset = Datacon.getDataset("SELECT * FROM tb_Order,tb_Order_state,tb_User WHERE order_state>0 and tb_Order.customer_id=tb_User.user_id and tb_Order.order_state=tb_Order_state.state_id", "Order");
            foreach (DataRow pRow in dataset.Tables["Order"].Rows)
            {
                Order order_test = new Order(pRow["order_id"].ToString(), pRow["order_state"].ToString(), pRow["order_date"].ToString(), pRow["customer_id"].ToString(), pRow["user_id"].ToString(), pRow["user_name"].ToString(), pRow["state_name"].ToString(), pRow["garment"].ToString());
                _orders.TryAdd(pRow["order_id"].ToString(), order_test);
            }
            // System.Console.WriteLine("success");
            dataset = Datacon.getDataset("SELECT * FROM tb_User ", "User");
            foreach (DataRow pRow in dataset.Tables["User"].Rows)
            {
                Person person_t = new Person(pRow["user_id"].ToString(), pRow["user_name"].ToString(), pRow["user_contact"].ToString(), pRow["user_active"].ToString(), pRow["user_selfie"].ToString(), pRow["password"].ToString(), pRow["role_id"].ToString());
                _users.TryAdd(pRow["user_id"].ToString(), person_t);
                System.Console.WriteLine(pRow["user_id"]);
            }
            controler = new Controler(_users, _orders);
            //System.Console.WriteLine("success");
        }
        /**
* This function is for clients to get all order from system and show them on page
* */
        public IEnumerable<Order> GetAllOrders()
        {
            return _orders.Values;
        }
        /**
* This function is to get specific user from system
* */
        public Person GetUser(string userid, string passwd)
        {
            Person person_t;
            //System.Console.WriteLine(userid+ passwd);
            if (_users.ContainsKey(userid) == true)
            {
                if (_users.TryGetValue(userid, out person_t))
                {
                    if (person_t.Passwd.Equals(passwd))
                    {
                        return _users[userid];
                    }
                }
            }
            return null;
        }
        /**
* This function is to update order detail into database and system
* */
        public void UpdateOrder(Order order)
        {
            lock (_updateOrderLock)
            {
                if (!_updatingOrder)
                {
                    _updatingOrder = true;

                    Clients.All.addOrder(order);

                    _updatingOrder = false;
                }
            }
        }
        /**
* This function is for clients to get all order from system and show them on page according to their account
* */
        public IEnumerable<Order> GetAllOrders(Person person)
        {
            if (person.Roleid == "3")
            {
                //This is driver
                ConcurrentDictionary<string, Order> orders_t = new ConcurrentDictionary<string, Order>();
                IEnumerable<Order> orderlist = controler.GetOrderList(person);
                foreach (Order order_t in orderlist)
                {
                    if (order_t.UserID == person.ID)
                    {
                        orders_t.TryAdd(order_t.ID, order_t);
                    }
                }
                return orders_t.Values;
            }
            if (person.Roleid == "2")
            {
                //This is packer
                ConcurrentDictionary<string, Order> orders_t = new ConcurrentDictionary<string, Order>();
                IEnumerable<Order> orderlist = controler.GetOrderList(person);
                foreach (Order order_t in orderlist)
                {
                    if (order_t.UserID == person.ID)
                    {
                        orders_t.TryAdd(order_t.ID, order_t);
                    }
                }
                return orders_t.Values;
            }
            if (person.Roleid == "1")
            {
                //This is officeworker
                return controler._orders.Values;
            }
            if (person.Roleid == "4")
            {
                //This is client

            }
            return null;
        }
        /**
* This function is to add order detail into database and system
* */
        public bool AddOrder(Order order)
        {
            try
            {
                if (controler.AddOrder(order))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        /**
* This function is to get order detail from system and return their value
* */
        public Order GetOrder(string order_id)
        {
            Order order=null;
            controler.drivers.ForEach((x) =>
            {
                
                if (x.getOrder_d(order_id) != null)
                {
                    order = x.getOrder_d(order_id);

                }
                else if (x.getOrder_p(order_id) != null)
                {
                    order = x.getOrder_p(order_id);
                }
            });
            controler.packers.ForEach((x) =>
            {
                
                if (x.getOrder_d(order_id) != null)
                {
                    order = x.getOrder_d(order_id);

                }
                else if (x.getOrder_p(order_id) != null)
                {
                    order = x.getOrder_p(order_id);
                }
            });
            return order;

        }
        /**
* This function is to distribute the order
* */
        public bool Distribute(string order_id)
        {
            if (controler.Distruibute(order_id))
            {
                return true;
            }
            return false;
        }
        /**
* This function is to save order detail into database and system
* */
        public bool SaveOrder(Order order)
        {
            if (controler.Save(order))
            { return true; }
            return false;
        }
    }
}