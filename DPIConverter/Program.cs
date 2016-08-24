namespace DpiConverter
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using DpiConverter.Presenters;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPresenter());
        }
    }
}