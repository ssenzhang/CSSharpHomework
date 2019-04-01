using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderService
    {
        //订单基本信息储存在OrderList中
        private static List<Order> OrderList = new List<Order>();

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
            Order order = CheckOrderId(id);

            if (order == null)
                Console.WriteLine("没有此订单！");

            else
            {
                AddOrder(order);

            }
        }

        //查询订单
        //根据订单号查询
        public Order CheckOrderId(int id)
        {
            foreach (Order o in OrderList)
            {
                if (o.Id == id)
                    return o;
            }
            return null;
        }
        //根据客户名查询
        public List<Order> CheckOrderCusName(string name)
        {
            List<Order> tmp = new List<Order>();
            foreach (Order o in OrderList)
            {
                if (o.CName == name)
                    tmp.Add(o);
            }
            return tmp;
        }
        //根据商品名查询
        public List<Order> CheckOrderGoodsName(string name)
        {
            List<Order> tmp = new List<Order>();
            foreach (Order o in OrderList)
            {
                if (o.GName == name)
                    tmp.Add(o);
            }
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
                Console.Write(o.Id + "\t" + o.CName + "\t" + o.GName);
                Console.WriteLine("\t" + odts.Goods.Price + "\t" + odts.Goods.Number + "\t" + (odts.Goods.Number * odts.Goods.Price));
            }
        }
        //显示全部订单
        public void DisplayOrder()
        {
            foreach (Order o in OrderList)
            {
                DisplayOne(o);
            }
        }
    }
}