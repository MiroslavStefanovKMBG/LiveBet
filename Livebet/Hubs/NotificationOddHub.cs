using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Livebet.Models;

namespace Livebet.Hubs
{
    public class NotificationOddHub : Hub
    {
        public override Task OnConnected()
        {



            NotificationOdds notificationOdds = new NotificationOdds();
            Clients.Caller.returnFullTableOdds(notificationOdds.GetTableOdds());


            return base.OnConnected();
        }
    }
}