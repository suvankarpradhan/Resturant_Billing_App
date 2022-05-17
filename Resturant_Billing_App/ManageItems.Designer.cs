
namespace Resturant_Billing_App
{
    partial class ManageItems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.item_id = new System.Windows.Forms.TextBox();
            this.item_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.item_price = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.addItem = new System.Windows.Forms.Button();
            this.deleteItem = new System.Windows.Forms.Button();
            this.clearItem = new System.Windows.Forms.Button();
            this.updateItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(52, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // item_id
            // 
            this.item_id.Enabled = false;
            this.item_id.Location = new System.Drawing.Point(106, 92);
            this.item_id.Name = "item_id";
            this.item_id.Size = new System.Drawing.Size(263, 22);
            this.item_id.TabIndex = 1;
            // 
            // item_name
            // 
            this.item_name.Enabled = false;
            this.item_name.Location = new System.Drawing.Point(106, 135);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(263, 22);
            this.item_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(52, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // item_price
            // 
            this.item_price.Enabled = false;
            this.item_price.Location = new System.Drawing.Point(106, 178);
            this.item_price.Name = "item_price";
            this.item_price.Size = new System.Drawing.Size(263, 22);
            this.item_price.TabIndex = 5;
            this.item_price.TextChanged += new System.EventHandler(this.item_price_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(52, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Price";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(405, 92);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(292, 195);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(50, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Modify Your Items";
            // 
            // addItem
            // 
            this.addItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.addItem.Enabled = false;
            this.addItem.ForeColor = System.Drawing.Color.Linen;
            this.addItem.Location = new System.Drawing.Point(132, 257);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(75, 30);
            this.addItem.TabIndex = 8;
            this.addItem.Text = "Save";
            this.addItem.UseVisualStyleBackColor = false;
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // deleteItem
            // 
            this.deleteItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteItem.Enabled = false;
            this.deleteItem.ForeColor = System.Drawing.Color.Linen;
            this.deleteItem.Location = new System.Drawing.Point(294, 257);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(75, 30);
            this.deleteItem.TabIndex = 9;
            this.deleteItem.Text = "Delete";
            this.deleteItem.UseVisualStyleBackColor = false;
            this.deleteItem.Click += new System.EventHandler(this.deleteItem_Click);
            // 
            // clearItem
            // 
            this.clearItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clearItem.ForeColor = System.Drawing.Color.White;
            this.clearItem.Location = new System.Drawing.Point(51, 257);
            this.clearItem.Name = "clearItem";
            this.clearItem.Size = new System.Drawing.Size(75, 30);
            this.clearItem.TabIndex = 10;
            this.clearItem.Text = "New";
            this.clearItem.UseVisualStyleBackColor = false;
            this.clearItem.Click += new System.EventHandler(this.clearItem_Click);
            // 
            // updateItem
            // 
            this.updateItem.BackColor = System.Drawing.Color.Navy;
            this.updateItem.Enabled = false;
            this.updateItem.ForeColor = System.Drawing.Color.Linen;
            this.updateItem.Location = new System.Drawing.Point(213, 257);
            this.updateItem.Name = "updateItem";
            this.updateItem.Size = new System.Drawing.Size(75, 30);
            this.updateItem.TabIndex = 11;
            this.updateItem.Text = "Update";
            this.updateItem.UseVisualStyleBackColor = false;
            this.updateItem.Click += new System.EventHandler(this.updateItem_Click);
            // 
            // ManageItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(764, 359);
            this.Controls.Add(this.updateItem);
            this.Controls.Add(this.clearItem);
            this.Controls.Add(this.deleteItem);
            this.Controls.Add(this.addItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.item_price);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.item_id);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "ManageItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Items";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox item_id;
        private System.Windows.Forms.TextBox item_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox item_price;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.Button deleteItem;
        private System.Windows.Forms.Button clearItem;
        private System.Windows.Forms.Button updateItem;
    }
}