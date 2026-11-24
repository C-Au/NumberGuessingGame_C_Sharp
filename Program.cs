Console.WriteLine("Welcome to the number guessing game!");

Console.WriteLine("Guess a number from 1 to 100. Type in your guess in the terminal.");

Random rng = new Random();
int secretNumber = rng.Next(1, 101);

int userInput;

int guessCount = 0;

do
{
    if (guessCount == 2)
    {
        Console.WriteLine("You've guessed 2 times. You have one last guess before the game ends.");
    }

    Console.Write("Enter your guess number:");

    string? input = Console.ReadLine();
    if (!int.TryParse(input, out userInput))
    {
        Console.WriteLine($"Your guess '{input}' is not a valid integer.");
        continue;
    }

    if (userInput >= 1 && userInput <= 100)
    {
        ++guessCount;
    }
    Console.WriteLine($"You typed: {userInput}");

    if (userInput < 1)
    {
        Console.WriteLine(
            "Your guess number is less than 1 and not within the 1 to 100 number range"
        );
    }
    else if (userInput > 100)
    {
        Console.WriteLine("Your guess number is over 100 and not within the 1 to 100 number range");
    }
    else if (userInput > secretNumber)
    {
        Console.WriteLine("Your guess number is too high.");
    }
    else if (userInput < secretNumber)
    {
        Console.WriteLine("Your guess number is too low.");
    }
} while (userInput != secretNumber && guessCount < 3);

if (userInput == secretNumber)
{
    Console.WriteLine(
        $"Your guess number matches the secret number {secretNumber}! You've made {guessCount} guesses"
    );
}
else
{
    Console.WriteLine($"You ran out of guesses. The secret number is {secretNumber}.");
}

Console.WriteLine("Thanks for playing. Goodbye!");
