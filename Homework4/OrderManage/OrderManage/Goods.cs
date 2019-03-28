using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Goods
    {
        private string goodsName;
        private float unitPrice;
        private int goodsNumber;

        public Goods(string name, float price, int num)
        {
            Name = name;
            unitPrice = price;
            goodsNumber = num;
        }
        public string Name
        {
            get
            {
                return goodsName;
            }
            set
            {
                goodsName = value;
            }
        }
        public float Price
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
            }
        }
        public int Number
        {
            get
            {
                return goodsNumber;
            }
            set
            {
                goodsNumber = value;
            }
        }
        public string Info
        {
            get
            {
                return "goodsName:" + Name + "unitPrice:" + unitPrice + "goodsNumber:" + Number;
            }
        }
    }
}