using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using encoder;

namespace Encoder
{
    // this class 
    public class EncoderProcessor : IEncoderProcessor
    {
        private readonly Dictionary<char, char> _letterDictinary;
       public EncoderProcessor(Dictionary<char, char> letterDictinary)
        {
            _letterDictinary = letterDictinary;
        }


        public string Encode(string message)
        {
            StringBuilder result = new StringBuilder();
            Stack<char> numbers = new Stack<char>();

            var input = message.ToLower();
            var lastDigitWasNumber = false;
            try
            {
            foreach (var c in input)
            {
                var charType = char.IsDigit(c) ? "digit" : "";
                switch (charType)
                {
                    case "digit":
                        numbers.Push(c);
                        lastDigitWasNumber = true;
                        break;
                    default:
                        if (lastDigitWasNumber)
                        {

                            result.Append(NumberToEncodedString(numbers));
                            lastDigitWasNumber = false;
                        }
                        result.Append(GetCodeForChar(c));
                        break;
                }


            }
            if (numbers.Count > 0)
            {
                result.Append(NumberToEncodedString(numbers));
            }
            return result.ToString();
        }
            catch (Exception)
            {
                // handle the exception and log it .

            }
            return string.Empty;
}
        private string NumberToEncodedString(Stack<char> inputNumbers)
        {
            var result = string.Empty;
            while (inputNumbers.Count > 0)
                result += inputNumbers.Pop();
            inputNumbers.Clear();
            return result;
        }

        //private char letterValueEncoding(char val)
        //{
        //    switch (val)
        //    {
        //        case 'a': return '1';
        //        case 'e': return '2';
        //        case 'i': return '3';
        //        case 'o': return '4';
        //        case 'u': return '5';
        //        case 'y': return ' ';
        //        default: return (char)(val - 1);
        //    }
        //}

        /// <summary>
        /// // get the encoded char for gievn character
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private char GetCodeForChar(char c)
        {
            var charType = char.IsLetter(c) ? "letter" : char.IsWhiteSpace(c) ? "WhiteSpace" : "";
            switch (charType)
            {

                case "letter":
                case "WhiteSpace":
                    if (_letterDictinary.ContainsKey(c))
                        return _letterDictinary[c];
                    else
                        return (char)(c - 1);                
                default:
                    return c;
            }
        }
    }
}