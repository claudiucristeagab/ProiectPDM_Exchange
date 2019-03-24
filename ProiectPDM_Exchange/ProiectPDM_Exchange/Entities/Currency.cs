using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDM_Exchange.Entities
{
    [Table ("Currencies")]
    public class Currency
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
