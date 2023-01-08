// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Hi-Lo Game!");

var randomNumber = new Random();
int minNumber = 1;
int maxNumber = 25;
int guess;
int guesses;
int maxGuesses = 5;
bool playAgain = true;


while (playAgain)
{
    var misteryNumber = randomNumber.Next(minNumber, maxNumber);
    guess = 0;
    guesses = 1;
    bool win = true;
    string willPlay = "";

    while (guess != misteryNumber)
    {
        try
        {
            if (guesses <= maxGuesses)
            {
                Console.WriteLine($"Please choose a number between {minNumber} and {maxNumber}");
                guess = Convert.ToInt32(Console.ReadLine());
                if (guess < minNumber || guess > maxNumber)
                    throw new ArgumentException();

                if (misteryNumber > guess)
                {
                    Console.WriteLine($"The mistery number is  greater than the guess {guess}");
                }
                else if (misteryNumber < guess)
                {
                    Console.WriteLine($"The mistery number is  less than the guess {guess}");
                }

                guesses++;
            }
            else
            {
                Console.WriteLine($"You lose, you have exceeded the maximum number of guesses: {maxGuesses}");
                Console.WriteLine($"The mistery number is {misteryNumber}");
                win = false;
                break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please only enter numbers!! Choose again...");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The number is out of range. Choose again...");
        }
    }

    if (win)
    {
        Console.WriteLine("You Win!!");
        Console.WriteLine($"The number is {misteryNumber}, and you used {guesses} guesses");
    }

    while (willPlay != "N" && willPlay != "Y")
    {
        Console.WriteLine("Would you like to play again? (y/n)");
        willPlay = Console.ReadLine().ToUpper();
        if (willPlay != "N" && willPlay != "Y")
        {
            Console.WriteLine("Incorrect answer!");
        }
        else
        {
            if (willPlay == "N")
            {
                playAgain = false;
            }
        }
    }
}
Console.WriteLine("Thanks for playing!");
Console.ReadKey();