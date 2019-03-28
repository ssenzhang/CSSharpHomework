using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            int key=0;
            /*OrderService os = new OrderService();
            Order order1 = new Order(1, "ew", "ww");
            os.AddOrder(order1);*/
            while (key != 6)
            {

                Console.Clear();
                //菜单
                Console.WriteLine("*******订单管理系统*******");
                Console.WriteLine("--------------------------");
                Console.WriteLine("        1.添加订单        ");
                Console.WriteLine("        2.删除订单        ");
                Console.WriteLine("        3.查询订单        ");
                Console.WriteLine("        4.查询订单        ");
                Console.WriteLine("        5.显示订单        ");
                Console.WriteLine("        6.退出系统        ");
                Console.WriteLine("--------------------------");
                key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        //添加订单
                        MyAddOrder();
                        break;
                    case 2:
                        //删除订单
                        MyDeleteOrder();
                        break;
                    case 3:
                        //修改订单
                        break;
                    case 4:
                        //查询订单
                        MyCheckOrder();
                        break;
                    case 5:
                        //显示订单
                        ShowOrder();
                        break;
                }
            }

        }
        //添加订单
        public static void MyAddOrder()
        {
            OrderService os = new OrderService();
            Console.Write("输入订单号：");
            int id = int.Parse(Console.ReadLine());
            while (os.CheckOrderId(id) != null)
            {
                Console.WriteLine("订单已存在！");
                Console.ReadKey();
                return;
            }
            Console.Write("输入客户名：");
            string cname = Console.ReadLine();
            Console.Write("输入商品名：");
            string gname = Console.ReadLine();
            Console.Write("输入商品单价：");
            float unitPrice = float.Parse(Console.ReadLine());
            Console.Write("输入商品数量：");
            int num = int.Parse(Console.ReadLine());

            Goods goods = new Goods(gname, unitPrice, num);
            Order order = new Order(id, cname, gname);
            OrderDetails details = new OrderDetails(id, cname, goods);

            Order o = new Order();
            o.AddDetails(details);
            os.AddOrder(order);

        }
        //删除订单
        public  static void MyDeleteOrder()
        {
            OrderService os = new OrderService();
            Console.Write("输入要删除的订单号：");
            int id = int.Parse(Console.ReadLine());
            if (os.CheckOrderId(id) == null)
            {
                Console.WriteLine("订单不存在！");
                Console.ReadKey();
                return;
            }
            else
                os.DeleteOrder(os.CheckOrderId(id));
        }
        //查询订单
        public static void MyCheckOrder()
        {
            OrderService os = new OrderService();
            Order o = new Order();
            Console.Write("输入选项（1.订单号 2.客户名 3.商品名）：");
            int ckey = int.Parse(Console.ReadLine());
            switch(ckey)
            {
                case 1:
                    Console.Write("输入订单号：");
                    o=os.CheckOrderId(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.Write("输入客户名：");
                    o=os.CheckOrderCusName(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("输入商品名：");
                    o=os.CheckOrderGoodsNmae(Console.ReadLine());
                    break;

            }
            if (o == null)
                Console.WriteLine("订单不存在！");
            else
            {
                Console.WriteLine("订单号\t客户名\t商品名");
                Console.WriteLine(o.Id + "\t" + o.CName + "\t" + o.GName);
            }
            Console.ReadKey();
        }
        //显示订单内容
        public static void ShowOrder()
        {
            OrderService os = new OrderService();
            Console.WriteLine("订单号\t客户名\t商品名");
            os.DisplayOrder();
            Console.ReadKey();
        }
    }
}