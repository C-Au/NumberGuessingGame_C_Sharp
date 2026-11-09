Console.WriteLine("Welcome to the number guessing game!");

Console.WriteLine("Guess a number from 1 to 100. Type in your guess in the terminal.");

int secretNumber = 42;

Console.Write("Enter your guess number:");
int userInput = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"You typed: {userInput}");

if (userInput == secretNumber)
{
    Console.WriteLine($"You guessed the secret number {secretNumber}!");
}

while (userInput != secretNumber)
{
    Console.Write("User guess does not match the secret number. Try again ");

    Console.Write("Enter your guess number:");
    int userInput_2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"You typed: {userInput_2}");

    if (userInput_2 == secretNumber)
    {
        Console.WriteLine($"You guessed the secret number {secretNumber}!");

        break;
    }
}

Console.WriteLine("Thanks for playing. Goodbye!");
