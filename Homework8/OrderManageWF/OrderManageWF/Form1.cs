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
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {

            Goods g1 = new Goods("apple", 4);
            Goods g2 = new Goods("orange", 6);
            Goods g3 = new Goods("peach", 4.5f);

            OrderDetails ods1 = new OrderDetails(g1, 5);
            OrderDetails ods2 = new OrderDetails(g2, 4);
            OrderDetails ods3 = new OrderDetails(g3, 6);

            Order o1 = new Order(1, "Sam");
            Order o2 = new Order(2, "Alen");
            Order o3 = new Order(3, "Betty");

            o1.AddDetails(ods1);
            o1.AddDetails(ods2);
            o2.AddDetails(ods1);
            o2.AddDetails(ods2);
            o2.AddDetails(ods3);
            o3.AddDetails(ods2);
            o3.AddDetails(ods3);

            OrderService os = new OrderService();
            os.AddOrder(o1);
            os.AddOrder(o2);
            os.AddOrder(o3);
            orderBindingSource.DataSource = os.QueryAll();    //Order: Id, Customer, TPrice

          //  txtValue.DataBindings.Add("Text", this, "Keyword");
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
                OrderService os = new OrderService();
                os.AddOrder(f.Result);
                QueryAll();
            }
        }
    }
}
