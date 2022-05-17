using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Resturant_Billing_App
{
    public partial class SellHistory : Form
    {
        public SellHistory()
        {
            InitializeComponent();
            DataViewTable();
        }
        void DataViewTable()
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            string query1 = @" select a.sell_date as Date, b.item_name as Name, sum(a.qty) as Quantity, sum(a.total) as total
                             from SELL_TABLE a, ITEM_REGISTER b where a.item_id = b.item_id group by a.sell_date,b.item_name";

            string query2 = @" select sell_date as Date,sum(total) as total from SELL_TABLE group by sell_date";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();

            try
            {
                adapter1.SelectCommand = cmd1;
                adapter2.SelectCommand = cmd2;

                DataTable dataset1 = new DataTable();
                DataTable dataset2 = new DataTable();

                adapter1.Fill(dataset1);
                adapter2.Fill(dataset2);

                BindingSource bindingSource1 = new BindingSource();
                BindingSource bindingSource2 = new BindingSource();

                bindingSource1.DataSource = dataset1;
                bindingSource2.DataSource = dataset2;

                dataGridView1.ReadOnly = true;
                dataGridView2.ReadOnly = true;

                dataGridView1.DataSource = bindingSource1;
                dataGridView2.DataSource = bindingSource2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
