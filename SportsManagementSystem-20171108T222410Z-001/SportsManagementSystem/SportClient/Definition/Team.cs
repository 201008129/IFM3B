using SportClient.Definition.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{
    public class Team
    {
        public int ID
        {
            get;set;
        }
        public string Type
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public string LeagueName
        {
            get; set;
        }
        public int NumPlayers
        {
            get;set;
        }
        public string Desc
        {
            get;set;
        }
        public int foreignID
        {
            get;set;
        }
        public int F_League
        {
            get; set;
        }
        public string ImagePath
        {
            get;set;
        }
   //Game Info
        //Cat
        public string Category
        {
            get;set;
        }
        public string T1
        {
            get;set;
        }
        public string T2
        {
            get;set;
        }
        public string sDate
        {
            get;set;
        }
        public string Venue
        {
            get;set;
        }
        public string GameType
        {
            get;set;
        }
        public List<Player> players
        {
            get;set;
        }
        public string ManagerName
        {
            get;set;
        }

        //LeagueInfo
        public decimal Price
        {
            get;set;
        }
        public DateTime eDate
        {
            get;set;
        }

        public int NumTems
        {
            get;set;
        }


    }
}