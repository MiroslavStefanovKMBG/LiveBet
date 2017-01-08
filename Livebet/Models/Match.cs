using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Livebet.Models
{
    public class Match
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    
        public string Type { get; set; }
        public int Event_ID { get; set; }


        [ForeignKey("Match_ID")]
        public List<Bet>Bet { get; set; }

        

    }
}