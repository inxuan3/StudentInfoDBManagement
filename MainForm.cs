using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace StudentInfoDBManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridViewStudentInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudentInfo.SelectedRows.Count > 0)
                textBox1.Text = dataGridViewStudentInfo.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void toolStripMenuItemConnectDB_Click(object sender, EventArgs e)
        {
            FormDBConnectionConfig form = new FormDBConnectionConfig();
            form.ShowDialog();
        }

        private void toolStripMenuItemQuery_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Helper.ConnectionString);
            string sql = "SELECT 学号 = '10112101' FROM 学生信息";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            
            da.Fill(ds);
            dataGridViewStudentInfo.DataSource = ds.Tables[0];
        }

        private void toolStripMenuItemInsert_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Helper.ConnectionString);
            conn.Open();
            string sql = string.Format("INSERT INTO student (s_id,sname,ssex) VALUES ('{0}','{1}','{2}')",textBox1.Text,textBox2.Text,textBox3.Text);
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }
    }
}
