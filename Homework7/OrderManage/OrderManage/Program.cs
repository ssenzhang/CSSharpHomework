using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            int key=0;
            while (key != 8)
            {
                Console.Clear();
                Console.WriteLine("*******订单管理系统*******");
                Console.WriteLine("--------------------------");
                Console.WriteLine("        1.添加订单        ");
                Console.WriteLine("        2.删除订单        ");
                Console.WriteLine("        3.修改订单        ");
                Console.WriteLine("        4.查询订单        ");
                Console.WriteLine("        5.显示订单        ");
                Console.WriteLine("        6.打印XML文件     ");
                Console.WriteLine("        7.从XML获取数据   ");
                Console.WriteLine("        8.退出系统        ");
                Console.WriteLine("--------------------------");
                key = PositiveNumber();
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
                        Console.ReadKey();
                        break;
                    case 5:
                        //显示订单
                        ShowOrder();
                        break;
                    case 6:
                        //显示XML文件
                        OrderService os1 = new OrderService();
                        os1.Export();
                        break;
                    case 7:
                        //读XML文件获取数据
                        OrderService os2 = new OrderService();
                        os2.Import();
                        break;
                    default:
                        //错误选项,重新选择
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
            int id =PositiveNumber();
            while (os.CheckId(id) != null)
            {
                Console.WriteLine("订单已存在！");
                Console.ReadKey();
                return;
            }
            Console.Write("输入客户名：");
            string cname = StringNotNull();
            Console.Write("输入商品名：");
            string gname = StringNotNull();
            Console.Write("输入商品单价：");
            float unitPrice = (float)(PositiveNumber());
            Console.Write("输入商品数量：");
            int num = PositiveNumber();

            Goods goods = new Goods(gname, unitPrice, num);
            Order order = new Order(id, cname, gname);
            OrderDetails dts = new OrderDetails(id, cname, goods);
            
            o.AddDetails(dts);
            os.AddOrder(order);
            Console.ReadKey();
        }
        //删除订单
        public static void MyDeleteOrder()
        {
            OrderService os = new OrderService();
            Console.Write("输入要删除的订单号：");
            int id = PositiveNumber();
            if (os.CheckId(id) == null)
            {
                Console.WriteLine("订单不存在！");
                Console.ReadKey();
                return;
            }
            else
            {
                os.DeleteOrder(os.CheckId(id));
                Console.WriteLine("订单已删除！");
                Console.ReadKey();
            }
        }
        //修改订单
        public  static void MyModifyOrder()
        {
            OrderService os = new OrderService();
            Order o = new Order();
            Console.Write("输入要修改的订单号：");
            int id = PositiveNumber();
            while (os.CheckId(id) == null)
            {
                Console.WriteLine("订单不存在！");
                Console.ReadKey();
                return;
            }
            o = os.CheckId(id);
            Console.Write("输入选项(1.客户名 2.商品名 3.商品数量)：");
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
            Console.Write("输入选项(1.订单号 2.客户名 3.商品名)：");
            int ckey = PositiveNumber();
            switch(ckey)
            {
                case 1:
                    Console.Write("输入订单号：");
                    //o=os.CheckId(PositiveNumber());
                    o = os.QueryById(PositiveNumber());
                    if (o == null)
                        Console.WriteLine("订单不存在！");
                    else
                    {
                        Console.WriteLine("订单号\t客户名\t商品名\t单价\t数量\t总价");
                        os.DisplayOne(o);
                    }
                    break;
                case 2:
                    Console.Write("输入客户名：");
                    string str1 = StringNotNull();
                    if (/*os.CheckCusName(str1).Count==0*/os.QueryByCusName(str1).Count==0)
                        Console.WriteLine("订单不存在！");
                    else
                        os.DisplayList(/*os.CheckCusName(str1)*/os.QueryByCusName(str1));
                    break;
                case 3:
                    Console.Write("输入商品名：");
                    string str2 = StringNotNull();
                    if (/*os.CheckGoodsName(str2).Count == 0*/os.QueryByGName(str2).Count==0)    //os.CheckGoodsName(str2)==null,error!
                        Console.WriteLine("订单不存在！");
                    else
                        os.DisplayList(os.QueryByGName(str2));              
                    break;
            }
            Console.ReadKey();
        }
        //显示订单内容
        public static void ShowOrder()
        {
            int dkey = 0;
            OrderService os = new OrderService();
            Console.WriteLine("输入选项(1.按添加顺序 2.按订单号升序 3.按总金额升序 4.退出查询)：");
            while (dkey != 4)
            {
                dkey = PositiveNumber();
                switch (dkey)
                {
                    case 1:
                        os.Display();
                        break;
                    case 2:
                        os.DisplayById();
                        break;
                    case 3:
                        os.DisplayByPrice();
                        break;
                    default:
                        break;
                }
            }
        }
        //输入一个正数
        public static int PositiveNumber()
        {
            int num=0;
            while (int.TryParse(Console.ReadLine(), out num) != true || num <= 0)
                Console.Write("请重新输入一个正数：");
            return num;
        }
        //输入非空字符串
        public static string StringNotNull()
        {
            string str =Console.ReadLine();
            while(str=="")
            {
                Console.Write("请重新输入一个非空字符串：");
                str = Console.ReadLine();
            }
            return str;
        }
    }
}