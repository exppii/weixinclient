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

namespace WeixinClient
{
    public partial class LoginForm : Form
    {
        public LoginForm(string dbPath)
        {
            InitializeComponent();
            InitLocalDB(dbPath);
            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            read_verify_info_from_db();

            if (ACCOUNT.Equals(textBox1.Text) && _pwd.Equals(textBox2.Text)) {
                
                Form main_form = new Form1();
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


                string x = Encrypt.Encode("888888", KEY);
                string y = Encrypt.Decode(x, KEY);
                SQLiteCommand insertAdmin = new SQLiteCommand(sql, dbConn);
                insertAdmin.ExecuteNonQuery();

                dbConn.Close();
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        void read_verify_info_from_db()
        {
            string sql = @"select pwd from user where isadmin = 1 and account = 'admin' limit 1";

            try
            {
                dbConn.Open();
                SQLiteCommand comm = new SQLiteCommand(sql, dbConn);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {               
                        _pwd = read.GetValue(read.GetOrdinal("pwd")).ToString();                   
                    } 

                    if(string.IsNullOrEmpty(_pwd))
                    {                    
                        _pwd = "888888";
                    }
                }
                dbConn.Close();
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Form change_form = new change(this);

            this.Visible = false;

            change_form.StartPosition = FormStartPosition.CenterScreen;
            change_form.ShowDialog();
            
        }

        public string get_pwd()
        {
            return _pwd;
        }

        public bool saveNewAdmin(string pwd)
        {

            string sql = string.Format( @"insert or replace into user 
            (id, account , pwd , comment, isadmin ) values 
            (select id from user where isadmin = 1, admin,'{1}','administor', 1)", pwd);
            dbConn.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            int count = command.ExecuteNonQuery();
            dbConn.Close();
            return count == 1;
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length > 0 && textBox1.Text.Trim().Length > 0)
            {
                this.button1.Enabled = true;
            }
        }
    }
}
