using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManageWF
{
    public class Goods
    {
        private float price;
        public Goods() { }
        public Goods(int id,string name, float price)    //名字，单价
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   Name == goods.Name;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
        public override string ToString()
        {
            return Name;    //DataGridView2中Goods列显示此内容
        }
    }
}
