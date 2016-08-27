namespace DpiConverter.Helpers
{
    using System;
    using System.Linq;
    using System.Text;

    internal static class StationHelper
    {
        public static string ParseNumber(string pointName)
        {
            StringBuilder number = new StringBuilder();

            for (int i = 0; i < pointName.Length; i++)
            {
                if (char.IsDigit(pointName[i]))
                {
                    number.Append(pointName[i]);
                }
            }

            return number.ToString();
        }

        public static string ParseCode(string pointName)
        {
            StringBuilder code = new StringBuilder();

            for (int i = 0; i < pointName.Length; i++)
            {
                if (char.IsLetter(pointName[i]))
                {
                    code.Append(pointName[i]);
                }
                else
                {
                    break;
                }
            }

            return code.ToString();
        }
    }
}