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

int CheckGuess(int guess, int secret)
{
    if (guess < secret)
    {
        return 1;
    }
    else if (guess > secret)
    {
        return -1;
    }
    else
    {
        return 0;
    }
}

void game(bool new_game, char difficulty = 'm')
{
    Console.WriteLine("Select the difficulty level(e, m or h)");
    do
    {
        string input = Console.ReadLine();
        if (input.ToLower() == "e")
        {
            difficulty = 'e';
            break;
        }
        else if (input.ToLower() == "m")
        {
            difficulty = 'm';
            break;
        }
        else if (input.ToLower() == "h")
        {
            difficulty = 'h';
            break;
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter 'e', 'm' or 'h'.");
        }
    } while (true);
}
