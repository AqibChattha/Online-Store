using Online_Store.Classes;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Online_Store.UI
{
    public partial class ProductInfo : Form
    {
        // This is the product id of the product that we are going to display the information of.
        private string productId;
        // This is the parent form of this form. We need this to hide this form and display the parent form.
        Form parent;
        // These are the preview images of the product.
        private List<Image> previewImages;
        // This is the index of the current preview image.
        int previewImageIndex;

        // This is the constructor of this form.
        public ProductInfo(string id, Form parentContainer)
        {
            InitializeComponent();
            
            // set the fields or initialize them
            productId = id;
            previewImageIndex = 0;
            previewImages = new List<Image>();
            parent = parentContainer;
            rtbDescription.ReadOnly = false;
            rtbDescription.TabStop = false;
        }

        // This method is used to lose the foucus of the description textbox when its clicked
        private void rtbDescription_Click(object sender, EventArgs e)
        {
            lbFocus.Focus();
        }

        // Called when the form is loaded
        private void ProductInfo_Load(object sender, EventArgs e)
        {
            try
            {
                // load the product information from the database and display it in the form fields
                var con = Config.Instance.Connection;
                SqlCommand cmd = new SqlCommand("SELECT [id], [description], [model/brand], [stockQuantity], [soldQuantity], [price] FROM [dbo].[Products] WHERE [id] = " + productId + ";", con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                rtbDescription.Text = reader["description"].ToString();
                rtbDescription.Tag = reader["description"].ToString();
                lbModelBrand.Text = "Model/Brand = " + reader["model/brand"].ToString();
                lbModelBrand.Tag = reader["model/brand"].ToString();
                lbStock.Text = "Stock = " + reader["stockQuantity"].ToString();
                lbStock.Tag = reader["stockQuantity"].ToString();
                lbSold.Text = "Sold = " + reader["soldQuantity"].ToString();
                lbSold.Tag = reader["soldQuantity"].ToString();
                lbPrice.Text = "Price = " + reader["price"].ToString();
                lbPrice.Tag = reader["price"].ToString();
                reader.Close();
                reader.Dispose();

                // load the product images from the database and display them in the form
                cmd = new SqlCommand("SELECT [image], [previewImage1], [previewImage2], [previewImage3] FROM [dbo].[ProductImages] WHERE [productId] = " + productId + ";", con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["image"] != DBNull.Value)
                    {
                        byte[] image = (byte[])reader["image"];
                        MemoryStream ms = new MemoryStream(image);
                        pbProductImage.BackgroundImage = Image.FromStream(ms);
                    }
                    if (reader["previewImage1"] != DBNull.Value)
                    {
                        byte[] image = (byte[])reader["previewImage1"];
                        MemoryStream ms = new MemoryStream(image);
                        previewImages.Add(Image.FromStream(ms));
                    }
                    if (reader["previewImage2"] != DBNull.Value)
                    {
                        byte[] image = (byte[])reader["previewImage2"];
                        MemoryStream ms = new MemoryStream(image);
                        previewImages.Add(Image.FromStream(ms));
                    }
                    if (reader["previewImage3"] != DBNull.Value)
                    {
                        byte[] image = (byte[])reader["previewImage3"];
                        MemoryStream ms = new MemoryStream(image);
                        previewImages.Add(Image.FromStream(ms));
                    }

                    // if there are preview images, display the first one
                    LoadPreviewImage();
                }
                reader.Close();
                reader.Dispose();
            }
            // if there is an error, display it and close the form.
            catch (Exception)
            {
                MessageBox.Show("There was an error Loading the product's Information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // loads the preview image at the current index
        private void LoadPreviewImage()
        {
            // change the index if it is out of range
            if (previewImageIndex < 0)
                previewImageIndex = previewImages.Count - 1;

            if (previewImageIndex >= previewImages.Count)
                previewImageIndex = 0;

            // if there are preview images, display the current one
            if (previewImages.Count > 0)
            {
                pbProductPreview.BackgroundImage = previewImages[previewImageIndex];
            }
        }

        // called when the previous cancel button is clicked it will also close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // called when the buy button is clicked
        private void btnBuy_Click(object sender, EventArgs e)
        {
            // if there is stock available, display the buy form
            if (Convert.ToInt32(lbStock.Tag.ToString()) > 0)
            {
                Purchase purchase = new Purchase(productId, this, lbModelBrand.Tag.ToString(), rtbDescription.Tag.ToString(), lbStock.Tag.ToString(), lbPrice.Tag.ToString(), pbProductImage.BackgroundImage);
                this.Hide();
                purchase.ShowDialog();
            }
            // if there is no stock, display an error message
            else
            {
                MessageBox.Show("Sorry, this product is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // called when the form is closing
        private void ProductInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // display the parent form and dispose of this form
            MainForm form = (MainForm)parent;
            form.RefreshUI();
            form.Show();
            this.Dispose();
        }

        // called when the next button is clicked
        private void btnNext_Click(object sender, EventArgs e)
        {
            // increase the preview image index and load the next preview image
            previewImageIndex++;
            LoadPreviewImage();
        }

        // called when the previous button is clicked
        private void btnPrev_Click(object sender, EventArgs e)
        {
            // decrease the preview image index and load the previous preview image
            previewImageIndex--;
            LoadPreviewImage();
        }
    }
}
