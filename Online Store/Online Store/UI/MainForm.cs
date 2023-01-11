using Online_Store.Classes;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;

namespace Online_Store.UI
{
    public partial class MainForm : Form
    {
        // This is constructor for the main form.
        public MainForm()
        {
            InitializeComponent();
        }

        // This method is called when a cell in the datagridview which contains the products, is clicked
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // check if the colomn is view button column
                if (e.ColumnIndex == 6)
                {
                    // get the id of the product from the datagridview and pass it to the product details form
                    DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                    ProductInfo productInfo = new ProductInfo(row.Cells[0].Value.ToString(), this);

                    // hide this form and display the details form
                    this.Hide();
                    productInfo.ShowDialog();
                }

                // Now if the description colomn is clicked just display the description in a message box 
                if (e.ColumnIndex == 1)
                {
                    DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                    MessageBox.Show(row.Cells[1].Value.ToString(), "View Description", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        // This method is called when the text in the search textbox is changed
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // clear the products already present in the table
                dgvProducts.Rows.Clear();

                // load the products from the database into the product table which contain the serched string
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
            // if there was an error in loading the products then just display the error
            catch (Exception)
            {
                MessageBox.Show("There was an error searching the products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method is used to load all the product in the products table
        public void LoadDataInDataGridView()
        {
            try
            {
                // clear the products if there are any
                dgvProducts.Rows.Clear();
                
                // load all the products from the database into the table
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
            // display error if there is any error
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // called when the form is loaded
        private void MainForm_Load(object sender, EventArgs e)
        {
            // load the products data into the table
            LoadDataInDataGridView();
        }

        // Refresh the user interface whenever its called.
        public void RefreshUI()
        {
            tbSearch.Text = "";
            LoadDataInDataGridView();            
        }

        // This method is called when the user clicks on the add products button
        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            // display the login form to the user
            Login login = new Login(this);
            login.ShowDialog();
        }
    }
}
