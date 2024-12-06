namespace PhoneShop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isConnected = DatabaseHelper.TestConnection();
            if (isConnected)
            {
                Console.WriteLine("Database connection successful!");
            }
            else
            {
                Console.WriteLine("Failed to connect to the database.");
            }

            // Proceed to run the form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormCatagory()); // Start your form after the test
        }

    }
}