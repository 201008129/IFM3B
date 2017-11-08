using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SportClient.Definition
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public int ID
        {
            get; set;
        }
        [DataMember]
        public string TeamOne
        {
            get;set;
        }
        [DataMember]
        public string TeamTwo
        {
            get;set;
        }
        [DataMember]
        public DateTime sDate
        {
            get;set;
        }
        [DataMember]
        public string Venue
        {
            get;set;
        }
        [DataMember]
        public string Type
        {
            get;set;
        }
        [DataMember]
        public int LeagueID
        {
            get;set;
        }
        [DataMember]
        public string imgLocation
        {
            get;set;
        }
        [DataMember]
        //GameStats
        public int stats_ID
        {
            get;set;
        }
        [DataMember]
        public string BestPlayer
        {
            get;set;
        }
        [DataMember]
        public int TeamOnePos
        {
            get;set;
        }
        [DataMember]
        public int TeamTwoPos
        {
            get;set;
        }
        [DataMember]
        public int TeamOneFouls
        {
            get;set;
        }
        [DataMember]
        public int TeamTwoFouls
        {
            get;set;
        }
        [DataMember]
        public int TeamTwoYellowCard
        {
            get; set;
        }
        [DataMember]
        public int TeamOneYellowCard
        {
            get; set;
        }
        [DataMember]
        public int TeamTwoRedCard
        {
            get; set;
        }
        [DataMember]
        public int TeamOneRedCard
        {
            get; set;
        }
        [DataMember]
        public int TeamTwoCornerKick
        {
            get; set;
        }
        [DataMember]
        public int TeamOneCornerKick
        {
            get; set;
        }
        [DataMember]
        public int TeamTwoGoalScored
        {
            get; set;
        }
        [DataMember]
        public int TeamOneGoalScored
        {
            get; set;
        }
        [DataMember]
        public decimal TeamTwo_OveralAverage
        {
            get; set;
        }
        [DataMember]
        public decimal TeamOne_OveralAverage
        {
            get; set;
        }

        [DataMember]
        //Game Ticket
        public int ticket_id
        {
            get;set;
        }
        [DataMember]
        public decimal ticket_Price
        {
            get;set;
        }
        [DataMember]
        public DateTime ticket_pDate
        {
            get;set;
        }
        [DataMember]
        public int NumTicket
        {
            get;set;
        }
        
    }
}