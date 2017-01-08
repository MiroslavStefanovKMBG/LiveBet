using Livebet.Context;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace Livebet.Models
{
    public class NotificationSports:Hub
    {
        public void RegisterNotificationSports()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString;
                string command = @"SELECT [Id],[Name] FROM [dbo].[Sports]";
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
                var notifHub = GlobalHost.ConnectionManager.GetHubContext<Hubs.NotificationSportHub>();

                using (MatchDBContext db = new MatchDBContext())
                {

                    notifHub.Clients.All.setValuesSports(db.Sports);



                }



            }
            RegisterNotificationSports();

        }

        public List<Sport> GetTableSports()
        {
            using (MatchDBContext db = new MatchDBContext())
            {
                return db.Sports.ToList();
            }
        }

    }
}
    
  