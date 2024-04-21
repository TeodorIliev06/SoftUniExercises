namespace Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Abracadabra")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandName = cmdArgs[0];

                switch (commandName)
                {
                    case "Abjuration":
                        spell = spell.ToUpper();
                        Console.WriteLine(spell);
                        break;

                    case "Necromancy":
                        spell = spell.ToLower();
                        Console.WriteLine(spell);
                        break;

                    case "Illusion":
                        int index = int.Parse(cmdArgs[1]);
                        char letter = char.Parse(cmdArgs[2]);

                        //If the index is valid - we replace through removing and inserting
                        if (index >= 0 && index < spell.Length)
                        {
                            spell = spell.Remove(index, 1).Insert(index, letter.ToString());
                            Console.WriteLine("Done!");
                        }
                        else
                        {
                            Console.WriteLine("The spell was too weak.");
                        }
                        break;

                    case "Divination":
                        string firstSubstring = cmdArgs[1];
                        string secondSubstring = cmdArgs[2];

                        if (spell.Contains(firstSubstring))
                        {
                            spell = spell.Replace(firstSubstring, secondSubstring);
                        }
                        break;

                    case "Alteration":
                        string toRemove = cmdArgs[1];

                        spell = spell.Replace(toRemove, "");
                        Console.WriteLine(spell);
                        break;

                    default:
                        Console.WriteLine("The spell did not work!");
                        break;
                }
            }

            //string spell = Console.ReadLine();

            //string modifiedSpell = spell;
            //string command;
            //while ((command = Console.ReadLine()) != "Abracadabra")
            //{
            //    string[] cmdArgs = command.Split();

            //    switch (cmdArgs[0])
            //    {
            //        case "Abjuration":
            //            modifiedSpell = modifiedSpell.ToUpper();
            //            Console.WriteLine(modifiedSpell);
            //            break;
            //        case "Necromancy":
            //            modifiedSpell = modifiedSpell.ToLower();
            //            Console.WriteLine(modifiedSpell);
            //            break;
            //        case "Illusion":
            //            if (cmdArgs.Length < 3)
            //            {
            //                Console.WriteLine("The spell was too weak.");
            //            }
            //            else
            //            {
            //                int index;
            //                if (!int.TryParse(cmdArgs[1], out index))
            //                {
            //                    Console.WriteLine("The spell was too weak.");
            //                    continue;
            //                }

            //                if (index >= 0 && index < modifiedSpell.Length)
            //                {
            //                    modifiedSpell = modifiedSpell.Substring(0, index) +
            //                                     cmdArgs[2] +
            //                                     modifiedSpell.Substring(index + 1);
            //                    Console.WriteLine("Done!");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("The spell was too weak.");
            //                }
            //            }
            //            break;
            //        case "Divination":
            //            if (cmdArgs.Length < 3)
            //            {
            //                continue;
            //            }

            //            modifiedSpell = modifiedSpell.Replace(cmdArgs[1], cmdArgs[2]);
            //            Console.WriteLine(modifiedSpell); //Added
            //            break;
            //        case "Alteration":
            //            if (cmdArgs.Length < 2)
            //            {

            //                continue;
            //            }

            //            modifiedSpell = modifiedSpell.Replace(cmdArgs[1], "");
            //            Console.WriteLine(modifiedSpell); //Added
            //            break;
            //        default:
            //            Console.WriteLine("The spell did not work!");
            //            break;
            //    }
            //}
        }
    }
}
