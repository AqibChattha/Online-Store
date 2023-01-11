using Online_Store.UI.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store.UI
{
    public partial class Product : Form
    {
        // This field is for storing the parent form of this form.
        private Form parent;

        // This is the constructor of this form.
        public Product(Form parentForm)
        {
            InitializeComponent();

            // Set the fields or initialize the components of this form.
            ProductCRUD.Initialize(this);
            AddOrUpdateProduct.Initialize(this);
            parent = parentForm;
            To_ProductCRUD();
        }
        
        // Change the user component to ProductCRUD
        public void To_ProductCRUD()
        {
            // if there is no productCRUD component in the user control then add it.
            if (!pnlMain.Controls.Contains(ProductCRUD.Instance))
            {
                pnlMain.Controls.Add(ProductCRUD.Instance);
                ProductCRUD.Instance.Dock = DockStyle.Fill;
                ProductCRUD.Instance.BringToFront();
            }
            // otherwise just bring it to front.
            else
            {
                ProductCRUD.Instance.RefreshUI();
                ProductCRUD.Instance.BringToFront();
            }
        }

        // Called if the back button is clicked.
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide this form and show the main form form.
            Login loginParent = (Login)parent;
            loginParent.closeAndLoadMainForm();
            this.Dispose();
        }

        // called when the form is closing.
        private void Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show the main form form and close this form.
            Login form = (Login)parent;
            MainForm mainForm = (MainForm)form.parent;
            mainForm.RefreshUI();
            mainForm.Show();
            parent.Close();
            this.Dispose();
        }

        // Change the user component to AddOrUpdateProduct when the add button is clicked.
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            To_AddProduct();
        }

        // Change the user component to AddOrUpdateProduct and set the product id to update.
        public void To_UpdateProduct(string id)
        {
            // if there is no addOrUpdateProduct component in the user control then add it.
            if (!pnlMain.Controls.Contains(AddOrUpdateProduct.Instance))
            {
                pnlMain.Controls.Add(AddOrUpdateProduct.Instance);
                AddOrUpdateProduct.Instance.Dock = DockStyle.Fill;
                AddOrUpdateProduct.Instance.RefreshUI(id);
                AddOrUpdateProduct.Instance.BringToFront();
            }
            // otherwise just bring it to the front
            else
            {
                AddOrUpdateProduct.Instance.RefreshUI(id);
                AddOrUpdateProduct.Instance.BringToFront();
            }
        }

        // Change the user component to AddOrUpdateProduct and set the fields to add a product.
        private void To_AddProduct()
        {
            // if there is no addOrUpdateProduct component in the user control then add it.
            if (!pnlMain.Controls.Contains(AddOrUpdateProduct.Instance))
            {
                pnlMain.Controls.Add(AddOrUpdateProduct.Instance);
                AddOrUpdateProduct.Instance.Dock = DockStyle.Fill;
                AddOrUpdateProduct.Instance.RefreshUI();
                AddOrUpdateProduct.Instance.BringToFront();
            }
            // otherwise just bring it to the front
            else
            {
                AddOrUpdateProduct.Instance.RefreshUI();
                AddOrUpdateProduct.Instance.BringToFront();
            }
        }
    }
}
