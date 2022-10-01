using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesTaxesCodingChallenge
{
    public class CurrencyToNumberConverter
    {
        public static Double ConvertFromCurrency(string numberInStringForm)
        {
            string newNumber;
            if (numberInStringForm.Contains("$"))
            {
                newNumber = numberInStringForm.Replace("$", "");
            }
            else
            {
                newNumber = numberInStringForm;
            }
            string strRegex = "/,/g";
            newNumber = Regex.Replace(newNumber, strRegex, "");
            return Double.Parse(newNumber);
        }
    }
}