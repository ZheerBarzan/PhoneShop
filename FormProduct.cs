using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneShop
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }


        private void LoadCatagories()
        {
            string query = "SELECT CatagoryName FROM Catagory";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            CatagoryComboBox.Items.Add(reader["CatagoryName"].ToString());
                        }

                        reader.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }


                }

            }
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadCatagories();
            LoadAllProducts();
        }

        private void ProductPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }

        }


        private void AddProduct()
        {
            // Get selected category ID
            string getCategoryIDQuery = "SELECT CatagoryID FROM Catagory WHERE CatagoryName = @CatagoryName";
            int categoryID;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(getCategoryIDQuery, connection))
                {
                    command.Parameters.AddWithValue("@CatagoryName", CatagoryComboBox.Text);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Selected category not found!");
                            return;
                        }

                        categoryID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to retrieve category ID: {ex.Message}");
                        return;
                    }
                }
            }

            // Insert product into the database
            string query = "INSERT INTO Product (ProductName, ProductPrice, CatagoryID) VALUES (@ProductName, @ProductPrice, @CatagoryID)";
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", ProductNameTextBox.Text);
                    command.Parameters.AddWithValue("@ProductPrice", ProductPriceTextBox.Text);
                    command.Parameters.AddWithValue("@CatagoryID", categoryID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product added successfully!");
                        ClearInputFileds();
                        // Optionally reload data grid here
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding product: {ex.Message}");
                    }
                }
            }
        }


        private void ClearInputFileds()
        {
            ProductNameTextBox.Clear();
            ProductPriceTextBox.Clear();
            CatagoryComboBox.SelectedIndex = -1;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTextBox.Text.Trim();
            string productPriceText = ProductPriceTextBox.Text.Trim();
            string category = CatagoryComboBox.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Product name is required!");
                return;
            }
            if (!decimal.TryParse(productPriceText, out decimal productPrice))
            {
                MessageBox.Show("Please enter a valid product price!");
                return;
            }
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category!");
                return;
            }

            // Add the product
            AddProduct();
        }


        private void LoadAllProducts()
        {
            string query = @"
        SELECT p.ProductName, p.ProductPrice, c.CatagoryName
        FROM Product p
        JOIN Catagory c ON p.CatagoryID = c.CatagoryID";


            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            ProductDataGrid.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No products found!");
                            ProductDataGrid.DataSource = null;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading products: {ex.Message}");
                    }

                }
            }
        }

        private void btnShowAllPoduct_Click(object sender, EventArgs e)
        {
            LoadAllProducts();
        }

        private void SearchProducts(string productNAme)
        {
            string query = @"
        SELECT p.ProductName, p.ProductPrice, c.CatagoryName
        FROM Product p
        JOIN Catagory c ON p.CatagoryID = c.CatagoryID
        WHERE p.ProductName LIKE @ProductName";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", "%" + productNAme + "%");

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            ProductDataGrid.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No products found!");
                            ProductDataGrid.DataSource = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error searching products: {ex.Message}");
                    }

                }
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please enter a product name to search!");
                return;
            }

            SearchProducts(productName);

        }

        private void EditProduct()
        {
            string query = @"
        UPDATE Product
        SET ProductName = @ProductName,
            ProductPrice = @ProductPrice,
            CatagoryID = (SELECT CatagoryID FROM Catagory WHERE CatagoryName = @CatagoryName)
        WHERE ProductName = @OriginalProductName";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", ProductNameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@ProductPrice", ProductPriceTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@CatagoryName", CatagoryComboBox.Text.Trim());
                    command.Parameters.AddWithValue("@OriginalProductName", ProductDataGrid.SelectedRows[0].Cells["ProductName"].Value.ToString());

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully!");
                            ClearInputFileds();
                            LoadAllProducts(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Product update failed. Please check the details.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating product: {ex.Message}");
                    }
                }
            }
        }

        private void ProductDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (ProductDataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ProductDataGrid.SelectedRows[0];
                ProductNameTextBox.Text = selectedRow.Cells["ProductName"].Value.ToString();
                ProductPriceTextBox.Text = selectedRow.Cells["ProductPrice"].Value.ToString();
                CatagoryComboBox.Text = selectedRow.Cells["CatagoryName"].Value.ToString();
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            if (ProductDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit!");
                return;
            }

            string productName = ProductNameTextBox.Text.Trim();
            string productPriceText = ProductPriceTextBox.Text.Trim();
            string category = CatagoryComboBox.Text.Trim();


            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Product name is required!");
                return;
            }
            if (!decimal.TryParse(productPriceText, out decimal productPrice))
            {
                MessageBox.Show("Please enter a valid product price!");
                return;
            }
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please select a category!");
                return;
            }
            EditProduct();
        }

        private void DeleteProduct()
        {
            string query = "DELETE FROM Product WHERE ProductName = @ProductName";


            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    string selectedProductName = ProductDataGrid.SelectedRows[0].Cells["ProductName"].Value.ToString();
                    command.Parameters.AddWithValue("@ProductName", selectedProductName);


                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product deleted successfully!");
                            ClearInputFileds();
                            LoadAllProducts();
                        }
                        else
                        {
                            MessageBox.Show("Product delete failed. Please check the details.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}");
                    }
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (ProductDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                   "Are you sure you want to delete this Product?",
                   "Delete product",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                DeleteProduct();
            }
        }
    }
}