namespace Online_Store.UI
{
    partial class ProductInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lbFocus = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pbProductPreview = new System.Windows.Forms.PictureBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.gbProductInfo = new System.Windows.Forms.GroupBox();
            this.tlpInfoColomns = new System.Windows.Forms.TableLayoutPanel();
            this.tlpColomn1Rows = new System.Windows.Forms.TableLayoutPanel();
            this.lbModelBrand = new System.Windows.Forms.Label();
            this.lbStock = new System.Windows.Forms.Label();
            this.lbSold = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPreview)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.gbProductInfo.SuspendLayout();
            this.tlpInfoColomns.SuspendLayout();
            this.tlpColomn1Rows.SuspendLayout();
            this.gbDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(884, 611);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBody.Controls.Add(this.lbFocus);
            this.pnlBody.Controls.Add(this.btnPrev);
            this.pnlBody.Controls.Add(this.btnNext);
            this.pnlBody.Controls.Add(this.pbProductPreview);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 151);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(884, 402);
            this.pnlBody.TabIndex = 2;
            // 
            // lbFocus
            // 
            this.lbFocus.AutoSize = true;
            this.lbFocus.Location = new System.Drawing.Point(788, 311);
            this.lbFocus.Name = "lbFocus";
            this.lbFocus.Size = new System.Drawing.Size(0, 13);
            this.lbFocus.TabIndex = 2;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnPrev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(3, 177);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(65, 48);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(817, 177);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 48);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pbProductPreview
            // 
            this.pbProductPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProductPreview.BackColor = System.Drawing.Color.Gainsboro;
            this.pbProductPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbProductPreview.Location = new System.Drawing.Point(74, 6);
            this.pbProductPreview.Name = "pbProductPreview";
            this.pbProductPreview.Size = new System.Drawing.Size(737, 384);
            this.pbProductPreview.TabIndex = 0;
            this.pbProductPreview.TabStop = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnBuy);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 553);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(884, 58);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 37);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuy.FlatAppearance.BorderSize = 0;
            this.btnBuy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(752, 11);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(120, 37);
            this.btnBuy.TabIndex = 0;
            this.btnBuy.Text = "Buy This Product";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.gbProductInfo);
            this.pnlHeader.Controls.Add(this.pbProductImage);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 151);
            this.pnlHeader.TabIndex = 0;
            // 
            // gbProductInfo
            // 
            this.gbProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProductInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbProductInfo.Controls.Add(this.tlpInfoColomns);
            this.gbProductInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbProductInfo.Location = new System.Drawing.Point(247, 12);
            this.gbProductInfo.Name = "gbProductInfo";
            this.gbProductInfo.Size = new System.Drawing.Size(564, 133);
            this.gbProductInfo.TabIndex = 1;
            this.gbProductInfo.TabStop = false;
            this.gbProductInfo.Text = "Product Information";
            // 
            // tlpInfoColomns
            // 
            this.tlpInfoColomns.ColumnCount = 2;
            this.tlpInfoColomns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.18731F));
            this.tlpInfoColomns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.8127F));
            this.tlpInfoColomns.Controls.Add(this.tlpColomn1Rows, 0, 0);
            this.tlpInfoColomns.Controls.Add(this.gbDescription, 1, 0);
            this.tlpInfoColomns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfoColomns.Location = new System.Drawing.Point(3, 16);
            this.tlpInfoColomns.Name = "tlpInfoColomns";
            this.tlpInfoColomns.RowCount = 1;
            this.tlpInfoColomns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfoColomns.Size = new System.Drawing.Size(558, 114);
            this.tlpInfoColomns.TabIndex = 0;
            // 
            // tlpColomn1Rows
            // 
            this.tlpColomn1Rows.ColumnCount = 1;
            this.tlpColomn1Rows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpColomn1Rows.Controls.Add(this.lbModelBrand, 0, 0);
            this.tlpColomn1Rows.Controls.Add(this.lbStock, 0, 1);
            this.tlpColomn1Rows.Controls.Add(this.lbSold, 0, 2);
            this.tlpColomn1Rows.Controls.Add(this.lbPrice, 0, 3);
            this.tlpColomn1Rows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpColomn1Rows.Location = new System.Drawing.Point(3, 3);
            this.tlpColomn1Rows.Name = "tlpColomn1Rows";
            this.tlpColomn1Rows.RowCount = 4;
            this.tlpColomn1Rows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tlpColomn1Rows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22223F));
            this.tlpColomn1Rows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tlpColomn1Rows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpColomn1Rows.Size = new System.Drawing.Size(179, 108);
            this.tlpColomn1Rows.TabIndex = 0;
            // 
            // lbModelBrand
            // 
            this.lbModelBrand.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbModelBrand.AutoSize = true;
            this.lbModelBrand.Location = new System.Drawing.Point(3, 5);
            this.lbModelBrand.Name = "lbModelBrand";
            this.lbModelBrand.Size = new System.Drawing.Size(96, 13);
            this.lbModelBrand.TabIndex = 0;
            this.lbModelBrand.Tag = "";
            this.lbModelBrand.Text = "Model/Brand = NA";
            // 
            // lbStock
            // 
            this.lbStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbStock.AutoSize = true;
            this.lbStock.Location = new System.Drawing.Point(3, 28);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(62, 13);
            this.lbStock.TabIndex = 0;
            this.lbStock.Tag = "";
            this.lbStock.Text = "Stock = NA";
            // 
            // lbSold
            // 
            this.lbSold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbSold.AutoSize = true;
            this.lbSold.Location = new System.Drawing.Point(3, 52);
            this.lbSold.Name = "lbSold";
            this.lbSold.Size = new System.Drawing.Size(55, 13);
            this.lbSold.TabIndex = 0;
            this.lbSold.Tag = "";
            this.lbSold.Text = "Sold = NA";
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(3, 81);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(80, 16);
            this.lbPrice.TabIndex = 0;
            this.lbPrice.Tag = "";
            this.lbPrice.Text = "Price = NA";
            // 
            // gbDescription
            // 
            this.gbDescription.Controls.Add(this.rtbDescription);
            this.gbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDescription.Location = new System.Drawing.Point(188, 3);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(367, 108);
            this.gbDescription.TabIndex = 1;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.HideSelection = false;
            this.rtbDescription.Location = new System.Drawing.Point(3, 16);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(361, 89);
            this.rtbDescription.TabIndex = 2;
            this.rtbDescription.Text = "";
            this.rtbDescription.Click += new System.EventHandler(this.rtbDescription_Click);
            // 
            // pbProductImage
            // 
            this.pbProductImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbProductImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pbProductImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbProductImage.Location = new System.Drawing.Point(74, 18);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(167, 124);
            this.pbProductImage.TabIndex = 0;
            this.pbProductImage.TabStop = false;
            // 
            // ProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "ProductInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectedProduct";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductInfo_FormClosing);
            this.Load += new System.EventHandler(this.ProductInfo_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPreview)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.gbProductInfo.ResumeLayout(false);
            this.tlpInfoColomns.ResumeLayout(false);
            this.tlpColomn1Rows.ResumeLayout(false);
            this.tlpColomn1Rows.PerformLayout();
            this.gbDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pbProductPreview;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox gbProductInfo;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.TableLayoutPanel tlpInfoColomns;
        private System.Windows.Forms.TableLayoutPanel tlpColomn1Rows;
        private System.Windows.Forms.Label lbModelBrand;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.Label lbSold;
        private System.Windows.Forms.GroupBox gbDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbFocus;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnCancel;
    }
}