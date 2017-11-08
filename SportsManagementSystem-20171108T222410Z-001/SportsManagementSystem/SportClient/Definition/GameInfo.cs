using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{

    public class GameInfo
    {
        public int intID
        {
            get;set;
        }
        public string TeamOne
        {
            get;set;
        }
        public string TeamTwo
        {
            get;set;
        }
        public DateTime Date
        {
            get;set;
        }
    }
}