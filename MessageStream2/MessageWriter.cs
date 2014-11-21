using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MessageStream2
{
    public class MessageWriter : IDisposable
    {
        //Static

        private static Dictionary<Type, Action<object, Stream>> registeredTypes;

        static MessageWriter()
        {
            registeredTypes = new Dictionary<Type, Action<object, Stream>>();
            registeredTypes.Add(typeof(bool), Writers.WriteBool);
            registeredTypes.Add(typeof(bool[]), Writers.WriteBoolArray);
            registeredTypes.Add(typeof(byte), Writers.WriteByte);
            registeredTypes.Add(typeof(byte[]), Writers.WriteByteArray);
            registeredTypes.Add(typeof(sbyte), Writers.WriteSByte);
            registeredTypes.Add(typeof(sbyte[]), Writers.WriteSByteArray);
            registeredTypes.Add(typeof(char), Writers.WriteChar);
            registeredTypes.Add(typeof(char[]), Writers.WriteCharArray);
            registeredTypes.Add(typeof(decimal), Writers.WriteDecimal);
            registeredTypes.Add(typeof(decimal[]), Writers.WriteDecimalArray);
            registeredTypes.Add(typeof(double), Writers.WriteDouble);
            registeredTypes.Add(typeof(double[]), Writers.WriteDoubleArray);
            registeredTypes.Add(typeof(float), Writers.WriteFloat);
            registeredTypes.Add(typeof(float[]), Writers.WriteFloatArray);
            registeredTypes.Add(typeof(int), Writers.WriteInt);
            registeredTypes.Add(typeof(int[]), Writers.WriteIntArray);
            registeredTypes.Add(typeof(uint), Writers.WriteUInt);
            registeredTypes.Add(typeof(uint[]), Writers.WriteUIntArray);
            registeredTypes.Add(typeof(long), Writers.WriteLong);
            registeredTypes.Add(typeof(long[]), Writers.WriteLongArray);
            registeredTypes.Add(typeof(ulong), Writers.WriteULong);
            registeredTypes.Add(typeof(ulong[]), Writers.WriteULongArray);
            registeredTypes.Add(typeof(short), Writers.WriteShort);
            registeredTypes.Add(typeof(short[]), Writers.WriteShortArray);
            registeredTypes.Add(typeof(ushort), Writers.WriteUShort);
            registeredTypes.Add(typeof(ushort[]), Writers.WriteUShortArray);
            registeredTypes.Add(typeof(string), Writers.WriteString);
            registeredTypes.Add(typeof(string[]), Writers.WriteStringArray);
        }

        public static void RegisterType<T>(Action<object,Stream> handler)
        {
            if (registeredTypes.ContainsKey(typeof(T)))
            {
                throw new IOException("Type already registered");
            }
            registeredTypes.Add(typeof(T), handler);
        }

        //Instance
        private MemoryStream messageStream;

        public MessageWriter()
        {
            messageStream = new MemoryStream();
        }

        public void Write<T>(T input)
        {
            if (!registeredTypes.ContainsKey(typeof(T)))
            {
                throw new IOException("Type not supported");
            }
            registeredTypes[typeof(T)]((object)input, messageStream);
        }

        public byte[] GetMessageBytes()
        {
            return messageStream.ToArray();
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

