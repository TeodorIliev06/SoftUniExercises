namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] initialIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] playground = new int[fieldSize];
            foreach (long newIndex in initialIndexes)
            {
                if (newIndex >= 0 && newIndex < playground.Length)
                {
                    playground[newIndex] = 1;
                }
            }

            string command = null;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split();
                int start = int.Parse(commandArr[0]); // позиция, от която взимаме калинка
                int end = int.Parse(commandArr[2]); // брой позиции за изместване
                string direction = commandArr[1];

                if (CheckPosition(start, end, playground))
                {
                    if (playground[start] == 1)
                    {
                        if (direction == "left")
                        {
                            playground = LadybugFlightLeft(start, end, playground);
                        }
                        else if (direction == "right")
                        {
                            playground = LadybugFlightRight(start, end, playground);
                        }
                    }
                }

            }
            Console.WriteLine(string.Join(" ", playground));
        }
        static bool CheckPosition(int startPosition, int endPosition, int[] playground)
        {
            bool result = false;
            if ((startPosition <= playground.Length - 1 && startPosition >= 0))
            { 
                result = true; 
            }
            else
            { 
                result = false; 
            }

            return result;
        }

        static int[] LadybugFlightLeft(int startPosition, int endPosition, int[] playground)
        {
            int ladybugFlightLeft = startPosition - endPosition; // стъпка наляво
            int flightToNewIndex = 0;

            // ако позициите са = 0, връщаме като резултат същия масив
            if (endPosition == 0)
            {
                return playground;
            }
            // ако позициите са < 0, връщаме като резултат масива за летене надясно
            if (endPosition < 0)
            {
                playground = LadybugFlightRight(startPosition, Math.Abs(endPosition), playground);
                return playground;
            }
            // ако калинката лети в границите на масива
            if (ladybugFlightLeft >= 0 && ladybugFlightLeft < playground.Length)
            {
                // 1) ако новата позиция в масива е свободна
                if (playground[ladybugFlightLeft] == 0)
                {
                    flightToNewIndex = ladybugFlightLeft; // присвояваме стойността като нов индекс
                    playground[startPosition] = 0; // освобождаваме индекса от който калинката тръгва
                    playground[flightToNewIndex] = 1; // поставяме калинката на новата бозиция
                }
                // 2) ако новата позиция в масива е заета от друга калинка 
                else
                {
                    flightToNewIndex = -1; // изваждаме променливата за нова позиция извън границите на масива

                    // обхождаме масива със посочената стъпка от позицията на калинката до началото на масива
                    // и проверяваме за свободен индекс - т.е. == 0
                    for (int i = ladybugFlightLeft; i >= 0; i -= endPosition)
                    {
                        // ако намерим свободен индекс
                        if (playground[i] != 1)
                        {
                            flightToNewIndex = i; // присвояваме стойността като нов индекс
                            playground[startPosition] = 0; // освобождаваме индекса от който калинката тръгва
                            playground[flightToNewIndex] = 1; // поставяме калинката на новата бозиция
                            break;
                        }
                    }
                    // ако стойността на новия индекс остане извън границите на масива
                    // калинката е отлетяла и нейната позиция остава празна
                    if (flightToNewIndex < 0)
                    {
                        playground[startPosition] = 0; // освобождаваме индекса от който калинката тръгва
                    }
                }
            }
            // ако калинката лети извън границите на масива
            // калинката е отлетяла и нейната позиция остава празна
            else
                playground[startPosition] = 0; // освобождаваме индекса от който калинката тръгва

            return playground;
        }

        static int[] LadybugFlightRight(int startPosition, int endPosition, int[] playground) // правим същите проверки за другата посока
        {
            int ladybugFlightLeft = startPosition + endPosition;
            int flightToNewIndex = 0;

            if (endPosition == 0)
            {
                return playground;
            }

            if (endPosition < 0)
            {
                playground = LadybugFlightLeft(startPosition, Math.Abs(endPosition), playground);
                return playground;
            }

            if (ladybugFlightLeft >= 0 && ladybugFlightLeft < playground.Length)
            {
                if (playground[ladybugFlightLeft] == 0)
                {
                    flightToNewIndex = ladybugFlightLeft;
                    playground[startPosition] = 0;
                    playground[flightToNewIndex] = 1;
                }
                else
                {
                    flightToNewIndex = -1;

                    for (int i = ladybugFlightLeft; i < playground.Length; i += endPosition)
                    {
                        if (playground[i] != 1)
                        {
                            flightToNewIndex = i;
                            playground[startPosition] = 0;
                            playground[flightToNewIndex] = 1;
                            break;
                        }
                    }
                    if (flightToNewIndex < 0)
                    {
                        playground[startPosition] = 0;
                    }
                }
            }
            else
            {
                playground[startPosition] = 0; 
            }

            return playground;
        }
    }
}