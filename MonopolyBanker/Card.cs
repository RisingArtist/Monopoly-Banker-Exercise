using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBanker
{
    // The player's card 
    class Card
    {
        static int numOfCards = 0;
        public int id;
        public float balance;

        public Card(float _balance = 0.0f)
        {
            id = ++numOfCards;
            balance = _balance;
        }

        public void DisplayBalance()
        {
            Console.WriteLine("Card #" + id.ToString() + "\'s Balance: " + balance.ToString());
        }
    }
}
