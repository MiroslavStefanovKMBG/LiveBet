using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Livebet.Context;
using Microsoft.AspNet.SignalR;

namespace Livebet.Models
{
    public class NotificationMatches
    {
        public void RegisterNotificationMatches()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString;
                string command = @"SELECT [Id],[Name],[StartDate],[Type] FROM [dbo].[Matches]";
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
                var notifHub = GlobalHost.ConnectionManager.GetHubContext<Hubs.NotificationMatchHub>();

                using (MatchDBContext db = new MatchDBContext())
                {

                    notifHub.Clients.All.setValuesMatches(db.Matches);



                }



            }
            RegisterNotificationMatches();

        }

        public List<Match> GetTableMatches()
        {
            using (MatchDBContext db = new MatchDBContext())
            {
                return db.Matches.ToList();
            }
        }

    }
}
 