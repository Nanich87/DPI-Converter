namespace DpiConverter.Helpers
{
    using System.Windows.Forms;

    internal  static class LogHelper
    {
        public static void Error(string message)
        {
            MessageBox.Show(message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Log(string message)
        {
            MessageBox.Show(message, "Грешка:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}