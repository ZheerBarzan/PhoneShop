namespace PhoneShop
{
    partial class FormProduct
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
            ProductCatagoryLable = new Label();
            ProdcutName = new Label();
            ProductPrice = new Label();
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            btnSearchProduct = new Button();
            btnDeleteProduct = new Button();
            btnShowAllPoduct = new Button();
            ProductDataGrid = new DataGridView();
            CatagoryComboBox = new ComboBox();
            ProductNameTextBox = new TextBox();
            ProductPriceTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ProductDataGrid).BeginInit();
            SuspendLayout();
            // 
            // ProductCatagoryLable
            // 
            ProductCatagoryLable.AutoSize = true;
            ProductCatagoryLable.Location = new Point(100, 75);
            ProductCatagoryLable.Name = "ProductCatagoryLable";
            ProductCatagoryLable.Size = new Size(196, 32);
            ProductCatagoryLable.TabIndex = 0;
            ProductCatagoryLable.Text = "Choose Catagory";
            // 
            // ProdcutName
            // 
            ProdcutName.AutoSize = true;
            ProdcutName.Location = new Point(100, 174);
            ProdcutName.Name = "ProdcutName";
            ProdcutName.Size = new Size(167, 32);
            ProdcutName.TabIndex = 1;
            ProdcutName.Text = "Product Name";
            // 
            // ProductPrice
            // 
            ProductPrice.AutoSize = true;
            ProductPrice.Location = new Point(100, 265);
            ProductPrice.Name = "ProductPrice";
            ProductPrice.Size = new Size(154, 32);
            ProductPrice.TabIndex = 2;
            ProductPrice.Text = "Product Price";
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = SystemColors.ButtonHighlight;
            btnAddProduct.FlatAppearance.BorderSize = 0;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Location = new Point(100, 351);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(150, 69);
            btnAddProduct.TabIndex = 3;
            btnAddProduct.Text = "Add";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.BackColor = SystemColors.ButtonHighlight;
            btnEditProduct.FlatAppearance.BorderSize = 0;
            btnEditProduct.FlatStyle = FlatStyle.Flat;
            btnEditProduct.Location = new Point(344, 351);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(150, 69);
            btnEditProduct.TabIndex = 4;
            btnEditProduct.Text = "Edit";
            btnEditProduct.UseVisualStyleBackColor = false;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnSearchProduct
            // 
            btnSearchProduct.BackColor = SystemColors.ButtonHighlight;
            btnSearchProduct.FlatAppearance.BorderSize = 0;
            btnSearchProduct.FlatStyle = FlatStyle.Flat;
            btnSearchProduct.Location = new Point(586, 351);
            btnSearchProduct.Name = "btnSearchProduct";
            btnSearchProduct.Size = new Size(150, 69);
            btnSearchProduct.TabIndex = 5;
            btnSearchProduct.Text = "Search";
            btnSearchProduct.UseVisualStyleBackColor = false;
            btnSearchProduct.Click += btnSearchProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.BackColor = SystemColors.ButtonHighlight;
            btnDeleteProduct.FlatAppearance.BorderSize = 0;
            btnDeleteProduct.FlatStyle = FlatStyle.Flat;
            btnDeleteProduct.Location = new Point(860, 351);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(150, 69);
            btnDeleteProduct.TabIndex = 6;
            btnDeleteProduct.Text = "Delete";
            btnDeleteProduct.UseVisualStyleBackColor = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnShowAllPoduct
            // 
            btnShowAllPoduct.BackColor = SystemColors.ButtonHighlight;
            btnShowAllPoduct.FlatAppearance.BorderSize = 0;
            btnShowAllPoduct.FlatStyle = FlatStyle.Flat;
            btnShowAllPoduct.Location = new Point(1099, 351);
            btnShowAllPoduct.Name = "btnShowAllPoduct";
            btnShowAllPoduct.Size = new Size(150, 69);
            btnShowAllPoduct.TabIndex = 7;
            btnShowAllPoduct.Text = "Show All";
            btnShowAllPoduct.UseVisualStyleBackColor = false;
            btnShowAllPoduct.Click += btnShowAllPoduct_Click;
            // 
            // ProductDataGrid
            // 
            ProductDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductDataGrid.Location = new Point(100, 504);
            ProductDataGrid.Name = "ProductDataGrid";
            ProductDataGrid.RowHeadersWidth = 200;
            ProductDataGrid.Size = new Size(1265, 401);
            ProductDataGrid.TabIndex = 8;
            ProductDataGrid.SelectionChanged += ProductDataGrid_SelectionChanged;
            // 
            // CatagoryComboBox
            // 
            CatagoryComboBox.FormattingEnabled = true;
            CatagoryComboBox.Location = new Point(401, 75);
            CatagoryComboBox.Name = "CatagoryComboBox";
            CatagoryComboBox.Size = new Size(417, 40);
            CatagoryComboBox.TabIndex = 9;
            // 
            // ProductNameTextBox
            // 
            ProductNameTextBox.Location = new Point(401, 174);
            ProductNameTextBox.Name = "ProductNameTextBox";
            ProductNameTextBox.Size = new Size(417, 39);
            ProductNameTextBox.TabIndex = 10;
            // 
            // ProductPriceTextBox
            // 
            ProductPriceTextBox.Location = new Point(401, 265);
            ProductPriceTextBox.Name = "ProductPriceTextBox";
            ProductPriceTextBox.Size = new Size(417, 39);
            ProductPriceTextBox.TabIndex = 11;
            ProductPriceTextBox.KeyPress += ProductPriceTextBox_KeyPress;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1610, 1157);
            Controls.Add(ProductPriceTextBox);
            Controls.Add(ProductNameTextBox);
            Controls.Add(CatagoryComboBox);
            Controls.Add(ProductDataGrid);
            Controls.Add(btnShowAllPoduct);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnSearchProduct);
            Controls.Add(btnEditProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(ProductPrice);
            Controls.Add(ProdcutName);
            Controls.Add(ProductCatagoryLable);
            Name = "FormProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormProduct";
            Load += FormProduct_Load;
            ((System.ComponentModel.ISupportInitialize)ProductDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProductCatagoryLable;
        private Label ProdcutName;
        private Label ProductPrice;
        private Button btnAddProduct;
        private Button btnEditProduct;
        private Button btnSearchProduct;
        private Button btnDeleteProduct;
        private Button btnShowAllPoduct;
        private DataGridView ProductDataGrid;
        private ComboBox CatagoryComboBox;
        private TextBox ProductNameTextBox;
        private TextBox ProductPriceTextBox;
    }
}