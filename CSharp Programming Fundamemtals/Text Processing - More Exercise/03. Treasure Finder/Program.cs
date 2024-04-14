using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string message;
            string type;
            string coordinates;

            while ((message = Console.ReadLine()) != "find")
            {
                StringBuilder decrypted = new StringBuilder();
                int maxLength = Math.Max(keys.Length, message.Length);
                for (int i = 0; i < maxLength; i++)
                {
                    decrypted.Append((char)(message[i] - keys[i % keys.Length]));// NB! how to looping
                }

                int startIndexType = decrypted.ToString().IndexOf('&') + 1;
                int endIndexType = decrypted.ToString().IndexOf('&', startIndexType + 1);
                int typeLength = endIndexType - startIndexType;
                type = decrypted.ToString().Substring(startIndexType, typeLength);

                int startIndexCoordinates = decrypted.ToString().IndexOf('<') + 1;
                int endIndexCoordinates = decrypted.ToString().IndexOf('>');
                int coordinatesLength = endIndexCoordinates - startIndexCoordinates;
                coordinates = decrypted.ToString().Substring(startIndexCoordinates, coordinatesLength);
                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}