using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static string[,] playField =
        {
            {"1","2","3"},
            {"4","5","6"},
            {"7","8","9"},
        };


        private static int turns = 0;
        static void Main(string[] args)
        {
            int player = 1;
            int input = 0;
            bool inputCorrect = false;

            setField();
            do {

                do
                {
                    Console.WriteLine($"Player {player} turn!");
                    Console.Write("Choose your square: ");

                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());

                        if (input > playField.Length || input <= 0)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
                    catch (FormatException exception)
                    {
                        setField();
                        Console.WriteLine("Incorrect input!\nPlease enter again");
                        continue;
                    }
                    
                    catch (IndexOutOfRangeException exception)
                    {
                        setField();
                        Console.WriteLine("The selected square dose not exist!\nPlease enter again");
                        continue;
                    }
                    
                    if (CheckPosition(input))
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        setField();
                        Console.WriteLine("\nThis square has been filled!\nPlease use another square.");
                        inputCorrect = false;
                        
                    }


                }
                while (!inputCorrect);

                PlayerInteraction(player, input);

                input = 0;
                inputCorrect = false;

                checkWinning();

                if (player == 2)
                { player = 1; }

                else
                { player = 2; }
            } 
            while (true);

            
        }

        private static bool CheckPosition(int input)
        {
            string inputStr =  input.ToString();
            
            if (input <= 3)
            {
                return playField[0, input - 1] == inputStr ? true:false;
            }
            else if(input > 3 && input <= 6)
            {
                return playField[1, input - 4] == inputStr ? true:false;
            }
            else if( input > 6 && input <= 9)
            {
                return playField[2, input - 7] == inputStr ? true:false;
            }
            else
            {
                return false;
            }
        }
        
        public static void PlayerInteraction(int player, int input)
        {
            string playerSign = " ";

            if(player == 1)
            { playerSign = "X"; }
            else { playerSign = "O"; }

            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
                default: break;
            }

            turns++;
            setField();

        }

        public static void checkWinning()
        {
            string[] playerSign = { "X", "O" };

            foreach (string playerChar in playerSign)
            {
                if(
                   (playField[0,0] == playerChar ) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar)
                   || (playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar)
                   || (playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar)
                   || (playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar)
                   || (playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar)
                   || (playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar)
                   || (playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar)
                   || (playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar)
                  )
                {
                    if(playerChar == "X")
                    {
                        Console.WriteLine("Player 1 has won!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 has won!");
                    }

                    Console.WriteLine("Please press any key to reset the game.");
                    Console.ReadKey();
                    resetGame();

                    break;
                    
                }
                else if (turns == 9) {

                    Console.WriteLine("Draw!");
                    Console.WriteLine("Please press any key to reset the game.");
                    Console.ReadKey();
                    resetGame();
                    break;

                }
                
            }
        }

        public static void resetGame()
        {
            string[,] playFieldInitial =
        {
            {"1","2","3"},
            {"4","5","6"},
            {"7","8","9"},
        };

            playField = playFieldInitial;
            turns = 0;
            setField();
        }

        public static void setField()
        {
            Console.Clear();
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playField[0,0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|─────|─────|─────|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|─────|─────|─────|");
            Console.WriteLine("|     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("|     |     |     |");
        }
    }
}
