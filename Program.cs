Console.WriteLine("Welcome to the number guessing game!");

Console.WriteLine("Guess a number from 1 to 100. Type in your guess in the terminal.");

int secretNumber = 42;

int userInput;

do
{
    Console.Write("Enter your guess number:");

    string? input = Console.ReadLine();
    if (!int.TryParse(input, out userInput))
    {
        Console.WriteLine($"Your guess '{input}' is not a valid integer.");
        continue;
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
        Console.WriteLine("Your guess number is too high. Try again");
    }
    else if (userInput < secretNumber)
    {
        Console.WriteLine("Your guess number is too low. Try again");
    }
} while (userInput != secretNumber);

if (userInput == secretNumber)
{
    Console.WriteLine($"Your guess number matches the secret number {secretNumber}!");
}

Console.WriteLine("Thanks for playing. Goodbye!");
