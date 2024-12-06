using Microsoft.Data.SqlClient;
using System.Data;

namespace PhoneShop
{
    public partial class FormCatagory : Form
    {
        public FormCatagory()
        {
            InitializeComponent();
        }



        private void LoadData()
        {
            string query = "SELECT c.CatagoryName, p.ProductName, p.ProductPrice " +
                           "FROM Catagory c " +
                           "JOIN Product p ON c.CatagoryID = p.CatagoryID";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);  // Fill the DataTable with data from the database

                // Check if dataTable has rows (i.e., data)
                if (dataTable.Rows.Count > 0)
                {
                    CatagoryDataGrid.DataSource = dataTable;  // Bind data to DataGridView
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
        }


        private void FormCatagory_Load(object sender, EventArgs e)
        {
            if (DatabaseHelper.TestConnection())
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Failed to connect to the database.");
            }
        }

        private void btnSaveCatagory_Click(object sender, EventArgs e)
        {
            string catagoryName = TxtBoxCatagory.Text.Trim();

            if (string.IsNullOrEmpty(catagoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            // Check if the category already exists
            string checkQuery = "SELECT COUNT(*) FROM Catagory WHERE CatagoryName = @CatagoryName";
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@CatagoryName", catagoryName);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("This category already exists.");
                            return;
                        }

                        // Insert new category
                        string insertQuery = "INSERT INTO Catagory (CatagoryName) VALUES (@CatagoryName)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@CatagoryName", catagoryName);
                            insertCommand.ExecuteNonQuery();
                            MessageBox.Show("Category saved successfully.");
                            TxtBoxCatagory.Clear();
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save category: {ex.Message}");
                    }
                }
            }
        }






        private bool DoesCatagoryExist(string catagoryName)
        {
            string query = "SELECT COUNT(*) FROM CATAGORY WHERE CatagoryName = @CatagoryName";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CatagoryName", catagoryName);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Catagory exists: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        private void UpdateCatagory(string oldCatagoryName, string newCatagoryName)
        {
            string query = "UPDATE Catagory SET CatagoryName = @newCatagoryName WHERE CatagoryName = @oldCatagoryName";


            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newCatagoryName", newCatagoryName);
                    command.Parameters.AddWithValue("@oldCatagoryName", oldCatagoryName);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Catagory updated successfully.");
                            TxtBoxCatagory.Clear();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Catagory not found.");
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to update catagory: {ex.Message}");
                    }
                }
            }
        }

        private void btnEditCatagory_Click(object sender, EventArgs e)
        {
            string oldCatagoryName = TxtBoxCatagory.Text.Trim();

            if (string.IsNullOrEmpty(oldCatagoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            if (DoesCatagoryExist(oldCatagoryName))
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to update this category?",
                    "Update Category",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


                if (dialogResult == DialogResult.Yes)
                {
                    string newCatagoryName = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter the new category name:",
                        "Update Category",
                        oldCatagoryName);

                    if (!string.IsNullOrEmpty(newCatagoryName) && newCatagoryName != oldCatagoryName)
                    {
                        UpdateCatagory(oldCatagoryName, newCatagoryName);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid new category name.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Catagory not found.");
            }

        }


        private void DeleteCatagory(string catagoryName)
        {

            string query = "DELETE FROM Catagory WHERE CatagoryName = @CatagoryName";

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CatagoryName", catagoryName);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Catagory deleted successfully.");
                            TxtBoxCatagory.Clear();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Catagory not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete catagory: {ex.Message}");

                    }
                }
            }
        }
        private void btnDeleteCatagory_Click(object sender, EventArgs e)
        {
            string catagoryNameToDelete = TxtBoxCatagory.Text.Trim();

            if (string.IsNullOrEmpty(catagoryNameToDelete))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }


            if (DoesCatagoryExist(catagoryNameToDelete))
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to delete this category?",
                    "Delete Category",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);



                if (dialogResult == DialogResult.Yes)
                {
                    DeleteCatagory(catagoryNameToDelete);
                }
            }
            else
            {
                MessageBox.Show("Catagory not found.");
            }


        }


        private void SearchCatagory(string catagoryName)
        {
            string query = "SELECT c.CatagoryName, p.ProductName, p.ProductPrice " +
                   "FROM Catagory c " +
                   "JOIN Product p ON c.CatagoryID = p.CatagoryID " +
                   "WHERE c.CatagoryName = @CatagoryName";


            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CatagoryName", catagoryName);


                    try
                    {
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            CatagoryDataGrid.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                            CatagoryDataGrid.DataSource = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to search catagory: {ex.Message}");
                    }
                }
            }
        }

        private void btnSearchCatagory_Click(object sender, EventArgs e)
        {
            string catagoryName = TxtBoxCatagory.Text.Trim();

            if (string.IsNullOrEmpty(catagoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            if (DoesCatagoryExist(catagoryName))
            {
                SearchCatagory(catagoryName);
            }
            else
            {
                MessageBox.Show("Catagory not found.");

            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnShowAddProductPage_Click(object sender, EventArgs e)
        {
            FormProduct formProduct = new FormProduct();
            formProduct.Show(); 
        }
    }

}