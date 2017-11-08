using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition.Reporting
{
    public class bestplayer
    {
        public int ID
        {
            get;set;
        }
        public int leagueID
        {
            get;set;
        }
        public int Goals
        {
            get;set;
        }
        public decimal Average
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
    }
}