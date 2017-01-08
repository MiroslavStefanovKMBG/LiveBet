The App works with external XML by default. 

If you want to change to local test file you need to provide the correct path to the file on the top of the class
XmlToDatabase.cs

Timer settings are in TimerCheck.cs class. By default the Timer checks for changes every 60 secs and if there are any it updates the database in XmlToDatabase.cs class.

The Database recreates whenever there are changes in any of the following classes: Sport.cs, Bet.cs, Event.cs, Match.cs, Odd.cs or in context class MatchDBContext.cs.



!!! Atention: after changes in any of these classes the database will be recreated and previous data will be deleted. If you'd like to preserve something please backup your data before you proceed !!!

The App reflects each change in the XML Data every 60 sec and represents the most up to date data without the need of refresh of the site.

The App represents all the events which are incoming within the next 24 hours.


ALTER DATABASE [dbname] SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE

<connectionStrings>
    <add name="MatchDBContext" connectionString="Data Source=SQL5033.SmarterASP.NET;Initial Catalog=DB_A09C78_LiveBet3;User Id=DB_A09C78_LiveBet3_admin;Password=LiveBet123456;MultipleActiveResultSets=true; "

 providerName="System.Data.SqlClient" />

  </connectionStrings>


 ---------------------------------------
 <connectionStrings>
    <add name="MatchDBContext" connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true; ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"

 providerName="System.Data.SqlClient" />

  </connectionStrings>