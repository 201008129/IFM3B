using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SportClient.Definition;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileUpload" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FileUpload.svc or FileUpload.svc.cs at the Solution Explorer and start debugging.
    public class FileUpload : IFileUpload
    {
        //Getter==============================>
        public string getGameImagePathById(string strID)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var innerJoinQuery =
                       (from file in db.GAME_IMAGEs
                        where file.Game_Id.Equals(Convert.ToInt32(strID))
                        select file).FirstOrDefault();
                    string fileImage = innerJoinQuery.Location;

                    string output = "";
                    if (fileImage == null)
                    {
                        // assets/img/default.jpg
                        output = "assets/img/default.jpg";
                        return output;
                    }
                    else
                    {
                        return fileImage;
                    }
                };
            }
            catch (Exception)
            {
                return "assets/img/default.jpg";
            }
        }

        //get team image
        public string getImagePathById(string strID)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var innerJoinQuery =
                       (from file in db.TEAMIMAGEs
                        where file.Sport_Id.Equals(Convert.ToInt32(strID))
                        select file).FirstOrDefault();
                    string fileImage = innerJoinQuery.Location;

                    string output = "";
                    if (fileImage == null)
                    {
                        // assets/img/default.jpg
                        output = "assets/img/default.jpg";
                        return output;
                    }
                    else
                    {
                        return fileImage;
                    }
                };
            }
            catch (Exception)
            {
                return "assets/img/default.jpg";
            }
        }

        public string getLeagueImagePath(string strID)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var innerJoinQuery =
                       (from file in db.LEAGUE_IMAGEs
                        where file.League_Id.Equals(Convert.ToInt32(strID))
                        select file).FirstOrDefault();
                    string fileImage = innerJoinQuery.Location;

                    string output = "";
                    if (fileImage == null)
                    {
                        // assets/img/default.jpg
                        output = "assets/img/default.jpg";
                        return output;
                    }
                    else
                    {
                        return fileImage;
                    }
                };
            }
            catch (Exception)
            {
                return "assets/img/default.jpg";
            }
        }

        public string getUserImagePathById(string strID)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var innerJoinQuery =
                       (from file in db.USERIMAGEs
                        where file.UserId.Equals(Convert.ToInt32(strID))
                        select file).FirstOrDefault();
                    string fileImage = innerJoinQuery.Location;

                    string output = "";
                    if (fileImage == null)
                    {
                        // assets/img/default.jpg
                        output = "assets/img/default.jpg";
                        return output;
                    }
                    else
                    {
                        return fileImage;
                    }
                };
            }
            catch (Exception)
            {
                return "assets/img/default.jpg";
            }
        }

        public string getTeamImageByTeamName(string strID)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    int ID = Convert.ToInt32(from sp in db.SPORTs where sp.Name.Equals(strID) select sp.Sport_Id);
                    var innerJoinQuery =
                           (from file in db.TEAMIMAGEs
                            where file.Sport_Id.Equals(ID)
                            select file).FirstOrDefault();
                    string fileImage = innerJoinQuery.Location;
                    string output = "";
                    if (fileImage == null)
                    {
                        // assets/img/default.jpg
                        output = "assets/img/default.jpg";
                        return output;
                    }
                    else
                    {
                        return fileImage;
                    }
                };
            }
            catch (Exception)
            {
                return "assets/img/default.jpg";
            }
        }
        //Insertions===============================>
        public string saveGameImage(ImageFile image)
        {            //trim string location
            String imgLocation = image.path;
            string output = imgLocation.Substring(imgLocation.IndexOf('L')); //trim string path from Event
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = from img in db.GAME_IMAGEs where img.image_Id.Equals(image.ImageID) select image;
                    if (query.Count() == 0)
                    {
                        GAME_IMAGE fileToSave = new GAME_IMAGE();
                        fileToSave.Name = image.Name;
                        fileToSave.Location = output;
                        fileToSave.Game_Id = Convert.ToInt32(image.foreignID);
                        db.GAME_IMAGEs.InsertOnSubmit(fileToSave);
                        db.SubmitChanges();
                    }
                    else
                    if (query.Count() == 1)
                    {
                        return "File Exist";
                    }

                }
                return "Success File Uploaded";
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        //Store League Image
        public string saveLeagueImage(ImageFile image)
        {
            //trim string location
            String imgLocation = image.path;
            string output = imgLocation.Substring(imgLocation.IndexOf('L')); //trim string path from Event
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = from img in db.LEAGUE_IMAGEs where img.Image_Id.Equals(image.ImageID) select image;
                    if (query.Count() == 0)
                    {
                        LEAGUE_IMAGE fileToSave = new LEAGUE_IMAGE();
                        fileToSave.Name = image.Name;
                        fileToSave.Location = output;
                        fileToSave.League_Id = Convert.ToInt32(image.foreignID);
                        db.LEAGUE_IMAGEs.InsertOnSubmit(fileToSave);
                        db.SubmitChanges();
                    }
                    else
                    if (query.Count() == 1)
                    {
                        return "File Exist";
                    }

                }
                return "success File Uploaded";
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        public string saveTeamImage(ImageFile image)
        {
            //trim string location
            String imgLocation = image.path;
            string output = imgLocation.Substring(imgLocation.IndexOf('T')); //trim string path from Event
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = from img in db.TEAMIMAGEs where img.ImageId.Equals(image.ImageID) select image;
                    if (query.Count() == 0)
                    {
                        TEAMIMAGE fileToSave = new TEAMIMAGE();
                        fileToSave.Name = image.Name;
                        fileToSave.Location = output;
                        fileToSave.Sport_Id = Convert.ToInt32(image.foreignID);
                        db.TEAMIMAGEs.InsertOnSubmit(fileToSave);
                        db.SubmitChanges();
                    }
                    else
                    if (query.Count() == 1)
                    {
                        return "File Exist";
                    }

                }
                return "Success File Uploaded";
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        public string saveUserImage(ImageFile image)
        {            //trim string location
            String imgLocation = image.path;
            string output = imgLocation.Substring(imgLocation.IndexOf('U')); //trim string path from Event
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = from img in db.USERIMAGEs where img.ImageId.Equals(image.ImageID) select image;
                    if (query.Count() == 0)
                    {
                        USERIMAGE fileToSave = new USERIMAGE();
                        fileToSave.Name = image.Name;
                        fileToSave.Location = output;
                        fileToSave.UserId = Convert.ToInt32(image.foreignID);
                        db.USERIMAGEs.InsertOnSubmit(fileToSave);
                        db.SubmitChanges();
                    }
                    else
                    if (query.Count() == 1)
                    {
                        return "File Exist";
                    }

                }
                return "Success File Uploaded";
            }
            catch (Exception)
            {
                return "Failed Upload Failed";
            }
        }

        //Delete Game Images Image
        public string deleteImageByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<GAME_IMAGE> toDelete = (from dl in db.GAME_IMAGEs where dl.Game_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.GAME_IMAGEs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public string deleteTeamImageByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<TEAMIMAGE> toDelete = (from dl in db.TEAMIMAGEs where dl.Sport_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.TEAMIMAGEs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public string deleteUserImageByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<USERIMAGE> toDelete = (from dl in db.USERIMAGEs where dl.UserId == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.USERIMAGEs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public string deleteLeagueImageByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<LEAGUE_IMAGE> toDelete = (from dl in db.LEAGUE_IMAGEs where dl.League_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.LEAGUE_IMAGEs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

    }
}
