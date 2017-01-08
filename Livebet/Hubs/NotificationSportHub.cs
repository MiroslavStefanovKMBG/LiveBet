using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Livebet.Models;
using System.Threading.Tasks;

namespace Livebet.Hubs
{
    public class NotificationSportHub : Hub
    {
        public override Task OnConnected()
        {


            NotificationSports notificationSports = new NotificationSports();
            Clients.Caller.returnFullTableSports(notificationSports.GetTableSports());

            
            return base.OnConnected();
        }
    }
}