using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{
    public class League
    {
        public int ID
        {
            get;set;
        }
        public string Name
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
        public int foreignID
        {
            get;set;
        }
        public int NumTeams
        {
            get; set;
        }
        public int F_SportID
        {
            get; set;
        }
        public string AdminName
        {
            get;set;
        }
        public string Category
        {
            get;set;
        }
        public string ImagePath
        {
            get;set;
        }
    }
}