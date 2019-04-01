using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Goods
    {
        public Goods()
        {
        }
        public Goods(string name, float unitPrice, int num)
        {
            this.Name = name;
            this.Price = unitPrice;
            this.Number = num;
        }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Number { get; set; }
        public  override string  ToString()
        {
             return Name+"\t"+Price+"\t"+Number+"\t"+Price*Number+"\t"; 
        }
    }
}