using System;
using System.Linq;
using MessageStream2;

namespace Tests
{
    public class MainClass
    {
        public static void Main()
        {
            byte[] messageBytes;
            //Test data
            bool orgBool = true;
            bool[] orgBoolArray = new bool[] { true, false };
            byte orgByte = 42;
            byte[] orgByteArray = new byte[] { 42, 24 };
            sbyte orgSByte = -42;
            sbyte[] orgSByteArray = new sbyte[] { -42, -24 };
            char orgChar = (char)42;
            char[] orgCharArray = new char[] { 'A', 'Z' };
            decimal orgDecimal = 1.1m;
            decimal[] orgDecimalArray = new decimal[] { 4.2m, 2.4m };
            double orgDouble = 1.1d;
            double[] orgDoubleArray = new double[] { 4.2d, 2.4d };
            float orgFloat = 1.1f;
            float[] orgFloatArray = new float[] { 4.2f, 2.4f };
            int orgInt = -42;
            int[] orgIntArray = new int[] { -4, -8, -15, -16, -23, -42 };
            uint orgUInt = 42;
            uint[] orgUIntArray = new uint[] { 4, 8, 15, 16, 23, 42 };
            long orgLong = -42;
            long[] orgLongArray = new long[] { -4, -8, -15, -16, -23, -42 };
            ulong orgULong = 42;
            ulong[] orgULongArray = new ulong[] { 4, 8, 15, 16, 23, 42 };
            short orgShort = -42;
            short[] orgShortArray = new short[] { -4, -8, -15, -16, -23, -42 };
            ushort orgUShort = 42;
            ushort[] orgUShortArray = new ushort[] { 4, 8, 15, 16, 23, 42 };
            string orgString = "Testing, testing, 123!";
            string[] orgStringArray = new string[]
            {
                //Git for ages 4 and up
                "DarkLight does not commit to master. Master commits to DarkLight.",
                "DarkLight once typed git pull --hard and dragged github's server room across the street.",
                "DarkLight's presence can cure cancer. Unfortunately his C# code gives it right back again.",
                //https://github.com/EugeneKay/git-jokes/blob/lulz/Jokes.txt
                "Commit early, commit often. A tip for version controlling - not for relationships",
                "Why did the commit cross the rebase? To git to the other repo",
                "Knock knock. Who's there? Git. Git-who? Sorry, 'who' is not a git command - did you mean 'show'?",
                "Be careful when rewriting history. It may push you to use the dark side of the --force",
                "git: Comitted for life",
                "git-blame: ruining friendships since 2006"
            };
            //Write
            using (MessageWriter mw = new MessageWriter())
            {
                mw.Write<bool>(orgBool);
                mw.Write<bool[]>(orgBoolArray);
                mw.Write<byte>(orgByte);
                mw.Write<byte[]>(orgByteArray);
                mw.Write<sbyte>(orgSByte);
                mw.Write<sbyte[]>(orgSByteArray);
                mw.Write<char>(orgChar);
                mw.Write<char[]>(orgCharArray);
                mw.Write<decimal>(orgDecimal);
                mw.Write<decimal[]>(orgDecimalArray);
                mw.Write<double>(orgDouble);
                mw.Write<double[]>(orgDoubleArray);
                mw.Write<float>(orgFloat);
                mw.Write<float[]>(orgFloatArray);
                mw.Write<int>(orgInt);
                mw.Write<int[]>(orgIntArray);
                mw.Write<uint>(orgUInt);
                mw.Write<uint[]>(orgUIntArray);
                mw.Write<long>(orgLong);
                mw.Write<long[]>(orgLongArray);
                mw.Write<ulong>(orgULong);
                mw.Write<ulong[]>(orgULongArray);
                mw.Write<short>(orgShort);
                mw.Write<short[]>(orgShortArray);
                mw.Write<ushort>(orgUShort);
                mw.Write<ushort[]>(orgUShortArray);
                mw.Write<string>(orgString);
                mw.Write<string[]>(orgStringArray);
                messageBytes = mw.GetMessageBytes();
            }
            //Read
            bool testBool;
            bool[] testBoolArray;
            byte testByte;
            byte[] testByteArray;
            sbyte testSByte;
            sbyte[] testSByteArray;
            char testChar;
            char[] testCharArray;
            decimal testDecimal;
            decimal[] testDecimalArray;
            double testDouble;
            double[] testDoubleArray;
            float testFloat;
            float[] testFloatArray;
            int testInt;
            int[] testIntArray;
            uint testUInt;
            uint[] testUIntArray;
            long testLong;
            long[] testLongArray;
            ulong testULong;
            ulong[] testULongArray;
            short testShort;
            short[] testShortArray;
            ushort testUShort;
            ushort[] testUShortArray;
            string testString;
            string[] testStringArray;
            using (MessageReader mr = new MessageReader(messageBytes))
            {
                testBool = mr.Read<bool>();
                testBoolArray = mr.Read<bool[]>();
                testByte = mr.Read<byte>();
                testByteArray = mr.Read<byte[]>();
                testSByte = mr.Read<sbyte>();
                testSByteArray = mr.Read<sbyte[]>();
                testChar = mr.Read<char>();
                testCharArray = mr.Read<char[]>();
                testDecimal = mr.Read<decimal>();
                testDecimalArray = mr.Read<decimal[]>();
                testDouble = mr.Read<double>();
                testDoubleArray = mr.Read<double[]>();
                testFloat = mr.Read<float>();
                testFloatArray = mr.Read<float[]>();
                testInt = mr.Read<int>();
                testIntArray = mr.Read<int[]>();
                testUInt = mr.Read<uint>();
                testUIntArray = mr.Read<uint[]>();
                testLong = mr.Read<long>();
                testLongArray = mr.Read<long[]>();
                testULong = mr.Read<ulong>();
                testULongArray = mr.Read<ulong[]>();
                testShort = mr.Read<short>();
                testShortArray = mr.Read<short[]>();
                testUShort = mr.Read<ushort>();
                testUShortArray = mr.Read<ushort[]>();
                testString = mr.Read<string>();
                testStringArray = mr.Read<string[]>();
            }
            Console.WriteLine("testBool: " + (orgBool == testBool));
            Console.WriteLine("testBoolArray: " + orgBoolArray.SequenceEqual(testBoolArray));
            Console.WriteLine("testByte: " + (orgByte == testByte));
            Console.WriteLine("testByteArray: " + orgByteArray.SequenceEqual(testByteArray));
            Console.WriteLine("testSByte: " + (orgSByte == testSByte));
            Console.WriteLine("testSByteArray: " + orgSByteArray.SequenceEqual(testSByteArray));
            Console.WriteLine("testChar: " + (orgChar == testChar));
            Console.WriteLine("testCharArray: " + orgCharArray.SequenceEqual(testCharArray));
            Console.WriteLine("testDecimal: " + (orgDecimal == testDecimal));
            Console.WriteLine("testDecimalArray: " + orgDecimalArray.SequenceEqual(testDecimalArray));
            Console.WriteLine("testDouble: " + (orgDouble == testDouble));
            Console.WriteLine("testDoubleArray: " + orgDoubleArray.SequenceEqual(testDoubleArray));
            Console.WriteLine("testFloat: " + (orgFloat == testFloat));
            Console.WriteLine("testFloatArray: " + orgFloatArray.SequenceEqual(testFloatArray));
            Console.WriteLine("testInt: " + (orgInt == testInt));
            Console.WriteLine("testIntArray: " + orgIntArray.SequenceEqual(testIntArray));
            Console.WriteLine("testUInt: " + (orgUInt == testUInt));
            Console.WriteLine("testUIntArray: " + orgUIntArray.SequenceEqual(testUIntArray));
            Console.WriteLine("testLong: " + (orgLong == testLong));
            Console.WriteLine("testLongArray: " + orgLongArray.SequenceEqual(testLongArray));
            Console.WriteLine("testULong: " + (orgULong == testULong));
            Console.WriteLine("testULongArray: " + orgULongArray.SequenceEqual(testULongArray));
            Console.WriteLine("testShort: " + (orgShort == testShort));
            Console.WriteLine("testShortArray: " + orgShortArray.SequenceEqual(testShortArray));
            Console.WriteLine("testUShort: " + (orgUShort == testUShort));
            Console.WriteLine("testUShortArray: " + orgUShortArray.SequenceEqual(testUShortArray));
            Console.WriteLine("testString: " + (orgString == testString));
            Console.WriteLine("testStringArray: " + orgStringArray.SequenceEqual(testStringArray));
            Console.WriteLine("");
            Console.WriteLine("===");
            Console.WriteLine(testString);
            Console.WriteLine("===");
            foreach (String value in testStringArray)
            {
                Console.WriteLine(value);
            }
            System.IO.File.WriteAllBytes("Message.bin", messageBytes);
        }
    }
}

