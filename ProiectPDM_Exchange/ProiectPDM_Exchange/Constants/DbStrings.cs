using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProiectPDM_Exchange.Constants
{
    public class DbStrings
    {
        public static readonly string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "exchangeRateDb.db3");
    }
}
