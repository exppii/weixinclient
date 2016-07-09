using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace WeiXinClient
{
    public partial class LoginForm : Form
    {
        public LoginForm(string dbPath)
        {
            InitializeComponent();
            InitLocalDB(dbPath);
            this.localDBPath = dbPath;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
            if (this.verifyIdentify()) {
                this.Visible = false;
                Form main_form = new HomeForm(localDBPath);
                main_form.StartPosition = FormStartPosition.CenterScreen;
                main_form.ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("您输入的账号密码不匹配，请重新输入！！", "!!错误!!");
            }

        }

        private void InitLocalDB(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
            dbConn = new SQLiteConnection(string.Format("Data Source={0};Version=3;",dbPath));
       
            try
            {
                dbConn.Open();
                string sql = @"create table if not exists user 
            (id integer,
            account varchar(50),
            pwd varchar(256),
            comment text,
            isadmin boolean default 0,
            primary key('id'));";
                SQLiteCommand createTable = new SQLiteCommand(sql, dbConn);
                createTable.ExecuteNonQuery();

                sql = string.Format(@"insert into user (account, pwd, isadmin ) select 'admin', '{0}', 1 
            where not exists(select 1 from user where account = 'admin' and isadmin = 1)", Encrypt.Encode("888888",KEY));

                SQLiteCommand insertAdmin = new SQLiteCommand(sql, dbConn);
                insertAdmin.ExecuteNonQuery();

                dbConn.Close();
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool verifyIdentify()
        {
            if (this.accountTextBox.Text != ACCOUNT) return false;

            return verifyPasswd(pwdTextBox.Text);

        }
        
        public bool verifyPasswd(string input)
        {
            string sql = @"select pwd from user where isadmin = 1 and account = 'admin' limit 1";
            try
            {
                string pwd = "";
                dbConn.Open();
                SQLiteCommand comm = new SQLiteCommand(sql, dbConn);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {

                    while (read.Read())
                    {
                        pwd = read.GetValue(read.GetOrdinal("pwd")).ToString();
                    }

                    if (string.IsNullOrEmpty(pwd))
                    {
                        return false;
                    }
                }
                dbConn.Close();

                return input == Encrypt.Decode(pwd, KEY);
            }
            catch (System.Data.SQLite.SQLiteException)
            {
             
                return false;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form change_form = new ChangeForm(this);

            this.Visible = false;

            change_form.StartPosition = FormStartPosition.CenterScreen;
            change_form.ShowDialog();
            
        }


        public bool saveNewAdmin(string pwd)
        {

            string sql = string.Format( @"update user set
            pwd = '{0}' where isadmin = 1 and account = 'admin'", Encrypt.Encode(pwd, KEY));
            dbConn.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            int count = command.ExecuteNonQuery();
            dbConn.Close();
            return count == 1;
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (pwdTextBox.Text.Trim().Length > 0 && accountTextBox.Text.Trim().Length > 0)
            {
                this.button1.Enabled = true;
            }
        }
    }
}
