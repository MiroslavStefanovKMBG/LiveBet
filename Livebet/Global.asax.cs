using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Livebet.Context;
using Livebet.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Livebet
{
    public class MvcApplication : System.Web.HttpApplication
    {
       string con = ConfigurationManager.ConnectionStrings["MatchDBContext"].ConnectionString;

        protected void Application_Start()
        {
            TimerCheck timer = new TimerCheck();
            timer.TimerStart();
            Database.SetInitializer(new SportSeeder());

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MatchDBContext>());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            try
            {
                SqlDependency.Start(con);
            }
            catch { }







        }
        protected void Session_Start(object sender, EventArgs e)
        {
            
            NotificationSports NS = new NotificationSports();
            NS.RegisterNotificationSports();
            NotificationBets NB = new NotificationBets();
            NB.RegisterNotificationBets();
            NotificationEvents NE = new NotificationEvents();
            NE.RegisterNotificationEvent();
            NotificationMatches NC = new NotificationMatches();
            NC.RegisterNotificationMatches();
            NotificationOdds NO = new NotificationOdds();
            NO.RegisterNotificationOdds();
        }
        protected void Application_End()
        {
            //here we will stop Sql Dependency
            SqlDependency.Stop(con);
        }
    }
}
