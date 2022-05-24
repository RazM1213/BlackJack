using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> Cards { get; }
        public int NumCards { get; set; }
        public Deck()
        {
            this.Cards = new List<Card>();

            for (int i = 0; i < Enum.GetValues(typeof(Suit)).Length; i++)
            {
                foreach (KeyValuePair<string, int> pair in Value.Values)
                {
                    Cards.Add(new Card((Suit)i, pair.Key));
                }
            }

            this.NumCards = this.Cards.Count;
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < this.NumCards; i++)
            {
                int firstIndex = random.Next(this.NumCards);
                int secondIndex = random.Next(this.NumCards);

                Card temp = this.Cards[firstIndex];
                this.Cards[firstIndex] = this.Cards[secondIndex];
                this.Cards[secondIndex] = temp;
            }
        }

        public Card DealCard()
        {
            int lastIndex = this.Cards.Count - 1;
            Card lastCard = this.Cards[lastIndex];

            this.Cards.RemoveAt(lastIndex);
            return lastCard;

        }
    }
}
