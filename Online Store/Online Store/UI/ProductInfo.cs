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
        private string productId;
        Form parent;
        private List<Image> previewImages;
        int previewImageIndex;

        public ProductInfo(string id, Form parentContainer)
        {
            InitializeComponent();
            productId = id;
            previewImageIndex = 0;
            previewImages = new List<Image>();
            parent = parentContainer;
            rtbDescription.ReadOnly = false;
            rtbDescription.TabStop = false;
        }

        private void rtbDescription_Click(object sender, EventArgs e)
        {
            lbFocus.Focus();
        }

        private void ProductInfo_Load(object sender, EventArgs e)
        {
            try
            {
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
                    LoadPreviewImage();
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error Loading the product's Information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadPreviewImage()
        {
            if (previewImageIndex < 0)
                previewImageIndex = previewImages.Count - 1;

            if (previewImageIndex >= previewImages.Count)
                previewImageIndex = 0;

            if (previewImages.Count > 0)
            {
                pbProductPreview.BackgroundImage = previewImages[previewImageIndex];
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lbStock.Tag.ToString()) > 0)
            {
                Purchase purchase = new Purchase(productId, this, lbModelBrand.Tag.ToString(), rtbDescription.Tag.ToString(), lbStock.Tag.ToString(), lbPrice.Tag.ToString(), pbProductImage.BackgroundImage);
                this.Hide();
                purchase.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry, this product is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProductInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm form = (MainForm)parent;
            form.LoadDataInDataGridView();
            form.Show();
            this.Dispose();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            previewImageIndex++;
            LoadPreviewImage();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            previewImageIndex--;
            LoadPreviewImage();
        }
    }
}
