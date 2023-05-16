using System;
using System.Threading.Tasks;

namespace GamblingSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Total dollar amount after all simulations
            // Note: this should be set to zero
            var overAllNetAmountAfterAllSimulations = 0;

            // Random seed based on Date ticks
            var seed = (int)DateTime.Now.Ticks;
            var random = new Random(seed);

            // PARAMETERS
            // Betting scales of dollar amount for each bet.
            // After each bet "loss", the next bet is the next dollar tier
            // For example, If your bet is 1000 and you lose the next bet is 1250 and son on,
            //      until you reach the maximum (i.e. 2000).  That is a single betting "round".
            var bettingDollarScales = new int[] { 1000, 1250, 1500, 1750, 2000 };

            // Percentage of being correct on a single bet
            var percentageOfCorrectBet = 48;

            // Number of betting "rounds"
            var numberOfBettingRounds = 4;

            // Total number of simulations to run
            var numberOfSimulations = 100;

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
