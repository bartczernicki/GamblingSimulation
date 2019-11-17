using System;
using System.Threading.Tasks;

namespace GamblingSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Random seed based on Date ticks
            var seed = (int)DateTime.Now.Ticks;
            var random = new Random(seed);

            // Betting scales of dollar amount for each bet.
            // After each bet "loss", the next bet is the next tier
            var bettingDollarScales = new int[] { 1000, 1250, 1500, 1750, 2000 };

            // Percentage of being correct on a single bet
            var percentageOfCorrectBet = 50;

            // Number of betting "rounds"
            var numberOfBettingRounds = 4;

            // Total number of simulations to run
            var numberOfSimulations = 500;

            // Total dollar amount after all simulations
            var overAllNetAmountAfterAllSimulations = 0;

            // number of individual simulations
            for (int i = 0; i < numberOfSimulations; i++)
            {
                // set the starting amount for each simulation
                var startingAmount = 0;

                // amount of betting rounds
                for (int j = 0; j != numberOfBettingRounds; j++)
                {
                    var amount = 0;

                    // Bet until win once, then stop
                    for (int k = 0; k != bettingDollarScales.Length; k++)
                    {
                        var randomNumber = random.Next(1, 100);

                        if (randomNumber <= percentageOfCorrectBet)
                        {
                            // Win
                            amount = (amount + bettingDollarScales[k]);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Win:  " + bettingDollarScales[k]);
                            break;
                        }
                        else
                        {
                            // Loss
                            amount = (amount - bettingDollarScales[k]);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Loss: " + bettingDollarScales[k]);
                        }
                    }

                    // Update the starting amount
                    startingAmount = startingAmount + amount;
                }

                overAllNetAmountAfterAllSimulations += startingAmount;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Net Amount left after ONE total simulation round(s): " + startingAmount);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*************************************************");
            Console.WriteLine("Net TOTAL Amount left after ALL simulation round(s): " + overAllNetAmountAfterAllSimulations);
            Console.WriteLine("Net AVERAGE Amount left after ALL simulation round(s): " + (overAllNetAmountAfterAllSimulations / numberOfSimulations));
        }
    }
}
