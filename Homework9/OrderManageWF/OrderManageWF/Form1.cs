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
    public partial class Form1 : Form
    {
        OrderService os = new OrderService();
        public String Keyword { get; set; }  //文本框Keyword
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {

            Goods g1 = new Goods(1, "apple", 4);
            Goods g2 = new Goods(2, "orange", 6);
            Goods g3 = new Goods(3, "peach", 4.5f);

            Customer c1 = new Customer(1, "Sam");
            Customer c2 = new Customer(2, "Alen");
            Customer c3 = new Customer(3, "Betty");

            OrderDetails ods1 = new OrderDetails(g1, 5);
            OrderDetails ods2 = new OrderDetails(g2, 4);
            OrderDetails ods3 = new OrderDetails(g3, 6);

            Order o1 = new Order(1, c1);
            Order o2 = new Order(2, c2);
            Order o3 = new Order(3, c3);

            o1.AddDetails(ods1);
            o1.AddDetails(ods2);
            o2.AddDetails(ods1);
            o2.AddDetails(ods2);
            o2.AddDetails(ods3);
            o3.AddDetails(ods2);
            o3.AddDetails(ods3);

            os.AddOrder(o1);
            os.AddOrder(o2);
            os.AddOrder(o3);
            orderBindingSource.DataSource = os.QueryAll();    //Order: Id, Customer, TPrice

            textBox1.DataBindings.Add("Text", this, "Keyword");
        }

        private void QueryAll()
        {
            OrderService os = new OrderService();
            orderBindingSource.DataSource = os.QueryAll();
            orderBindingSource.ResetBindings(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)    //添加订单
        {
            Form2 f = new Form2(new Order());
            f.ShowDialog();
            if (f.Result != null)
            {
                os.AddOrder(f.Result);
                QueryAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)          //查询
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    orderBindingSource.DataSource = os.QueryAll();
                    break;
                case 1:
                    int.TryParse(Keyword, out int id);
                    orderBindingSource.DataSource = os.QueryById(id);
                    break;
                case 2:
                    orderBindingSource.DataSource = os.QueryByCName(Keyword);
                    break;
                case 3:
                    orderBindingSource.DataSource = os.QueryByGName(Keyword);
                    break;
                case 4:
                    float.TryParse(Keyword, out float amout);
                    orderBindingSource.DataSource = os.QueryByTPrice(amout);
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2((Order)orderBindingSource.Current);
            f.ShowDialog();
            QueryAll();
        }

        private void button4_Click(object sender, EventArgs e)      //删除订单
        {
            Order o = (Order)orderBindingSource.Current;
            if (o != null)
            {
                os.RemoveOrder(o.Id);
                QueryAll();
            }
        }
    }
}
