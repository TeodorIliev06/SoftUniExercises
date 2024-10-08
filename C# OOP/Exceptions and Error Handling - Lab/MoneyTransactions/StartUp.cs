namespace MoneyTransactions;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] bankAccountsInput = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
        Dictionary<int, double> bankAccounts = new();
        foreach (string bankAccount in bankAccountsInput)
        {
            string[] currAccountTokens = bankAccount.Split('-', StringSplitOptions.RemoveEmptyEntries);
            int accountId = int.Parse(currAccountTokens[0]);
            double accountBalance = double.Parse(currAccountTokens[1]);
            bankAccounts.Add(accountId, accountBalance);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commandTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = commandTokens[0];
            int accountNumber = int.Parse(commandTokens[1]);
            double sum = double.Parse(commandTokens[2]);
            try
            {
                if (command == "Deposit")
                {
                    bankAccounts[accountNumber] += sum;
                }
                else if (command == "Withdraw")
                {
                    if (bankAccounts[accountNumber] < sum)
                    {
                        throw new InvalidOperationException();
                    }
                    bankAccounts[accountNumber] -= sum;
                }
                else
                {
                    throw new ArgumentException();
                }
                Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid command!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Insufficient balance!");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Invalid account!");
            }
            finally
            {
                Console.WriteLine("Enter another command");
            }
        }
    }
}