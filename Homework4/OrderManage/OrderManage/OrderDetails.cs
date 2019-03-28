using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
	class OrderDetails
	{
	    //订单号，客户名，货物
	    private	int orderId;
		private string cusName;
		private Goods orGoods;
		

		public OrderDetails(int id,string name,Goods goods)
		{
			orderId=id;
			cusName=name;
			orGoods=goods;
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
                cusName = value;
			}
		}
		public Goods Goods
		{
			get
			{
				return orGoods;
			}
			set 
			{
				orGoods=value;
			}
		}
	}
}		