using SportClient.Definition.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{
    public class TeamModel
    {
       public int G_ID
        {
            get;set;
        }
        public string TeamOne
        {
            get;set;
        }
        public string TeamTwo
        {
            get; set;
        }
        public string Date
        {
            get; set;
        }
        public string Venue
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public int  LeagueID
        {
            get; set;
        }
        public string ImagePath
        {
            get; set;
        }

        public string LeaguName
        {
            get; set;
        }
        public int s_ID
        {
            get;set;
        }
        public string TeamName
        {
            get;set;
        }
        public int NumPlayers
        {
            get;set;
        }
        public string Desc
        {
            get;set;
        }
        public List<Player> players
        {
            get;set;
        }
    }
}