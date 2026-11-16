//START PROGRAM. Display a welcome message in the console.
Console.WriteLine("Welcome to the number guessing game!");
// Ask the user to type in their guess
Console.WriteLine("Guess a number from 1 to 100. Type in your guess in the terminal.");
// Store the secret number
int secretNumber = 42;
//Ask user to type in their guess number
Console.Write("Enter your guess number:");
int userInput = Convert.ToInt32(Console.ReadLine());
// shows the user what they typed
Console.WriteLine($"You typed: {userInput}");

/*
User validation; enter number within range of 1 to 100.

Bonus: user validation; "must be a number". Try catch interger.
*/

if (userInput == secretNumber)
{
    Console.WriteLine($"You guessed the secret number {secretNumber}!");
}

while (userInput != secretNumber)
{
    Console.Write("Your guess does not match the secret number. Try again ");

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
// END PROGRAM



/*User validation; check the following:

    - if the user guess is a number
    
    - then is within the 1 to 100 range

    */

// Do While loop with user input inside the loop

//Once the user guesses the secert number the game prints the close game message


