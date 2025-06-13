namespace ManakaIntiface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            multiScreenshot_button = new Button();
            toyColor_label = new Label();
            toyColorFinal_label = new Label();
            connectIntiface = new Button();
            intifaceStatusFinal_label = new Label();
            label2 = new Label();
            sextoy_label = new Label();
            sexToyFunctionBindingSource = new BindingSource(components);
            dg_sextoys = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnDisconnect = new Button();
            label1 = new Label();
            dg_PistonToy = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            pistonToyFunctionBindingSource = new BindingSource(components);
            btn_Link = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sexToyFunctionBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg_sextoys).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg_PistonToy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pistonToyFunctionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(38, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 43);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // multiScreenshot_button
            // 
            multiScreenshot_button.Location = new Point(643, 139);
            multiScreenshot_button.Name = "multiScreenshot_button";
            multiScreenshot_button.Size = new Size(75, 23);
            multiScreenshot_button.TabIndex = 2;
            multiScreenshot_button.Text = "Start";
            multiScreenshot_button.UseVisualStyleBackColor = true;
            multiScreenshot_button.Click += multiScreenshot_button_Click;
            // 
            // toyColor_label
            // 
            toyColor_label.AutoSize = true;
            toyColor_label.Location = new Point(587, 298);
            toyColor_label.Name = "toyColor_label";
            toyColor_label.Size = new Size(55, 15);
            toyColor_label.TabIndex = 3;
            toyColor_label.Text = "Toy color";
            // 
            // toyColorFinal_label
            // 
            toyColorFinal_label.AutoSize = true;
            toyColorFinal_label.Location = new Point(648, 298);
            toyColorFinal_label.Name = "toyColorFinal_label";
            toyColorFinal_label.Size = new Size(0, 15);
            toyColorFinal_label.TabIndex = 4;
            // 
            // connectIntiface
            // 
            connectIntiface.Location = new Point(643, 45);
            connectIntiface.Name = "connectIntiface";
            connectIntiface.Size = new Size(75, 27);
            connectIntiface.TabIndex = 5;
            connectIntiface.Text = "Connect";
            connectIntiface.UseVisualStyleBackColor = true;
            connectIntiface.Click += connectIntiface_Click;
            // 
            // intifaceStatusFinal_label
            // 
            intifaceStatusFinal_label.AutoSize = true;
            intifaceStatusFinal_label.Location = new Point(648, 355);
            intifaceStatusFinal_label.Name = "intifaceStatusFinal_label";
            intifaceStatusFinal_label.Size = new Size(45, 15);
            intifaceStatusFinal_label.TabIndex = 7;
            intifaceStatusFinal_label.Text = "Default";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(561, 355);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 6;
            label2.Text = "Intiface Status";
            // 
            // sextoy_label
            // 
            sextoy_label.AutoSize = true;
            sextoy_label.Location = new Point(38, 111);
            sextoy_label.Name = "sextoy_label";
            sextoy_label.Size = new Size(46, 15);
            sextoy_label.TabIndex = 9;
            sextoy_label.Text = "Sex Toy";
            // 
            // sexToyFunctionBindingSource
            // 
            sexToyFunctionBindingSource.DataSource = typeof(Model.SexToyFunction);
            // 
            // dg_sextoys
            // 
            dg_sextoys.AllowUserToAddRows = false;
            dg_sextoys.AllowUserToDeleteRows = false;
            dg_sextoys.AutoGenerateColumns = false;
            dg_sextoys.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_sextoys.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn });
            dg_sextoys.DataSource = sexToyFunctionBindingSource;
            dg_sextoys.Location = new Point(38, 155);
            dg_sextoys.Name = "dg_sextoys";
            dg_sextoys.ReadOnly = true;
            dg_sextoys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_sextoys.Size = new Size(345, 112);
            dg_sextoys.TabIndex = 10;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn.HeaderText = "name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            typeDataGridViewTextBoxColumn.HeaderText = "type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(643, 187);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 27);
            btnDisconnect.TabIndex = 11;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 280);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 12;
            label1.Text = "Piston toy";
            // 
            // dg_PistonToy
            // 
            dg_PistonToy.AllowUserToAddRows = false;
            dg_PistonToy.AllowUserToDeleteRows = false;
            dg_PistonToy.AutoGenerateColumns = false;
            dg_PistonToy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_PistonToy.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dg_PistonToy.DataSource = pistonToyFunctionBindingSource;
            dg_PistonToy.Location = new Point(38, 309);
            dg_PistonToy.Name = "dg_PistonToy";
            dg_PistonToy.ReadOnly = true;
            dg_PistonToy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_PistonToy.Size = new Size(345, 112);
            dg_PistonToy.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "id";
            dataGridViewTextBoxColumn1.HeaderText = "id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "name";
            dataGridViewTextBoxColumn2.HeaderText = "name";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "type";
            dataGridViewTextBoxColumn3.HeaderText = "type";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // pistonToyFunctionBindingSource
            // 
            pistonToyFunctionBindingSource.DataSource = typeof(Model.SexToyFunction);
            // 
            // btn_Link
            // 
            btn_Link.Location = new Point(643, 91);
            btn_Link.Name = "btn_Link";
            btn_Link.Size = new Size(75, 27);
            btn_Link.TabIndex = 14;
            btn_Link.Text = "Link";
            btn_Link.UseVisualStyleBackColor = true;
            btn_Link.Click += btn_Link_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Link);
            Controls.Add(dg_PistonToy);
            Controls.Add(label1);
            Controls.Add(btnDisconnect);
            Controls.Add(dg_sextoys);
            Controls.Add(sextoy_label);
            Controls.Add(intifaceStatusFinal_label);
            Controls.Add(label2);
            Controls.Add(connectIntiface);
            Controls.Add(toyColorFinal_label);
            Controls.Add(toyColor_label);
            Controls.Add(multiScreenshot_button);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "ManakaIntiface";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sexToyFunctionBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg_sextoys).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg_PistonToy).EndInit();
            ((System.ComponentModel.ISupportInitialize)pistonToyFunctionBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button multiScreenshot_button;
        private Label toyColor_label;
        private Label toyColorFinal_label;
        private Button connectIntiface;
        private Label intifaceStatusFinal_label;
        private Label label2;
        private Label sextoy_label;
        private BindingSource sexToyFunctionBindingSource;
        private DataGridView dg_sextoys;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private Button btnDisconnect;
        private Label label1;
        private DataGridView dg_PistonToy;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button btn_Link;
        private BindingSource pistonToyFunctionBindingSource;
    }
}
