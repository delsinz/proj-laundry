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
        private readonly ConcurrentDictionary<string, Order> _orders = new ConcurrentDictionary<string, Order>();
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
        public bool Distruibute(Order order)
        {
            //order.State = (int.Parse(order.State) + 1).ToString();
            if (order.State == "5")
            {
                //finished
            }
            else if (order.State == "0")
            {
                //deactive
            }
            else if (order.State == "1")
            {
                //driver should pickup
                int  n=0;
                for (int t=0;t<drivers.Count;t++)// get the driver who have less works
                {
                    if (drivers[t].OrderNumber < drivers[n].OrderNumber)
                    {
                        n = t;
                    }
                }
                if(drivers[n].addOrder_p(order)>0)
                {
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
                if (drivers[n].addOrder_d(order) > 0)
                {
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
                if (packers[n].addOrder_p(order) > 0) { return true; }
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
                if (packers[n].addOrder_d(order) > 0) { return true; }
            }
            return false;
        }
    }
}