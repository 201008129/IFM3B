﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition.Users
{
    public class BASE_USER
    {
        public int ID
        {
            get;set;
        }
        public string Level
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public string Surname
        {
            get;set;
        }
        public string Email
        {
            get;set;
        }
        public string Pass
        {
            get;set;
        }
        public string imgLocation
        {
            get;set;
        }
    }
}