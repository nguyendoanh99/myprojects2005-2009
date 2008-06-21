using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
namespace ManHinhDocGia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtMa.Text;
            string KieuDocGia = txtDocGia.Text;
            string sql = "insert into DocGiaTable (ID, KieuDocGia) values (?,?)";
            SqlCeConnection conn = null;

            try
            {
                conn = new SqlCeConnection(@"Data Source = Program Files\ManHinhDocGia\MyDatabase.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@ID", SqlDbType.NChar, 5);
                cmd.Parameters.Add("@KieuDocGia", SqlDbType.NChar, 40);
                cmd.Parameters["@ID"].Value = id;
                cmd.Parameters["@KieuDocGia"].Value = KieuDocGia;

                if (cmd.ExecuteNonQuery() != 0)
                    MessageBox.Show("Da them thanh cong");                    
            }
            catch(Exception _e)
            {
                MessageBox.Show(_e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}