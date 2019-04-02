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
        public  static List<Order> OrderList = new List<Order>();
        //按订单号升序排列
        public List<Order> OrderById = OrderList.OrderBy(o => o.Id).ToList<Order>();  //降序，OrderByDescending
        //按总金额排序
        public List<Order> OrderByTotalPrice = OrderList.OrderBy(o => o.CheckOrderDtailsId(o.Id).Goods.Price * o.CheckOrderDtailsId(o.Id).Goods.Number).ToList<Order>();

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
            Console.WriteLine("订单已删除！");
            Console.ReadKey();
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
        //显示某个订单
       public void DisplayOne(Order o)
        {
            if (o == null)
                Console.WriteLine("订单不存在");
            else
            {
                OrderDetails odts = new OrderDetails();
                odts = o.CheckOrderDtailsId(o.Id);
                Console.WriteLine(o.ToStirng()+odts.ToString());
            }
        }
        //显示List里的Order
        public void  DisplayList(List<Order> list)
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
    }
}