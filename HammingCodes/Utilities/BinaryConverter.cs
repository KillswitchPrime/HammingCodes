namespace HammingCodes.Utilities
{
    public static class BinaryConverter
    {
        public static string ConvertToBinary(int number)
        {
            return Convert.ToString(number, 2).PadLeft(4, '0');
        }

        public static int ConvertToDecimal(string binary)
        {
            int decimalNumber = 0;
            int power = 0;
            foreach (int bit in binary.Reverse())
            {
                decimalNumber += bit * (int)Math.Pow(2, power);
                power++;
            }
            return decimalNumber;
        }

        public static string XOR(string binaryString1, string binaryString2)
        {
            if (binaryString1.Length != binaryString2.Length)
            {
                throw new ArgumentException("Binary strings must have the same length.");
            }

            var result = new char[binaryString1.Length];

            for (int i = 0; i < binaryString1.Length; i++)
            {
                result[i] = binaryString1[i] == binaryString2[i] ? '0' : '1';
            }

            return new string(result);
        }
    }
}
