using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Livebet.Models;
using System.Data.Entity;

namespace Livebet.Context
{
    public class MatchDBContext: DbContext
    {
        public DbSet<Sport> Sports { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Match> Matches { get; set; }


        public DbSet<Bet> Bets { get; set; }

        public DbSet<Odd> Odds { get; set; }

       
    }
    
}