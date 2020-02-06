using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno_counter
{
    internal class Player
    {

        internal string Name
        { get; set; }
        internal int Points
        { get; set; }
        internal int Counter
        { get; set; }
        
        internal static int increaseCounter = 1;
    
        // String override
        public override string ToString()
        {
            return Counter + ": " + Name;
        }

    }

    internal class Program : Player
    {
        private static int playerNumbers;
        private static List<Player> array = new List<Player>();
        private static int maxPoints = 0;
        private static int round = 0;
        static void Main(string[] args)
        {
            Start();
        }


        //control flow methods

        // Starting the game
        private static void Start() 
        {
            Console.WriteLine("Hello, to start a game please press: S");
            Console.WriteLine("Any other character will stop this app.");
            string input = Console.ReadLine();
            if (input.ToUpper() == "S")
            {
                newGame();
            }
            else
                Exit();

        }

        // General control for the menu
        private static void Control()
        {

            // Options for handle the flow
            Console.WriteLine("To start a new game enter: N " + " For quick result enter: Q  ");
            Console.WriteLine("For end game result enter: R " + " To exit enter: E ");
            Console.WriteLine(" ");
            Console.WriteLine("To enter to the current round press: C");

            string input = Console.ReadLine();
            if (input.ToUpper() == "N")
            {
                newGame();
            }
            else if (input.ToUpper() == "Q")
            {
                QuickResult();
            }
            else if (input.ToUpper() == "R")
            {
                Result();
            }
            else if (input.ToUpper() == "C")
            {
                Current();
            }
            else if (input.ToUpper() == "E")
            {
                Exit();
            }

        }

        // End of game result
        private static void Result()
        {
            if (round < 1)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Too early, come back after one more round.");
                Console.WriteLine(" ");
                Control();
            }
            Console.WriteLine(" ");
            Console.WriteLine("One player reached the maximum points. Thus, lets see who was the best this time.");
            Console.WriteLine(" ");
            array.Sort((x, y) => x.Points.CompareTo(y.Points));
            for (int i = 0; i < array.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("The Champion is: " + array[i].Name.ToUpper() + " with only " + array[i].Points + " points.");
                    Console.WriteLine(" ");
                    Crown();
                    Console.WriteLine(" ");
                    Console.WriteLine("And everyone else: ");
                    continue;
                }
            
            Console.WriteLine("The player named " + array[i].Name.ToUpper() + " has " + array[i].Points + " points.");
            }
            Console.WriteLine(" ");
            
            Control();
        }
        
        // To check quickly the result
        private static void QuickResult()
        {
            bool IsOverMaxScore = false;
            if (round < 1)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Too early, come back after one more round.");
                Console.WriteLine(" ");
                Control();
            }
            Console.WriteLine(" ");
            array.Sort((x, y) => x.Points.CompareTo(y.Points));
            for (int i = 0; i < array.Count; i++) 
            {
                if (array[i].Points > maxPoints)
                {
                    IsOverMaxScore = true;
                }
                Console.WriteLine("The player named " + array[i].Name.ToUpper() + " has " + array[i].Points + " points.");
            }
            Console.WriteLine(" ");
            if (IsOverMaxScore)
            {
                Result();
            }
            Control();

        }

        // To calculate card values
        private static int CardValues()
        {

            int sum = 0;
            int input = 0;
            String[] array = new String[13] { "card-1", "card-2", "card-3", "card-4", "card-5", "card-6", "card-7",
            "card-8","card-9","Draw2","Reverse","Wild","WildDraw4"};

            Console.WriteLine("Fill with whole number the following fields to sum up your cards values");
            for (int i = 0; i < array.Length; i++) // Loop through List with for
            {
                Console.WriteLine(array[i]);
            Convert:
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Careful mate! :)");
                    goto Convert;
                }
                switch (array[i])
                {

                    case "card-1":
                        sum = sum + (1 * input);
                        break;

                    case "card-2":
                        sum = sum + (2 * input);
                        break;

                    case "card-3":
                        sum = sum + (3 * input);
                        break;

                    case "card-4":
                        sum = sum + (4 * input);
                        break;

                    case "card-5":
                        sum = sum + (5 * input);
                        break;

                    case "card-6":
                        sum = sum + (6 * input);
                        break;

                    case "card-7":
                        sum = sum + (7 * input);
                        break;

                    case "card-8":
                        sum = sum + (8 * input);
                        break;

                    case "card-9":
                        sum = sum + (9 * input);
                        break;

                    case "Draw2":
                        sum = sum + (20 * input);
                        break;

                    case "Reverse":
                        sum = sum + (20 * input);
                        break;

                    case "Wild":
                        sum = sum + (50 * input);
                        break;

                    case "WildDraw4":
                        sum = sum + (50 * input);
                        break;

                    default:
                        Console.WriteLine("Bug");
                        break;
                }
            }
            return sum;
        }

        // To run the current round in the game
        private static void Current()
        {
            round++;
            bool RigthName = true;
            String RoundWinner = "";
            Console.WriteLine(" ");
            Console.WriteLine("The current round is: " + round + " .");
            Console.WriteLine("Tell me who win this round");
            Console.WriteLine(" ");

            while (RigthName)
            {
                Console.WriteLine("Waiting for input :");
                RoundWinner = Console.ReadLine();

                for (int i = 0; i < array.Count; i++) // Loop through List with for
                {
                    if (RoundWinner.ToUpper().Equals(array[i].Name.ToUpper()))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Good job " + array[i].Name.ToUpper() + " !");
                        Console.WriteLine("");
                        goto next;
                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine("Check who is playing");
                Console.WriteLine(" ");
            }
        next:
            for (int i = 0; i < array.Count; i++) // Loop through List with for
            {
                if (RoundWinner.ToUpper().Equals(array[i].Name.ToUpper()))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Maybe next time " + array[i].Name.ToUpper());
                    array[i].Points += CardValues();
                }
            }
            for (int i = 0; i < array.Count; i++) // Loop through List with for
            {
                if (array[i].Points > maxPoints)
                {
                    Result();
                }
            }
                Control();
        }
       
        // To start a new game
        private static void newGame()
        {
            array.Clear();
            round = 0;
            maxPoints = 0;
            playerNumbers = 0;
        // Welcom message + setting player numbers + max score till the game is on
        start:
            Console.WriteLine("Hello, Please enter the numbers of players.(2-10)");
            try
            {
                playerNumbers = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Dont crash me Big Boy!");
                goto start;
            }
            if (playerNumbers < 2 || playerNumbers > 10)
            {
                Console.WriteLine(" ");
                Console.WriteLine("You are not too good at math, aren't you?");
                Console.WriteLine("Let start it again :)");
                Console.WriteLine(" ");
                goto start;
            }
        second:
            Console.WriteLine("Please enter the maximum points, till you want to play this game.");
            try
            {
                maxPoints = Convert.ToInt32(Console.ReadLine());

                if (maxPoints < 50)
                {
                    Console.WriteLine("It is gonna be a short game.");
                    Console.WriteLine(" ");
                    goto second;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Again ? Go back to school :)");
                goto second;
            }
            // Name the players
            Console.WriteLine(" ");
            Console.WriteLine("Please enter the name of the players.");
            while (playerNumbers > 0)
            {
                Player player = new Player();
                player.Points = 0;
                player.Name = Console.ReadLine();
                player.Counter += Player.increaseCounter;
                Player.increaseCounter++;
                array.Add(player);
                playerNumbers--;
            }

            // showing players + the score where the game will end
            Console.WriteLine(" ");
            Console.WriteLine("Players in this game : ");
            Console.WriteLine("");
            foreach (Player inList
                in array)
            {
                Console.WriteLine("Player " + inList + ";  ");
            }
            Console.WriteLine("You will play till someone reach : " + maxPoints + " points.");
            Console.WriteLine(" ");


            // Options for handle the flow
            Control();
        }

        // To exit from this app
        private static void Exit()
        {
            Environment.Exit(0);
        }

        // Thanks for the crown code for NishuAggarwal and the https://www.geeksforgeeks.org/ 
        public static void Crown(int length = 35, int height = 17)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    // for first row, print '*' 
                    // i.e, for top part of crown
                    if (i == 0)
                    {

                        // print '*' at first, middle 
                        // and last column 
                        if (j == 0 || j == height
                                 || j == length - 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    // print '*' at base of 
                    // crown i.e, for last row 
                    else if (i == height - 1)
                    {
                        Console.Write("*");
                    }

                    // fill '#' to make a perfect crown 
                    else if ((j < i || j > height - i) &&
                                     (j < height + i ||
                                      j >= length - i))
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }

        }
    }
}
