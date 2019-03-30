using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
	class Order
	{
        //订单细节储存在DetailsList中
        private static List<OrderDetails> DetailsList = new List<OrderDetails>();
        
        private string cusName;
		private string goodsName;
		private	int orderId;

        public Order()
        {
        }
        public Order(int id,string cusname,string goodsname)
		{
			orderId=id;
			cusName=cusname;
			goodsName=goodsname;
		}
		public int Id
		{
			get
			{
				return orderId;
			}
			set
			{
				orderId=value;
			}
		}	 
		public string CName
		{
			get
			{
				return cusName;
			}
			set
			{
				cusName=value;
			}
		}
		public string GName
		{
			get
			{
				return goodsName;
			}
			set
			{
				goodsName=value;
			}
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
    }
}