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
    public partial class BillingApp : Form
    {
        public BillingApp()
        {
            InitializeComponent();
        }
        //Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True
        void DataViewTable(int table_id)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            string query = "select b.item_name as Name, a.qty as Quantity, a.price as Price, a.total as Total from sell_temp a, item_register b where a.item_id=b.item_id and a.table_id="+table_id;
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                adapter.SelectCommand = cmd;
                DataTable dataset = new DataTable();
                adapter.Fill(dataset);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataset;
                switch(table_id){
                    case 1:
                        dataGridView1.ReadOnly = true;
                        dataGridView1.DataSource = bindingSource;
                        break;
                    case 2:
                        dataGridView2.ReadOnly = true;
                        dataGridView2.DataSource = bindingSource;
                        break;
                    case 3:
                        dataGridView3.ReadOnly = true;
                        dataGridView3.DataSource = bindingSource;
                        break;
                    case 4:
                        dataGridView4.ReadOnly = true;
                        dataGridView4.DataSource = bindingSource;
                        break;
                    case 5:
                        dataGridView5.ReadOnly = true;
                        dataGridView5.DataSource = bindingSource;
                        break;
                    case 6:
                        dataGridView6.ReadOnly = true;
                        dataGridView6.DataSource = bindingSource;
                        break;
                    case 7:
                        dataGridView7.ReadOnly = true;
                        dataGridView7.DataSource = bindingSource;
                        break;
                    case 8:
                        dataGridView8.ReadOnly = true;
                        dataGridView8.DataSource = bindingSource;
                        break;
                    case 9:
                        dataGridView9.ReadOnly = true;
                        dataGridView9.DataSource = bindingSource;
                        break;
                    case 10:
                        dataGridView10.ReadOnly = true;
                        dataGridView10.DataSource = bindingSource;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        double getItemPrice(int item_id)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            
            string query = "select item_price from item_register where item_id=" +item_id;
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader;
            double price=0;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if(reader.Read())
                    price = Convert.ToDouble(reader.GetValue(0).ToString());
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return price;
        }
        int getItemId(string item_name)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            string query = "select item_id from item_register where item_name='"+item_name+"'";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader;
            int id = 0;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    id = Convert.ToInt32(reader.GetValue(0).ToString());
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }
        double getPerTableBill(int table_no)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            string query = "select sum(total) from sell_temp where table_id=" + table_no;
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader;
            double price = 0;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    price = Convert.ToDouble(reader.GetValue(0).ToString());
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return price;
        }
        void addItem(int table_id,int item_id, int qty, double item_price, double total)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query = "INSERT INTO sell_temp(table_id,item_id,qty,price,total) VALUES ("+table_id+","+item_id+","+qty+","+item_price+","+total+")";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("1 Item Add..", "Insert");
                con.Close();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Item Already Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void updateItem(int table_id, int item_id, int qty, double total)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query = "update sell_temp set qty = " + qty + ", total = " + total +" where item_id = " + item_id + " and table_id = "+table_id;
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                adapter.UpdateCommand = cmd;
                adapter.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("1 Item updated..", "Update");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void deleteItem(int item_id)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query = "delete from sell_temp where item_id = '" + item_id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                adapter.DeleteCommand = cmd;
                adapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("1 Item deleted..", "Delete");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void addDataToMainTable(int table_no)
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DateTime todaysDate = DateTime.Today;
            string query1 = "INSERT INTO SELL_TABLE select '" + todaysDate + "', item_id, qty,total,table_id from SELL_TEMP where table_id = " + table_no;
            string query2 = "delete from sell_temp where table_id = " + table_no;
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            try
            {
                con.Open();
                adapter.InsertCommand = cmd1;
                adapter.InsertCommand.ExecuteNonQuery();
                adapter.DeleteCommand = cmd2;
                adapter.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("1 Item Add..", "Insert");
                con.Close();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Item Already Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void add1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || qty1.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty1.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);
                
                addItem(1,item_id,qty,item_price,total);
            }
            qty1.Value = 0;
            DataViewTable(1);           
        }
        private void add2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || qty3.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty3.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(2, item_id, qty, item_price, total);
            }
            qty3.Value = 0;
            DataViewTable(2);
        }
        private void add3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || qty5.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox3.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty5.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(3, item_id, qty, item_price, total);
            }
            qty5.Value = 0;
            DataViewTable(3);
        }
        private void add4_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "" || qty7.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox4.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty7.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(4, item_id, qty, item_price, total);
            }
            qty7.Value = 0;
            DataViewTable(4);
        }
        private void add5_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "" || qty9.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox5.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty9.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(5, item_id, qty, item_price, total);
            }
            qty9.Value = 0;
            DataViewTable(5);
        }
        private void add6_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "" || qty11.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox6.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty11.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(6, item_id, qty, item_price, total);
            }
            qty11.Value = 0;
            DataViewTable(6);
        }
        private void add7_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "" || qty13.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox7.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty13.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(7, item_id, qty, item_price, total);
            }
            qty13.Value = 0;
            DataViewTable(7);
        }
        private void add8_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text == "" || qty15.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox8.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty15.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(8, item_id, qty, item_price, total);
            }
            qty15.Value = 0;
            DataViewTable(8);
        }
        private void add9_Click(object sender, EventArgs e)
        {
            if (comboBox9.Text == "" || qty17.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox9.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty17.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(9, item_id, qty, item_price, total);
            }
            qty17.Value = 0;
            DataViewTable(9);
        }
        private void add10_Click(object sender, EventArgs e)
        {
            if (comboBox10.Text == "" || qty19.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                int item_id = Convert.ToInt32(comboBox10.SelectedValue.ToString());
                int qty = Convert.ToInt32(qty19.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty+" price "+item_price+ " total "+total);

                addItem(10, item_id, qty, item_price, total);
            }
            qty19.Value = 0;
            DataViewTable(10);
        }

        private void update1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || qty2.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox1.Text.ToString();
                int item_id=getItemId(item_name);
                int qty = Convert.ToInt32(qty2.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(1, item_id, qty, total);
            }
            textBox1.Text = "";
            qty2.Value = 0;
            groupBox2.Enabled = false;
            DataViewTable(1);
        }
        private void update2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || qty4.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox2.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty4.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(2, item_id, qty, total);
            }
            textBox2.Text = "";
            qty4.Value = 0;
            groupBox3.Enabled = false;
            DataViewTable(2);
        }
        private void update3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || qty6.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox3.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty6.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(3, item_id, qty, total);
            }
            textBox3.Text = "";
            qty6.Value = 0;
            groupBox5.Enabled = false;
            DataViewTable(3);
        }
        private void update4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || qty8.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox4.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty8.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(4, item_id, qty, total);
            }
            textBox4.Text = "";
            qty8.Value = 0;
            groupBox7.Enabled = false;
            DataViewTable(4);
        }
        private void update5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || qty10.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox5.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty10.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(5, item_id, qty, total);
            }
            textBox5.Text = "";
            qty10.Value = 0;
            groupBox9.Enabled = false;
            DataViewTable(5);
        }
        private void update6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || qty12.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox6.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty12.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(6, item_id, qty, total);
            }
            textBox6.Text = "";
            qty12.Value = 0;
            groupBox11.Enabled = false;
            DataViewTable(6);
        }
        private void update7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || qty14.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox7.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty14.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(7, item_id, qty, total);
            }
            textBox7.Text = "";
            qty14.Value = 0;
            groupBox13.Enabled = false;
            DataViewTable(7);
        }
        private void update8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || qty16.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox8.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty16.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(8, item_id, qty, total);
            }
            textBox8.Text = "";
            qty16.Value = 0;
            groupBox15.Enabled = false;
            DataViewTable(8);
        }
        private void update9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || qty18.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox9.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty18.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(9, item_id, qty, total);
            }
            textBox9.Text = "";
            qty18.Value = 0;
            groupBox17.Enabled = false;
            DataViewTable(9);
        }
        private void update10_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || qty20.Value == 0)
            {
                MessageBox.Show("You must give Quantity.", "Error in Item Add");
            }
            else
            {
                string item_name = textBox10.Text.ToString();
                int item_id = getItemId(item_name);
                int qty = Convert.ToInt32(qty20.Value);
                double item_price = getItemPrice(item_id);
                double total = item_price * qty;
                //MessageBox.Show("selected item " + item_id + " quantity " + qty + " price " + item_price + " total " + total);

                updateItem(10, item_id, qty, total);
            }
            textBox10.Text = "";
            qty20.Value = 0;
            groupBox19.Enabled = false;
            DataViewTable(10);
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            string item_name = textBox1.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox1.Text = "";
            qty2.Value = 0;
            groupBox2.Enabled = false;
            DataViewTable(1);
        }
        private void delete2_Click(object sender, EventArgs e)
        {
            string item_name = textBox2.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox2.Text = "";
            qty4.Value = 0;
            groupBox3.Enabled = false;
            DataViewTable(2);
        }
        private void delete3_Click(object sender, EventArgs e)
        {
            string item_name = textBox3.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox3.Text = "";
            qty6.Value = 0;
            groupBox5.Enabled = false;
            DataViewTable(3);
        }
        private void delete4_Click(object sender, EventArgs e)
        {
            string item_name = textBox4.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox4.Text = "";
            qty8.Value = 0;
            groupBox7.Enabled = false;
            DataViewTable(4);
        }
        private void delete5_Click(object sender, EventArgs e)
        {
            string item_name = textBox5.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox5.Text = "";
            qty10.Value = 0;
            groupBox9.Enabled = false;
            DataViewTable(5);
        }
        private void delete6_Click(object sender, EventArgs e)
        {
            string item_name = textBox6.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox6.Text = "";
            qty12.Value = 0;
            groupBox11.Enabled = false;
            DataViewTable(6);
        }
        private void delete7_Click(object sender, EventArgs e)
        {
            string item_name = textBox7.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox7.Text = "";
            qty14.Value = 0;
            groupBox13.Enabled = false;
            DataViewTable(7);
        }
        private void delete8_Click(object sender, EventArgs e)
        {
            string item_name = textBox8.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox8.Text = "";
            qty16.Value = 0;
            groupBox15.Enabled = false;
            DataViewTable(8);
        }
        private void delete9_Click(object sender, EventArgs e)
        {
            string item_name = textBox9.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox9.Text = "";
            qty18.Value = 0;
            groupBox17.Enabled = false;
            DataViewTable(9);
        }
        private void delete10_Click(object sender, EventArgs e)
        {
            string item_name = textBox10.Text.ToString();
            int item_id = getItemId(item_name);

            deleteItem(item_id);

            textBox10.Text = "";
            qty20.Value = 0;
            groupBox19.Enabled = false;
            DataViewTable(10);
        }

        private void calculate1_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(1);
            total1.Text= total.ToString();
        }
        private void calculate2_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(2);
            total2.Text = total.ToString();
        }
        private void calculate3_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(3);
            total3.Text = total.ToString();
        }
        private void calculate4_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(4);
            total4.Text = total.ToString();
        }
        private void calculate5_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(5);
            total5.Text = total.ToString();
        }
        private void calculate6_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(6);
            total6.Text = total.ToString();
        }
        private void calculate7_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(7);
            total7.Text = total.ToString();
        }
        private void calculate8_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(8);
            total8.Text = total.ToString();
        }
        private void calculate9_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(9);
            total9.Text = total.ToString();
        }
        private void calculate10_Click(object sender, EventArgs e)
        {
            double total = getPerTableBill(10);
            total10.Text = total.ToString();
        }

        private void refresh1_Click(object sender, EventArgs e)
        {
            DataViewTable(1);
        }
        private void refresh2_Click(object sender, EventArgs e)
        {
            DataViewTable(2);
        }
        private void refresh3_Click(object sender, EventArgs e)
        {
            DataViewTable(3);
        }
        private void refresh4_Click(object sender, EventArgs e)
        {
            DataViewTable(4);
        }
        private void refresh5_Click(object sender, EventArgs e)
        {
            DataViewTable(5);
        }
        private void refresh6_Click(object sender, EventArgs e)
        {
            DataViewTable(6);
        }
        private void refresh7_Click(object sender, EventArgs e)
        {
            DataViewTable(7);
        }
        private void refresh8_Click(object sender, EventArgs e)
        {
            DataViewTable(8);
        }
        private void refresh9_Click(object sender, EventArgs e)
        {
            DataViewTable(9);
        }
        private void refresh10_Click(object sender, EventArgs e)
        {
            DataViewTable(10);
        }

        private void print1_Click(object sender, EventArgs e)
        {

        }
        private void print2_Click(object sender, EventArgs e)
        {

        }
        private void print3_Click(object sender, EventArgs e)
        {

        }
        private void print4_Click(object sender, EventArgs e)
        {

        }
        private void print5_Click(object sender, EventArgs e)
        {

        }
        private void print6_Click(object sender, EventArgs e)
        {

        }
        private void print7_Click(object sender, EventArgs e)
        {

        }
        private void print8_Click(object sender, EventArgs e)
        {

        }
        private void print9_Click(object sender, EventArgs e)
        {

        }
        private void print10_Click(object sender, EventArgs e)
        {

        }

        private void new1_Click(object sender, EventArgs e)
        {
            addDataToMainTable(1);
            DataViewTable(1);
            total1.Text = "0";
        }
        private void new2_Click(object sender, EventArgs e)
        {
            addDataToMainTable(2);
            DataViewTable(2);
            total2.Text = "0";
        }
        private void new3_Click(object sender, EventArgs e)
        {
            addDataToMainTable(3);
            DataViewTable(3);
            total3.Text = "0";
        }
        private void new4_Click(object sender, EventArgs e)
        {
            addDataToMainTable(4);
            DataViewTable(4);
            total4.Text = "0";
        }
        private void new5_Click(object sender, EventArgs e)
        {
            addDataToMainTable(5);
            DataViewTable(5);
            total5.Text = "0";
        }
        private void new6_Click(object sender, EventArgs e)
        {
            addDataToMainTable(6);
            DataViewTable(6);
            total6.Text = "0";
        }
        private void new7_Click(object sender, EventArgs e)
        {
            addDataToMainTable(7);
            DataViewTable(7);
            total7.Text = "0";
        }
        private void new8_Click(object sender, EventArgs e)
        {
            addDataToMainTable(8);
            DataViewTable(8);
            total8.Text = "0";
        }
        private void new9_Click(object sender, EventArgs e)
        {
            addDataToMainTable(9);
            DataViewTable(9);
            total9.Text = "0";
        }
        private void new10_Click(object sender, EventArgs e)
        {
            addDataToMainTable(10);
            DataViewTable(10);
            total10.Text = "0";
        }

        private void RowHeaderClick1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    textBox1.Text = row.Cells["Name"].Value.ToString();
                    qty2.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox2.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick2(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                    textBox2.Text = row.Cells["Name"].Value.ToString();
                    qty4.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox3.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick3(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];

                    textBox3.Text = row.Cells["Name"].Value.ToString();
                    qty6.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox5.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick4(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];

                    textBox4.Text = row.Cells["Name"].Value.ToString();
                    qty8.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox7.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick5(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];

                    textBox5.Text = row.Cells["Name"].Value.ToString();
                    qty10.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox9.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick6(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView6.Rows[e.RowIndex];

                    textBox6.Text = row.Cells["Name"].Value.ToString();
                    qty12.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox11.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick7(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];

                    textBox7.Text = row.Cells["Name"].Value.ToString();
                    qty14.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox13.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick8(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView8.Rows[e.RowIndex];

                    textBox8.Text = row.Cells["Name"].Value.ToString();
                    qty16.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox15.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick9(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView9.Rows[e.RowIndex];

                    textBox9.Text = row.Cells["Name"].Value.ToString();
                    qty18.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox17.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RowHeaderClick10(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView10.Rows[e.RowIndex];

                    textBox10.Text = row.Cells["Name"].Value.ToString();
                    qty20.Value = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    groupBox19.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BillingApp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'billing_appDataSet.ITEM_REGISTER' table. You can move, or remove it, as needed.
            this.iTEM_REGISTERTableAdapter.Fill(this.billing_appDataSet.ITEM_REGISTER);

        }

        private void editItem_Click(object sender, EventArgs e)
        {
            ManageItems manageItems = new ManageItems();
            manageItems.ShowDialog();
        }

        private void history_Click(object sender, EventArgs e)
        {
            SellHistory history = new SellHistory();
            history.ShowDialog();
        }
    }
}
