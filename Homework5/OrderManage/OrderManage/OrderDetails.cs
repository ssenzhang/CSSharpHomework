using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderDetails
    {


        public OrderDetails()
        {

        }
        public OrderDetails(int id, string name, Goods goods)
        {
            this.Id = id;
            this.CName = name;
            this.Goods = goods;
        }
        public int Id { get; set; }
        public string CName { get; set; }
        public Goods Goods { get; set; }
        public override string ToString()
        {
            return Goods.ToString()+"\t";
        }
    }
}		