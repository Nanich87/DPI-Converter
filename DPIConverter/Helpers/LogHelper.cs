namespace DpiConverter.Helpers
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    internal  static class LogHelper
    {
        public static void Log(string message)
        {
            MessageBox.Show(message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}