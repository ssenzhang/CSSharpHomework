using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderManageWF
{
    public class OrderService
    {

        private List<Order> OrderList;

        public OrderService()
        {
            OrderList = new List<Order>();
        }
        public void AddOrder(Order o)
        {
            if (OrderList.Contains(o))
            {
                throw new ApplicationException($"Order {o.Id} already exist!");
            }
            OrderList.Add(o);
        }

        public void Update(Order order)
        {
            RemoveOrder(order.Id);
            OrderList.Add(order);
        }
        public Order QueryById(int id)
        {
            return OrderList.FirstOrDefault(o => o.Id == id);
        }
        public void RemoveOrder(int orderId)
        {
            OrderList.RemoveAll(o => o.Id == orderId);
        }
        public List<Order> QueryAll()
        {
            return OrderList;
        }
        public List<Order> QueryByGName(string name)
        {
            var query = OrderList.Where(
              o => o.Details.Exists(
                d => d.Goods.Name == name));
            return query.ToList();
        }
        public List<Order> QueryByTPrice(float totalAmount)
        {
            var query = OrderList.Where(o => o.TPrice >= totalAmount);
            return query.ToList();
        }
        public List<Order> QueryByCName(string name)
        {
            var query = OrderList
                .Where(o => o.CName == name);
            return query.ToList();
        }

        public void Sort(Comparison<Order> cmp)
        {
            OrderList.Sort(cmp);
        }

        public void Export(String fileName)
        {
            if (Path.GetExtension(fileName) != ".xml")
                throw new ArgumentException("the exported file must be a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, this.OrderList);
            }
        }
        public List<Order> Import(string path)
        {
            if (Path.GetExtension(path) != ".xml")
                throw new ArgumentException($"{path} isn't a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            List<Order> result = new List<Order>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    return (List<Order>)xs.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("import error:" + e.Message);
            }

        }

    }
}
