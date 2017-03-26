using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    public class HangmanGamePlay
    {
        public static string randomWord = "";
        public static char[] randomWordArray;
        public int NumberOfMisses = 0;
        public char userinput;
        public int miss = 0;
        public int x = 0;
        public int y = 0;
        public static char[] anwersArray;


        public void GamePlay()
        {
            ConsoleWriteReadClear("Are you ready to play hangman! Press any key to play");
            GetRandomWord();
            GamePlayLoop();

            Console.ReadLine();

        }

        public void GetRandomWord()
        {
            var lines = File.ReadAllLines(@".\dictionary.txt");
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            randomWord = lines[randomLineNumber];

            randomWordArray = randomWord.ToCharArray();

        }

        public void GamePlayLoop()
        {

                char[] anwersArray = new char[randomWord.Length];
                int NumberofGuesses = 0;
            do
            {
                Console.WriteLine("               ");
                for (var i = 0; i < randomWord.Length; i++)
                {

                    Console.Write("_ ");

                }
                Console.WriteLine();
                Console.WriteLine("Enter a letter");
                userinput = Console.ReadKey().KeyChar;
                Console.ReadLine();

                for (var i = 0; i < randomWord.Length; i++)
                {

                    if (userinput == randomWordArray[i])
                    {
                        anwersArray[i] += userinput;
                        if ((anwersArray.SequenceEqual(randomWordArray)))
                        {
                            ConsoleWriteReadClear("Victory!");
                            
                        }
                    }
                    else
                    {
                        x++;
                        if (x == randomWordArray.Length)
                        {
                            miss++;
                            GameBoard();
                            Console.ReadLine();
                            Console.Clear();
                        }
                        continue;
                    }
                   
                }
                x = 0;
                NumberofGuesses++;
                Console.WriteLine(anwersArray);

            } while (miss < 6);

        }

        public static string PromptForString(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Input is required");
                    continue;
                }
                if(userInput.Length > 1)
                {
                    Console.WriteLine("Only one Letter please");
                    continue;
                }

                return userInput;
            }
        }

        public static void ConsoleWriteReadClear(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
            Console.Clear();
        }








        public void GameBoard()
        {
            if (miss == 0)
            {
                Console.WriteLine(@"
                    0000000000000
                    0           0
                    0           
                    0          
                    0           
                    0          
                    0         
                    0        
                    0          
                    0         
                    0        
                    0       
                    0
                    0
                    0
                Press any key to continue!
");
            }
            if (miss == 1)
            {
                Console.WriteLine(@"
                    0000000000000
                    0           0
                    0           1
                    0          1 1
                    0           1
                    0         
                    0         
                    0        
                    0          
                    0         
                    0        
                    0       
                    0
                    0
                    0
                Press any key to continue!
            ");
            }
            if (miss == 2)
            {
                Console.WriteLine(@"
                    0000000000000
                    0           0
                    0           1
                    0          1 1
                    0           1
                    0           2
                    0           2 
                    0           2  
                    0          
                    0        
                    0        
                    0       
                    0
                    0
                    0
                Press any key to continue!
            ");
            }
            if (miss == 3)
            {
                Console.WriteLine(@"
                    0000000000000
                    0           0
                    0           1
                    0          1 1
                    0           1
                    0          32
                    0         3 2 
                    0        3  2  
                    0          
                    0         
                    0        
                    0       
                    0
                    0
                    0
                Press any key to continue!
            ");
            }
            if (miss == 4)
            {
                Console.WriteLine(@"
                    0000000000000
                    0           0
                    0           1
                    0          1 1
                    0           1
                    0          324
                    0         3 2 4
                    0        3  2  4
                    0          
                    0         
                    0        
                    0       
                    0
                    0
                    0
                Press any key to continue!
            ");
            }
            if (miss == 5)
            {
                Console.WriteLine(@"
                    0000000000000
                    0           0
                    0           1
                    0          1 1
                    0           1
                    0          324
                    0         3 2 4
                    0        3  2  4
                    0          5 
                    0         5   
                    0        5     
                    0       5       
                    0
                    0
                    0
                Press any key to continue!
            ");
            }
            if (miss == 6)
            {
                Console.WriteLine(@"
                    0000000000000
                    0           0
                    0           1
                    0          1 1
                    0           1
                    0          324
                    0         3 2 4
                    0        3  2  4
                    0          5 6
                    0         5   6
                    0        5     6
                    0       5       6
                    0
                    0
                    0
                Press any key to continue!
");
                Console.WriteLine("Game over! The word was: "+ randomWord);
            }

        }
    }
}
