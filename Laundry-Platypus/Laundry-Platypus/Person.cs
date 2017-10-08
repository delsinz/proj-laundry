using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry_Platypus
{
    public class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Active { get; set; }
        public string Selfie { get; set; }
        public string Passwd { get; set; }
        public string Roleid { get; set; }
        public Person(string id,string name, string contact,string active,string selfie, string passwd, string roleid)
        {
            ID=id;
            Name = name;
            Contact = contact;
            Active = active;
            Selfie = selfie;
            Roleid = roleid;
            Passwd = passwd;
            
        }
    }
    public class Producer:Person
    {
        public Producer(string id, string name, string contact, string active, string selfie, string passwd, string roleid) : base(id, name, contact, active, selfie, passwd, roleid)
        {
            ID = id;
            Name = name;
            Contact = contact;
            Active = active;
            Selfie = selfie;
            Roleid = roleid;
            Passwd = passwd;
        }

        public string Department { get; set; }
        public string LeaderID { get; set; }
        public int OrderNumber { get; set; }
    }
    public class Driver : Producer
    {
        public List<Order> pickup_list = new List<Order>();
        public List<Order> dropoff_list = new List<Order>();

        public Driver(string id, string name, string contact, string active, string selfie, string passwd, string roleid) : base(id, name, contact, active, selfie, passwd, roleid)
        {
            OrderNumber = 0;
            ID = id;
            Name = name;
            Contact = contact;
            Active = active;
            Selfie = selfie;
            Roleid = roleid;
            Passwd = passwd;
        }

        public Order getOrder_p(string ID)
        {
            foreach (Order order in pickup_list)
            {
                if (order.ID == ID)
                {
                    return order;
                }
            }
            return null;
        }
        public bool rmOrder_d(string ID)
        {
            foreach (Order order in dropoff_list)
            {
                if (order.ID == ID)
                {
                    dropoff_list.Remove(order);
                    return true;
                }
            }
            return false;
        }
        public bool rmOrder_p(string ID)
        {
            foreach (Order order in pickup_list)
            {
                if (order.ID == ID)
                {
                    pickup_list.Remove(order);
                    return true;
                }
            }
            return false;
        }
        public List<Order> getOrder_p()
        {
            
            return pickup_list;
        }
        public Order getOrder_d(string ID)
        {
            foreach (Order order in dropoff_list)
            {
                if (order.ID == ID)
                {
                    return order;
                }
            }
            return null;
        }
        public List<Order> getOrder_d()
        {
            return dropoff_list;
        }
        public int addOrder_p(Order order)
        {
            OrderNumber = OrderNumber + 1;
            pickup_list.Add(order);
            return pickup_list.Count;
        }
        public int addOrder_d(Order order)
        {
            OrderNumber = OrderNumber + 1;
            dropoff_list.Add(order);
            return dropoff_list.Count;
        }
        public bool setOrder(Order order)
        {
            foreach (Order order_t in pickup_list)
            {
                if (order_t.ID == order.ID)
                {
                    int index=pickup_list.IndexOf(order_t);
                    // change the order_t's attribute
                    pickup_list[index] = order;
                    return true;
                }
            }
            return false;
        }
        public void setOrder(Order[] order)
        {
            pickup_list.Clear();
            foreach (Order order_t in order)
            {
                pickup_list.Add(order_t);
            }
            OrderNumber = pickup_list.Count();
            return;
        }
    }
    public class Packer : Producer
    {
        public List<Order> pickup_list = new List<Order>();
        public List<Order> dropoff_list = new List<Order>();

        public Packer(string id, string name, string contact, string active, string selfie, string passwd, string roleid) : base(id, name, contact, active, selfie, passwd, roleid)
        {
            OrderNumber = 0;
            ID = id;
            Name = name;
            Contact = contact;
            Active = active;
            Selfie = selfie;
            Roleid = roleid;
            Passwd = passwd;
        }

        public Order getOrder_p(string ID)
        {
            foreach (Order order in pickup_list)
            {
                if (order.ID == ID)
                {
                    return order;
                }
            }
            return null;
        }
        public bool rmOrder_p(string ID)
        {
            foreach (Order order in pickup_list)
            {
                if (order.ID == ID)
                {
                    pickup_list.Remove(order);
                    return true;
                }
            }
            return false;
        }
        public List<Order> getOrder_p()
        {

            return pickup_list;
        }
        public Order getOrder_d(string ID)
        {
            foreach (Order order in dropoff_list)
            {
                if (order.ID == ID)
                {
                    return order;
                }
            }
            return null;
        }
        public bool rmOrder_d(string ID)
        {
            foreach (Order order in dropoff_list)
            {
                if (order.ID == ID)
                {
                    dropoff_list.Remove(order);
                    return true;
                }
            }
            return false;
        }
        public List<Order> getOrder_d()
        {
            return dropoff_list;
        }
        public int addOrder_p(Order order)
        {
            OrderNumber++;
            pickup_list.Add(order);
            return pickup_list.Count;
        }
        public int addOrder_d(Order order)
        {
            OrderNumber++;
            dropoff_list.Add(order);
            return pickup_list.Count;
        }
        public bool setOrder(Order order)
        {
            foreach (Order order_t in pickup_list)
            {
                if (order_t.ID == order.ID)
                {
                    int index = pickup_list.IndexOf(order_t);
                    // change the order_t's attribute
                    pickup_list[index] = order;
                    return true;
                }
            }
            return false;
        }
        public void setOrder(Order[] order)
        {
            pickup_list.Clear();
            foreach (Order order_t in order)
            {
                pickup_list.Add(order_t);
            }
            OrderNumber = pickup_list.Count();
            return;
        }
    }
}