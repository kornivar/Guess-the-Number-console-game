int try_count = 0;
int[] attempts = new int[10];
Random random = new Random();

int GetRandomNumber(int min, int max)
{
    return random.Next(min, max+1);
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

    int target_number = 0;
    bool max_tries = false;
    if (new_game && difficulty == 'e')
    {
        target_number = GetRandomNumber(1, 50);
        try_count = 0;
        attempts = new int[10];
        Console.WriteLine("Easy difficulty! Guess a number between 1 and 50. \nPress Enter to continue...");
        Console.ReadLine();
    }
    else if (new_game && difficulty == 'm')
    {
        target_number = GetRandomNumber(1, 100);
        try_count = 0;
        attempts = new int[10];
        Console.WriteLine("Medium difficulty! Guess a number between 1 and 100. \nPress Enter to continue...");
        Console.ReadLine();
    }
    else if (new_game && difficulty == 'h')
    {
        max_tries = true;
        target_number = GetRandomNumber(1, 500);
        try_count = 0;
        attempts = new int[10];
        Console.WriteLine("Hard difficulty! Guess a number between 1 and 500 in 10 TRIES. \nPress Enter to continue...");
        Console.ReadLine();
    }

    while (true)
    {
        int guess = 0;
        if (max_tries && try_count < 10)
        {
            guess = GetUserInput();
        }
        else if (max_tries && try_count >= 10)
        {
            Console.WriteLine("You couldn't guess the number in 10 tries!");
            break;
        }
        else
        {
            guess = GetUserInput();
        }

        if (try_count >= attempts.Length)
        {
            Array.Resize(ref attempts, attempts.Length * 2);
        }
        attempts[try_count] = guess;
        try_count++;


        int result = CheckGuess(guess, target_number);
        if (result == 1)
        {
            Console.WriteLine("The secret number is bigger.");
        }
        else if (result == -1)
        {
            Console.WriteLine("The secret number is smaller.");
        }
        else
        {
            Console.WriteLine("You guessed the secret number in " + try_count + " tries!");
            Console.WriteLine("List of attempts:");
            for (int i = 0; i < try_count; i++)
            {
                Console.WriteLine("Attempt " + (i + 1) + ": " + attempts[i]);
            }
            break;
        }
    }
}

bool playAgain = true;

while (playAgain)
{
    game(true);

    while (true)
    {
        Console.Write("Would you like to play again? (y/n): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
            playAgain = true;
            break;
        }
        else if (input.ToLower() == "n")
        {
            playAgain = false;
            break; 
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter 'y' or 'n'.");
        }
    }
}
