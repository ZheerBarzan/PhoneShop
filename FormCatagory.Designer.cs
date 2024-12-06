namespace PhoneShop
{
    partial class FormCatagory
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CatagoryName = new Label();
            TxtBoxCatagory = new TextBox();
            btnSaveCatagory = new Button();
            btnEditCatagory = new Button();
            btnSearchCatagory = new Button();
            btnDeleteCatagory = new Button();
            CatagoryDataGrid = new DataGridView();
            btnShowAll = new Button();
            btnShowAddProductPage = new Button();
            ((System.ComponentModel.ISupportInitialize)CatagoryDataGrid).BeginInit();
            SuspendLayout();
            // 
            // CatagoryName
            // 
            CatagoryName.AutoSize = true;
            CatagoryName.Location = new Point(81, 79);
            CatagoryName.Name = "CatagoryName";
            CatagoryName.Size = new Size(253, 45);
            CatagoryName.TabIndex = 0;
            CatagoryName.Text = "Catagory Name";
            // 
            // TxtBoxCatagory
            // 
            TxtBoxCatagory.Location = new Point(399, 71);
            TxtBoxCatagory.Name = "TxtBoxCatagory";
            TxtBoxCatagory.Size = new Size(386, 53);
            TxtBoxCatagory.TabIndex = 1;
            // 
            // btnSaveCatagory
            // 
            btnSaveCatagory.BackColor = SystemColors.ButtonHighlight;
            btnSaveCatagory.FlatAppearance.BorderSize = 0;
            btnSaveCatagory.FlatStyle = FlatStyle.Flat;
            btnSaveCatagory.Location = new Point(99, 201);
            btnSaveCatagory.Name = "btnSaveCatagory";
            btnSaveCatagory.Size = new Size(150, 69);
            btnSaveCatagory.TabIndex = 2;
            btnSaveCatagory.Text = "Save";
            btnSaveCatagory.UseVisualStyleBackColor = false;
            btnSaveCatagory.Click += btnSaveCatagory_Click;
            // 
            // btnEditCatagory
            // 
            btnEditCatagory.BackColor = SystemColors.ButtonHighlight;
            btnEditCatagory.FlatAppearance.BorderSize = 0;
            btnEditCatagory.FlatStyle = FlatStyle.Flat;
            btnEditCatagory.Location = new Point(345, 201);
            btnEditCatagory.Name = "btnEditCatagory";
            btnEditCatagory.Size = new Size(150, 69);
            btnEditCatagory.TabIndex = 3;
            btnEditCatagory.Text = "Edit";
            btnEditCatagory.UseVisualStyleBackColor = false;
            btnEditCatagory.Click += btnEditCatagory_Click;
            // 
            // btnSearchCatagory
            // 
            btnSearchCatagory.BackColor = SystemColors.ButtonHighlight;
            btnSearchCatagory.FlatAppearance.BorderSize = 0;
            btnSearchCatagory.FlatStyle = FlatStyle.Flat;
            btnSearchCatagory.Location = new Point(590, 201);
            btnSearchCatagory.Name = "btnSearchCatagory";
            btnSearchCatagory.Size = new Size(150, 69);
            btnSearchCatagory.TabIndex = 4;
            btnSearchCatagory.Text = "Search";
            btnSearchCatagory.UseVisualStyleBackColor = false;
            btnSearchCatagory.Click += btnSearchCatagory_Click;
            // 
            // btnDeleteCatagory
            // 
            btnDeleteCatagory.BackColor = SystemColors.ButtonHighlight;
            btnDeleteCatagory.FlatAppearance.BorderSize = 0;
            btnDeleteCatagory.FlatStyle = FlatStyle.Flat;
            btnDeleteCatagory.Location = new Point(839, 201);
            btnDeleteCatagory.Name = "btnDeleteCatagory";
            btnDeleteCatagory.Size = new Size(150, 69);
            btnDeleteCatagory.TabIndex = 5;
            btnDeleteCatagory.Text = "Delete";
            btnDeleteCatagory.UseVisualStyleBackColor = false;
            btnDeleteCatagory.Click += btnDeleteCatagory_Click;
            // 
            // CatagoryDataGrid
            // 
            CatagoryDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CatagoryDataGrid.Location = new Point(29, 369);
            CatagoryDataGrid.Name = "CatagoryDataGrid";
            CatagoryDataGrid.RowHeadersWidth = 200;
            CatagoryDataGrid.Size = new Size(1265, 401);
            CatagoryDataGrid.TabIndex = 6;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = SystemColors.ButtonHighlight;
            btnShowAll.FlatAppearance.BorderSize = 0;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.Location = new Point(1084, 201);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(277, 69);
            btnShowAll.TabIndex = 7;
            btnShowAll.Text = "Show ALL";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnShowAddProductPage
            // 
            btnShowAddProductPage.BackColor = SystemColors.ButtonHighlight;
            btnShowAddProductPage.FlatAppearance.BorderSize = 0;
            btnShowAddProductPage.FlatStyle = FlatStyle.Flat;
            btnShowAddProductPage.Location = new Point(1084, 37);
            btnShowAddProductPage.Name = "btnShowAddProductPage";
            btnShowAddProductPage.Size = new Size(277, 69);
            btnShowAddProductPage.TabIndex = 8;
            btnShowAddProductPage.Text = "Add Product";
            btnShowAddProductPage.UseVisualStyleBackColor = false;
            btnShowAddProductPage.Click += btnShowAddProductPage_Click;
            // 
            // FormCatagory
            // 
            AutoScaleDimensions = new SizeF(19F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1610, 1157);
            Controls.Add(btnShowAddProductPage);
            Controls.Add(btnShowAll);
            Controls.Add(CatagoryDataGrid);
            Controls.Add(btnDeleteCatagory);
            Controls.Add(btnSearchCatagory);
            Controls.Add(btnEditCatagory);
            Controls.Add(btnSaveCatagory);
            Controls.Add(TxtBoxCatagory);
            Controls.Add(CatagoryName);
            Font = new Font("Calibri", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormCatagory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCatagory";
            Load += FormCatagory_Load;
            ((System.ComponentModel.ISupportInitialize)CatagoryDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CatagoryName;
        private TextBox TxtBoxCatagory;
        private Button btnSaveCatagory;
        private Button btnEditCatagory;
        private Button btnSearchCatagory;
        private Button btnDeleteCatagory;
        private DataGridView CatagoryDataGrid;
        private Button btnShowAll;
        private Button btnShowAddProductPage;
    }
}
