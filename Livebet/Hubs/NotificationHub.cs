using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Livebet.Models;
using Microsoft.AspNet.SignalR;



namespace Livebet.Hubs
{
    public class NotificationHub : Hub
    {
        public override  Task OnConnected()
        {
            

            NotificationSports notificationSports = new NotificationSports();
            Clients.All.returnFullTableSports(notificationSports.GetTableSports());
      
            NotificationEvents notificationEvents = new NotificationEvents();
            Clients.All.returnSportEv(notificationEvents.GetSportEv());

            NotificationMatches notificationClass = new NotificationMatches();
            Clients.All.returnFullTableMatches(notificationClass.GetTableMatches());

            NotificationBets notificationBets = new NotificationBets();
            Clients.All.returnFullTableBets(notificationBets.GetTableBets());

            NotificationOdds notificationOdds = new NotificationOdds();
            Clients.All.returnFullTableOdds(notificationOdds.GetTableOdds());


            return base.OnConnected();
        }
         
       
    }
}