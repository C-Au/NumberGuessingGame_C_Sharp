# How Program.cs works

This program is a number guessing game played in the terminal. The player guesses a whole number from 1 to 100. The secret number is always 42. The program gives feedback and keeps asking until the player guesses correctly.

The explanations below follow the code from top to bottom. Think of a variable as a labelled box that holds a value.

## Welcoming the player

```csharp
Console.WriteLine("Welcome to the number guessing game!");

Console.WriteLine("Guess a number from 1 to 100. Type in your guess in the terminal.");
```

`Console` lets the program communicate through the terminal. `WriteLine` displays the text between the quotation marks and moves the cursor to a new line. These instructions welcome the player and explain what to type.

Quotation marks surround text in the code. The semicolon marks the end of each instruction.

## Preparing the numbers

```csharp
int secretNumber = 42;

int userInput;
```

`int` means a variable holds a whole number, such as 7, 42, or -3. A number with a decimal part, such as 2.5, cannot be stored in an `int`.

`secretNumber` is the variable holding the answer. The `=` assigns 42 to it. This program uses the same answer every time it runs.

`userInput` will hold the player's guess after the program converts it into a whole number. This declaration gives the variable its name and type. It receives a value later through `TryParse`.

Both variables are declared before the loop, so the program can use them inside the loop and after it finishes. C# requires a local variable to receive a value before the program reads it. Here, `TryParse` assigns `userInput` before the later comparisons use it.

## Starting a turn

```csharp
do
{
    Console.Write("Enter your guess number:");
```

`do` starts a loop. A loop repeats a group of instructions. Each trip through this loop is another chance to guess.

The opening brace `{` begins the loop's body. Its matching closing brace appears before the `while` condition near the bottom of the file. Braces group instructions together.

A `do` loop runs its body at least once. It checks whether to repeat at the end of each turn.

`Console.Write` displays the prompt and leaves the cursor on the same line. The player can type their guess beside the prompt. `Console.WriteLine` moves the cursor to a new line after displaying its message.

## Reading what the player types

```csharp
string? input = Console.ReadLine();
```

`Console.ReadLine()` waits for the player to type something and press Enter. It then returns the text they typed. The parentheses `()` call the method, which performs that action.

`string` means text. `input` is the variable that stores the text. The `=` assigns the result from the right-hand side to the variable on the left.

If the player types `25`, `input` holds the text `"25"`. The next step tries to turn that text into a whole number the game can compare with 42.

The `?` allows `input` to hold `null`, which means there is no text value. `ReadLine()` can return `null` when the input stream ends. Pressing Enter without typing anything produces an empty string, written as `""`.

`input` is declared inside the loop's braces, so it is available within that loop body. Each turn reads a fresh answer.

## Checking whether the answer is a whole number

```csharp
if (!int.TryParse(input, out userInput))
{
    Console.WriteLine($"Your guess '{input}' is not a valid integer.");
    continue;
}
```

This block handles answers the program cannot convert into an `int`. An integer is a whole number.

### What TryParse does

`int.TryParse(input, out userInput)` tries to turn the text in `input` into a whole number.

- `input` supplies the text to check.
- `out userInput` tells the method where to put its numeric result. It uses the variable declared earlier.
- If conversion succeeds, the method stores the number in `userInput` and returns `true`.
- If conversion fails, the method stores 0 in `userInput` and returns `false`.

`true` and `false` are the two possible answers to a yes-or-no check. The method both assigns a numeric result through `out` and returns a success-or-failure answer for the condition.

For example, `"25"` succeeds and stores 25. `"hello"`, `"2.5"`, and an empty string fail. A whole number outside the supported `int` range of -2,147,483,648 through 2,147,483,647 also fails. `TryParse` handles these conversion failures by returning `false`.

### What if and ! do

`if` runs the code inside its braces when its condition is `true`.

The `!` means “the opposite.” It changes `true` to `false` and `false` to `true`. Here, it makes the error block run when conversion fails.

| Player types | TryParse returns | After ! | Error block runs |
| --- | --- | --- | --- |
| `25` | `true` | `false` | No |
| `hello` | `false` | `true` | Yes |

