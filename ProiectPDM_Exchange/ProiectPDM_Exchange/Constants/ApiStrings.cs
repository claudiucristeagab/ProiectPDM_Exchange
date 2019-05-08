using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDM_Exchange.Constants
{
    public class ApiStrings
    {
        public static readonly string Base = $"https://api.exchangeratesapi.io/";
        public static readonly string Latest = $"https://api.exchangeratesapi.io/latest?base=";
        public static readonly string DefaultCurrency = "EUR";
        public static readonly string History = $"https://api.exchangeratesapi.io/history?";
        public static readonly string Image = "https://raw.githubusercontent.com/transferwise/currency-flags/master/src/flags/";
    }
}
