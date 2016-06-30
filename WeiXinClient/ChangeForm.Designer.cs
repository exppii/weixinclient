namespace WeiXinClient
{
    partial class ChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeForm));
            this.newPwdTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.oldPwdtextBox = new System.Windows.Forms.TextBox();
            this.ChangePwd = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newPwdTextBox
            // 
            this.newPwdTextBox.Location = new System.Drawing.Point(144, 121);
            this.newPwdTextBox.Name = "newPwdTextBox";
            this.newPwdTextBox.PasswordChar = '*';
            this.newPwdTextBox.Size = new System.Drawing.Size(122, 21);
            this.newPwdTextBox.TabIndex = 3;
            this.newPwdTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(144, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "admin";
            // 
            // oldPwdtextBox
            // 
            this.oldPwdtextBox.Location = new System.Drawing.Point(144, 22);
            this.oldPwdtextBox.Name = "oldPwdtextBox";
            this.oldPwdtextBox.PasswordChar = '*';
            this.oldPwdtextBox.Size = new System.Drawing.Size(122, 21);
            this.oldPwdtextBox.TabIndex = 1;
            // 
            // ChangePwd
            // 
            this.ChangePwd.Enabled = false;
            this.ChangePwd.Location = new System.Drawing.Point(81, 170);
            this.ChangePwd.Name = "ChangePwd";
            this.ChangePwd.Size = new System.Drawing.Size(86, 23);
            this.ChangePwd.TabIndex = 4;
            this.ChangePwd.Text = "  修改密码";
            this.ChangePwd.UseVisualStyleBackColor = true;
            this.ChangePwd.Click += new System.EventHandler(this.chagnePwd_Click);
            // 
            // Return
            // 
            this.Return.Location = new System.Drawing.Point(180, 170);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(86, 23);
            this.Return.TabIndex = 5;
            this.Return.Text = " 返回";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "新密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "用户名: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = " 旧密码: ";
            // 
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 227);
            this.Controls.Add(this.newPwdTextBox);
            this.Controls.Add(this.oldPwdtextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ChangePwd);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeForm";
            this.Text = " 修改管理信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.change_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newPwdTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ChangePwd;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox oldPwdtextBox;
    }
}