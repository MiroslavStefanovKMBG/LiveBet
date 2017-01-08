using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Livebet.Models
{
    public class Bet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsLive { get; set; }
        public int Match_ID { get; set; }

        [ForeignKey("Bet_ID")]
        public List<Odd> Odd { get; set; }


    }

}