namespace HammingCodes.Utilities
{
    public static class Writer
    {
        public static void WriteData(Dictionary<string, int> data, List<string>? errorIndexes = null, string? correctedIndex = null)
        {
            var count = 1;
            foreach (var item in data)
            {
                if (errorIndexes is not null && errorIndexes.Contains(item.Key))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (correctedIndex is not null && correctedIndex == item.Key)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (count % 4 == 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                else
                {
                    Console.Write($"{item.Key}: {item.Value} ");
                }
                count++;
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
    }
}
