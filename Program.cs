// See https://aka.ms/new-console-template for more information

using hi_lo_Test.models;
internal class Program
{
    static int minNumber = 1;
    static int maxNumber = 25;
    static int guesses;
    static int maxGuesses = 5;
    static bool playAgain = true;
    static int numberOfPlayers = 0;
    static List<Player> players;
    static bool oneWin = false;
    private static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the Hi-Lo Game!");

        while (playAgain)
        {
            SetPlayers();
            guesses = 1;
            while (guesses <= maxGuesses)
            {
                if (oneWin)
                    break;
                TurnPlayers();
            }

            ValidateWinner();
            WantPlayAgain();

        }
        Console.WriteLine("Thanks for playing!");
        Console.ReadKey();

        static void SetPlayers()
        {
            players = new();
            var randomNumber = new Random();
            Console.WriteLine("Please set a number of players:(minimum 1)");
            int.TryParse(Console.ReadLine(), out numberOfPlayers);
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Player player = new()
                {
                    IdPlayer = i,
                    Guess = 0,
                    MisteryNumber = randomNumber.Next(minNumber, maxNumber)
                };

                bool next = false;
                while (!next)
                {

                    Console.WriteLine($"Please write de name of player {i}");
                    player.PlayerName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(player.PlayerName))
                        next = true;
                        else
                        Console.WriteLine("The name is empty.Please write a valid name!");
                }
                players.Add(player);
            }

        }
        static void TurnPlayers()
        {
            foreach (var p in players)
            {
                bool next = false;
                while (!next)
                {
                    try
                    {
                        Console.WriteLine($"{p.PlayerName} Please choose a number between {minNumber} and {maxNumber}");
                        p.Guess = Convert.ToInt32(Console.ReadLine());
                        if (p.Guess < minNumber || p.Guess > maxNumber)
                            throw new ArgumentException();

                        if (p.Guess == p.MisteryNumber)
                        {
                            p.Win = true;
                            oneWin = true;
                        }

                        if (p.MisteryNumber > p.Guess)
                        {
                            Console.WriteLine($"{p.PlayerName} The mistery number is greater than the guess {p.Guess}");
                            Line();
                        }
                        else if (p.MisteryNumber < p.Guess)
                        {
                            Console.WriteLine($"{p.PlayerName} The mistery number is  less than the guess {p.Guess}");
                            Line();
                        }
                        next = true;
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
                if (oneWin)
                    break;
            }
            guesses++;
        }
        static void LoopMisteryNumbers()
        {
            foreach (var p in players)
            {
                Console.WriteLine($"{p.PlayerName}, The mistery number was {p.MisteryNumber}");
                Line();
            }
        }
        static void ValidateWinner()
        {
            if (oneWin)
            {
                var winnerPlayer = players.Where(x => x.Win).FirstOrDefault();
                Line();
                Console.WriteLine($"{winnerPlayer.PlayerName}, You Win!!");
                Line();
                LoopMisteryNumbers();
                oneWin = false;
            }
            else
            {
                Line();
                Console.WriteLine($"There was no winner! you have exceeded the maximum number of guesses: {maxGuesses} :( ");
                Line();
                LoopMisteryNumbers();
            }

        }
        static void WantPlayAgain()
        {
            string willPlay = "";
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
        static void Line() =>
            Console.WriteLine("----------------------------------------------------------------------------------------------");
    }
}