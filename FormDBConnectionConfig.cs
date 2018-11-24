using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentInfoDBManagement
{
    public partial class FormDBConnectionConfig : Form
    {
        private SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public FormDBConnectionConfig()
        {
            InitializeComponent();

        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (TestConnection())
            {
                Helper.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
                Close();
            }
        }

        private bool TestConnection()
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = textBoxDataSource.Text;
            
            sqlConnectionStringBuilder.InitialCatalog = textBoxInitialCatalog.Text;
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            bool result = false;
            try
            {
                conn.Open();
                MessageBox.Show("连接成功.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }
            catch
            {
                MessageBox.Show("连接失败.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
