using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OrderManage
{
    public class OrderService
    {
        //订单基本信息储存在OrderList中
        public static List<Order> OrderList = new List<Order>();
        //按订单号升序排列
        public List<Order> OrderById = OrderList.OrderBy(o => o.Id).ToList<Order>();  //降序，OrderByDescending
        //按总金额排序
        public List<Order> OrderByTotalPrice = OrderList.OrderBy(o => o.CheckOrderDtailsId(o.Id).Goods.Price * o.CheckOrderDtailsId(o.Id).Goods.Number).ToList<Order>();
        //ordermessage.xml
        private const string filename = "ordermessage.xml";

        public OrderService()
        {

        }
        //添加订单
        public void AddOrder(Order order)
        {
            OrderList.Add(order);
        }

        //删除订单
        public void DeleteOrder(Order order)
        {
            OrderList.Remove(order);
        }

        //修改订单 
        public void ModifyOrder(int id)
        {
            Order order = CheckId(id);

            if (order == null)
                Console.WriteLine("没有此订单！");

            else
            {
                AddOrder(order);
                Console.WriteLine("订单已修改！");
                Console.ReadKey();

            }
        }

        //查询订单
        //根据订单号查询
        public Order CheckId(int id)
        {
            foreach (Order o in OrderList)
            {
                if (o.Id == id)
                    return o;
            }
            return null;
        }
        //根据客户名查询
        public List<Order> CheckCusName(string name)
        {
            List<Order> tmp = new List<Order>();
            foreach (Order o in OrderList)
            {
                if (o.CName == name)
                    tmp.Add(o);
            }
            List<Order> TmpById = tmp.OrderBy(o => o.Id).ToList<Order>();
            return TmpById;
        }
        //根据商品名查询
        public List<Order> CheckGoodsName(string name)
        {
            List<Order> tmp = new List<Order>();
            foreach (Order o in OrderList)
            {
                if (o.GName == name)
                    tmp.Add(o);
            }
            List<Order> TmpById = tmp.OrderBy(o => o.Id).ToList<Order>();
            return TmpById;
        }
        //LINQ查询Id
        public Order QueryById(int id)
        {
            var m = from n in OrderList where n.Id == id select n;

            {
                foreach (var n in m)
                    return n;
            }
            return null;
        }
        //LINQ查询CustomerName
        public List<Order> QueryByCusName(string name)
        {
            List<Order> tmp = new List<Order>();
            var m = from n in OrderList where n.CName == name orderby n.Id select n;
            foreach (var n in m)
                tmp.Add(n);
            return tmp;
        }
        //LINQ查询GoodsName
        public List<Order> QueryByGName(string name)
        {
            List<Order> tmp = new List<Order>();
            var m = from n in OrderList where n.GName == name orderby n.Id select n;
            foreach (var n in m)
                tmp.Add(n);
            return tmp;
        }
        //显示某个订单
        public void DisplayOne(Order o)
        {
            if (o == null)
                Console.WriteLine("订单不存在");
            else
            {
                OrderDetails odts = new OrderDetails();
                odts = o.CheckOrderDtailsId(o.Id);
                Console.WriteLine(o.ToStirng() + odts.ToString());
            }
        }
        //显示List里的Order
        public void DisplayList(List<Order> list)
        {
            Console.WriteLine("订单号\t客户名\t商品名\t单价\t数量\t总价");
            foreach (Order o in list)
            {
                DisplayOne(o);
            }
        }
        //按添加顺序显示订单
        public void Display()
        {
            DisplayList(OrderList);
        }
        //按订单号升序显示订单
        public void DisplayById()
        {
            DisplayList(OrderById);
        }
        //按总金额升序显示订单
        public void DisplayByPrice()
        {
            DisplayList(OrderByTotalPrice);
        }

        //所有的订单序列化为XML文件
        public void Export()
        {
            XmlTextWriter writer;
            writer = new XmlTextWriter(filename, null);
            //使文件易读，缩进
            writer.Formatting = Formatting.Indented;
            //Xml声明
            writer.WriteStartDocument();

            //引用样式
            String PItext = "type='text/xsl'href='order.xsl'";
            writer.WriteProcessingInstruction("xml-stylesheet", PItext);
            //文档类型
            writer.WriteDocType("order", null, null, "<!ENTITY h ' hardcover'>");
            //写入注释
            writer.WriteComment("Order XML");

            //写入元素
            //写入一个元素（根元素）
            writer.WriteStartElement("OrderMessage");
            OrderDetails odts = new OrderDetails();
            foreach (Order o in OrderList)
            {
                //写入一个元素（根元素）
                writer.WriteStartElement("Order");
                writer.WriteAttributeString("OrderId", o.Id + "");

                //其他元素
                //OrderId
                writer.WriteElementString("Id", o.Id + "");
                //CusName
                writer.WriteElementString("CustomerName", o.CName);
                //GoodsName
                writer.WriteElementString("GoodsName", o.GName);

                odts = o.CheckOrderDtailsId(o.Id);
                //UnitPrice
                writer.WriteElementString("UnitPrice", odts.Goods.Price + "");
                //Number
                writer.WriteElementString("Number", odts.Goods.Number + "");
                //TotalPrice
                writer.WriteElementString("TotalPrice", odts.Goods.Price * odts.Goods.Number + "");

                writer.WriteEndElement();
            }
            //关闭根元素
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();

            //加载文件
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(filename);
            //Xml文件显示在控制台
            Console.Write(doc.InnerXml);
            Console.ReadKey();
        }
        //从XML了文件载入订单
        public void Import()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("order.xml");
            XmlNodeList list = doc.SelectNodes("/OrderMessage/Order");
            foreach (XmlNode item in list)
            {
                Order o = new Order();
                Goods goods = new Goods();
                OrderDetails odts = new OrderDetails();
                o.Id = int.Parse(item.Attributes["OrderId"].Value); //根
                o.Id = int.Parse(item["Id"].InnerText);
                o.CName = item["CustomerName"].InnerText;
                o.GName = item["GoodsName"].InnerText;
                OrderList.Add(o);

                odts.Id = o.Id;
                odts.CName = o.CName;
                goods.Name = o.GName;
                goods.Price = (float)int.Parse(item["UnitPrice"].InnerText);
                goods.Number = int.Parse(item["Number"].InnerText);
                OrderDetails dts = new OrderDetails(o.Id, o.CName, goods);
                o.AddDetails(dts);
            }
            if (OrderList.Count != 0)
                Console.WriteLine("订单载入成功！");
            Console.ReadKey();
        }
    }
}
  

        
    