namespace SerialPortTerminal.Helpers
{
    using System;
    using System.Linq;
    using System.Text;

    internal class DataConversionHelper
    {
        public static byte[] HexStringToByteArray(string inputString)
        {
            inputString = inputString.Replace(" ", string.Empty);
            byte[] buffer = new byte[inputString.Length / 2];

            for (int i = 0; i < inputString.Length; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(inputString.Substring(i, 2), 16);
            }

            return buffer;
        }

        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder hexString = new StringBuilder(data.Length * 3);

            foreach (byte piece in data)
            {
                hexString.Append(Convert.ToString(piece, 16).PadLeft(2, '0').PadRight(3, ' '));
            }

            return hexString.ToString().ToUpper();
        }
    }
}