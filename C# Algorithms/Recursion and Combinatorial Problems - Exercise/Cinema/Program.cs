using System;
using System.Linq;
using System.Collections.Generic;

namespace Cinema
{
    internal class Program
    {
        private static List<string> fixedPeople;
        private static string[] people;
        private static bool[] used;
        static void Main(string[] args)
        {
            fixedPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[fixedPeople.Count];
            used = new bool[fixedPeople.Count];

            string input;
            while ((input = Console.ReadLine()) != "generate")
            {
                var tokens = input.Split(" - ");
                var name = tokens[0];
                var position = int.Parse(tokens[1]);

                people[position - 1] = name;
                used[position - 1] = true;

                fixedPeople.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= fixedPeople.Count)
            {
                Print();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < fixedPeople.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Print()
        {
            var peopleIndex = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (!used[i])
                {
                    people[i] = fixedPeople[peopleIndex++];
                }
            }

            Console.WriteLine(String.Join(' ', people));
        }

        private static void Swap(int first, int second)
        {
            var temp = fixedPeople[first];
            fixedPeople[first] = fixedPeople[second];
            fixedPeople[second] = temp;
        }
    }
}
