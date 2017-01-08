using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Livebet.Models
{
    public class Sport
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string Name{ get; set; }

        [ForeignKey("Sport_ID")]
        public List<Event> Events { get; set; }
    }
}