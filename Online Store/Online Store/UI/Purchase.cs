using Online_Store.Classes;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Online_Store.UI
{
    public partial class Purchase : Form
    {
        // This is the product id of the product that we are going to purchase.
        private string productId;
        // This is the parent form of this form. We need this to hide this form and display the parent form.
        private Form parent;
        // This is the price of the product that we are going to purchase.
        private int productUnitPrice;
        // This is to store the customer id of the customer that is going to purchase the product.
        private string customerId;
        // This is to store the phone number of the customer that is going to purchase the product.
        private string customerPhoneNo;
        // This is to store the credit card of the customer that is going to purchase the product.
        private string customerCreditNo;

        // This is the constructor of this form.
        public Purchase(string id, Form parentForm, string model, string description, string quantity, string price, Image pdImage)
        {
            InitializeComponent();

            // set the fields or initialize them
            productId = id;
            parent = parentForm;
            lbModelBrand.Text = "Model/Brand = " + model;
            rtbDescription.Text = description;
            lbStock.Text = "Stock = " + quantity;
            nudProductQuantity.Maximum = Convert.ToInt32(quantity);
            lbPrice.Text = "Price = " + price;
            lbTotalDisplay.Text = price;
            productUnitPrice = (int)Convert.ToDouble(price);
            pbProductImage.BackgroundImage = pdImage;
            rtbDescription.ReadOnly = false;
            rtbDescription.TabStop = false;
            rtbCustomerAddress.ReadOnly = false;
            rtbCustomerAddress.TabStop = false;
            gbOrderDetails.Enabled = false;
        }

        // This method is called when the cancel button is clicked. It closes this form.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Called when buy button is clicked
        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the database eacoording to the transaction that is going to happen.
                var con = Config.Instance.Connection;
                SqlCommand cmd = new SqlCommand(" BEGIN TRAN BEGIN TRY" +
                                                " DECLARE @stock int" +
                                                " DECLARE @quantity AS int = " + (int)nudProductQuantity.Value +
                                                " DECLARE @productId AS int = " + productId +
                                                " Select @stock = [stockQuantity] from[Products] WHERE id = @productId;" +
                                                " IF @stock >= @quantity" +
                                                " BEGIN" +
                                                " INSERT INTO Orders([customerId], [productId], [dateTime], [quantity]) VALUES((SELECT id FROM Customer AS C WHERE C.[telephone] = '" + customerPhoneNo + "' AND C.[creditCardNum] = '" + customerCreditNo + "'), @productId, GETDATE(), @quantity);" +
                                                " UPDATE[dbo].[Products] SET[stockQuantity] = (Select[stockQuantity] from[Products] WHERE id = @productId) -@quantity, [soldQuantity] = (Select[soldQuantity] from[Products] WHERE id = @productId) +@quantity WHERE id = @productId;" +
                                                " COMMIT TRANSACTION" +
                                                " END" +
                                                " END TRY" +
                                                " BEGIN CATCH" +
                                                " ROLLBACK TRANSACTION" +
                                                " END CATCH", con);
                int affectedRows = cmd.ExecuteNonQuery();

                // if the transaction is successful, display a receipt message box and close this form.
                if (affectedRows > 0)
                {
                    // receipt
                    string receipt = "The product has been purchased successfully." + Environment.NewLine + Environment.NewLine;
                    receipt += "Receipt" + Environment.NewLine + Environment.NewLine;
                    receipt += "Product ID: " + productId + Environment.NewLine;
                    receipt += "Customer ID: " + customerId + Environment.NewLine;
                    receipt += "Product Model/Brand: " + lbModelBrand.Text + Environment.NewLine + Environment.NewLine;
                    receipt += "Product Quantity Purchased: " + nudProductQuantity.Value + Environment.NewLine;
                    receipt += "Product Description: " + rtbDescription.Text + Environment.NewLine;
                    receipt += "---------------------------------------------------------------------------" + Environment.NewLine;
                    receipt += "Total Price: " + lbTotalDisplay.Text + Environment.NewLine;
                    receipt += "---------------------------------------------------------------------------" + Environment.NewLine;
                    MessageBox.Show(receipt, "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                // if the transaction is not successful, display an error message box.
                else
                {
                    MessageBox.Show("There was an error in the transaction. Please close this form and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // if there is an exception, display an error message box.
            catch (Exception)
            {
                MessageBox.Show("There was an error in the transaction. Please close this form and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method is called when the form is closed.
        private void Purchase_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Close();
            this.Dispose();
        }

        // This method is called when the quantity of the product is changed.
        private void nudProductQuantity_ValueChanged(object sender, EventArgs e)
        {
            // update the total cost of the product.
            lbTotalDisplay.Text = (productUnitPrice * nudProductQuantity.Value).ToString();
        }

        // This method is called to lose the focus.
        private void rtb_Click(object sender, EventArgs e)
        {
            lbFocus.Focus();
        }

        // this mthod is used to transition when the focus enters the credit card text box.
        private void tbCreditCardNumber_Enter(object sender, EventArgs e)
        {
            if (tbCreditCardNumber.Text.Equals(tbCreditCardNumber.Tag.ToString()))
            {
                tbCreditCardNumber.Text = "";
                tbCreditCardNumber.ForeColor = Color.Black;
            }
        }

        // this mthod is used to transition when the focus eneters the phone text box.
        private void tbPhoneNo_Enter(object sender, EventArgs e)
        {
            if (tbPhoneNo.Text.Equals(tbPhoneNo.Tag.ToString()))
            {
                tbPhoneNo.Text = "";
                tbPhoneNo.ForeColor = Color.Black;
            }
        }

        // this mthod is used to transition when the focus leaves the credit card text box.
        private void tbCreditCardNumber_Leave(object sender, EventArgs e)
        {
            if (tbCreditCardNumber.Text.Equals(""))
            {
                tbCreditCardNumber.Text = tbCreditCardNumber.Tag.ToString();
                tbCreditCardNumber.ForeColor = Color.DimGray;
            }
        }

        // this mthod is used to transition when the focus leaves the phone text box.
        private void tbPhoneNo_Leave(object sender, EventArgs e)
        {
            if (tbPhoneNo.Text.Equals(""))
            {
                tbPhoneNo.Text = tbPhoneNo.Tag.ToString();
                tbPhoneNo.ForeColor = Color.DimGray;
            }
        }

        // This method is called when the verify button is clicked.
        private void btnVerify_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            try
            {
                // check the database if the credit card and phone number information of the user match and are present in the database
                var con = Config.Instance.Connection;
                SqlCommand cmd = new SqlCommand("SELECT [id], [firstName], [lastName], [telephone], [address], [creditCardNum] FROM [dbo].[Customer] WHERE [telephone] = " + tbPhoneNo.Text + " AND [creditCardNum] = " + tbCreditCardNumber.Text + ";", con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customerId = reader["id"].ToString();
                    lbCustomerName.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                    lbCustomerPhone.Text = reader["telephone"].ToString();
                    lbCustomerCredit.Text = reader["creditCardNum"].ToString();
                    rtbCustomerAddress.Text = reader["address"].ToString();
                    customerPhoneNo = lbCustomerPhone.Text;
                    customerCreditNo = lbCustomerCredit.Text;
                    gbOrderDetails.Enabled = true;
                }
                // if the information is invalid then display the error in the message box
                else
                {
                    MessageBox.Show("The customer with given phone number and credit card information is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                reader.Close();
                reader.Dispose();
            }
            // if there is any error then also display the message too
            catch (Exception)
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                MessageBox.Show("The customer with given phone number and credit card information is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}