using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livebet.Models;
using Livebet.Context;

namespace Livebet.Controllers
{

    public class DefaultController : Controller
    {
        public ActionResult Index()
        {

            using (MatchDBContext db = new MatchDBContext())
            {
                //db.Database.Delete();

                //NewFilter newFilter = new NewFilter();
                //newFilter.DataImport();

                List<object> MultyList = new List<object>();
                MultyList.Add(db.Sports.ToList());
                MultyList.Add(db.Events.ToList());
                MultyList.Add(db.Matches.ToList());
                MultyList.Add(db.Bets.ToList());
                MultyList.Add(db.Odds.ToList());




                return View(MultyList);


            }




        }

    }
}