### Showing the invalid answer

The `$` before the message lets the program insert a variable's value using braces. This is called string interpolation.

`{input}` is replaced by the original text the player entered. If the player types `hello`, the message becomes `Your guess 'hello' is not a valid integer.` The single quotation marks around the answer appear in the printed message.

### Trying another turn with continue

`continue;` skips the remaining instructions in the current loop turn. This prevents the failed conversion's value of 0 from reaching the range and high-or-low checks.

In a `do` loop, `continue` goes to the `while` condition at the bottom. After a failed conversion, `userInput` is 0. Since 0 differs from the secret number 42, the loop repeats and asks for another guess.

## Showing a valid whole number

```csharp
Console.WriteLine($"You typed: {userInput}");
```

When conversion succeeds, the program reaches this line and displays the converted number. If the player types `25`, the message is `You typed: 25`.

A successful conversion means the answer is a whole number that fits in an `int`. The next checks decide whether it is within the game's allowed range.

## Checking the range and comparing the guess

```csharp
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
else
{
    break;
}
```

This is a chain of checks. The program checks them in order and runs the first matching block. Once one block runs, it skips the remaining branches in this chain.

| Check | Meaning | Example guess | Result |
| --- | --- | --- | --- |
| `userInput < 1` | The guess is below 1 | 0 | Prints the below-range message |
| `userInput > 100` | The guess is above 100 | 101 | Prints the above-range message |
| `userInput > secretNumber` | The guess is higher than 42 | 60 | Prints “too high” |
| `userInput < secretNumber` | The guess is lower than 42 | 20 | Prints “too low” |
| `else` | All earlier checks were false | 42 | Leaves the loop |

`<` means “less than,” and `>` means “greater than.” The allowed range includes both 1 and 100.

`else if` means “if the earlier checks did not match, try this check.” `else` handles the remaining possibility. Here, a guess that passes every earlier check must equal 42.

`break;` immediately exits the loop. The program then continues with the instructions after the loop.

The first `Console.WriteLine` is spread across several lines to make the long message easier to read in the editor. It still prints one line of text.

## Deciding whether to repeat

```csharp
} while (userInput != secretNumber);
```

The closing brace ends the loop body. `while` checks whether the loop should repeat.

`!=` means “is different from.” This condition says, “Keep playing while the guess is different from the secret number.”

After an incorrect guess, the condition is `true`, so another turn begins. After an invalid text answer, `continue` also brings the program to this check.

In the current code, a correct guess reaches `break` and exits immediately. The `while` condition is skipped on the winning turn. Both the condition and the `break` express that guessing 42 ends the loop.

## Celebrating the correct guess

```csharp
if (userInput == secretNumber)
{
    Console.WriteLine($"Your guess number matches the secret number {secretNumber}!");
}
```

After the loop, `==` checks whether the two numbers are equal. A single `=` assigns a value, while `==` compares values.

When `userInput` equals 42, the program prints `Your guess number matches the secret number 42!` The `{secretNumber}` part inserts the answer into the message.

With the current logic, the loop finishes when the player guesses correctly, so this message runs after the winning guess.

## Ending the game

```csharp
Console.WriteLine("Thanks for playing. Goodbye!");
```

The program prints its goodbye message. There are no more instructions, so the program ends.

## Walking through one game

1. The program welcomes the player and sets the secret number to 42.
2. The player types `hello`. Conversion fails, the program shows the invalid-integer message, and `continue` leads to another turn.
3. The player types `101`. Conversion succeeds, but the range check reports that the number is above 100.
4. The player types `20`. The number is in range and below 42, so the program says the guess is too low.
5. The player types `60`. The number is in range and above 42, so the program says the guess is too high.
6. The player types `42`. The final `else` runs, and `break` exits the loop.
7. The program prints the winning message and goodbye message, then ends.

## Current behavior when input ends

If the input stream ends, `ReadLine()` returns `null`. `TryParse` treats that as a failed conversion, and the loop asks again. The current code has no exit condition for the end of input, so it can repeatedly print prompts and error messages in that situation.
