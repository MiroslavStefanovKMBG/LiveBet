using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Livebet.Models
{
    public class Event

    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }


        public string Name { get; set; }
        
        

        public bool IsLive { get; set; }
        public int CategoryID { get; set; }
        public int Sport_ID { get; set; }

        


    }
}
    