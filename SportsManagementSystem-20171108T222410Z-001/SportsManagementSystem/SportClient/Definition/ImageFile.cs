using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportClient.Definition
{
    public class ImageFile
    {
        public string ImageID
        {
            get;set;
        }
        public string foreignID
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public string path
        {
            get;set;
        }
    }
}