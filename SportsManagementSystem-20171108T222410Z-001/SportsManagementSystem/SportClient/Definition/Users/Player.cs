using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition.Users
{
    public class Player : BASE_USER
    {
        public string Position
        {
            get;set;
        }
        public decimal PerformanceRate
        {
            get;set;
        }
        public string Desc
        {
            get;set;
        }
        public int SportID
        {
            get;set;
        }
    }
}