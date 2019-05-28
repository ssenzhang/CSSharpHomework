using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManageWF
{
    public class Order : IComparable<Order>
    {
        private List<OrderDetails> details = new List<OrderDetails>();       //储存某个订单的details
        public Order() { }

        public Order(int id, string name)
        {
            Id = id;
            CName = name;
        }
        public int Id { get; set; }
        public string CName { get; set; }
        public float TPrice { get => details.Sum(d => d.Price); }         //某个订单总价格
        
   
        public List<OrderDetails> Details
        {
            get => this.details;
        }
        public void AddDetails(OrderDetails orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetail of the goods ({orderDetail.Goods.Name}) exists in order {Id}");
            }
            details.Add(orderDetail);
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return Id - other.Id;
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   Id == order.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public void RemoveDetails(int num)
        {
            details.RemoveAt(num);
        }

        public override string ToString()
        {
            String result = $"orderId:{Id}, customer:({CName})";
            details.ForEach(detail => result += "\n\t" + detail);
            return result;
        }
    }
}
