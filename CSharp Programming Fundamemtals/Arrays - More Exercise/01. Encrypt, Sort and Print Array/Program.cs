namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] vowels = { 'a', 'o', 'u', 'e', 'i', 'A', 'E', 'O', 'U', 'I' };
            int[] arr = new int[n];
            int encryptedValue = 0, encryptedSum = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                foreach (char letter in input)
                {
                    if (vowels.Contains(letter))
                    {
                        encryptedValue = (int)letter * input.Length;
                    }
                    else
                    {
                        encryptedValue = (int)letter / input.Length;
                    }
                    encryptedSum += encryptedValue;
                }
                arr[i] = encryptedSum;
                encryptedSum = 0;
            }
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}