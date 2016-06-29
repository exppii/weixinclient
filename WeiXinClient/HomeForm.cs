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

namespace WeixinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initDB();
        }


        private void initDB()
        {
            
            dbConn = new SQLiteConnection("Data Source=./user.db;Version=3;");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = this.textBox1.Text;
            string pwd = this.textBox2.Text;
            string sql = string.Format(@"insert into user (account, pwd) values ('{0}', '{1}')", account, pwd);

            dbConn.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
            dbConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConn.Open();
            //DataSet data = new DataSet();
            //SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select account, pwd,comment From user", dbConn);

            //adapter.Fill(data);
            //dataGridView1.DataSource = data.Tables[0].DefaultView;
            try
            {
                
                SQLiteCommand comm = new SQLiteCommand("Select account, pwd,comment From user", dbConn);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        //string comment = read.GetValue(read.GetOrdinal("comment")).ToString();
                        //if (string.Empty == comment)
                        //{

                        //}
                        dataGridView1.Rows.Add(new object[] {
                        //read.GetValue(0),  // U can use column index
                        read.GetValue(read.GetOrdinal("account")),  // Or column name like this
                        read.GetValue(read.GetOrdinal("pwd")),
                        read.GetValue(read.GetOrdinal("comment"))
                         });
                    }
                }

                dbConn.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool seleted_one = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Selected)
                {
                    seleted_one = true;
                    this.textBox1.Text = row.Cells[0].Value.ToString();
                    this.textBox2.Text = row.Cells[1].Value.ToString();
                }
            }

            
            
        }
    }
}
