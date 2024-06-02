using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = null, result = null;
            int resultInInt = 0;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "Finish")
                {
                    foreach (int element in numbers)
                    {
                        Console.Write($"{element} ");
                    }
                    break;
                }
                if (command.Contains("Add"))
                {
                    result = Regex.Match(command, @"-?\d+").Value;
                    resultInInt = Int32.Parse(result);
                    numbers.Add(resultInInt);
                }
                else if (command.Contains("Remove"))
                {
                    result = Regex.Match(command, @"-?\d+").Value;
                    resultInInt = Int32.Parse(result);
                    numbers.Remove(resultInInt);
                }
                else if (command.Contains("Replace"))
                {
                    var match = Regex.Match(command, @"-?\d+");
                    if (match.Success)
                    {
                        int valueToReplace = Int32.Parse(match.Value);

                        if (numbers.Contains(valueToReplace))
                        {
                            var replacementMatch = match.NextMatch();
                            if (replacementMatch.Success)
                            {
                                int replacementValue = Int32.Parse(replacementMatch.Value);
                                int indexToReplace = numbers.IndexOf(valueToReplace);
                                numbers[indexToReplace] = replacementValue;
                            }
                        }
                    }                                                        
                }
                else if (command.Contains("Collapse"))
                {
                    var match = Regex.Match(command, @"-?\d+");
                    if (match.Success)
                    {
                        int minValue = Int32.Parse(match.Value);
                        numbers.RemoveAll(x => x < minValue);
                    }
                }
            }
        }
    }
}