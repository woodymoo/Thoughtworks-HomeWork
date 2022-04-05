using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    /// <summary>
    /// roman digit
    /// </summary>
    public class RomanNumbers
    {
        /// <summary>
        /// Gets or sets the roman number string.
        /// </summary>
        /// <value>The roman number string.</value>
        public string RomanNumberString { get; set; }
        char[] romanSymbols;

        public RomanNumbers( string romanNumberString)
        {
            RomanNumberString = romanNumberString;
            romanSymbols = RomanNumberString.ToArray();
        }

        /// <summary>
        /// Gets the Decimal integer value of the Roman Number string.
        /// </summary>
        /// <returns>The value.</returns>
        public int GetValue()
        {
            
            //int index = 0;
            //List<int> dealedRomanSymbolValueList = new List<int>();
            int TotalRomanSymbolValue = 0;

            Validate();
            for (int index = 0; index < romanSymbols.Length; index++)
            {
                int currentValue = RomanSymbolValueMap.Parse(romanSymbols[index]).DecimalValue;
                int nextValue = 0;
                if ( index < romanSymbols.Length - 1 )
                    nextValue = RomanSymbolValueMap.Parse(romanSymbols[index + 1]).DecimalValue;

                if ( index >= romanSymbols.Length)
                {
                    TotalRomanSymbolValue += currentValue;
                }
                    
                if (currentValue < nextValue)
                {
                    TotalRomanSymbolValue += (nextValue - currentValue);
                    index += 1;
                }
                else
                {
                    TotalRomanSymbolValue += currentValue;
                }
            }


            // add last value
            //if (index == romanSymbols.Length - 1)
            //{
            //    dealedRomanSymbolValueList.Add(RomanSymbolValueMap.Parse(romanSymbols[index]).decimalValue);
            //}

            //int sumOfRomanSymbolValue = 0;
            //foreach (var value in dealedRomanSymbolValueList)
            //{
            //    sumOfRomanSymbolValue += value;
            //}
            return TotalRomanSymbolValue;

        }

        private void Validate()
        {
            ValidateRepeat();
            ValidateSubstractPairs();
            ValidateSymbolOrder();
        }

        private void ValidateRepeat()
        {
            
            for (int i = 0; i < RomanSymbolValueMap.RomanSymbols.Count; i++)
            {
                char symbol = RomanSymbolValueMap.RomanSymbols[i].Symbol;

                string pattern;
                if (RomanSymbolValueMap.RomanSymbols[i].AllowRepeat)
                {
                    pattern = symbol.ToString() + symbol.ToString() + symbol.ToString() + symbol.ToString();
                }
                else
                {
                    pattern = symbol.ToString() + symbol.ToString();
                }
                if (RomanNumberString.Contains(pattern) )
                {
                    string repeatNumber = RomanSymbolValueMap.RomanSymbols[i].AllowRepeat ? "3" : "1";
                    throw new ArgumentException(
                        $"The Roman Symbol {symbol.ToString()} does not allow to repeat more than {repeatNumber} times");
                 }
            }
        }


        /// <summary>
        /// Validates the position of the roman symbols in roman number string.
        /// </summary>
        private void ValidateSubstractPairs()
        {
            // check substruction pairs, and generate a symbol list without substracters. 
            for (int i = 0; i < romanSymbols.Length -1; i++)
            {
                var currentSymbol = romanSymbols[i];
                char nextSymbol = currentSymbol;
                var currentSymbolValue = RomanSymbolValueMap.Parse(currentSymbol).DecimalValue;
                int nextSymbolValue = currentSymbolValue;
                if (i < romanSymbols.Length - 1)
                {
                    nextSymbol = romanSymbols[i + 1];
                    nextSymbolValue = RomanSymbolValueMap.Parse(nextSymbol).DecimalValue;

                }
                if (currentSymbolValue < nextSymbolValue)
                {
                    
                    var allowedNextSymbols = RomanSymbolValueMap.Parse(currentSymbol).AllowSubtractedBy;
                    if ( allowedNextSymbols == null || allowedNextSymbols.Count() <= 0 )
                    {
                        throw new ArgumentException($"Invalid symbol ({currentSymbolValue}) in Roman Number String.");
                    }
                    if (allowedNextSymbols.Contains<char>(nextSymbol) == false)
                    {
                        throw new ArgumentException($"Invalid symbol ({nextSymbol.ToString()}) in Roman Number String.");
                    }

                    // substracter symbol should only repeat once.
                    ValidateSubstracterNotRepeat(currentSymbol);

                    // skip the next symbol;
                    i++;
                }


            }

        }

        private void ValidateSymbolOrder()
        {
            int previousSymbolValue = 0;
            for (int i = 0; i < romanSymbols.Length - 1 ; i++ )
            {
                //var previousSymbolValue = RomanSymbolValueMap.RomanSymbols[i - 1].decimalValue;
                var currentSymbolValue = RomanSymbolValueMap.Parse(romanSymbols[i]).DecimalValue;
                var nextSymbolValue = RomanSymbolValueMap.Parse(romanSymbols[i + 1]).DecimalValue;
                if (currentSymbolValue < nextSymbolValue)
                {
                    // should be substract pair
                    if ( previousSymbolValue != 0 && previousSymbolValue < nextSymbolValue )
                    {
                        throw new ArgumentException($"Invalid symbol ({romanSymbols[i]}), the symbols should be placed in order, except of substracter.");
                    }
                    previousSymbolValue = nextSymbolValue;
                    i++;
                }
                else
                {
                    previousSymbolValue = currentSymbolValue;
                }
            }

        }

        char previousSymbol = (char)0;
        private void ValidateSubstracterNotRepeat(char currentSymbol)
        {
            if ( currentSymbol != previousSymbol )
            {
                previousSymbol = currentSymbol;
            }
            else
            {
                throw new ArgumentException($"Invalid substracter symbol ({currentSymbol})");
            }
        }
    }


}
