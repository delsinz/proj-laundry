using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry_Platypus
{
    public class Controler
    {
        private readonly ConcurrentDictionary<string, Person> _users = new ConcurrentDictionary<string, Person>();
        public readonly ConcurrentDictionary<string, Order> _orders = new ConcurrentDictionary<string, Order>();
        public List<Driver> drivers = new List<Driver>();
        public List<Packer> packers = new List<Packer>();
        public Controler(ConcurrentDictionary<string, Person> users, ConcurrentDictionary<string, Order> orders)
        {
            _users = users;
            _orders = orders;
            IEnumerable<Person> personlist = users.Values;
            IEnumerable<Order> orderlist = orders.Values;
            foreach (Person person_t in personlist)
            {
                //driver
                if (person_t.Roleid == "3")
                {
                    Driver driver_t = new Driver(person_t.ID,person_t.Name, person_t.Contact, person_t.Active, person_t.Selfie, person_t.Passwd, person_t.Roleid);
                    foreach (Order order_t in orderlist)
                    {
                        if (person_t.ID == order_t.UserID)
                        {
                            if (order_t.State == "1")
                            {
                                driver_t.addOrder_p(order_t);
                            }
                            else if (order_t.State == "4")
                            {
                                driver_t.addOrder_d(order_t);
                            }
                        }
                    }
                    drivers.Add(driver_t);
                }
                //packer
                else if (person_t.Roleid == "2")
                {
                    Packer packer_t = new Packer(person_t.ID, person_t.Name, person_t.Contact, person_t.Active, person_t.Selfie, person_t.Passwd, person_t.Roleid);
                    foreach (Order order_t in orderlist)
                    {
                        if (person_t.ID == order_t.UserID)
                        {
                            if (order_t.State == "2")
                            {
                                packer_t.addOrder_p(order_t);
                            }
                            else if (order_t.State == "3")
                            {
                                packer_t.addOrder_d(order_t);
                            }
                        }
                    }
                    packers.Add(packer_t);
                }
            }
        }
        public bool Distruibute(string order_id)
        {
            Order order = null;
            this.drivers.ForEach((x) =>
            {
                if (x.getOrder_d(order_id) != null)
                {
                    order = x.getOrder_d(order_id);
                    x.rmOrder_d(order_id);
                }
                else if (x.getOrder_p(order_id) != null)
                {
                    order = x.getOrder_p(order_id);
                    x.rmOrder_p(order_id);
                }
            });
            this.packers.ForEach((x) =>
            {
                if (x.getOrder_d(order_id) != null)
                {
                    order = x.getOrder_d(order_id);
                    x.rmOrder_d(order_id);

                }
                else if (x.getOrder_p(order_id) != null)
                {
                    order = x.getOrder_p(order_id);
                    x.rmOrder_p(order_id);
                }
            });
            if (order != null)
            {
                order.State = (int.Parse(order.State) + 1).ToString();
                if (order.State == "5")
                {
                    //finished
                    System_L.Instance.UpdateOrder(order);
                    return true;
                }
                else if (order.State == "0")
                {
                    //deactive
                }
                else if (order.State == "1")
                {
                    //driver should pickup
                    int n = 0;
                    for (int t = 0; t < drivers.Count; t++)// get the driver who have less works
                    {
                        if (drivers[t].OrderNumber < drivers[n].OrderNumber)
                        {
                            n = t;
                        }
                    }
                    if (drivers[n].addOrder_p(order) > 0)
                    {
                        Order order_t = order;
                        order_t.UserID = drivers[n].ID;
                        _orders.TryUpdate(order.ID,order_t,order);
                        System_L.Instance.UpdateOrder(order);
                        return true;
                    }
                }
                else if (order.State == "4")
                {
                    //driver should dropoff
                    int n = 0;
                    for (int t = 0; t < drivers.Count; t++)// get the driver who have less works
                    {
                        if (drivers[t].OrderNumber < drivers[n].OrderNumber)
                        {
                            n = t;
                        }
                    }
                    if (drivers[n].addOrder_d(order) >= 0)
                    {
                        Order order_t = order;
                        order_t.UserID = drivers[n].ID;
                        _orders.TryUpdate(order.ID, order_t, order);
                        System_L.Instance.UpdateOrder(order);
                        return true;
                    }
                }
                else if (order.State == "2")
                {
                    //packer should distribute
                    int n = 0;
                    for (int t = 0; t < packers.Count; t++)// get the packer who have less works
                    {
                        if (packers[t].OrderNumber < packers[n].OrderNumber)
                        {
                            n = t;
                        }
                    }
                    if (packers[n].addOrder_p(order) > 0) {
                        Order order_t = order;
                        order_t.UserID = packers[n].ID;
                        _orders.TryUpdate(order.ID, order_t, order);
                        System_L.Instance.UpdateOrder(order); return true; }
                }
                else if (order.State == "3")
                {
                    //packer should packup
                    int n = 0;
                    for (int t = 0; t < packers.Count; t++)// get the packer who have less works
                    {
                        if (packers[t].OrderNumber < packers[n].OrderNumber)
                        {
                            n = t;
                        }
                    }
                    if (packers[n].addOrder_d(order) > 0) {
                        Order order_t = order;
                        order_t.UserID = packers[n].ID;
                        _orders.TryUpdate(order.ID, order_t, order);
                        System_L.Instance.UpdateOrder(order);
                        return true; }
                }
            }
            return false;
            
        }
        public IEnumerable<Order> GetOrderList(Person person)
        {
            IEnumerable<Order> orders_t=null;
            foreach (Driver driver in drivers)
            {
                if (driver.ID == person.ID)
                {
                    List<Order> orders_tL = driver.pickup_list;
                    orders_tL.AddRange(driver.dropoff_list);
                   orders_t = orders_tL;
                    
                }
            }
            foreach (Packer packer in packers)
            {
                if (packer.ID == person.ID)
                {
                    List<Order> orders_tL = packer.pickup_list;
                    orders_tL.AddRange(packer.dropoff_list);
                    orders_t = orders_tL;
                }
            }
            return orders_t;
        }
        public bool Save(Order order)
        {
            if(Datacon.execSQL("UPDATE tb_Order SET user_id ='"+order.UserID+"', order_state = '"+order.State+"', garment = '"+order.Garment+"' WHERE order_id ='"+order.ID+"';"))
             {
                this.drivers.ForEach((x) =>
                {
                    if (x.getOrder_d(order.ID) != null)
                    {
                        order = x.getOrder_d(order.ID);
                        x.rmOrder_d(order.ID);
                        x.addOrder_d(order);
                    }
                    else if (x.getOrder_p(order.ID) != null)
                    {
                        order = x.getOrder_p(order.ID);
                        x.rmOrder_p(order.ID);
                        x.addOrder_p(order);
                    }
                });
                this.packers.ForEach((x) =>
                {
                    if (x.getOrder_d(order.ID) != null)
                    {
                        order = x.getOrder_d(order.ID);
                        x.rmOrder_d(order.ID);
                        x.addOrder_d(order);
                    }
                    else if (x.getOrder_p(order.ID) != null)
                    {
                        order = x.getOrder_p(order.ID);
                        x.rmOrder_p(order.ID);
                        x.addOrder_p(order);
                    }
                });
                return true;
            }
            return false;

        }

        public bool AddOrder(Order order)
        {
            order.State = "1";
            if (order.State == "1")
            {
                //driver should pickup
                int n = 0;
                for (int t = 0; t < drivers.Count; t++)// get the driver who have less works
                {
                    if (drivers[t].OrderNumber < drivers[n].OrderNumber)
                    {
                        n = t;
                    }
                }
                if (drivers[n].addOrder_p(order) > 0)
                {
                    Order order_t = order;
                    order_t.UserID = drivers[n].ID;
                    _orders.TryAdd(order_t.ID, order_t);
                    //System_L.Instance.UpdateOrder(order);
                    if(Save(order_t))
                    { return true; }
                    
                }
            }
            return false;
        }
    }
}