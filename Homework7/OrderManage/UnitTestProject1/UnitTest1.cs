using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManage;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OrderService os = new OrderService();
            Order o1 = new Order(1, "zss", "apple");
            Order o2 = new Order(2, "zs", "eggs");
            os.AddOrder(o1);

            Assert.AreEqual(OrderManage.OrderService.OrderList[OrderManage.OrderService.OrderList.Count-1], o1);
            //Assert.AreEqual(OrderManage.OrderService.OrderList.Count, 1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            OrderService os = new OrderService();
            Order o1 = new Order(1, "zss", "apple");
            Order o2 = new Order(2, "zs", "eggs");
            OrderManage.OrderService.OrderList.Add(o1);
            OrderManage.OrderService.OrderList.Add(o2);
            
            os.DeleteOrder(o1);
            Assert.AreEqual(OrderManage.OrderService.OrderList.Count, 1);
        }

    }
}
