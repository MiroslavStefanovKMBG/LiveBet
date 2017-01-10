using Livebet.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data.Entity.Migrations;


namespace Livebet.Models
{
    public class XmlToDatabase
    {
       
        public void DataImport()
        {
            //try
            //{
            //    DeleteOldItems();//Delete old Matches
            //}
            //catch
            //{
            //    throw new Exception();
            //}
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(@"http://vitalbet.net/sportxml"); // NWebFile
                //doc.Load(@"C:\Users\momo\Desktop\Livebet5.01.2017-9.00h-working\Livebet5.01.2017-19.00h-working-FinallToSend\Livebet\Livebet\XMLFile2.xml");//Locall File
            }
            catch
            {
            }

            //----------------------fromXml----------------------------------------
            XmlNodeList elementListSports = doc.GetElementsByTagName("Sport");
            XmlNodeList elementListEvent = doc.GetElementsByTagName("Event");
            XmlNodeList elementListMatch = doc.GetElementsByTagName("Match");
            XmlNodeList elementListBet = doc.GetElementsByTagName("Bet");
            XmlNodeList elementListOdd = doc.GetElementsByTagName("Odd");


            try
            {
                foreach (XmlNode item in elementListSports)
                {
                    using (MatchDBContext db = new MatchDBContext())
                    {

                        db.Sports.AddOrUpdate(s => s.Id,
                     new Sport()
                     {
                         Id = CheckIntegers(item.Attributes["ID"]),
                         Name = CheckStrings(item.Attributes["Name"])
                     });

                        db.SaveChanges();
                    }
                }
            }
            catch
            {}
            try
            {

                foreach (XmlNode item2 in elementListEvent)
                {
                    using (MatchDBContext db = new MatchDBContext())
                    {

                        db.Events.AddOrUpdate(e => e.Id,
                        new Event()
                        {
                            Id = CheckIntegers(item2.Attributes["ID"]),
                            Name = CheckStrings(item2.Attributes["Name"]),

                            IsLive = CheckBooleans(item2.Attributes["IsLive"]),
                            Sport_ID = CheckIntegers(item2.ParentNode.Attributes["ID"]),
                            CategoryID = CheckIntegers(item2.Attributes["CategoryID"])

                        });
                        db.SaveChanges();
                    }
                }
            }
            catch
            { }
            try
            {
                foreach (XmlNode itemMatch in elementListMatch)
                {

                    DateTime startDate = Convert.ToDateTime(itemMatch.Attributes["StartDate"].Value);
                    if (startDate.AddHours(3) > DateTime.Now.ToUniversalTime() && startDate.AddHours(-3) < DateTime.Now.ToUniversalTime().AddHours(24))
                    {
                        using (MatchDBContext db = new MatchDBContext())
                        {


                            int id = Convert.ToInt32(itemMatch.Attributes["ID"].Value);

                            db.Matches.AddOrUpdate(m => m.Id,
                            new Match()
                            {
                                Id = id,
                                Name = CheckStrings(itemMatch.Attributes["Name"]),
                                StartDate = startDate,
                                Type = CheckStrings(itemMatch.Attributes["MatchType"]),
                               
                                Event_ID = CheckIntegers(itemMatch.ParentNode.Attributes["ID"])

                            });
                            db.SaveChanges();
                        }


                        foreach (XmlNode itemBets in itemMatch.ChildNodes)
                        {

                            using (MatchDBContext db = new MatchDBContext())
                            {

                                db.Bets.AddOrUpdate(b => b.Id,
                                new Bet()
                                {
                                    Id = CheckIntegers(itemBets.Attributes["ID"]),
                                    Name = CheckStrings(itemBets.Attributes["Name"]),
                                    IsLive = CheckBooleans(itemBets.Attributes["IsLive"]),
                                    Match_ID = CheckIntegers(itemBets.ParentNode.Attributes["ID"])



                                });

                                db.SaveChanges();

                            }





                            foreach (XmlNode itemOdds in itemBets.ChildNodes)
                            {
                                using (MatchDBContext db = new MatchDBContext())
                                {

                                    try
                                    {
                                        db.Odds.AddOrUpdate(o => o.Id,
                                            new Odd()
                                            {

                                                Id = CheckIntegers(itemOdds.Attributes["ID"]),
                                                Name = CheckStrings(itemOdds.Attributes["Name"]),
                                                Value = CheckStrings(itemOdds.Attributes["Value"]),
                                                Bet_ID = CheckIntegers(itemOdds.ParentNode.Attributes["ID"]),
                                                SpecialBetValue = CheckStrings(itemOdds.Attributes["SpecialBetValue"])


                                            });

                                        db.SaveChanges();
                                    }
                                    catch
                                    { }

                                }
                            }



                        }
                    }


                }





            }
            catch
            { }
        }


     protected   string CheckStrings(XmlNode item)
        {
            if (item == null)
            {
                return "null";
            }
            else
            {
                return item.Value;
                
            }

            
        }
        protected int CheckIntegers(XmlNode item)
        {
            if (item == null)
            {
                return 0;
            }
            else
            {
                int integerItem=0;
                try
                {

                    integerItem = Convert.ToInt32(item.Value);

                }
                catch { }
                
                
                    return integerItem;
                
            }
        }
        protected bool CheckBooleans(XmlNode item)
        {
            if (item == null)
            {
                return false;
            }
            else
            {
                bool booleanItem =false;
                try
                {

                    booleanItem = Convert.ToBoolean(item.Value);

                }
                catch { }


                return booleanItem;

            }
        }
        
        
        protected decimal CheckDecimal(XmlNode item)
        {
            if (item == null)
            {
                return 0;
            }
            else
            {
                decimal decimalItem = 0m;
                try
                {

                    decimalItem = Convert.ToDecimal(item.Value.Replace(".",","));

                }
                catch { }


                return decimalItem;

            }
        }
        DateTime date = DateTime.UtcNow.AddHours(-3);
        public void DeleteOldItems()
        {
            //Delete old Matches
            using (MatchDBContext db = new MatchDBContext())
            {
                

                foreach (var itemMatch in from c in db.Matches where c.StartDate < date select c)
                {

                    db.Matches.Remove(itemMatch);


                    foreach (var itemBet in from c in db.Bets where c.Match_ID == itemMatch.Id select c)
                    {
                        db.Bets.Remove(itemBet);



                        foreach (var itemOdd in from c in db.Odds where c.Bet_ID == itemBet.Id select c)
                        {
                            db.Odds.Remove(itemOdd);


                        }
                    }

                }
                try
                {
                    db.SaveChanges();
                }
                catch { }


            }
        }
            
        
    }
         

}

    


            
        
   




