using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    // a class map the roman symbol to decimal value
    public class RomanSymbolValueMap
    {
        public static List<RomanSymbolValueMap> RomanSymbols { get; } = new List<RomanSymbolValueMap>
        {
            new RomanSymbolValueMap('I', 1, true, new char[]{'V', 'X'}),

            new RomanSymbolValueMap('V', 5, false, new char[]{}) ,

            new RomanSymbolValueMap('X', 10, true, new char[]{'L', 'C'}),
            new RomanSymbolValueMap('L', 50, false, new char[]{}),
            new RomanSymbolValueMap('C', 100, true, new char[]{'D', 'M'}),
            new RomanSymbolValueMap('D', 500, false, new char[] {}),
            new RomanSymbolValueMap('M', 1000, true, new char[] {} )
        };

        public readonly static ILookup<char, RomanSymbolValueMap> RomanSymbolValueLookup
            = RomanSymbols.ToLookup(item => item.Symbol);

        private RomanSymbolValueMap(
            char symbol,
            int decimalValue,
            bool allowRepeat,
            //bool allowSubtract,
            IEnumerable<char> allowSubtractedBy
        )
        {
            Symbol = symbol;
            DecimalValue = decimalValue;
            AllowRepeat = allowRepeat;
            //AllowSubtract = allowSubtract;
            AllowSubtractedBy = allowSubtractedBy;

        }

        public char Symbol { get; private set; }

        public int DecimalValue { get; private set; }

        public bool AllowRepeat { get; private set; }

        //public bool AllowSubtract { get; private set; }

        public IEnumerable<char> AllowSubtractedBy { get; private set; }

        public RomanSymbolValueMap this[char symbol]
        {
            get
            {
                return RomanSymbolValueMap.Parse(symbol);
            }
        }

        public static RomanSymbolValueMap Parse(char symbol)
        {
            if (!RomanSymbolValueLookup.Contains(symbol))
            {
                throw new ArgumentException($"({symbol.ToString()}) is invalid Roman Symbol");
            }

            return RomanSymbolValueLookup[symbol].First();
        }
    }


}
