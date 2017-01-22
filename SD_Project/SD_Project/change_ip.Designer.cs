namespace SD_Project
{
    partial class change_ip
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.change_bt = new System.Windows.Forms.Button();
            this.rewrite_pass = new System.Windows.Forms.TextBox();
            this.new_pass = new System.Windows.Forms.TextBox();
            this.new_ID = new System.Windows.Forms.TextBox();
            this.old_pass = new System.Windows.Forms.TextBox();
            this.oldID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ch_main_bt = new System.Windows.Forms.Button();
            this.ch_admin_bt = new System.Windows.Forms.Button();
            this.ch_exit_bt = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.change_bt);
            this.groupBox1.Controls.Add(this.rewrite_pass);
            this.groupBox1.Controls.Add(this.new_pass);
            this.groupBox1.Controls.Add(this.new_ID);
            this.groupBox1.Controls.Add(this.old_pass);
            this.groupBox1.Controls.Add(this.oldID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 510);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change ID and PASSWORD";
            // 
            // change_bt
            // 
            this.change_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_bt.ForeColor = System.Drawing.Color.Black;
            this.change_bt.Location = new System.Drawing.Point(139, 454);
            this.change_bt.Name = "change_bt";
            this.change_bt.Size = new System.Drawing.Size(138, 38);
            this.change_bt.TabIndex = 10;
            this.change_bt.Text = "Change";
            this.change_bt.UseVisualStyleBackColor = true;
            this.change_bt.Click += new System.EventHandler(this.change_bt_Click);
            // 
            // rewrite_pass
            // 
            this.rewrite_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rewrite_pass.Location = new System.Drawing.Point(10, 402);
            this.rewrite_pass.Name = "rewrite_pass";
            this.rewrite_pass.PasswordChar = '*';
            this.rewrite_pass.Size = new System.Drawing.Size(385, 29);
            this.rewrite_pass.TabIndex = 9;
            // 
            // new_pass
            // 
            this.new_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_pass.Location = new System.Drawing.Point(11, 325);
            this.new_pass.Name = "new_pass";
            this.new_pass.PasswordChar = '*';
            this.new_pass.Size = new System.Drawing.Size(385, 29);
            this.new_pass.TabIndex = 8;
            // 
            // new_ID
            // 
            this.new_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_ID.Location = new System.Drawing.Point(11, 257);
            this.new_ID.Name = "new_ID";
            this.new_ID.Size = new System.Drawing.Size(385, 29);
            this.new_ID.TabIndex = 7;
            // 
            // old_pass
            // 
            this.old_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.old_pass.Location = new System.Drawing.Point(10, 184);
            this.old_pass.Name = "old_pass";
            this.old_pass.PasswordChar = '*';
            this.old_pass.Size = new System.Drawing.Size(385, 29);
            this.old_pass.TabIndex = 6;
            // 
            // oldID
            // 
            this.oldID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldID.Location = new System.Drawing.Point(11, 106);
            this.oldID.Name = "oldID";
            this.oldID.Size = new System.Drawing.Size(385, 29);
            this.oldID.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "REWRITE PASSWORD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "NEW PASSWORD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "NEW ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Old PASSWORD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old ID";
            // 
            // ch_main_bt
            // 
            this.ch_main_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_main_bt.ForeColor = System.Drawing.Color.Black;
            this.ch_main_bt.Location = new System.Drawing.Point(12, 528);
            this.ch_main_bt.Name = "ch_main_bt";
            this.ch_main_bt.Size = new System.Drawing.Size(116, 33);
            this.ch_main_bt.TabIndex = 11;
            this.ch_main_bt.Text = "MAIN PAGE";
            this.ch_main_bt.UseVisualStyleBackColor = true;
            this.ch_main_bt.Click += new System.EventHandler(this.ch_main_bt_Click);
            // 
            // ch_admin_bt
            // 
            this.ch_admin_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_admin_bt.ForeColor = System.Drawing.Color.Black;
            this.ch_admin_bt.Location = new System.Drawing.Point(151, 528);
            this.ch_admin_bt.Name = "ch_admin_bt";
            this.ch_admin_bt.Size = new System.Drawing.Size(138, 33);
            this.ch_admin_bt.TabIndex = 12;
            this.ch_admin_bt.Text = "ADMIN PAGE";
            this.ch_admin_bt.UseVisualStyleBackColor = true;
            this.ch_admin_bt.Click += new System.EventHandler(this.ch_admin_bt_Click);
            // 
            // ch_exit_bt
            // 
            this.ch_exit_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_exit_bt.ForeColor = System.Drawing.Color.Black;
            this.ch_exit_bt.Location = new System.Drawing.Point(328, 528);
            this.ch_exit_bt.Name = "ch_exit_bt";
            this.ch_exit_bt.Size = new System.Drawing.Size(97, 33);
            this.ch_exit_bt.TabIndex = 13;
            this.ch_exit_bt.Text = "EXIT";
            this.ch_exit_bt.UseVisualStyleBackColor = true;
            this.ch_exit_bt.Click += new System.EventHandler(this.ch_exit_bt_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Blue;
            this.radioButton1.Location = new System.Drawing.Point(11, 34);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 20);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ADMIN";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.Blue;
            this.radioButton2.Location = new System.Drawing.Point(212, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(107, 20);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "SALESMAN";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // change_ip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 582);
            this.Controls.Add(this.ch_exit_bt);
            this.Controls.Add(this.ch_admin_bt);
            this.Controls.Add(this.ch_main_bt);
            this.Controls.Add(this.groupBox1);
            this.Name = "change_ip";
            this.Text = "change_ip";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button change_bt;
        private System.Windows.Forms.TextBox rewrite_pass;
        private System.Windows.Forms.TextBox new_pass;
        private System.Windows.Forms.TextBox new_ID;
        private System.Windows.Forms.TextBox old_pass;
        private System.Windows.Forms.TextBox oldID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ch_main_bt;
        private System.Windows.Forms.Button ch_admin_bt;
        private System.Windows.Forms.Button ch_exit_bt;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}