using System;
using System.Text;

namespace MessageStream2
{
    internal class Common
    {
        internal static UTF8Encoding utf8Encoder = new UTF8Encoding();

        internal static byte[] ReverseIfLittleEndian(byte[] input)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(input);
            }
            return input;
        }
    }
}

