using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using Livebet.Context;
using Microsoft.AspNet.SignalR;

namespace Livebet.Models
{
    public class TimerCheck:System.Web.HttpApplication

    {
       

        /// <summary>
        /// Starting Timer to check every x seconds new updates
        /// </summary>
        public  void TimerStart()

        {
            Timer timer = new Timer();

            timer.Interval = 30000;
            timer.Elapsed += timer_Elapsed;

            timer.Start();

        }

        void timer_Elapsed(object s,EventArgs args)
        {

            //db.Database.Delete();
            using (MatchDBContext db = new MatchDBContext()) {
                XmlToDatabase newFilter = new XmlToDatabase();
                newFilter.DataImport();
                newFilter.DeleteOldItems();
                db.SaveChanges();
                
            }

            

        }
      

    }
}