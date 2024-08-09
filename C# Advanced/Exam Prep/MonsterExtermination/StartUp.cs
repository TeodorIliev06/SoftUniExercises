using Microsoft.VisualBasic;
using System;

namespace MonsterExtermination;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] firstSeq = ReadIntArr();
        Queue<int> armors = new(firstSeq);

        int[] secondSeq = ReadIntArr();
        Stack<int> strikingImpacts = new(secondSeq);

        int killedMonsters = 0;
        while (armors.Any() && strikingImpacts.Any())
        {
            int currArmor = armors.Peek();
            int currStrike = strikingImpacts.Peek();

            if (currStrike >= currArmor)
            {
                currStrike -= currArmor;
                killedMonsters++;
                armors.Dequeue();

                if (currStrike == 0)
                {                   
                    strikingImpacts.Pop();
                }

                else
                {
                    //If it's the last strike
                    if (strikingImpacts.Count == 1)
                    {
                        strikingImpacts.Pop();
                        strikingImpacts.Push(currStrike);
                        continue;
                    }

                    //If not - add to the next strike
                    else
                    {
                        strikingImpacts.Pop();
                        strikingImpacts.Push(strikingImpacts.Pop() + currStrike);
                    }
                }
            }
            else
            {
                currArmor -= currStrike;
                strikingImpacts.Pop();
                armors.Dequeue();
                armors.Enqueue(currArmor);
            }
        }
        if (!armors.Any())
        {
            Console.WriteLine("All monsters have been killed!");

        }

        if (!strikingImpacts.Any())
        {
            Console.WriteLine("The soldier has been defeated.");

        }
        Console.WriteLine($"Total monsters killed: {killedMonsters}");
    }

    private static int[] ReadIntArr()
    {
        return Console.ReadLine()
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}