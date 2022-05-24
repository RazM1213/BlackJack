using System.Collections.Generic;

namespace BlackJack
{
    public struct Value
    {
        public static Dictionary<string, int> Values = new Dictionary<string, int>()
        {
            {"TWO", 2 },
            {"THREE", 3 },
            {"FOUR", 4 },
            {"FIVE", 5 },
            {"SIX", 6 },
            {"SEVEN", 7 },
            {"EIGHT", 8 },
            {"NINE", 9 },
            {"TEN", 10 },
            {"JACK", 10 },
            {"QUEEN", 10 },
            {"KING", 10 },
            {"ACE", 11 }
        };
    }
}
