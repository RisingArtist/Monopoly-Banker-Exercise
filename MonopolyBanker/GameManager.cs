using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBanker
{
    // Handles User's input and keeping track of the players in the game
    static class GameManager
    {
        public static List<Card> players = new List<Card>();
        static string answer = null;
        public static void ShowCommand()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine("1 - Add a card.");
            Console.WriteLine("2 - Insert a card into the Banker (card #).");
            Console.WriteLine("3 - Eject card out of the Banker, if has one.");
            Console.WriteLine("4 - Add amount to inserted card's balance (amount)");
            Console.WriteLine("5 - Subtract amount to inserted card's balance (amount)");
            Console.WriteLine("6 - Give inserted card GO.");
            Console.WriteLine("7 - Pay a player from another (from_card# other_card# amount).");
            Console.WriteLine("8 - Pay a player, if card already inserted (other_card# amount).");
            Console.WriteLine("9 - Remove player (card #)");
            Console.WriteLine("0 - Reset a card, if inserted.");
            Console.WriteLine("q - Quit");
        }

        // Gets the user's input for COMMAND option and check to see if its ok
        public static bool isValidChoice()
        {
            string line = Console.ReadLine();

            // Check validity against the first param 
            if (line.Length > 1) // ..checks if the first arg is more than 1 letter long
            {
                Console.WriteLine("The parameter needs to be a SINGLE number");
                return false;
            }

            if(line == "q") // .. checks if the user wants to quit
            {
                Console.WriteLine("Ending the game...");
                answer = line;
                return true;
            }

            if (!line.All(char.IsDigit)) // ..checks if there is only a digit here
            {
                Console.WriteLine("The parameter needs to be a NUMBER");
                return false;
            }
            answer = line;
            return true;
        }

        // Gets the user input for CARD ID and see if its ok. 
        public static bool isValidCard()
        {
            string line = Console.ReadLine();
            if(line.Any(char.IsLetter)) // ...checks if there are any letters 
            {
                Console.WriteLine("Card IDs go by NUMBERS.");
                return false;
            }
            int tempId = Int32.Parse(line);
            if (players.Find(card => card.id == tempId) == null) // ...checks to see if a card by id exists
            {
                Console.WriteLine("Can't find card!");
                return false;
            }
            answer = line;
            return true;
        }

        // Gets the user's input for AMOUNT entered and see its ok. 
        public static bool isValidAmount()
        {
            string line = Console.ReadLine();
            if(line.Any(char.IsLetter)) // ...checks to see if there are any letters 
            {
                Console.WriteLine("Only a NUMBER is allowed for the amount");
                return false;
            }

            answer = line;
            return true;
        }

        // Used this to retrieve the COMMAND choice, CARD ID choice and AMOUNT
        public static string getAnswer()
        {
            return answer;
        }

        // Retrieve the card so we can use it for the banker
        public static Card getCard(int _id)
        {
            Card temp = players.Find(card => card.id == _id);
            if ( temp == null)
            {
                Console.WriteLine("Couldn't find card #" + _id.ToString());
                return null;
            }
            return temp;
        }

        // Command #1
        public static void AddPlayer()
        {
            Card _tempPlayer = new Card();
            players.Add(_tempPlayer);
        }

        // Command #9
        public static void RemovePlayer(int _cardID)
        {
            Card temp = getCard(_cardID);
            players.Remove(temp);
        }

        // Displays all the players that are in the game
        public static void DisplayPlayers()
        {
            Console.WriteLine("List of players:");
            foreach(Card p in players)
            {
                Console.WriteLine("Card #" + p.id.ToString() + " and balance: " + p.balance.ToString());
            }
        }
    }
}
