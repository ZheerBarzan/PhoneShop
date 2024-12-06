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
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1610, 1157);
            Controls.Add(ProductPrice);
            Controls.Add(ProdcutName);
            Controls.Add(ProductCatagoryLable);
            Name = "FormProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormProduct";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProductCatagoryLable;
        private Label ProdcutName;
        private Label ProductPrice;
    }
}