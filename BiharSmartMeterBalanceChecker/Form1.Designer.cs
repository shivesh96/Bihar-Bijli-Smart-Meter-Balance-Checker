
namespace BiharSmartMeterBalanceChecker
{
    partial class Form1
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
            this.lbl_consumer_id = new System.Windows.Forms.Label();
            this.txt_consumer_id = new System.Windows.Forms.TextBox();
            this.btn_fetch = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_consumer_id
            // 
            this.lbl_consumer_id.AutoSize = true;
            this.lbl_consumer_id.Location = new System.Drawing.Point(23, 27);
            this.lbl_consumer_id.Name = "lbl_consumer_id";
            this.lbl_consumer_id.Size = new System.Drawing.Size(68, 13);
            this.lbl_consumer_id.TabIndex = 0;
            this.lbl_consumer_id.Text = "Consumer ID";
            // 
            // txt_consumer_id
            // 
            this.txt_consumer_id.Location = new System.Drawing.Point(97, 24);
            this.txt_consumer_id.Name = "txt_consumer_id";
            this.txt_consumer_id.Size = new System.Drawing.Size(209, 20);
            this.txt_consumer_id.TabIndex = 1;
            this.txt_consumer_id.Text = "101337295";
            // 
            // btn_fetch
            // 
            this.btn_fetch.Location = new System.Drawing.Point(312, 22);
            this.btn_fetch.Name = "btn_fetch";
            this.btn_fetch.Size = new System.Drawing.Size(75, 23);
            this.btn_fetch.TabIndex = 2;
            this.btn_fetch.Text = "&Fetch";
            this.btn_fetch.UseVisualStyleBackColor = true;
            this.btn_fetch.Click += new System.EventHandler(this.btn_fetch_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(26, 206);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(361, 20);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Url = new System.Uri("https://sbpdcl.co.in/frmAdvBillPaymentAll.aspx", System.UriKind.Absolute);
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_date,
            this.col_balance});
            this.dataGridView1.Location = new System.Drawing.Point(26, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(361, 170);
            this.dataGridView1.TabIndex = 6;
            // 
            // col_date
            // 
            this.col_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_date.HeaderText = "Date";
            this.col_date.Name = "col_date";
            this.col_date.ReadOnly = true;
            // 
            // col_balance
            // 
            this.col_balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_balance.HeaderText = "Balance";
            this.col_balance.Name = "col_balance";
            this.col_balance.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 238);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_fetch);
            this.Controls.Add(this.txt_consumer_id);
            this.Controls.Add(this.lbl_consumer_id);
            this.Name = "Form1";
            this.Text = "Bihar Smart Meter Balance Checker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_consumer_id;
        private System.Windows.Forms.TextBox txt_consumer_id;
        private System.Windows.Forms.Button btn_fetch;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_balance;
    }
}

