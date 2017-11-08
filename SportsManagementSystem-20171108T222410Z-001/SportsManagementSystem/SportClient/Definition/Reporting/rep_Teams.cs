using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition.Reporting
{
    public class rep_Teams
    {
        public int S_ID
        {
            get; set;
        }

        public string LeagueName
        {
            get;set;
        }
        public string Manager
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public int numPlayers
        {
            get;set;
        }
        public decimal Average
        {
            get;set;
        }
    }
}