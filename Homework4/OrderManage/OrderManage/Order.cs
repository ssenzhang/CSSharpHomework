using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
	class Order
	{
       private List<OrderDetails> details = new List<OrderDetails>();
		//订单号，客户名，货物名，数量
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
        public List<OrderDetails> Details
        {
            get
            {
                return details;
            }
            set
            {
                details = value;
            }
        }
		public void AddDetails(OrderDetails details)
        {
            Details.Add(details);
        }
	}
}