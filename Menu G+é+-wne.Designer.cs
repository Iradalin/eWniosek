namespace eWniosek
{
    partial class Menu_Główne
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
            this.buttonWłaściwości = new System.Windows.Forms.Button();
            this.buttonKartaKM = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWłaściwości
            // 
            this.buttonWłaściwości.Location = new System.Drawing.Point(3, 97);
            this.buttonWłaściwości.Name = "buttonWłaściwości";
            this.buttonWłaściwości.Size = new System.Drawing.Size(194, 41);
            this.buttonWłaściwości.TabIndex = 0;
            this.buttonWłaściwości.Text = "Właściwości";
            this.buttonWłaściwości.UseVisualStyleBackColor = true;
            this.buttonWłaściwości.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonKartaKM
            // 
            this.buttonKartaKM.Location = new System.Drawing.Point(3, 3);
            this.buttonKartaKM.Name = "buttonKartaKM";
            this.buttonKartaKM.Size = new System.Drawing.Size(194, 41);
            this.buttonKartaKM.TabIndex = 1;
            this.buttonKartaKM.Text = "Karta KM";
            this.buttonKartaKM.UseVisualStyleBackColor = true;
            this.buttonKartaKM.Click += new System.EventHandler(this.buttonKartaKM_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(3, 50);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(194, 41);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "TEST";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonKartaKM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonWłaściwości, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonTest, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 452);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Menu_Główne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Menu_Główne";
            this.Text = "Menu Główne";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWłaściwości;
        private System.Windows.Forms.Button buttonKartaKM;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}