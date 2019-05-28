using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManageWF
{
    public class OrderDetails
    {
        public OrderDetails() { }
        public OrderDetails(Goods g, int n)
        {
            this.Goods = g;
            this.Number = n;
        }

        public Goods Goods { get; set; }
        public int Number { get; set; }
        public float UPrice { get =>Goods!=null? Goods.Price:0; }                    //单价，一定要判断Goods初始是否为空
        public string GName { get => Goods != null ? Goods.Name : ""; }              //货物名

        public float Price { get => Goods != null ? Goods.Price * Number : 0; }      //某商品总价格

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetails;
            return detail != null &&
                   EqualityComparer<Goods>.Default.Equals(Goods, detail.Goods);
        }

        public override int GetHashCode()
        {
            return 785010553 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
        }
        public override string ToString()
        {
            return $"orderDetail:{Goods},{Number}";
        }
    }
}
