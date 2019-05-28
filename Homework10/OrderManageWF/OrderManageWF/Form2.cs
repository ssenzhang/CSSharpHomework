using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManageWF
{
    public partial class Form2 : Form
    {
        public Order Result { get => (Order)orderBindingSource.Current; }    //?
        public Form2()
        {
            InitializeComponent();

            goodsBindingSource.Add(new Goods("apple", 4));
            goodsBindingSource.Add(new Goods("orange", 6));
            goodsBindingSource.Add(new Goods("peach", 4.5f));
            goodsBindingSource.Add(new Goods("watermelon", 12));

        }
        public Form2(Order order) : this()
        {
            orderBindingSource.DataSource = order;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)       //添加商品
        {
            OrderDetails detail = new OrderDetails();
            ((Order)orderBindingSource.Current).AddDetails(detail);
            detailsBindingSource.MoveLast();
            comboBox2.SelectedItem = null;                           //商品ComboBox内容
            orderBindingSource.ResetBindings(false);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)       //数量TextBox栏
        {
            orderBindingSource.ResetBindings(false);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)    //ComboBox商品栏
        {
            ((OrderDetails)detailsBindingSource.Current).Goods= (Goods)comboBox2.SelectedItem;
            detailsBindingSource.ResetBindings(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Order)orderBindingSource.Current).CName = (string)comboBox1.SelectedItem;
            detailsBindingSource.ResetBindings(false);
        }
    }
}
