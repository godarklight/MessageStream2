using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MessageStream2
{
    public class MessageReader : IDisposable
    {
        //Static
        private static Dictionary<Type, Func<Stream, object>> registeredTypes;

        static MessageReader()
        {
            registeredTypes = new Dictionary<Type, Func<Stream, object>>();
            registeredTypes.Add(typeof(bool), Readers.ReadBool);
            registeredTypes.Add(typeof(bool[]), Readers.ReadBoolArray);
            registeredTypes.Add(typeof(byte), Readers.ReadByte);
            registeredTypes.Add(typeof(byte[]), Readers.ReadByteArray);
            registeredTypes.Add(typeof(sbyte), Readers.ReadSByte);
            registeredTypes.Add(typeof(sbyte[]), Readers.ReadSByteArray);
            registeredTypes.Add(typeof(char), Readers.ReadChar);
            registeredTypes.Add(typeof(char[]), Readers.ReadCharArray);
            registeredTypes.Add(typeof(decimal), Readers.ReadDecimal);
            registeredTypes.Add(typeof(decimal[]), Readers.ReadDecimalArray);
            registeredTypes.Add(typeof(double), Readers.ReadDouble);
            registeredTypes.Add(typeof(double[]), Readers.ReadDoubleArray);
            registeredTypes.Add(typeof(float), Readers.ReadFloat);
            registeredTypes.Add(typeof(float[]), Readers.ReadFloatArray);
            registeredTypes.Add(typeof(int), Readers.ReadInt);
            registeredTypes.Add(typeof(int[]), Readers.ReadIntArray);
            registeredTypes.Add(typeof(uint), Readers.ReadUInt);
            registeredTypes.Add(typeof(uint[]), Readers.ReadUIntArray);
            registeredTypes.Add(typeof(long), Readers.ReadLong);
            registeredTypes.Add(typeof(long[]), Readers.ReadLongArray);
            registeredTypes.Add(typeof(ulong), Readers.ReadULong);
            registeredTypes.Add(typeof(ulong[]), Readers.ReadULongArray);
            registeredTypes.Add(typeof(short), Readers.ReadShort);
            registeredTypes.Add(typeof(short[]), Readers.ReadShortArray);
            registeredTypes.Add(typeof(ushort), Readers.ReadUShort);
            registeredTypes.Add(typeof(ushort[]), Readers.ReadUShortArray);
            registeredTypes.Add(typeof(string), Readers.ReadString);
            registeredTypes.Add(typeof(string[]), Readers.ReadStringArray);
        }

        public static void RegisterType<T>(Func<Stream, object> handler)
        {
            if (registeredTypes.ContainsKey(typeof(T)))
            {
                throw new IOException("Type already registered");
            }
            registeredTypes.Add(typeof(T), handler);
        }

        //Instance
        private MemoryStream messageStream;

        public MessageReader(byte[] messageData)
        {
            if (messageData == null)
            {
                throw new NullReferenceException("Message reader cannot be instantated with an empty byte[]");
            }
            messageStream = new MemoryStream(messageData);
        }

        public T Read<T>()
        {
            if (!registeredTypes.ContainsKey(typeof(T)))
            {
                throw new IOException("Type not supported");
            }
            return (T)registeredTypes[typeof(T)](messageStream);
        }


        public void Dispose()
        {
            if (messageStream != null)
            {
                messageStream.Dispose();
            }
        }
    }
}

