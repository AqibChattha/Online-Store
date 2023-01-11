using Online_Store.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store.UI.Components
{
    public partial class ProductCRUD : UserControl
    {
        // This field is for storing the parent form of this form.
        private static Product parent;

        // This is used to store the static instance of this form.
        private static ProductCRUD _instance;

        // This is used to get the instance of this form across all classes
        public static ProductCRUD Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductCRUD();
                }
                return _instance;
            }
        }

        // This is used to initialize the form.
        public static void Initialize(Product parentForm)
        {
            parent = parentForm;
            _instance = new ProductCRUD();

        }

        // This is the constructor of this form.
        private ProductCRUD()
        {
            InitializeComponent();
            // load the data into the product table.
            LoadDataInDataGridView();
        }

        // Called when the text in the search textbox is changed.
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // clear the current table if there is any data
                dgvProducts.Rows.Clear();

                // load new data from the database.
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
            // display error message if there is any error.
            catch (Exception)
            {
                MessageBox.Show("There was an error searching the products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method is used to load all the products from the database into the table.
        private void LoadDataInDataGridView()
        {
            try
            {
                // clear the table if there is any data.
                dgvProducts.Rows.Clear();
                // load data from database
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
            // display error if there is any
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to refresh the user ineterface to the initial state.
        public void RefreshUI()
        {
            tbSearch.Text = "";
            LoadDataInDataGridView();
        }

        // This method is called when the user clicks on a cell in the product datagridview.
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // check if the user selects the delete button.
                if (e.ColumnIndex == 7)
                {
                    // ask user for confirmation
                    if (MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            // if the user wants to delete the product delete it from the database
                            var con = Config.Instance.Connection;
                            SqlCommand cmd = new SqlCommand("BEGIN TRAN BEGIN TRY " +
                                "DELETE FROM [dbo].[ProductImages] WHERE [productId] = " + dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString() + " " +
                                "DELETE FROM [dbo].[Products] WHERE [id] = " + dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString() +
                                " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH", con);
                            int executed = cmd.ExecuteNonQuery();

                            // if the product was deleted or not display a message to the user.
                            if (executed > 1)
                            {
                                MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshUI();
                            }
                            else
                            {
                                MessageBox.Show("There was an error deleting the product. Or probely the product can't be deleted because it already has sales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        // Also display any error if there is any.
                        catch (Exception)
                        {
                            MessageBox.Show("There was an error deleting the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                // if the user click on the update button then pass that product row product id to the product form to update the product.
                else if (e.ColumnIndex == 6)
                {
                    parent.To_UpdateProduct(dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }
    }
}
