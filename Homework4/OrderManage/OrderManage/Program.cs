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
            while (key != 6)
            {
                Console.Clear();
                Console.WriteLine("*******订单管理系统*******");
                Console.WriteLine("--------------------------");
                Console.WriteLine("        1.添加订单        ");
                Console.WriteLine("        2.删除订单        ");
                Console.WriteLine("        3.修改订单        ");
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
                        MyModifyOrder();
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
            Order o = new Order();
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
            OrderDetails dts = new OrderDetails(id, cname, goods);
            
            o.AddDetails(dts);
            os.AddOrder(order);
            Console.ReadKey();
            

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
        //修改订单
        public  static void MyModifyOrder()
        {
            OrderService os = new OrderService();
            Order o = new Order();
            Console.Write("输入要修改的订单号：");
            int id = int.Parse(Console.ReadLine());
            while (os.CheckOrderId(id) == null)
            {
                Console.WriteLine("订单不存在！");
                Console.ReadKey();
                return;
            }
            o = os.CheckOrderId(id);
            Console.Write("输入选项（1.客户名 2.商品名 3.商品数量）：");
            int mkey = int.Parse(Console.ReadLine());
            
            switch (mkey)
            {
                case 1:
                    Console.Write("输入修改后的客户名：");
                    o.CName = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("输入修改后的商品名：");
                    o.GName = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("输入修改后的商品数量：");
                    o.CheckOrderDtailsId(id).Goods.Number= int.Parse(Console.ReadLine());
                    break;

            }
        }
        //查询订单
        public static void MyCheckOrder()
        {
            OrderService os = new OrderService();
            Order o = new Order();
            OrderDetails od = new OrderDetails();
            Console.Write("输入选项（1.订单号 2.客户名 3.商品名）：");
            int ckey = int.Parse(Console.ReadLine());
            switch(ckey)
            {
                case 1:
                    Console.Write("输入订单号：");
                    o=os.CheckOrderId(int.Parse(Console.ReadLine()));
                    Console.WriteLine("订单号\t客户名\t商品名\t单价\t数量\t总价");
                    os.DisplayOne(o);
                    break;
                case 2:
                    Console.Write("输入客户名：");
                    string str1 = Console.ReadLine();
                    Console.WriteLine("订单号\t客户名\t商品名\t单价\t数量\t总价");
                    foreach (Order ot in os.CheckOrderCusName(str1))
                    {
                        os.DisplayOne(ot);
                    }
                    break;
                case 3:
                    Console.Write("输入商品名：");
                    string str2 = Console.ReadLine();
                    Console.WriteLine("订单号\t客户名\t商品名\t单价\t数量\t总价");
                    foreach (Order ot in os.CheckOrderGoodsName(str2))
                    {
                        os.DisplayOne(ot);
                    }
                    break;

            }
            Console.ReadKey();
        }
        //显示订单内容
        public static void ShowOrder()
        {
            OrderService os = new OrderService();
            Console.WriteLine("订单号\t客户名\t商品名\t单价\t数量\t总价");
            os.DisplayOrder();
            Console.ReadKey();
        }
    }
}