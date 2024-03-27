namespace SieuThiMiniXmart
{
    partial class Giaodienquanly
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.taikhoanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginnhanvienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xmartDataSet = new SieuThiMiniXmart.xmartDataSet();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.taikhoanDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginquanlyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xmartDataSet1 = new SieuThiMiniXmart.xmartDataSet1();
            this.cbmonth = new System.Windows.Forms.ComboBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbnam = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.loginnhanvienTableAdapter = new SieuThiMiniXmart.xmartDataSetTableAdapters.loginnhanvienTableAdapter();
            this.loginquanlyTableAdapter = new SieuThiMiniXmart.xmartDataSet1TableAdapters.loginquanlyTableAdapter();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.xmartDataSet18 = new SieuThiMiniXmart.xmartDataSet18();
            this.loginnhanvienBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.loginnhanvienTableAdapter1 = new SieuThiMiniXmart.xmartDataSet18TableAdapters.loginnhanvienTableAdapter();
            this.xmartDataSet19 = new SieuThiMiniXmart.xmartDataSet19();
            this.loginquanlyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.loginquanlyTableAdapter1 = new SieuThiMiniXmart.xmartDataSet19TableAdapters.loginquanlyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginnhanvienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginquanlyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginnhanvienBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginquanlyBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taikhoanDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.loginnhanvienBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(68, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(336, 252);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // taikhoanDataGridViewTextBoxColumn
            // 
            this.taikhoanDataGridViewTextBoxColumn.DataPropertyName = "taikhoan";
            this.taikhoanDataGridViewTextBoxColumn.HeaderText = "Tài khoản nhân viên";
            this.taikhoanDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.taikhoanDataGridViewTextBoxColumn.Name = "taikhoanDataGridViewTextBoxColumn";
            // 
            // loginnhanvienBindingSource
            // 
            this.loginnhanvienBindingSource.DataMember = "loginnhanvien";
            this.loginnhanvienBindingSource.DataSource = this.xmartDataSet;
            // 
            // xmartDataSet
            // 
            this.xmartDataSet.DataSetName = "xmartDataSet";
            this.xmartDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taikhoanDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.loginquanlyBindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(645, 30);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(336, 252);
            this.dataGridView2.TabIndex = 11;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            this.dataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView2_DataBindingComplete);
            // 
            // taikhoanDataGridViewTextBoxColumn1
            // 
            this.taikhoanDataGridViewTextBoxColumn1.DataPropertyName = "taikhoan";
            this.taikhoanDataGridViewTextBoxColumn1.HeaderText = "Tài khoản quản lý";
            this.taikhoanDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.taikhoanDataGridViewTextBoxColumn1.Name = "taikhoanDataGridViewTextBoxColumn1";
            // 
            // loginquanlyBindingSource
            // 
            this.loginquanlyBindingSource.DataMember = "loginquanly";
            this.loginquanlyBindingSource.DataSource = this.xmartDataSet1;
            // 
            // xmartDataSet1
            // 
            this.xmartDataSet1.DataSetName = "xmartDataSet1";
            this.xmartDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbmonth
            // 
            this.cbmonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbmonth.FormattingEnabled = true;
            this.cbmonth.Location = new System.Drawing.Point(377, 354);
            this.cbmonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbmonth.Name = "cbmonth";
            this.cbmonth.Size = new System.Drawing.Size(105, 24);
            this.cbmonth.TabIndex = 19;
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(147)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(68, 396);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(913, 348);
            this.dataGridView3.TabIndex = 14;
            this.dataGridView3.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView3_CellFormatting);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(641, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Count:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(704, 297);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 21);
            this.label11.TabIndex = 16;
            this.label11.Text = "1";
            // 
            // cbnam
            // 
            this.cbnam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbnam.FormattingEnabled = true;
            this.cbnam.Location = new System.Drawing.Point(488, 354);
            this.cbnam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbnam.Name = "cbnam";
            this.cbnam.Size = new System.Drawing.Size(105, 24);
            this.cbnam.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(128, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 21);
            this.label10.TabIndex = 15;
            this.label10.Text = "1";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(65, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "Count:";
            // 
            // loginnhanvienTableAdapter
            // 
            this.loginnhanvienTableAdapter.ClearBeforeFill = true;
            // 
            // loginquanlyTableAdapter
            // 
            this.loginquanlyTableAdapter.ClearBeforeFill = true;
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(147)))), ((int)(((byte)(43)))));
            this.button10.Cursor = System.Windows.Forms.Cursors.Default;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Image = global::SieuThiMiniXmart.Properties.Resources.xoa_25;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(426, 113);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(194, 36);
            this.button10.TabIndex = 23;
            this.button10.Text = "Xóa tài khoản";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(147)))), ((int)(((byte)(43)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Default;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Image = global::SieuThiMiniXmart.Properties.Resources.sua_25;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(426, 71);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(194, 36);
            this.button9.TabIndex = 22;
            this.button9.Text = "Sửa tài khoản";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(147)))), ((int)(((byte)(43)))));
            this.button8.Cursor = System.Windows.Forms.Cursors.Default;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Image = global::SieuThiMiniXmart.Properties.Resources.them_25;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(426, 30);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(194, 36);
            this.button8.TabIndex = 21;
            this.button8.Text = "Thêm tài khoản";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(147)))), ((int)(((byte)(43)))));
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.Transparent;
            this.button11.Image = global::SieuThiMiniXmart.Properties.Resources.find__1_;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.Location = new System.Drawing.Point(599, 346);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(200, 36);
            this.button11.TabIndex = 18;
            this.button11.Text = "Check chấm công";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // xmartDataSet18
            // 
            this.xmartDataSet18.DataSetName = "xmartDataSet18";
            this.xmartDataSet18.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loginnhanvienBindingSource1
            // 
            this.loginnhanvienBindingSource1.DataMember = "loginnhanvien";
            this.loginnhanvienBindingSource1.DataSource = this.xmartDataSet18;
            // 
            // loginnhanvienTableAdapter1
            // 
            this.loginnhanvienTableAdapter1.ClearBeforeFill = true;
            // 
            // xmartDataSet19
            // 
            this.xmartDataSet19.DataSetName = "xmartDataSet19";
            this.xmartDataSet19.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loginquanlyBindingSource1
            // 
            this.loginquanlyBindingSource1.DataMember = "loginquanly";
            this.loginquanlyBindingSource1.DataSource = this.xmartDataSet19;
            // 
            // loginquanlyTableAdapter1
            // 
            this.loginquanlyTableAdapter1.ClearBeforeFill = true;
            // 
            // Giaodienquanly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1051, 756);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbnam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.cbmonth);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Giaodienquanly";
            this.Text = "Giaodienquanly";
            this.Load += new System.EventHandler(this.Giaodienquanly_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginnhanvienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginquanlyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginnhanvienBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmartDataSet19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginquanlyBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cbmonth;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbnam;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private xmartDataSet xmartDataSet;
        private System.Windows.Forms.BindingSource loginnhanvienBindingSource;
        private xmartDataSetTableAdapters.loginnhanvienTableAdapter loginnhanvienTableAdapter;
        private xmartDataSet1 xmartDataSet1;
        private System.Windows.Forms.BindingSource loginquanlyBindingSource;
        private xmartDataSet1TableAdapters.loginquanlyTableAdapter loginquanlyTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn taikhoanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taikhoanDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private xmartDataSet18 xmartDataSet18;
        private System.Windows.Forms.BindingSource loginnhanvienBindingSource1;
        private xmartDataSet18TableAdapters.loginnhanvienTableAdapter loginnhanvienTableAdapter1;
        private xmartDataSet19 xmartDataSet19;
        private System.Windows.Forms.BindingSource loginquanlyBindingSource1;
        private xmartDataSet19TableAdapters.loginquanlyTableAdapter loginquanlyTableAdapter1;
    }
}