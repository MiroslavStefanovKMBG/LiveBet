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
    public class NotificationOdds
    {
        public void RegisterNotificationOdds()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString;
                string command = @"SELECT [Id],[Name],[Value],[SpecialBetValue],[Bet_ID] FROM [dbo].[Odds]";
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
                var notifHub = GlobalHost.ConnectionManager.GetHubContext<Hubs.NotificationOddHub>();

                using (MatchDBContext db = new MatchDBContext())
                {

                    notifHub.Clients.All.setValuesOdds(db.Odds);



                }



            }
            RegisterNotificationOdds();

        }

        public List<Odd> GetTableOdds()
        {
            using (MatchDBContext db = new MatchDBContext())
            {
                return db.Odds.ToList();
            }
        }

    }
}
    