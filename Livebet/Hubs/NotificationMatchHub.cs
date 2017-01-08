using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Livebet.Models;

namespace Livebet.Hubs
{
    public class NotificationMatchHub : Hub
    {
        public override Task OnConnected()
        {



            NotificationMatches notificationClass = new NotificationMatches();
            Clients.Caller.returnFullTableMatches(notificationClass.GetTableMatches());

          


            return base.OnConnected();
        }
    }
}