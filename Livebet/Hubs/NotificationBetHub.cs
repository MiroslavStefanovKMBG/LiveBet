using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Livebet.Models;

namespace Livebet.Hubs
{
    public class NotificationBetHub : Hub
    {
        public override Task OnConnected()
        {



            NotificationBets notificationBets = new NotificationBets();
            Clients.Caller.returnFullTableBets(notificationBets.GetTableBets());

          


            return base.OnConnected();
        }
    }
}