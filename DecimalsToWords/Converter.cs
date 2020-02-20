using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalsToWords
{
    internal class Converter
    {

        static internal string DecimalToWords(decimal number)
        {
            StringBuilder sb = new StringBuilder();

            int intComponent = (int)number;

            decimal decComponent = Math.Abs(number - (decimal)intComponent);

            AppendIntegerString(intComponent, sb);

            AppendPoint(decComponent, sb);

            AppendDecimalString(decComponent, sb);

            return sb.ToString().TrimEnd();
        }

        static void AppendIntegerString(int intValue, StringBuilder sb)
        {
            if(intValue == 100)
            {
                sb.Append("One hundred");
                return;
            }

            if(intValue == 0)
            {
                sb.Append(UniqueNumbers[0]);
                return;
            }

            if(intValue < 0)
            {
                sb.Append("negative ");
                intValue *= -1;
            }

            while(intValue > 0)
            {
                if(intValue >= 20 || intValue / 10 <= 99)
                {
                    int tensValue = intValue / 10;
                    if(tensValue >= 2)
                    {
                        sb.Append(dictTensValues[tensValue * 10]);
                        intValue -= tensValue * 10;
                    } else
                    {
                        sb.Append(UniqueNumbers[intValue]);
                        intValue = 0;
                    }
                }
            }
        }
        
        static void AppendPoint(decimal decValue, StringBuilder sb)
        {
            if(decValue.ToString().IndexOf('.') != -1)
            {
                sb.Append("point ");
            }
        }

        static void AppendDecimalString(decimal decValue, StringBuilder sb)
        {
            string strDec = decValue.ToString();

            string[] arrIntegerAndDecimalParts = decValue.ToString().Split(new char[] { '.' });

            if(arrIntegerAndDecimalParts.Length < 2)
            {
                return;
            }

            foreach(char numeral in arrIntegerAndDecimalParts[1])
            {
                sb.Append(singleDigits[numeral]);
            }
        }

        static string[] UniqueNumbers = new string[]
        {
            "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine ",
            "ten ", "eleven ", "twelve ", "thirteen ", "fourteen ", "fifteen ", "sixteen ", "seventeen ",
            "eighteen ", "nineteen "
        };

        static Dictionary<char, string> singleDigits = new Dictionary<char, string>()
        {
            { '0', UniqueNumbers[0] },
            { '1', UniqueNumbers[1] },
            { '2', UniqueNumbers[2] },
            { '3', UniqueNumbers[3] },
            { '4', UniqueNumbers[4] },
            { '5', UniqueNumbers[5] },
            { '6', UniqueNumbers[6] },
            { '7', UniqueNumbers[7] },
            { '8', UniqueNumbers[8] },
            { '9', UniqueNumbers[9] }
        };

        static Dictionary<int, string> dictTensValues = new Dictionary<int, string>()
        {
            { 20, "twenty " },
            { 30, "thirty " },
            { 40, "forty " },
            { 50, "fifty " },
            { 60, "sixty " },
            { 70, "seventy " },
            { 80, "eighty " },
            { 90, "ninety " }
        };
    }
}
