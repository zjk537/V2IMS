using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Vogue2_IMS.DBBackUp
{
    public partial class DBHandler : Form
    {
        readonly string ConnectionString = ConfigurationManager.ConnectionStrings["IMSContext"].ConnectionString;
       
        public DBHandler()
        {
            InitializeComponent();
        }

        private void btn_BackUpDB_Click(object sender, EventArgs e)
        {
            string backUpSql = @"BACKUP DATABASE V2IMSDB TO DISK ='{0}' with init";

            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = ".db|*.db";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataService.SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, string.Format(backUpSql, sf.FileName));

                    MessageBox.Show(string.Concat("备份成功,备份地址：", sf.FileName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("备份失败，请尝试一个新的地址文件。原因如下：\r\n" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
        }

        private void btn_RestoreDb_Click(object sender, EventArgs e)
        {
            string restoreSql = @"use master RESTORE DATABASE V2IMSDB FROM DISK='{0}' WITH REPLACE ";
            string selectSpidSql = "use master  select spid from sysprocesses WHERE dbid=db_id('V2IMSDB')";
            string killSql = "exec('KILL {0}') ";

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = ".db|*.db";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var reader = DataService.SQLHelper.ExecuteReader(ConnectionString, CommandType.Text, selectSpidSql);
                    while (reader.Read())
                    {
                        try
                        {
                            DataService.SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, string.Format(killSql, reader[0]));
                        }
                        finally { }
                    }

                    DataService.SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, string.Format(restoreSql, of.FileName));

                    MessageBox.Show(string.Concat("还原成功,还原文件：",of.FileName), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("还原失败，请选择一个新文件重试。原因如下：\r\n" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
