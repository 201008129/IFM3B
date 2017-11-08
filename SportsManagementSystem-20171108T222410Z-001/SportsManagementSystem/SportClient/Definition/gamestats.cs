using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{
    public class gamestats
    {
        public int s_id
        {
            get;set;
        }
        public string BestPlayer
        {
            get;set;
        }
        public int t1_pos
        {
            get;set;
        }
        public int t2_pos
        {
            get;set;
        }
        public int t1_fouls
        {
            get;set;
        }
        public int t2_fouls
        {
            get;set;
        }
        public int g_id
        {
            get;set;
        }
        public int t1_Yellow_Card
        {
            get;set;
        }
        public int t2_Yellow_Card
        {
            get; set;
        }
        public int t1_Red_Card
        {
            get; set;
        }
        public int t2_Red_Card
        {
            get; set;
        }
        public int t1_Corner_Kicks
        {
            get; set;
        }
        public int t2_Corner_Kicks
        {
            get; set;
        }
        public int t1_goalScored
        {
            get;set;
        }
        public int t2_goalScored
        {
            get; set;
        }
        public decimal t1_OveralAverage
        {
            get; set;
        }
        public decimal t2_OveralAverage
        {
            get; set;
        }
    }
}