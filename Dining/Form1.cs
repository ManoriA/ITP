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
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using Dining;

namespace insert
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQJ1O4EQ\MANORI;Initial Catalog=waiter;Integrated Security=True");
        private int i;
        private decimal sum;

        public object Parameters { get; private set; }

        private void InitializeComponent()
        {
            this.itemId = new System.Windows.Forms.Label();
            this.item = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.dgvTempryBill = new System.Windows.Forms.DataGridView();
            this.save = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.operation = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.insertGroupbox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.lblprice = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.Label();
            this.ddfoodname = new System.Windows.Forms.ComboBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtItemQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fQuan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_tot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempryBill)).BeginInit();
            this.operation.SuspendLayout();
            this.insertGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemId
            // 
            this.itemId.AutoSize = true;
            this.itemId.BackColor = System.Drawing.SystemColors.HotTrack;
            this.itemId.Location = new System.Drawing.Point(17, 121);
            this.itemId.Name = "itemId";
            this.itemId.Size = new System.Drawing.Size(63, 16);
            this.itemId.TabIndex = 7;
            this.itemId.Text = "ITEM ID";
            // 
            // item
            // 
            this.item.AutoSize = true;
            this.item.BackColor = System.Drawing.SystemColors.HotTrack;
            this.item.Location = new System.Drawing.Point(17, 169);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(91, 16);
            this.item.TabIndex = 8;
            this.item.Text = "ITEM NAME";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(126, 121);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(167, 22);
            this.txtItemId.TabIndex = 13;
            this.txtItemId.TextChanged += new System.EventHandler(this.txtItemId_TextChanged);
            this.txtItemId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemId_KeyPress);
            // 
            // dgvTempryBill
            // 
            this.dgvTempryBill.AllowUserToAddRows = false;
            this.dgvTempryBill.AllowUserToDeleteRows = false;
            this.dgvTempryBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTempryBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTempryBill.Location = new System.Drawing.Point(670, 94);
            this.dgvTempryBill.Name = "dgvTempryBill";
            this.dgvTempryBill.ReadOnly = true;
            this.dgvTempryBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTempryBill.Size = new System.Drawing.Size(573, 359);
            this.dgvTempryBill.TabIndex = 15;
            this.dgvTempryBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTempryBill_CellContentClick);
            this.dgvTempryBill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvTempryBill_MouseClick);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.save.Location = new System.Drawing.Point(79, 354);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(137, 40);
            this.save.TabIndex = 16;
            this.save.Text = "SAVE";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdate.Location = new System.Drawing.Point(152, 23);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPrint.Location = new System.Drawing.Point(274, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 23);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.view_Click);
            // 
            // operation
            // 
            this.operation.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.operation.Controls.Add(this.btnClear);
            this.operation.Controls.Add(this.btnPrint);
            this.operation.Controls.Add(this.btnUpdate);
            this.operation.Controls.Add(this.btnRefresh);
            this.operation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operation.Location = new System.Drawing.Point(719, 578);
            this.operation.Name = "operation";
            this.operation.Size = new System.Drawing.Size(524, 57);
            this.operation.TabIndex = 19;
            this.operation.TabStop = false;
            this.operation.Text = "OPERATION";
            this.operation.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(374, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(92, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "DELETE";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.delete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(47, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(76, 23);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // insertGroupbox
            // 
            this.insertGroupbox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.insertGroupbox.BackgroundImage = global::Dining.Properties.Resources.basque_cake;
            this.insertGroupbox.Controls.Add(this.label3);
            this.insertGroupbox.Controls.Add(this.lblDate);
            this.insertGroupbox.Controls.Add(this.txtDate);
            this.insertGroupbox.Controls.Add(this.txtprice);
            this.insertGroupbox.Controls.Add(this.save);
            this.insertGroupbox.Controls.Add(this.lblprice);
            this.insertGroupbox.Controls.Add(this.lblUnit);
            this.insertGroupbox.Controls.Add(this.label1);
            this.insertGroupbox.Controls.Add(this.txtID);
            this.insertGroupbox.Controls.Add(this.ddfoodname);
            this.insertGroupbox.Controls.Add(this.txtUnitPrice);
            this.insertGroupbox.Controls.Add(this.txtItemQty);
            this.insertGroupbox.Controls.Add(this.label2);
            this.insertGroupbox.Controls.Add(this.fQuan);
            this.insertGroupbox.Controls.Add(this.itemId);
            this.insertGroupbox.Controls.Add(this.txtItemId);
            this.insertGroupbox.Controls.Add(this.item);
            this.insertGroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertGroupbox.Location = new System.Drawing.Point(72, 143);
            this.insertGroupbox.Name = "insertGroupbox";
            this.insertGroupbox.Size = new System.Drawing.Size(329, 408);
            this.insertGroupbox.TabIndex = 20;
            this.insertGroupbox.TabStop = false;
            this.insertGroupbox.Enter += new System.EventHandler(this.insert_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(63, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "THE REGENT COUNTRY CLUB";
            this.label3.Click += new System.EventHandler(this.label3_Click_3);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblDate.Location = new System.Drawing.Point(17, 73);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 16);
            this.lblDate.TabIndex = 34;
            this.lblDate.Text = "BIll Date";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(126, 73);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(167, 22);
            this.txtDate.TabIndex = 33;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(126, 303);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(167, 22);
            this.txtprice.TabIndex = 32;
            this.txtprice.TextChanged += new System.EventHandler(this.txtprice_TextChanged);
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblprice.Location = new System.Drawing.Point(17, 306);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(44, 16);
            this.lblprice.TabIndex = 31;
            this.lblprice.Text = "Price";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblUnit.Location = new System.Drawing.Point(17, 212);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(93, 16);
            this.lblUnit.TabIndex = 21;
            this.lblUnit.Text = "UNIT PRICE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 30;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.Location = new System.Drawing.Point(123, 24);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(0, 16);
            this.txtID.TabIndex = 29;
            this.txtID.Visible = false;
            // 
            // ddfoodname
            // 
            this.ddfoodname.FormattingEnabled = true;
            this.ddfoodname.Location = new System.Drawing.Point(126, 166);
            this.ddfoodname.Name = "ddfoodname";
            this.ddfoodname.Size = new System.Drawing.Size(167, 24);
            this.ddfoodname.TabIndex = 28;
            this.ddfoodname.SelectedIndexChanged += new System.EventHandler(this.txtfoodname_SelectedIndexChanged);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(126, 212);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(167, 22);
            this.txtUnitPrice.TabIndex = 27;
            this.txtUnitPrice.TextChanged += new System.EventHandler(this.txtUnitPrice_TextChanged);
            this.txtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitPrice_KeyPress);
            // 
            // txtItemQty
            // 
            this.txtItemQty.Location = new System.Drawing.Point(126, 260);
            this.txtItemQty.Name = "txtItemQty";
            this.txtItemQty.Size = new System.Drawing.Size(167, 22);
            this.txtItemQty.TabIndex = 26;
            this.txtItemQty.TextChanged += new System.EventHandler(this.txtItemQty_TextChanged);
            this.txtItemQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemQty_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 24;
            // 
            // fQuan
            // 
            this.fQuan.AutoSize = true;
            this.fQuan.BackColor = System.Drawing.SystemColors.HotTrack;
            this.fQuan.Location = new System.Drawing.Point(17, 260);
            this.fQuan.Name = "fQuan";
            this.fQuan.Size = new System.Drawing.Size(85, 16);
            this.fQuan.TabIndex = 23;
            this.fQuan.Text = "QUANTITY";
            this.fQuan.Click += new System.EventHandler(this.fQun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(25, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(464, 47);
            this.label4.TabIndex = 21;
            this.label4.Text = "REGENT COUNTRY CLUB";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btn_tot
            // 
            this.btn_tot.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tot.Location = new System.Drawing.Point(1031, 477);
            this.btn_tot.Name = "btn_tot";
            this.btn_tot.Size = new System.Drawing.Size(129, 36);
            this.btn_tot.TabIndex = 22;
            this.btn_tot.Text = "Total Price";
            this.btn_tot.UseVisualStyleBackColor = true;
            this.btn_tot.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form
            // 
            this.BackgroundImage = global::Dining.Properties.Resources.download;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btn_tot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.insertGroupbox);
            this.Controls.Add(this.operation);
            this.Controls.Add(this.dgvTempryBill);
            this.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempryBill)).EndInit();
            this.operation.ResumeLayout(false);
            this.insertGroupbox.ResumeLayout(false);
            this.insertGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fQun_Click(object sender, EventArgs e)
        {

        }

        private void dQun_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bvgNm_Click(object sender, EventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {

            fillcomb();
            //fQuan.Visible = false;
            txtDate.Visible = false;
            txtprice.Visible = false;
            lblDate.Visible = false;
            lblprice.Visible = false;
            label3.Visible = false;

        }

        private void save_Click(object sender, EventArgs e)

        {
            if ((String.IsNullOrEmpty(txtItemQty.Text)) || (String.IsNullOrEmpty(txtItemId.Text)) || (String.IsNullOrEmpty(txtUnitPrice.Text)) || (ddfoodname.SelectedIndex == -1))
            {
                MessageBox.Show("Please Fill in The Blanks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            }

            else {

                string dt;

                DateTime date = DateTime.Now;
                dt = date.ToString("yyyy-MM-dd");

                DialogResult d = MessageBox.Show("Are you sure you want to add this item...?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (d == DialogResult.Yes)
                {
                    DBConnect db = new DBConnect();
                    String q = "insert into tempbill(foodId,name,qty,unitPrice,price,billdate) values ('" + txtItemId.Text + "','" + ddfoodname.Text + "','" + txtItemQty.Text + "','" + txtUnitPrice.Text + "','" + Int32.Parse(txtItemQty.Text) * Int32.Parse(txtUnitPrice.Text) + "', '" + dt + "')";
                    MySqlCommand cmd = new MySqlCommand(q, db.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                    refresh();
                
                retrieve();

            }

        }

        private void retrieve() {
            dgvTempryBill.DataSource = loadData();
        }

        private DataTable loadData()
        {
            DBConnect db = new DBConnect();
            DataTable dt = new DataTable();
             
            String q = "select id as 'ID', foodId as 'Item ID',name as'Item Name',qty as 'Quantity',unitPrice as 'Unit Price',price as 'Price',billdate as 'Bill Date' from tempbill order by id DESC";
            MySqlCommand cmd = new MySqlCommand(q, db.con);
            MySqlDataReader r = cmd.ExecuteReader();
            dt.Load(r); 
            return dt;
        }


        private void values(string v)
        {
            throw new NotImplementedException();
        }

        private void foodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            retrieve();
            refresh();
            loadData();
        }

        private void dgvTempryBill_MouseClick(object sender, MouseEventArgs e)
        {
            save.Visible = false;
                    
           
            txtID.Text = dgvTempryBill.SelectedRows[0].Cells[0].Value.ToString();
            txtItemId.Text = dgvTempryBill.SelectedRows[0].Cells[1].Value.ToString();
            ddfoodname.Text = dgvTempryBill.SelectedRows[0].Cells[2].Value.ToString();
            txtItemQty.Text = dgvTempryBill.SelectedRows[0].Cells[3].Value.ToString();
            txtUnitPrice.Text = dgvTempryBill.SelectedRows[0].Cells[4].Value.ToString();
            txtprice.Text = dgvTempryBill.SelectedRows[0].Cells[5].Value.ToString();
            txtDate.Text = dgvTempryBill.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            if ((String.IsNullOrEmpty(txtItemQty.Text)) || (String.IsNullOrEmpty(txtItemId.Text)) || (String.IsNullOrEmpty(txtUnitPrice.Text)) || (ddfoodname.SelectedIndex == -1))
            {
                MessageBox.Show("Please select row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {

                string dt;

                DateTime date = DateTime.Now;
                dt = date.ToString("yyyy-MM-dd");


                DialogResult d = MessageBox.Show("Are you sure you want to update this item...?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);



                save.Visible = false;

                if (d == DialogResult.Yes)
                {
                    DBConnect db = new DBConnect();
                    String q = "update tempbill set foodid = '" + txtItemId.Text + "' , name = '" + ddfoodname.Text + "', qty = '" + txtItemQty.Text + "', unitPrice = '" + txtUnitPrice.Text + "',  price = '" + Int32.Parse(txtItemQty.Text) * Int32.Parse(txtUnitPrice.Text) + "' where id ='" + txtID.Text + "' ";
                    MySqlCommand cmd = new MySqlCommand(q, db.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    refresh();
                
                retrieve();
            }

        }
        private void view_Click(object sender, EventArgs e)
        {
        //    fill_billgridview();


        //    //PrintDocument pd = new PrintDocument();
        //    //pd.PrintPage += new PrintPageEventHandler(PrintImage);
        //    //pd.Print();      
        //    PrintDocument doc = new PrintDocument();
        //    doc.PrintPage += this.Doc_PrintPage;
        //    PrintDialog dlgSettings = new PrintDialog();
        //    dlgSettings.Document = doc;
        //    if (dlgSettings.ShowDialog() == DialogResult.OK)
        //    {
        //        doc.Print();
        //    }

          Bill b = new Bill();
            b.Show();






        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
             
            save.Visible = false;
            txtItemId.Visible = false;
            itemId.Visible = false;
            txtDate.Visible = true;
            txtprice.Visible = true;
            lblDate.Visible = true;
            lblprice.Visible = true;
            label3.Visible = true;
            


            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.insertGroupbox.Width, this.insertGroupbox.Height);
            this.insertGroupbox.DrawToBitmap(bmp, new Rectangle(0, 0, this.insertGroupbox.Width, this.insertGroupbox.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);


        }




        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to Delete this item...?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d == DialogResult.Yes)
            {
                DBConnect db = new DBConnect();
                string q = "DELETE FROM tempBill";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Deleted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();

            }
            retrieve();

        }
            public void refresh() {

            
            txtID.Text = "";
            txtItemId.Text = "";
            ddfoodname.Text = "";
            txtUnitPrice.Text = "";
            txtItemQty.Text = "";
            txtDate.Visible = false;
            txtprice.Visible = false;
            lblDate.Visible = false;
            lblprice.Visible = false;
            txtItemId.Visible = true;
            save.Visible = true;
            itemId.Visible = true;
            label3.Visible = false;
        }

        protected void insert_Enter(object sender, EventArgs e)
        {

        }

        private void txtfoodname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddfoodname.SelectedIndex == -1)//Nothing selected
            {
                MessageBox.Show("You must select a type", "Error");
            }
        }

        public void fillcomb()
        {

            List<String> foodItem = new List<string>();
            DBConnect db = new DBConnect();
            String q = "select name from newmenu";
            MySqlCommand cmd = new MySqlCommand(q, db.con);
            MySqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                foodItem.Add(r[0].ToString());
            }

            ddfoodname.DataSource = foodItem;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void dgvTempryBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewRow row in dgvTempryBill.Rows)
            //{
            //    row.Cells[dgvTempryBill.Columns["amount"].Index].Value = (Convert.ToDouble(row.Cells[dgvTempryBill.Columns["unitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dgvTempryBill.Columns["Qty"].Index].Value));
            //}
            int sum = 0;
            for (i = 0; i < dgvTempryBill.Rows.Count - 1; i++)
            {
                sum = sum + int.Parse(dgvTempryBill.Rows[i].Cells[6].ToString());

            }
            //txt_tot.Text = sum.ToString();


        }



        //Validation

        private void txtItemId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                DialogResult d = MessageBox.Show("Check Again, You Can Only Add Numbers.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }          
        }

        private void txtItemId_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "  ^ [0-9]"))
            //{
            //    textBox1.Text = "";
            //}

        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                DialogResult d = MessageBox.Show("Check Again, You Can Only Add Numbers.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "  ^ [0-9]"))
            //{
            //    textBox1.Text = "";
            //}

        }

        private void txtItemQty_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "  ^ [0-9]"))
            //{
            //    textBox1.Text = "";
            //}
        }

        private void txtItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                DialogResult d = MessageBox.Show("Check Again, You Can Only Add Numbers.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }


        //public void fill_billgridview()
        //{
        //    var select = "select billdate,name,unitPrice,qty,price from tempbill where userName = 'manori'";

        //    var dataAdapter = new SqlDataAdapter(select, con);
        //    var commandBuilder = new SqlCommandBuilder(dataAdapter);
        //    var ds = new DataSet();
        //    dataAdapter.Fill(ds);
        //    billgv.ReadOnly = true;
        //    billgv.DataSource = ds.Tables[0];
        //}

        private void logOut_Click(object sender, EventArgs e)
        {
      
        }

        private void lbl_uName_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_3(object sender, EventArgs e)
        {

        }

        //private void txt_tot_TextChanged(object sender, EventArgs e)
        //{
           

        //    //foreach (DataGridViewRow row in dgvTempryBill.Rows)
        //    //{
        //    //    row.Cells[dgvTempryBill.Columns["price"].Index].Value = (Convert.ToDouble(row.Cells[dgvTempryBill.Columns["unitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dgvTempryBill.Columns["Qty"].Index].Value));
        //    //}
        //    //int sum = 0;
        //    //for (i = 0; i < dgvTempryBill.Rows.Count; i++)
        //    //{
        //    //    sum += Convert.ToInt32(dgvTempryBill.Rows[i].Cells[6].Value);

        //    //}
        //    //txt_tot.Text = sum.ToString();

           
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            dgvTempryBill[5, dgvTempryBill.Rows.Count - 1].Value = "total";
            dgvTempryBill.Rows[dgvTempryBill.Rows.Count - 1].Cells[5].Style.BackColor = Color.Green;
            dgvTempryBill.Rows[dgvTempryBill.Rows.Count - 1].Cells[5].Style.ForeColor = Color.Red;

            decimal tot = 0;
            for(int i =0; i<dgvTempryBill.Rows.Count -1; i++)
            {
                var value = dgvTempryBill.Rows[i].Cells[5].Value;
                if(value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }
            if(tot == 0)
            {

            }
            dgvTempryBill.Rows[dgvTempryBill.Rows.Count - 1].Cells[5].Value = tot.ToString();
        }
    }
}



