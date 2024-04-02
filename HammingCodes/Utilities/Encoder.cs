namespace HammingCodes.Utilities
{
    public static class Encoder
    {
        public static Dictionary<string, int> EncodeData(Dictionary<string, int> data)
        {
            var count = data.Where(x => x.Key[3] == '1').Count(x => x.Value == 1);

            if(count % 2 == 1)
            {
                data["0001"] = FlipBinary.FlipBit(data["0001"]);
            }

            count = data.Where(x => x.Key[2] == '1').Count(x => x.Value == 1);

            if (count % 2 == 1)
            {
                data["0010"] = FlipBinary.FlipBit(data["0010"]);
            }

            count = data.Where(x => x.Key[1] == '1').Count(x => x.Value == 1);

            if (count % 2 == 1)
            {
                data["0100"] = FlipBinary.FlipBit(data["0100"]);
            }

            count = data.Where(x => x.Key[0] == '1').Count(x => x.Value == 1);

            if (count % 2 == 1)
            {
                data["1000"] = FlipBinary.FlipBit(data["1000"]);
            }

            count = data.Count(x => x.Value == '1');
            if (count % 2 == 1)
            {
                data["0000"] = FlipBinary.FlipBit(data["0000"]);
            }

            return data;
        }

        public static string GetErrorIndex(Dictionary<string, int> data)
        {
            var positiveBits = data.Where(x => x.Value == 1).Select(x => x.Key).ToList();

            var errorIndex = positiveBits[0];
            for (var i = 1; i < positiveBits.Count; i++)
            {
                errorIndex = BinaryConverter.XOR(errorIndex, positiveBits[i]);
            }

            return errorIndex;
        }

        public static Dictionary<string, int> DecodeData(Dictionary<string, int> data, string errorIndex)
        {
            data[errorIndex] = FlipBinary.FlipBit(data[errorIndex]);
            return data;
        }
    }
}
