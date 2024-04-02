using HammingCodes.Utilities;

var random = new Random(37);
var numbers = Enumerable.Range(0, 16).Select(i => random.Next(2)).ToArray();
var data = new Dictionary<string, int>();

for(var i = 0; i < numbers.Length; i++)
{
    data.Add(BinaryConverter.ConvertToBinary(i), numbers[i]);
}

var encodedData = Encoder.EncodeData(data);

Console.WriteLine("Original data:");
Writer.WriteData(encodedData);

var errorIndexes = new List<string>();
var numberOfErrors = random.Next(0, 3);
for(var i = 0; i < numberOfErrors; i++)
{
    var intentionalErrorIndex = random.Next(0, 16);
    var errorKey = BinaryConverter.ConvertToBinary(intentionalErrorIndex);
    encodedData[errorKey] = FlipBinary.FlipBit(encodedData[errorKey]);
    errorIndexes.Add(errorKey);
}

Console.WriteLine("Data with errors:");
Writer.WriteData(encodedData, errorIndexes);

var errorIndex = Encoder.GetErrorIndex(encodedData);
Console.WriteLine($"Error index: {errorIndex}");
Console.WriteLine();

var decodedData = Encoder.DecodeData(encodedData, errorIndex);
Console.WriteLine("Error-corrected data:");
Writer.WriteData(decodedData, correctedIndex: errorIndex);