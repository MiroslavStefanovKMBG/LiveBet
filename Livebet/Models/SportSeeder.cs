using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Livebet.Context;

namespace Livebet.Models
{
    public class SportSeeder : DropCreateDatabaseIfModelChanges<MatchDBContext>
    {


        protected override void Seed(MatchDBContext context)
        {

            
           

           
                
                base.Seed(context);
            }
        }
    }
 