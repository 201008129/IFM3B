using SportClient.Definition.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public BASE_USER Login(string email, string password)
        {
            string hashedPass = HashPassword.HashPass(password);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
               try
                  {
                    return db.USERs.Where(pe => pe.Email == email && pe.Password == hashedPass).Select(pe => new BASE_USER
                    {
                        ID = pe.UserId,
                        Name = pe.Name,
                        Email = pe.Email,
                        Surname = pe.Surname,
                        Pass = pe.Password,
                        Level = pe.Level
                    }).First();

                }
                 catch
                  {
                    return null;
                  }
            };
        }

        public string UpdateUser(BASE_USER user)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    string hashedPass = HashPassword.HashPass(user.Pass);
                    var query = (from res in db.USERs where res.UserId.Equals(user.ID) select res);
                    if (query.Count() != 0)
                    {
                        USER toinsert = query.Single();
                        toinsert.Name = user.Name;
                        toinsert.Surname = user.Surname;
                        toinsert.Email = user.Email;
                        toinsert.Password = hashedPass;
                        db.SubmitChanges();
                        return "success";
                    }
                    else
                    {
                        return "failed: No Such User exist";
                    }
                }
                catch (Exception)
                {
                    return "failed";
                }
            };
        }
    }
}
