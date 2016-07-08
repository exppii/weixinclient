using System.Data.SQLite;

namespace WeiXinClient
{
    partial class HomeForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.insertButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.account_textBox = new System.Windows.Forms.TextBox();
            this.pwd_textBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.webpanel = new System.Windows.Forms.Panel();
            this.login = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.contralPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comment_textBox = new System.Windows.Forms.TextBox();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contralPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(23, 246);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 4;
            this.insertButton.Text = "新增";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码:";
            // 
            // account_textBox
            // 
            this.account_textBox.Location = new System.Drawing.Point(112, 48);
            this.account_textBox.Name = "account_textBox";
            this.account_textBox.Size = new System.Drawing.Size(125, 21);
            this.account_textBox.TabIndex = 1;
            // 
            // pwd_textBox
            // 
            this.pwd_textBox.Location = new System.Drawing.Point(112, 109);
            this.pwd_textBox.Name = "pwd_textBox";
            this.pwd_textBox.PasswordChar = '*';
            this.pwd_textBox.Size = new System.Drawing.Size(125, 21);
            this.pwd_textBox.TabIndex = 2;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(227, 246);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = " 删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.delete_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(125, 246);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 5;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.update_Click);
            // 
            // webpanel
            // 
            this.webpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webpanel.Location = new System.Drawing.Point(335, 12);
            this.webpanel.Name = "webpanel";
            this.webpanel.Size = new System.Drawing.Size(1093, 792);
            this.webpanel.TabIndex = 0;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(36, 344);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 0;
            this.login.Text = "登陆微信";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(191, 344);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 2;
            this.logout.Text = "登出微信";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // contralPanel
            // 
            this.contralPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.contralPanel.Controls.Add(this.groupBox2);
            this.contralPanel.Controls.Add(this.groupBox1);
            this.contralPanel.Location = new System.Drawing.Point(5, 1);
            this.contralPanel.Name = "contralPanel";
            this.contralPanel.Size = new System.Drawing.Size(329, 803);
            this.contralPanel.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.login);
            this.groupBox2.Controls.Add(this.logout);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 410);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作面板";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnAcc,
            this.ColumnPwd,
            this.ColumnCom,
            this.IndexColumn});
            this.dataGridView1.Location = new System.Drawing.Point(4, 20);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(308, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.insertButton);
            this.groupBox1.Controls.Add(this.account_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.comment_textBox);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.pwd_textBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 377);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 用户编辑区";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "备注:";
            // 
            // comment_textBox
            // 
            this.comment_textBox.Location = new System.Drawing.Point(112, 175);
            this.comment_textBox.Name = "comment_textBox";
            this.comment_textBox.Size = new System.Drawing.Size(125, 21);
            this.comment_textBox.TabIndex = 3;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnID.Width = 35;
            // 
            // ColumnAcc
            // 
            this.ColumnAcc.HeaderText = " 账号";
            this.ColumnAcc.Name = "ColumnAcc";
            this.ColumnAcc.ReadOnly = true;
            this.ColumnAcc.Width = 75;
            // 
            // ColumnPwd
            // 
            this.ColumnPwd.HeaderText = "密码";
            this.ColumnPwd.Name = "ColumnPwd";
            this.ColumnPwd.ReadOnly = true;
            this.ColumnPwd.Width = 60;
            // 
            // ColumnCom
            // 
            this.ColumnCom.HeaderText = "备注";
            this.ColumnCom.Name = "ColumnCom";
            this.ColumnCom.ReadOnly = true;
            // 
            // IndexColumn
            // 
            this.IndexColumn.HeaderText = "index";
            this.IndexColumn.Name = "IndexColumn";
            this.IndexColumn.ReadOnly = true;
            this.IndexColumn.Visible = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 816);
            this.Controls.Add(this.contralPanel);
            this.Controls.Add(this.webpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeForm";
            this.Text = "国防科技大学微信管理平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeForm_FormClosing);
            this.contralPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SQLiteConnection dbConn;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox account_textBox;
        private System.Windows.Forms.TextBox pwd_textBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Panel webpanel;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button logout;

        private const string KEY = "a528fbe0-0c45-4e7e-973b-02f13692d76d";
        private long selectID = 0;
        private int selectRowIndex = -1;
        private System.Windows.Forms.Panel contralPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox comment_textBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexColumn;
    }
}

