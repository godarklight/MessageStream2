using System;
using System.IO;

namespace MessageStream2
{
    internal class Writers
    {

        internal static void WriteBool(object inputData, Stream outputStream)
        {
            outputStream.Write(BitConverter.GetBytes((bool)inputData), 0, 1);
        }

        internal static void WriteBoolArray(object inputData, Stream outputStream)
        {
            bool[] data = (bool[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (bool value in data)
            {
                WriteBool(value, outputStream);
            }            
        }

        internal static void WriteByte(object inputData, Stream outputStream)
        {
            outputStream.WriteByte((byte)inputData);
        }

        internal static void WriteByteArray(object inputData, Stream outputStream)
        {
            byte[] data = (byte[])inputData;
            WriteInt(data.Length, outputStream);
            outputStream.Write(data, 0, data.Length);
        }

        //SByte casts to Byte. This is the correct approach.
        internal static void WriteSByte(object inputData, Stream outputStream)
        {
            WriteByte((byte)(sbyte)inputData, outputStream);
        }

        internal static void WriteSByteArray(object inputData, Stream outputStream)
        {
            sbyte[] data = (sbyte[])inputData;
            byte[] writeData = new byte[data.Length];
            Buffer.BlockCopy(data, 0, writeData, 0, writeData.Length);
            WriteByteArray(writeData, outputStream);
        }

        internal static void WriteChar(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((char)inputData)), 0, 2);
        }

        internal static void WriteCharArray(object inputData, Stream outputStream)
        {
            char[] data = (char[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (char value in data)
            {
                WriteChar(value, outputStream);
            }            
        }

        internal static void WriteDecimal(object inputData, Stream outputStream)
        {
            decimal data = (decimal)inputData;
            int[] dataArray = Decimal.GetBits(data);
            WriteInt(dataArray[0], outputStream);
            WriteInt(dataArray[1], outputStream);
            WriteInt(dataArray[2], outputStream);
            WriteInt(dataArray[3], outputStream);
        }

        internal static void WriteDecimalArray(object inputData, Stream outputStream)
        {
            decimal[] data = (decimal[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (decimal value in data)
            {
                WriteDecimal(value, outputStream);
            }   
        }

        internal static void WriteDouble(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((double)inputData)), 0, 8);
        }

        internal static void WriteDoubleArray(object inputData, Stream outputStream)
        {
            double[] data = (double[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (double value in data)
            {
                WriteDouble(value, outputStream);
            }            
        }

        internal static void WriteFloat(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((float)inputData)), 0, 4);
        }

        internal static void WriteFloatArray(object inputData, Stream outputStream)
        {
            float[] data = (float[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (float value in data)
            {
                WriteFloat(value, outputStream);
            }            
        }

        internal static void WriteInt(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((int)inputData)), 0, 4);
        }

        internal static void WriteIntArray(object inputData, Stream outputStream)
        {
            int[] data = (int[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (int value in data)
            {
                WriteInt(value, outputStream);
            }            
        }

        internal static void WriteUInt(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((uint)inputData)), 0, 4);
        }

        internal static void WriteUIntArray(object inputData, Stream outputStream)
        {
            uint[] data = (uint[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (uint value in data)
            {
                WriteUInt(value, outputStream);
            }            
        }

        internal static void WriteLong(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((long)inputData)), 0, 8);
        }

        internal static void WriteLongArray(object inputData, Stream outputStream)
        {
            long[] data = (long[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (long value in data)
            {
                WriteLong(value, outputStream);
            }            
        }

        internal static void WriteULong(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((ulong)inputData)), 0, 8);
        }

        internal static void WriteULongArray(object inputData, Stream outputStream)
        {
            ulong[] data = (ulong[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (ulong value in data)
            {
                WriteULong(value, outputStream);
            }            
        }

        internal static void WriteShort(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((short)inputData)), 0, 2);
        }

        internal static void WriteShortArray(object inputData, Stream outputStream)
        {
            short[] data = (short[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (short value in data)
            {
                WriteShort(value, outputStream);
            }            
        }

        internal static void WriteUShort(object inputData, Stream outputStream)
        {
            outputStream.Write(Common.ReverseIfLittleEndian(BitConverter.GetBytes((ushort)inputData)), 0, 2);
        }

        internal static void WriteUShortArray(object inputData, Stream outputStream)
        {
            ushort[] data = (ushort[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (ushort value in data)
            {
                WriteUShort(value, outputStream);
            }            
        }

        internal static void WriteString(object inputData, Stream outputStream)
        {
            string data = (string)inputData;
            if (data == null)
            {
                data = "";
            }
            byte[] stringBytes = Common.utf8Encoder.GetBytes(data);
            WriteByteArray(stringBytes, outputStream);
        }

        internal static void WriteStringArray(object inputData, Stream outputStream)
        {
            string[] data = (string[])inputData;
            WriteInt(data.Length, outputStream);
            foreach (string value in data)
            {
                WriteString(value, outputStream);
            }            
        }
    }
}

