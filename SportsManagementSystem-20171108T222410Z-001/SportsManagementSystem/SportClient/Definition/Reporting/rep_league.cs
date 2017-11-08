using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition.Reporting
{
    public class rep_league
    {
        public string LeagueName
        {
            get;set;
        }
        public int Wins
        {
            get; set;
        }
        public int Draws
        {
            get; set;
        }
        public int Lose
        {
            get; set;
        }
    }
}