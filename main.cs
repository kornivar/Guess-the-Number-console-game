int try_count = 0;
int[] attempts = new int[10];
Random random = new Random();

int GetRandomNumber(int min, int max)
{
    return random.Next(min, max + 1);
}

int GetUserInput()
{
    bool checker;
    do
    {
        checker = true;
        Console.WriteLine("Enter a number: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            checker = false;
            Console.WriteLine("It's not a number!");
            continue;
        }

        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                checker = false;
                Console.WriteLine("It's not a number!");
                break;
            }
        }

        if (checker)
        {
            return int.Parse(input);
        }

    } while (!checker);

    return 0;
}
