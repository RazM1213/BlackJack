using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public int WinCount { get; set; } // Added set property
        public List<Card> Hand { get; set; }
        public int HandValue { get; set; }

        public Player()
        {
            this.WinCount = 0;
            this.Hand = new List<Card>();
            this.HandValue = 0;
        }

        public string GetHand() // Added method 
        {
            return String.Join(",", this.Hand);
        }

        private void AdjustForAce()
        {
            if (this.HandValue > 21)
            {
                this.HandValue -= 10;
            }
        }
        
        public void AddCard(Card cardToAdd)
        {
            this.Hand.Add(cardToAdd);
            this.HandValue += Value.Values[cardToAdd.Value];

            if (cardToAdd.Value == "ACE")
            {
                this.AdjustForAce();
            }
        }

        public bool IsLost() => this.HandValue > 21;
        
    }
}
