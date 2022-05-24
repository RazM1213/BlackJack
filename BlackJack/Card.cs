namespace BlackJack
{
    public class Card
    {
        public Suit Suit { get; }
        public string Value { get; }

        public Card(Suit suit, string value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value + " Of " + this.Suit;
        }
    }
}
