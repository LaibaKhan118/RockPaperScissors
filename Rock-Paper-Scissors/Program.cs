using System;

namespace ROCKPAPERSCISSORS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            bool playAgain = true;
            Random rnd = new Random();

            while (playAgain)
            {
                int playerScore = 0;
                int cpuScore = 0;

                while (playerScore < 3 && cpuScore < 3)
                {
                    Console.Write("Choose between ROCK, PAPER, SCISSORS: ");
                    string playerInput = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(playerInput))
                    {
                        Console.WriteLine("Input cannot be empty. Try again.");
                        continue;
                    }

                    playerInput = playerInput.Trim().ToUpper();

                    if (playerInput != "ROCK" && playerInput != "PAPER" && playerInput != "SCISSORS")
                    {
                        Console.WriteLine("Invalid choice. Please type Rock, Paper, or Scissors.");
                        continue;
                    }


                    int randomInt = rnd.Next(1, 4);
                    string cpuInput = randomInt switch
                    {
                        1 => "ROCK",
                        2 => "PAPER",
                        _ => "SCISSORS"
                    };

                    Console.WriteLine($"The computer chose {cpuInput}");


                    if (playerInput == cpuInput)
                    {
                        Console.WriteLine("Draw!\n");
                    }
                    else if ((playerInput == "ROCK" && cpuInput == "SCISSORS") ||
                             (playerInput == "PAPER" && cpuInput == "ROCK") ||
                             (playerInput == "SCISSORS" && cpuInput == "PAPER"))
                    {
                        Console.WriteLine("Player Wins!\n");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine("CPU Wins!\n");
                        cpuScore++;
                    }

                    Console.WriteLine($"Score => Player: {playerScore} | CPU: {cpuScore}\n");
                }

                if (playerScore == 3)
                {
                    Console.WriteLine("Player WINS the match!\n");
                }
                else
                {
                    Console.WriteLine("CPU WINS the match!\n");
                }

                string loop;
                do
                {
                    Console.Write("Do you want to play again? (y/n): ");
                    loop = Console.ReadLine() ?? string.Empty;
                } while (string.IsNullOrWhiteSpace(loop));

                playAgain = loop.Trim().ToLower() == "y";
            }
        }
    }
}
