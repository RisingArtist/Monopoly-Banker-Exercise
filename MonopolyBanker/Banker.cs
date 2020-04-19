using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyBanker
{
    // Responsible for making transactions on the cards and transfers.
    static class Banker
    {
        static Card currentCard = null;
        public static bool hasCard
        {
            get;
            private set;
        }

        // Put a card in to work with
        public static void InsertCard(Card _card)
        {
            if(hasCard)
            {
                Console.WriteLine("Banker has a card already INSERTED!");
                return;
            }
            currentCard = _card;
            hasCard = true;
            Console.WriteLine("INSERTED Card #" + _card.id.ToString());
        }

        // Finish using the inserted card
        public static void EjectCard()
        {
            if (!hasCard)
            {
                Console.WriteLine("Banker doesn't have a card to EJECT!");
                return;
            }
            Console.WriteLine("EJECTED Card #" + currentCard.id.ToString());
            currentCard = null;
            hasCard = false;
        }

        // Initializes or Resets the card
        public static void InitializeCard()
        {
            if(!hasCard)
            {
                Console.WriteLine("Banker doesn't have a card to INITIALIZE!");
                return;
            }
            currentCard.balance = 15.000f;
            Console.WriteLine("Card #" + currentCard.id.ToString() + " INITIALIZED!");
        }

        // A shortcut to add GO to the inserted card's balance
        public static void PassGo()
        {
            if(!hasCard)
            {
                Console.WriteLine("Banker doesn't have a CARD!");
                return;
            }
            Add(2.000f);
            //Console.WriteLine("Card #" + currentCard.id.ToString() + " recieves 2 Mil for PASSING GO!");
        }

        // Add money to the inserted card's balance
        public static void Add(float _value)
        {
            if (!hasCard)
            {
                Console.WriteLine("Banker doesn't have a CARD!");
                return;
            }
            currentCard.balance += _value;
            Console.WriteLine("Card #" + currentCard.id.ToString() + " GAINED " + _value.ToString());
        }

        // Take money out of the inserted card's balance
        public static void Subtract(float _value)
        {
            if(!hasCard)
            {
                Console.WriteLine("Banker doesn't have a CARD!");
                return;
            }
            if(currentCard.balance - _value < 0.0f)
            {
                Console.WriteLine("Card #" + currentCard.id + " doesn't have enough money!");
                return;
            }
            currentCard.balance -= _value;
            Console.WriteLine("Card #" + currentCard.id.ToString() + " LOST " + _value.ToString());
        }

        // Handles transferring money between 2 players (cards)
        public static void Pay(Card from, Card other, float _amount)
        {
            if (hasCard && from == currentCard)
            {
                Pay(other, _amount);
                return;
            }
            else if(hasCard && from != currentCard)
            {
                EjectCard();
                InsertCard(from);
                Pay(other, _amount);
            }
            InsertCard(from);
            Pay(other, _amount);
            Console.WriteLine("Card #" + from.id.ToString() + " paid " + _amount.ToString() + " to Card #" + other.id.ToString());
        }

        // ...Same as above but the card thats going to pay is already inserted
        public static void Pay(Card other, float _amount)
        {
            Subtract(_amount);
            EjectCard();
            InsertCard(other);
            Add(_amount);
            Console.WriteLine("Card #" + currentCard.id.ToString() + " paid " + _amount.ToString() + " to Card #" + other.id.ToString());
        }
    }
}
