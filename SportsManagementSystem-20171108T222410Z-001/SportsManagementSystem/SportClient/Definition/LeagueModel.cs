using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{
    public class LeagueModel
    {
        public int ID
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public string Category
        {
            get;set;
        }
        public decimal Price
        {
            get;set;
        }
        public string Desc
        {
            get;set;
        }
        public DateTime sDate
        {
            get;set;
        }
        public DateTime eDate
        {
            get;set;
        }
        public int NumTeams
        {
            get;set;
        }
        public int UserID
        {
            get;set;
        }
    }
}