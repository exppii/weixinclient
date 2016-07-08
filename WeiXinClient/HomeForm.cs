using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Data.SQLite;

using CefSharp;
using CefSharp.WinForms;

namespace WeiXinClient
{
    public partial class HomeForm : Form
    {
        public HomeForm(string dbPath)
        {
            InitializeComponent();
            InitDB(dbPath);
            InitTable();
            InitBrowser();
        }


        private void InitDB(string dbPath)
        {

            dbConn = new SQLiteConnection(string.Format("Data Source={0};Version=3;", dbPath));
            dbConn.Open();
        }

        private void InitTable()
        {
            reloadData();
            if(dataGridView1.Rows.Count > 1)
            {
                dataGridView1.Rows[0].Selected = true;
                saveSelectInfo(0);
            }
        }


        private void reloadData()
        {
            dataGridView1.Rows.Clear();
            try
            {
  
                SQLiteCommand comm = new SQLiteCommand("Select id, account, pwd,comment From user where isadmin = 0", dbConn);

                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    int count = 0;
                    while (read.Read())
                    {
                        var pwd = read.GetValue(read.GetOrdinal("pwd")).ToString();

                        dataGridView1.Rows.Add(new object[] {
                        ++count,
                        read.GetValue(read.GetOrdinal("account")),  // Or column name like this
                        Encrypt.Decode(pwd,KEY),
                        read.GetValue(read.GetOrdinal("comment")),
                        read.GetValue(read.GetOrdinal("id"))
                         });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ChromiumWebBrowser browser;
        private void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("https://mp.weixin.qq.com/");
            //this.webBrowser1.Controls.Add(browser);
            this.webpanel.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

        }
     

        private void login_Click(object sender, EventArgs e)
        {
            if(selectRowIndex == -1 || selectRowIndex == dataGridView1.Rows.Count -1)
            {
                var offset = new Point();
                offset.X = Cursor.Position.X - 20;
                offset.Y = Cursor.Position.Y - 80;
                showMessage("当前未选中有效用户！！！", "错误", offset);
                return;
            }
            var acc = dataGridView1.Rows[selectRowIndex].Cells[1].Value.ToString();
            var pwd = dataGridView1.Rows[selectRowIndex].Cells[2].Value.ToString();
            if (browser.Address == "https://mp.weixin.qq.com/" && acc.Length > 0 && pwd.Length > 0)
            {
                browser.ExecuteScriptAsync(string.Format("document.getElementById('account').value = '{0}'", acc));
                System.Threading.Thread.Sleep(100);
                browser.ExecuteScriptAsync(string.Format("document.getElementById('pwd').value = '{0}'", pwd));
                System.Threading.Thread.Sleep(50);
                browser.ExecuteScriptAsync("document.getElementById('loginBt').click()");
            }
            else
            {
                browser.ExecuteScriptAsync("alert('请退出当前登录帐号！！！'，'错误')");
            }


        }

        private void logout_Click(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync("document.getElementById('logout').click()");
            System.Threading.Thread.Sleep(200);
            browser.Load("https://mp.weixin.qq.com/");
            System.Threading.Thread.Sleep(100);
            if(selectRowIndex < dataGridView1.Rows.Count -2)
            {
                dataGridView1.Rows[++selectRowIndex].Selected = true;
                saveSelectInfo(selectRowIndex);
            }
        }

        private void showMessage(string message, string title, Point point)
        {
            Form notify = new WeiXinClient.MyNotifyForm(message, title, point);
            notify.Location = point;
            notify.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            var offset = new Point();
            offset.X = Cursor.Position.X - 150;
            offset.Y = Cursor.Position.Y - 180;
            if (selectRowIndex < 0 || selectRowIndex > dataGridView1.Rows.Count - 1)
            {
                showMessage("更改账号信息失败！\r\n请点击要更改的数据", "错误", offset);
                return;
            }


            if (!parametersIsValid(offset)) return;

            string sql = @"update user set account = @Account, pwd = @Passwd, comment = @Comment where id = @Id";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);


            try
            {
                command.Parameters.Add(new SQLiteParameter("@Account", account_textBox.Text));
                command.Parameters.Add(new SQLiteParameter("@Passwd", Encrypt.Encode(pwd_textBox.Text,KEY)));
                command.Parameters.Add(new SQLiteParameter("@Comment", comment_textBox.Text));
                command.Parameters.Add(new SQLiteParameter("@Id", selectID));

                var count = command.ExecuteNonQuery();

               
               
                if (count == 1)
                {
                    showMessage("更新账号信息成功！！！","成功", offset);

                    reloadData();

                    dataGridView1.Rows[0].Selected = false;
                    
                    dataGridView1.Rows[selectRowIndex].Selected = true;
                    saveSelectInfo(selectRowIndex);

                } else
                { 
                    showMessage("更新账号信息失败！！！", "错误", offset);
                }
            } catch(Exception ex)
            {
                showMessage(ex.ToString(), "错误", offset);
            }
            

        }

        private void delete_Click(object sender, EventArgs e)
        {
            var offset = new Point();
            offset.X = Cursor.Position.X - 150;
            offset.Y = Cursor.Position.Y - 180;
            if (selectRowIndex < 0 || selectRowIndex > dataGridView1.Rows.Count -1 )
            {
                showMessage("删除账号信息失败！\r\n请点击要删除的数据", "错误", offset);
                return;
            }

            string sql = @"delete  from user where id = @Id";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            
            try {
                command.Parameters.Add(new SQLiteParameter("@Id", selectID));
                var count = command.ExecuteNonQuery();

                if (count == 1)
                {
                    showMessage("删除账号信息成功！！！", "成功", offset);
                    reloadData();
                    dataGridView1.Rows[0].Selected = false;
                    if (dataGridView1.Rows.Count > 1)
                    {
                        dataGridView1.Rows[0].Selected = true;
                        saveSelectInfo(0);
                    }
                    
                }
                else
                {
                    showMessage("删除账号信息失败！！！", "错误", offset);
                }
            }
            catch (Exception ex)
            {
                    showMessage(ex.ToString(), "错误", offset);
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {

            var offset = new Point();
            offset.X = Cursor.Position.X - 150;
            offset.Y = Cursor.Position.Y - 180;

            if (!parametersIsValid(offset)) return;

            try { 

                string sql = @"insert into user (account, pwd, comment) values (@Account, @Passwd, @Comment)";
                SQLiteCommand command = new SQLiteCommand(sql, dbConn);

                command.Parameters.Add(new SQLiteParameter("@Account", account_textBox.Text));
                command.Parameters.Add(new SQLiteParameter("@Passwd", Encrypt.Encode(pwd_textBox.Text, KEY)));
                command.Parameters.Add(new SQLiteParameter("@Comment", comment_textBox.Text));
            

                var count = command.ExecuteNonQuery();

                if (count == 1)
                {
                    showMessage("新增账号信息成功！！！", "成功", offset);
                    reloadData();

                    dataGridView1.Rows[0].Selected = false;

                    if (selectRowIndex == -1)
                    {
                        selectRowIndex = 0;
                    } 
                    dataGridView1.Rows[selectRowIndex].Selected = true;
                    saveSelectInfo(selectRowIndex);

                }
                else
                {
                    showMessage("新增账号信息失败！！！", "错误", offset);
                }
                


            }
            catch (Exception ex)
            {
                showMessage(ex.ToString(), "错误", offset);
            }
        }

        private bool parametersIsValid(Point offset)
        {

            if(account_textBox.Text.Length < 1)
            {
                showMessage("账号名为空", "错误", offset);
                return false;
            } else if(pwd_textBox.Text.Length < 6)
            {
                showMessage("密码长度错误", "错误", offset);
                return false;
            } 

            return true;
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == dataGridView1.Rows.Count -1)
            {
                selectRowIndex = -1; return;
            }
            saveSelectInfo(e.RowIndex);
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.RowIndex < dataGridView1.Rows.Count - 1) //dataGridView1 has an empty row
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                saveSelectInfo(e.RowIndex);
            }

        }

        private void saveSelectInfo(int index)
        {
            selectRowIndex = index;
            account_textBox.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            pwd_textBox.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            comment_textBox.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            selectID = Convert.ToInt64(dataGridView1.Rows[index].Cells[4].Value.ToString());
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 2)//select target column
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ColumnPwd" && e.Value != null)
    {
                dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
    }
}
