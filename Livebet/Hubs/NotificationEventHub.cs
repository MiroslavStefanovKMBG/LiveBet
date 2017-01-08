using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Livebet.Models;

namespace Livebet.Hubs
{
    public class NotificationEventHub : Hub
    {
        public override Task OnConnected()
        {


            

            NotificationEvents notificationEvents = new NotificationEvents();
            Clients.Caller.returnSportEv(notificationEvents.GetSportEv());

            
            


            return base.OnConnected();
        }
    }
}