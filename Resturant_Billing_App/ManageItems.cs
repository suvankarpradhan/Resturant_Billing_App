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
    public partial class ManageItems : Form
    {
        public ManageItems()
        {
            InitializeComponent();
            refreshForm();
        }
        void refreshForm()
        {
            item_id.Text = "";
            item_name.Text = "";
            item_price.Text = "";

            item_name.Enabled = false;
            item_price.Enabled = false;
            DataViewTable();
        }
        void DataViewTable()
        {
            string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);

            string query = "select item_name as Name, item_price as Price, item_id as Id from item_register";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                adapter.SelectCommand = cmd;
                DataTable dataset = new DataTable();
                adapter.Fill(dataset);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataset;
                dataGridView.ReadOnly = true;
                dataGridView.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clearItem_Click(object sender, EventArgs e)
        {
            refreshForm();
            item_name.Enabled = true;
            item_price.Enabled = true;
            addItem.Enabled = true;
            updateItem.Enabled = false;
            deleteItem.Enabled = false;
        }

        private void item_price_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(item_price.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                item_price.Text = item_price.Text.Remove(item_price.Text.Length - 1);
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            
            if (item_name.Text == "" || item_price.Text == "")
            {
                MessageBox.Show("You must enter Item name and Item price");
            }
            else
            {
                string itemName = item_name.Text;
                double itemPrice = Convert.ToDouble(item_price.Text);
                string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                SqlDataAdapter adapter = new SqlDataAdapter();
                string query = "INSERT INTO item_register(item_name,item_price) VALUES ('" + itemName + "'," + itemPrice + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("1 Item Add..", "Insert");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                refreshForm();
            }           
        }

        private void updateItem_Click(object sender, EventArgs e)
        {            
            if (item_name.Text == "" || item_price.Text == "")
            {
                MessageBox.Show("You must enter Item name and Item price");
            }
            else
            {
                int itemId = Convert.ToInt32(item_id.Text);
                string itemName = item_name.Text;
                double itemPrice = Convert.ToDouble(item_price.Text);
                string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                SqlDataAdapter adapter = new SqlDataAdapter();
                string query = "update item_register set item_name = '" + itemName + "', item_price = " + itemPrice + " where item_id = " + itemId;
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
                refreshForm();
                updateItem.Enabled = false;
                deleteItem.Enabled = false;
            }
        }

        private void deleteItem_Click(object sender, EventArgs e)
        {
            
            if (item_id.Text == "")
            {
                MessageBox.Show("You must select a Item");
            }
            else
            {
                int itemId = Convert.ToInt32(item_id.Text);
                string constring = @"Data Source=SUVANKAR;Initial Catalog=billing_app;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);
                SqlDataAdapter adapter = new SqlDataAdapter();
                string query = "delete from item_register where item_id =" + itemId;
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
                refreshForm();
                updateItem.Enabled = false;
                deleteItem.Enabled = false;
            }
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];

                    item_id.Text = row.Cells["Id"].Value.ToString();
                    item_name.Text = row.Cells["Name"].Value.ToString();
                    item_price.Text = row.Cells["Price"].Value.ToString();
                    item_name.Enabled = true;
                    item_price.Enabled = true;
                    addItem.Enabled = false;
                    updateItem.Enabled = true;
                    deleteItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
