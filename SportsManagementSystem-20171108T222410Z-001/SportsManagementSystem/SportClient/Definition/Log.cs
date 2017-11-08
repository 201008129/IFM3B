using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{
    public class Log
    {
        public int ID
        {
            get;set;
        }
        public string TeamName
        {
            get;set;
        }
        public int Position
        {
            get;set;
        }
        public int MatchPlayed
        {
            get;set;
        }
        public int Wins
        {
            get;set;
        }
        public int Loose
        {
            get;set;
        }
        public int Draws
        {
            get;set;
        }
        public int Points
        {
            get;set;
        }
        public int League_ID
        {
            get; set;
        }
        public string LeagueName
        {
            get;set;
        }
       
    }
}