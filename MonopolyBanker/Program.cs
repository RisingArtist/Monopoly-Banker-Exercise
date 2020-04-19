using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isDone = false;
            float amount = 0.0f;
            int fromCardID;
            int toCardID;
            Card fromCard;
            Card toCard;

            Console.WriteLine("Welcome Banker!");
            Console.WriteLine("This program tries to mimic how the electronic banker version of monopoly works.");
            Console.WriteLine("Instead of paper money, each player has a card and the banker can only handle 1 at a time.");
            Console.WriteLine("Have fun playing as the banker!");

            //Game loop
            while (!isDone)
            {
                do
                {
                    Console.WriteLine();
                    GameManager.ShowCommand();
                    Console.WriteLine("#####################");
                    GameManager.DisplayPlayers();
                    Console.WriteLine("#####################");
                } while (!GameManager.isValidChoice());

                switch (GameManager.getAnswer())
                {
                    case "1":
                        GameManager.AddPlayer();
                        Console.Clear();
                        Console.WriteLine("Added in a new player!");
                        break;

                    case "2":
                        if (Banker.hasCard)
                        {
                            Console.Clear();
                            Console.WriteLine("Banker already has a card inserted!");
                            break;
                        }
                        int cardID = getCardID("Please enter the card id: ");
                        Console.Clear();
                        Banker.InsertCard(GameManager.getCard(cardID));
                        break;

                    case "3":
                        Console.Clear();
                        Banker.EjectCard();
                        break;

                    case "4":
                        amount = getAmount("How much do you want to add: "); 
                        Console.Clear();
                        Banker.Add(amount);
                        break;

                    case "5":
                        amount = getAmount("How much do you want to subtract: ");
                        Console.Clear();
                        Banker.Subtract(amount);
                        break;

                    case "6":
                        Console.Clear();
                        Banker.PassGo();
                        break;

                    case "7":
                        if (GameManager.players.Capacity < 2)
                        {
                            Console.WriteLine("Not Enough Players playing to pay another!");
                            break;
                        }
                       
                        fromCardID = getCardID("Please enter the card id to withdraw from: ");
                        fromCard = GameManager.getCard(fromCardID);

                        amount = getAmount("Please enter the amount to take out: ");

                        toCardID = getCardID("Please enter the card id to deposit to: ");
                        toCard = GameManager.getCard(toCardID);

                        Console.Clear();
                        Banker.Pay(fromCard, toCard, amount);
                        break;

                    case "8":
                        if (Banker.hasCard)
                        {
                            toCardID = getCardID("Please enter the card id to deposit to: ");
                            toCard = GameManager.getCard(toCardID);

                            amount = getAmount("Please enter the amount to take out: ");

                            Console.Clear();
                            Banker.Pay(toCard, amount);
                        }
                        break;

                    case "9":
                        cardID = getCardID("Please enter the card id to remove: ");
                        GameManager.RemovePlayer(cardID);
                        Console.Clear();
                        Console.WriteLine("Removed Card #" + cardID);
                        break;

                    case "0":
                        Console.Clear();
                        Banker.InitializeCard();
                        break;

                    case "q":
                    case "Q":
                        isDone = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }

        private static float getAmount(string message)
        {
            float amount;
            do
            {
                Console.Write(message);
            } while (!GameManager.isValidAmount());
            amount = float.Parse(GameManager.getAnswer());
            return amount;
        }

        private static int getCardID(string message)
        {
            do
            {
                Console.Write(message);
            } while (!GameManager.isValidCard());
            int cardID = Int32.Parse(GameManager.getAnswer());
            return cardID;
        }
    }
}
