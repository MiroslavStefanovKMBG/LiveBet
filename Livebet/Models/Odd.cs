using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Livebet.Models
{
    public class Odd
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
        public string SpecialBetValue { get; set; }
     
        public int? Bet_ID { get; set; }
    }
}