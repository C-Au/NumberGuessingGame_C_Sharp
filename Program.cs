// START PROGRAM
// Display a welcome message in the console.
Console.WriteLine("Welcome to the number guessing game!");

// Ask the user to type in their guess
Console.WriteLine("Guess a number from 1 to 100. Type in your guess in the terminal.");

// Store the secret number. Comment out for now because it shows an error
int secretNumber = 42;

// Temporarily display it to check that it works. To be commented out
// Console.WriteLine(secretNumber);

//Ask user to type in their guess number
Console.Write("Enter your guess number:");
int userInput = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"You typed: {userInput}"); // Program resumes after Enter is pressed

//Compares user input with the secret number

while (userInput != secretNumber)
{
    Console.Write("User guest does not match the secret number. Try again");
    
}

//If user guess is wrong the game asks the user for another guess

//If user guess is right the game prints "you guess the secret number {xxx}!"

//Game ends