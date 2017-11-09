using SportClient.Definition.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportWCF
{
    public class MyTeamModel
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
        public string ManagerName
        {
            get;set;
        }
        public string ImagePath
        {
            get;set;
        }

        
    }
}