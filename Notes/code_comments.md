# Code Comments

// START PROGRAM

// Display a welcome message in the console.

Console.WriteLine("Welcome to the number guessing game!");

// Ask the user to type in their guess

Console.WriteLine("Guess a number from 1 to 100. Type in your guess in the terminal.");

// Store the secret number. Comment out for now because it shows an error

int secretNumber = 42;

//Ask user to type in their guess number

Console.Write("Enter your guess number:");
int userInput = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"You typed: {userInput}"); // Program resumes after Enter is pressed

//Compares user input with the secret number. If the guess is correct the game tells the user they guessed correctly and stops the program.

if (userInput == secretNumber)
{
Console.WriteLine("You guessed the secret number!");
}

//If user guess is wrong the game asks the user for another guess

while (userInput != secretNumber)
{
Console.Write("User guess does not match the secret number. Try again ");

    Console.Write("Enter your guess number:");
    int userInput_2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"You typed: {userInput_2}");
    if (userInput_2 == secretNumber)
    {
        Console.WriteLine($"You guessed the secret number {secretNumber}!");
        
        //If user guess is right the game prints "you guess the secret number {xxx}!"

        return;
        
        //Game ends
    }

}
