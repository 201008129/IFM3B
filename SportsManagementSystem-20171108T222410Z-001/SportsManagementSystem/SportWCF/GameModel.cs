using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SportWCF
{

    [DataContract]
    public class GameModel
    {
        [DataMember]
        public string TeamOne
        {
            get; set;
        }
        [DataMember]
        public string TeamTwo
        {
            get; set;
        }
        [DataMember]
        public int LeagueID
        {
            get; set;
        }
        [DataMember]
        //GameStats
        public int stats_ID
        {
            get; set;
        }
        [DataMember]
        public string BestPlayer
        {
            get; set;
        }
        [DataMember]
        public int TeamOnePos
        {
            get; set;
        }
        [DataMember]
        public int TeamTwoPos
        {
            get; set;
        }
        [DataMember]
        public int TeamOneFouls
        {
            get; set;
        }
        [DataMember]
        public int TeamTwoFouls
        {
            get; set;
        }
        
        [DataMember]
        public string TeamTwoImage
        {
            get; set;
        }
        [DataMember]
        public string TeamOneImage
        {
            get; set;
        }
        [DataMember]
        public decimal TeamTwoAverage
        {
            get; set;
        }
        [DataMember]
        public decimal TeamOneAverage
        {
            get; set;
        }

        [DataMember]
        public int TeamTwoGoals
        {
            get; set;
        }
        [DataMember]
        public int TeamOneGoals
        {
            get; set;
        }
    }
}