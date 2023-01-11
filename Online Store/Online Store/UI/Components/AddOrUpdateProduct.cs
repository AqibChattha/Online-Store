using Online_Store.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace Online_Store.UI.Components
{
    public partial class AddOrUpdateProduct : UserControl
    {
        // This is the instance of this user control.
        private static AddOrUpdateProduct _instance;

        // productId of the product if updating.
        private string productId = "";

        // parent form
        private static Product parent;

        // Static instance to call the product from any other class.
        public static AddOrUpdateProduct Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddOrUpdateProduct();
                }
                return _instance;
            }
        }

        // Initialize the form and set the parent form.
        public static void Initialize(Product parentForm)
        {
            _instance = new AddOrUpdateProduct();
            parent = parentForm;
        }

        // This is the constructor of this user control.
        private AddOrUpdateProduct()
        {
            InitializeComponent();
        }

        // Refresh the user interface and set the fields according to add or upadte.
        public void RefreshUI(string id = "")
        {
            this.productId = id;

            // if the id is not empty then it is for updating the product.
            if (!productId.Equals(""))
            {
                // Change the text of the button to update.
                btnAddUpdate.Text = "Update";

                // Change the fields color to black
                tbDescription.ForeColor = SystemColors.ControlText;
                tbModelBrand.ForeColor = SystemColors.ControlText;
                tbStockQuantity.ForeColor = SystemColors.ControlText;
                tbSoldQuantity.ForeColor = SystemColors.ControlText;
                tbPrice.ForeColor = SystemColors.ControlText;

                try
                {
                    // load the inforjmation of the product in the fields of the user control
                    var con = Config.Instance.Connection;
                    SqlCommand cmd = new SqlCommand("SELECT [id], [description], [model/brand], [stockQuantity], [soldQuantity], [price] FROM [dbo].[Products] WHERE [id] = " + productId + ";", con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        tbDescription.Text = reader["description"].ToString();
                        tbModelBrand.Text = reader["model/brand"].ToString();
                        tbStockQuantity.Text = reader["stockQuantity"].ToString();
                        tbSoldQuantity.Text = reader["soldQuantity"].ToString();
                        tbPrice.Text = reader["price"].ToString();
                    }

                    // load the images of the product
                    cmd = new SqlCommand("SELECT [image], [previewImage1], [previewImage2], [previewImage3] FROM [dbo].[ProductImages] WHERE [productId] = " + productId + ";", con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["image"] != DBNull.Value)
                            {
                                byte[] image = (byte[])reader["image"];
                                MemoryStream ms = new MemoryStream(image);
                                pictureBox3.BackgroundImage = Image.FromStream(ms);
                            }
                            if (reader["previewImage1"] != DBNull.Value)
                            {
                                byte[] image = (byte[])reader["previewImage1"];
                                MemoryStream ms = new MemoryStream(image);
                                pictureBox1.BackgroundImage = Image.FromStream(ms);
                            }
                            if (reader["previewImage2"] != DBNull.Value)
                            {
                                byte[] image = (byte[])reader["previewImage2"];
                                MemoryStream ms = new MemoryStream(image);
                                pictureBox4.BackgroundImage = Image.FromStream(ms);
                            }
                            if (reader["previewImage3"] != DBNull.Value)
                            {
                                byte[] image = (byte[])reader["previewImage3"];
                                MemoryStream ms = new MemoryStream(image);
                                pictureBox2.BackgroundImage = Image.FromStream(ms);
                            }
                        }
                    }
                }
                // if there is an error then show the error message
                catch (Exception)
                {
                    MessageBox.Show("There was an error Loading the product's Information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // if the id is empty then it is for adding a product
            else
            {
                // Change the text of the button to add.
                btnAddUpdate.Text = "Add";

                // initialize all the fields and images to default values.
                tbDescription.Text = "Description";
                tbModelBrand.Text = "Model/Brand";
                tbStockQuantity.Text = "Stock";
                tbSoldQuantity.Text = "Sold";
                tbPrice.Text = "Price";

                tbDescription.ForeColor = Color.Gray;
                tbModelBrand.ForeColor = Color.Gray;
                tbStockQuantity.ForeColor = Color.Gray;
                tbSoldQuantity.ForeColor = Color.Gray;
                tbPrice.ForeColor = Color.Gray;

                pictureBox3.BackgroundImage = null;
                pictureBox1.BackgroundImage = null;
                pictureBox4.BackgroundImage = null;
                pictureBox2.BackgroundImage = null;
            }
        }

        // If the focus enters any of the text boxes this method is called.
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox btn = (TextBox)sender;
            if (btn.Text.Equals(btn.Tag.ToString()))
            {
                btn.Text = "";
                btn.ForeColor = Color.Black;
            }
        }

        // If the focus leaves any of the text boxes this method is called.
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox btn = (TextBox)sender;
            if (btn.Text.Equals(""))
            {
                btn.Text = btn.Tag.ToString();
                btn.ForeColor = Color.Gray;
            }
        }

        // Called when the cancel button is clicked.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ProductCRUD.Instance.RefreshUI();
            parent.To_ProductCRUD();
        }

        // Called when the add/update button is clicked.
        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            // Check whether we are adding or updating the product.
            if (btnAddUpdate.Text.Equals("Add"))
            {
                // check if all the fields are empty and return an error message.
                if (tbDescription.Text.Equals("Description") || tbModelBrand.Text.Equals("Model/Brand") || tbStockQuantity.Text.Equals("Stock Quantity") || tbSoldQuantity.Text.Equals("Sold Quantity") || tbPrice.Text.Equals("Price"))
                {
                    MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // also check if the images are not provided then return an error message.
                else if (pictureBox1.BackgroundImage == null || pictureBox2.BackgroundImage == null || pictureBox3.BackgroundImage == null || pictureBox4.BackgroundImage == null)
                {
                    MessageBox.Show("Please select all the images for the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    // add the product information into the database.
                    var con = Config.Instance.Connection;
                    SqlCommand cmd = new SqlCommand("BEGIN TRAN BEGIN TRY " +
                        "INSERT INTO [dbo].[Products]([description], [model/brand], [stockQuantity], [soldQuantity], [price]) " +
                        "VALUES (@description, @modelBrand, @stockQuantity, @soldQuantity, @price) " +
                        "DECLARE @pdId int SET @pdId = SCOPE_IDENTITY() " +
                        "INSERT INTO [dbo].ProductImages([productId], [image], [previewImage1], [previewImage2], [previewImage3]) VALUES (@pdId, @image, @previewImage1, @previewImage2, @previewImage3) " +
                        "COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH", con);
                    cmd.Parameters.AddWithValue("@description", tbDescription.Text);
                    cmd.Parameters.AddWithValue("@modelBrand", tbModelBrand.Text);
                    cmd.Parameters.AddWithValue("@stockQuantity", tbStockQuantity.Text);
                    cmd.Parameters.AddWithValue("@soldQuantity", tbSoldQuantity.Text);
                    cmd.Parameters.AddWithValue("@price", tbPrice.Text);
                    cmd.Parameters.Add(new SqlParameter("@image", ImageToByteArray(pictureBox1.BackgroundImage)));
                    cmd.Parameters.Add(new SqlParameter("@previewImage1", ImageToByteArray(pictureBox2.BackgroundImage) ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@previewImage2", ImageToByteArray(pictureBox3.BackgroundImage) ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@previewImage3", ImageToByteArray(pictureBox4.BackgroundImage) ?? (object)DBNull.Value));
                    int result = cmd.ExecuteNonQuery();

                    // check whether the product was added or not and show the appropriate message.
                    if (result > 0)
                    {
                        MessageBox.Show("The product has been added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductCRUD.Instance.RefreshUI();
                        parent.To_ProductCRUD();
                    }
                    else
                    {
                        MessageBox.Show("There was an error adding the product. Please make sure the given input is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // if there was any error then display an appropriate message.
                catch (Exception)
                {
                    MessageBox.Show("There was an error adding the product. Please make sure the given input is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // If the user component is set up for the update product
            else
            {
                // check if all the fields are empty and return an error message.
                if (tbDescription.Text.Equals("Description") || tbModelBrand.Text.Equals("Model/Brand") || tbStockQuantity.Text.Equals("Stock Quantity") || tbSoldQuantity.Text.Equals("Sold Quantity") || tbPrice.Text.Equals("Price"))
                {
                    MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // also check if the images are not provided then return an error message.
                else if (pictureBox1.BackgroundImage == null || pictureBox2.BackgroundImage == null || pictureBox3.BackgroundImage == null || pictureBox4.BackgroundImage == null)
                {
                    MessageBox.Show("Please select all the images for the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    // update the product information in the database whith the given product id.
                    var con = Config.Instance.Connection;
                    SqlCommand cmd = new SqlCommand("BEGIN TRAN BEGIN TRY " +
                        "UPDATE [dbo].[Products] SET [description] = @description, [model/brand] = @modelBrand, [stockQuantity] = @stockQuantity, [soldQuantity] = @soldQuantity, [price] = @price WHERE [id] = @id " +
                        "UPDATE [dbo].[ProductImages] SET [image] = @image, [previewImage1] = @previewImage1, [previewImage2] = @previewImage2, [previewImage3] = @previewImage3 WHERE [productId] = @id " +
                        "COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH", con);
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.Parameters.AddWithValue("@description", tbDescription.Text);
                    cmd.Parameters.AddWithValue("@modelBrand", tbModelBrand.Text);
                    cmd.Parameters.AddWithValue("@stockQuantity", tbStockQuantity.Text);
                    cmd.Parameters.AddWithValue("@soldQuantity", tbSoldQuantity.Text);
                    cmd.Parameters.AddWithValue("@price", tbPrice.Text);
                    cmd.Parameters.AddWithValue("@image", ImageToByteArray(pictureBox1.BackgroundImage));
                    cmd.Parameters.AddWithValue("@previewImage1", ImageToByteArray(pictureBox2.BackgroundImage));
                    cmd.Parameters.AddWithValue("@previewImage2", ImageToByteArray(pictureBox3.BackgroundImage));
                    cmd.Parameters.AddWithValue("@previewImage3", ImageToByteArray(pictureBox4.BackgroundImage));
                    int result = cmd.ExecuteNonQuery();

                    // check whether the product was updated or not and show the appropriate message.
                    if (result > 0)
                    {
                        MessageBox.Show("The product has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductCRUD.Instance.RefreshUI();
                        parent.To_ProductCRUD();
                    }
                    else
                    {
                        MessageBox.Show("There was an error updating the product. Please make sure the given input is correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // If there was any error then display am error message.
                catch (Exception)
                {
                    MessageBox.Show("There was an error updating the product. Please make sure the given input is correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // This method is used to convert the image to byte array.
        private byte[] ImageToByteArray(Image backgroundImage)
        {
            // check if the image is not null then convert it to byte array otherwise return null.
            if (backgroundImage == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream();
            backgroundImage.Save(ms, backgroundImage.RawFormat);
            byte[] image = ms.ToArray();
            return image;
        }

        // This method is called when ever a select image button is clicked
        private void SelectImageFromFiles(object sender, EventArgs e)
        {
            // open the file dialog and select the image and load it into the corresponding picturebox.
            Button btn = (Button)sender;
            // OPEN THE dialog box to select the image file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string picPath = dialog.FileName.ToString();
                Image img = Image.FromFile(picPath);

                // check the button name to load the image in the corrsponding picturebox.
                if (btn.Name.Equals("btnImage"))
                {
                    pictureBox1.BackgroundImage = img;
                }
                else if (btn.Name.Equals("btnImage1"))
                {
                    pictureBox2.BackgroundImage = img;
                }
                else if (btn.Name.Equals("btnImage2"))
                {
                    pictureBox3.BackgroundImage = img;
                }
                else if (btn.Name.Equals("btnImage3"))
                {
                    pictureBox4.BackgroundImage = img;
                }
            }
        }
    }
}