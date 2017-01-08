using Livebet.Context;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Livebet.Models
{
    public class NotificationEvents
    {

        public void RegisterNotificationEvent()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString;
                string command = @"SELECT [Id],[Name],[Sport_ID],[IsLive],[CategoryID] FROM [dbo].[Events]";
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    if (con.State != System.Data.ConnectionState.Open)
                    {

                        con.Open();

                    }
                    cmd.Notification = null;
                    SqlDependency sDep = new SqlDependency(cmd);
                    sDep.OnChange += sqlDep_OnChange;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                    }
                }
            }
            catch
            {
            }
        }
        void sqlDep_OnChange(object s, SqlNotificationEventArgs e)
        {

            if (e.Type == SqlNotificationType.Change)
            {
                var notifHub = GlobalHost.ConnectionManager.GetHubContext<Hubs.NotificationEventHub>();

                using (MatchDBContext db = new MatchDBContext())
                {

                    notifHub.Clients.All.setValuesEvents(db.Events);



                }



            }
            RegisterNotificationEvent();

        }


        public List<Event> GetSportEv()
        {
            using (MatchDBContext db = new MatchDBContext())
            {
                return db.Events.ToList();
            }
        }
    }
 }
