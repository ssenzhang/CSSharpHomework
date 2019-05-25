using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
	public class Order:IComparable
	{
        //订单细节储存在DetailsList中
        private static List<OrderDetails> DetailsList = new List<OrderDetails>();

        public Order()
        {
        }
        public Order(int id,string cusName,string goodsName)
		{
			this.Id=id;
			this.CName=cusName;
			this.GName=goodsName;
		}
		public int Id { get; set; }	 
		public string CName { get; set; }
        public string GName { get; set; }

       
        public string ToStirng()
        {
            return Id + "\t" + CName + "\t";
        }

        //添加details
        public void AddDetails(OrderDetails dts)
        {
            DetailsList.Add(dts);
        }
        //根据订单号查询details
        public OrderDetails CheckOrderDtailsId(int id)
        {
            foreach (OrderDetails od in DetailsList)
            {
                if (od.Id == id)
                    return od;
            }
            return null;
        }
        //实现接口
        public int CompareTo(object obj)
        {
            return Id.CompareTo(obj);
        }
    }
}