namespace _04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] originalArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int foldPoint = originalArray.Length / 4;
            int[] output = new int[foldPoint * 2];

            for (int i = 0; i < foldPoint; i++)
            {
                output[i] = originalArray[i + foldPoint] + originalArray[foldPoint - 1 - i];
                //Console.WriteLine(output[i]);

                output[i + foldPoint] = originalArray[i + 2 * foldPoint] + originalArray[originalArray.Length - 1 - i];
                //Console.WriteLine(output[i+foldPoint]);
            }

            Console.WriteLine(String.Join(' ', output));
        }
    }
}