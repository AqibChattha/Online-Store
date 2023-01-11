using Online_Store.UI;
using System;
using System.Windows.Forms;

namespace Online_Store
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // We start the application by displaying the mainform that has the products gallery for customers.
            Application.Run(new MainForm());
        }
    }
}
