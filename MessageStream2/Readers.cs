using System;
using System.IO;

namespace MessageStream2
{
    internal class Readers
    {
        private static byte[] GetBytesFromStream(Stream inputStream, int length)
        {
            byte[] returnBytes = new byte[length];
            if ((inputStream.Position + length) > inputStream.Length)
            {
                throw new IOException("Cannot read past the end of the stream!");
            }
            while (length > 0)
            {
                length -= inputStream.Read(returnBytes, returnBytes.Length - length, length);
            }
            return returnBytes;
        }

        internal static object ReadBool(Stream inputStream)
        {
            return BitConverter.ToBoolean(GetBytesFromStream(inputStream, 1), 0);
        }

        internal static object ReadBoolArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            bool[] returnArray = new bool[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (bool)ReadBool(inputStream);
            }
            return returnArray;
        }

        internal static object ReadByte(Stream inputStream)
        {
            byte[] returnBytes = GetBytesFromStream(inputStream, 1);
            return returnBytes[0];
        }

        internal static object ReadByteArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            return GetBytesFromStream(inputStream, arrayLength);
        }

        internal static object ReadSByte(Stream inputStream)
        {
            return (sbyte)(byte)ReadByte(inputStream);
        }

        internal static sbyte[] ReadSByteArray(Stream inputStream)
        {
            byte[] data = (byte[])ReadByteArray(inputStream);
            sbyte[] returnArray = new sbyte[data.Length];
            Buffer.BlockCopy(data, 0, returnArray, 0, returnArray.Length);
            return returnArray;
        }

        internal static object ReadChar(Stream inputStream)
        {
            return BitConverter.ToChar(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 2)), 0);
        }

        internal static object ReadCharArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            char[] returnArray = new char[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (char)ReadChar(inputStream);
            }
            return returnArray;
        }

        internal static object ReadDecimal(Stream inputStream)
        {
            int[] arrayData = new int[4];
            arrayData[0] = (int)ReadInt(inputStream);
            arrayData[1] = (int)ReadInt(inputStream);
            arrayData[2] = (int)ReadInt(inputStream);
            arrayData[3] = (int)ReadInt(inputStream);
            return new decimal(arrayData);
        }

        internal static object ReadDecimalArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            decimal[] returnArray = new decimal[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (decimal)ReadDecimal(inputStream);
            }
            return returnArray;
        }

        internal static object ReadDouble(Stream inputStream)
        {
            return BitConverter.ToDouble(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 8)), 0);
        }

        internal static object ReadDoubleArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            double[] returnArray = new double[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (double)ReadDouble(inputStream);
            }
            return returnArray;
        }

        internal static object ReadFloat(Stream inputStream)
        {
            return BitConverter.ToSingle(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 4)), 0);
        }

        internal static object ReadFloatArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            float[] returnArray = new float[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (float)ReadFloat(inputStream);
            }
            return returnArray;
        }

        internal static object ReadInt(Stream inputStream)
        {
            return BitConverter.ToInt32(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 4)), 0);
        }

        internal static object ReadIntArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            int[] returnArray = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (int)ReadInt(inputStream);
            }
            return returnArray;
        }

        internal static object ReadUInt(Stream inputStream)
        {
            return BitConverter.ToUInt32(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 4)), 0);
        }

        internal static object ReadUIntArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            uint[] returnArray = new uint[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (uint)ReadUInt(inputStream);
            }
            return returnArray;
        }

        internal static object ReadLong(Stream inputStream)
        {
            return BitConverter.ToInt64(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 8)), 0);
        }

        internal static object ReadLongArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            long[] returnArray = new long[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (long)ReadLong(inputStream);
            }
            return returnArray;
        }

        internal static object ReadULong(Stream inputStream)
        {
            return BitConverter.ToUInt64(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 8)), 0);
        }

        internal static object ReadULongArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            ulong[] returnArray = new ulong[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (ulong)ReadULong(inputStream);
            }
            return returnArray;
        }

        internal static object ReadShort(Stream inputStream)
        {
            return BitConverter.ToInt16(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 2)), 0);
        }

        internal static object ReadShortArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            short[] returnArray = new short[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (short)ReadShort(inputStream);
            }
            return returnArray;
        }

        internal static object ReadUShort(Stream inputStream)
        {
            return BitConverter.ToUInt16(Common.ReverseIfLittleEndian(GetBytesFromStream(inputStream, 2)), 0);
        }

        internal static object ReadUShortArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            ushort[] returnArray = new ushort[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (ushort)ReadUShort(inputStream);
            }
            return returnArray;
        }

        internal static object ReadString(Stream inputStream)
        {
            return Common.utf8Encoder.GetString((byte[])ReadByteArray(inputStream));
        }

        internal static object ReadStringArray(Stream inputStream)
        {
            int arrayLength = (int)ReadInt(inputStream);
            string[] returnArray = new string[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = (string)ReadString(inputStream);
            }
            return returnArray;
        }
    }
}

