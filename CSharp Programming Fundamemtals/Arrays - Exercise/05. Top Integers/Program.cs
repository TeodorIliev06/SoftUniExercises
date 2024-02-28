namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] inputArr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            int inputArrLen = inputArr.Length;

            for (long i = 0; i < inputArrLen; i++)
            {
                bool isBigger = true;
                for (long j = i + 1; j < inputArrLen; j++)
                {
                    if (inputArr[i] <= inputArr[j])
                    {
                        isBigger = false;
                    }
                }

                if (isBigger) 
                {
                    Console.Write(inputArr[i] + " ");
                }
            }
        }
    }
}