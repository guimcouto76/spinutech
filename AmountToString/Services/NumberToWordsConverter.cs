using AmountToString.Interfaces;

namespace AmountToString.Services
{
    public class NumberToWordsConverter : INumberToWordsConverter
    {
        public string ConvertAmountToWords(decimal amount)
        {
            var dollars = (long)Math.Floor(amount);
            var cents = (int)((amount - dollars) * 100);

            string dollarsInWords = ConvertNumberToWords(dollars);
            string result = cents > 0 ? $"{dollarsInWords} and {cents:00}/100 dollars" : $"{dollarsInWords} dollars";

            return CapitalizeFirstLetter(result);
        }

        private static string ConvertNumberToWords(long number)
        {
            if (number == 0) return "zero";

            if (number < 0) return "minus " + ConvertNumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertNumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertNumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertNumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != string.Empty) words += " ";
                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                    "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
                    "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            if (input.Length == 1) return input.ToUpper();

            // Make the first character uppercase and the rest lowercase
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
