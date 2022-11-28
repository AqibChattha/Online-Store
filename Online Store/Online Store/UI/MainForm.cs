using Online_Store.Classes;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;

namespace Online_Store.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                    ProductInfo productInfo = new ProductInfo(row.Cells[0].Value.ToString(), this);
                    this.Hide();
                    productInfo.ShowDialog();
                }

                if (e.ColumnIndex == 1)
                {
                    DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                    MessageBox.Show(row.Cells[1].Value.ToString(), "View Description", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.Rows.Clear();
                var con = Config.Instance.Connection;
                SqlCommand cmd = new SqlCommand("SELECT [id], [description], [model/brand], [stockQuantity], [soldQuantity], [price] FROM [dbo].[Products] WHERE [id] LIKE '%" + tbSearch.Text + "%' OR [description] LIKE '%" + tbSearch.Text + "%';", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvProducts.Rows.Add(reader["id"].ToString()
                        , reader["description"].ToString()
                        , reader["model/brand"].ToString()
                        , reader["stockQuantity"].ToString()
                        , reader["soldQuantity"].ToString()
                        , reader["price"].ToString());
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error searching the products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataInDataGridView()
        {
            try
            {
                dgvProducts.Rows.Clear();
                var con = Config.Instance.Connection;
                SqlCommand cmd = new SqlCommand("SELECT [id], [description], [model/brand], [stockQuantity], [soldQuantity], [price] FROM [dbo].[Products];", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvProducts.Rows.Add(reader["id"].ToString()
                        , reader["description"].ToString()
                        , reader["model/brand"].ToString()
                        , reader["stockQuantity"].ToString()
                        , reader["soldQuantity"].ToString()
                        , reader["price"].ToString());
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDataInDataGridView();
        }
    }
}
