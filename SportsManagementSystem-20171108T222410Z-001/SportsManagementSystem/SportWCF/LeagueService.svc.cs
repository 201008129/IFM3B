using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SportClient.Definition;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LeagueService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LeagueService.svc or LeagueService.svc.cs at the Solution Explorer and start debugging.
    public class LeagueService : ILeagueService
    {
        public int CreateLeague(League _league)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = (from res in db.LEAGUEs where res.UserId.Equals(_league.foreignID) && res.Name.Equals(_league.Name) select res);
                    if (query.Count() == 0) //AddTeam
                    {
                        LEAGUE toinsert = new LEAGUE();
                        toinsert.Name = _league.Name;
                        toinsert.WinningPrice = _league.Price;
                        toinsert.Description = _league.Desc;
                        toinsert.Category = _league.Category;
                        toinsert.sDate = _league.sDate;
                        toinsert.eDate = _league.eDate;
                        toinsert.UserId = _league.foreignID;
                        toinsert.NumTeams = _league.NumTeams;
                        db.LEAGUEs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                    }
                };

                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {

                    var queryID = (from results in db.LEAGUEs where results.UserId.Equals(_league.foreignID) && results.Name.Equals(_league.Name) select results);

                    LEAGUE res = queryID.Single();
                    int ID = res.League_Id;
                    return ID;
                };

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool CreateLeagueTeams(Team _teams)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = from team in db.SPORTs where team.Name.ToLower().Equals(_teams.Name.ToLower()) select team;
                    SPORT teams = new SPORT();
                    LEAGUE leagues = new LEAGUE();
                    if(query.Count() != 0)
                    {
                        teams = query.Single();
                        var leagueQuery = from league in db.LEAGUEs where league.Name.ToLower().Equals(_teams.LeagueName.ToLower()) select league;
                        if(leagueQuery.Count() != 0)
                        {
                            leagues = leagueQuery.Single();
                            var insertQuery = from team in db.SPORT_LEAGUEs
                                              where team.League_Id.Equals(leagues.League_Id)
                                     && team.Sport_Id.Equals(teams.Sport_Id)
                                              select team;
                            if(insertQuery.Count() == 0) //Insert to DB
                            {
                                SPORT_LEAGUE toinsert = new SPORT_LEAGUE();
                                toinsert.League_Id = leagues.League_Id;
                                toinsert.Sport_Id = teams.Sport_Id;
                                toinsert.LeagueName = leagues.Name;
                                toinsert.TeamName = teams.Name;
                                toinsert.TeamAverage = 0;
                                db.SPORT_LEAGUEs.InsertOnSubmit(toinsert);
                                db.SubmitChanges();
                                return true;
                            }else
                            {
                                return false;
                            }
                        }else
                        {
                            return false;
                        }
                    }else
                    {
                        return false;
                    }
                };
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string UpdateLeague(League _league)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from res in db.LEAGUEs where res.League_Id.Equals(_league.ID) select res);
                    if (query.Count() != 0)
                    {
                        LEAGUE toinsert = query.Single();
                        toinsert.Name = _league.Name;
                        toinsert.WinningPrice = _league.Price;
                        toinsert.Description = _league.Desc;
                        toinsert.sDate = _league.sDate;
                        toinsert.eDate = _league.eDate;
                        db.SubmitChanges();
                        return "success";
                    }
                    else
                    {
                        return "failed: No Such team exist";
                    }
                }
                catch (Exception)
                {
                    return "failed";
                }
            };
        }

        //Getter=======>>>>
        public List<League> GetAllLeagues()
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    FileUpload fileService = new FileUpload();
                    List<League> leagues = new List<League>();
                    var query = (from lg in db.LEAGUEs select
                                 new League
                                 {
                                     ID = lg.League_Id,
                                     Name = lg.Name,
                                     
                                     Price = Convert.ToDecimal(lg.WinningPrice),
                                     Desc = lg.Description,
                                     sDate = Convert.ToDateTime(lg.sDate),
                                     eDate = Convert.ToDateTime(lg.eDate),
                                     NumTeams = Convert.ToInt32(lg.NumTeams),
                                     Category = lg.Category,
                                     ImagePath = fileService.getLeagueImagePath(Convert.ToString(lg.League_Id)),
                                 }).ToList();
                    foreach(League league in query)
                    {
                        leagues.Add(league);
                    }
                    return leagues;
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        public List<League> GetleagueByCat(string Cat)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    FileUpload fileService = new FileUpload();
                    List<League> leagues = new List<League>();
                    var query = (from lg in db.LEAGUEs where lg.Category.Equals(Cat)
                                 select
           new League
           {
               ID = lg.League_Id,
               Name = lg.Name,
               AdminName = lg.USER.Name,
               foreignID = Convert.ToInt32(lg.UserId),
               Price = Convert.ToDecimal(lg.WinningPrice),
               Desc = lg.Description,
               sDate = Convert.ToDateTime(lg.sDate),
               eDate = Convert.ToDateTime(lg.eDate),
               NumTeams = Convert.ToInt32(lg.NumTeams),
               Category = lg.Category,
               ImagePath = fileService.getLeagueImagePath(Convert.ToString(lg.League_Id)),
           }).ToList();
                    foreach (League league in query)
                    {
                        leagues.Add(league);
                    }
                    return leagues;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }
        public League GetleagueByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    FileUpload fileService = new FileUpload();
                    var query = (from lg in db.LEAGUEs
                                 where lg.UserId.Equals(_id)
                                 select
           new League
           {
               ID = lg.League_Id,
               Name = lg.Name,
               AdminName = lg.USER.Name,
               foreignID = Convert.ToInt32(lg.UserId),
               Price = Convert.ToDecimal(lg.WinningPrice),
               Desc = lg.Description,
               sDate = Convert.ToDateTime(lg.sDate),
               eDate = Convert.ToDateTime(lg.eDate),
               NumTeams = Convert.ToInt32(lg.NumTeams),
               Category = lg.Category,
               ImagePath = fileService.getLeagueImagePath(Convert.ToString(lg.League_Id)),
           }).First();
                    return query;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }

        public List<League> GetleagueByUserID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    FileUpload fileService = new FileUpload();
                    var query = (from lg in db.LEAGUEs
                                 where lg.UserId.Equals(_id)
                                 select
                       new League
                       {
                           ID = lg.League_Id,
                           Name = lg.Name,
                           AdminName = lg.USER.Name,
                           foreignID = Convert.ToInt32(lg.UserId),
                           Price = Convert.ToDecimal(lg.WinningPrice),
                           Desc = lg.Description,
                           sDate = Convert.ToDateTime(lg.sDate),
                           eDate = Convert.ToDateTime(lg.eDate),
                           NumTeams = Convert.ToInt32(lg.NumTeams),
                           Category = lg.Category,
                           ImagePath = fileService.getLeagueImagePath(Convert.ToString(lg.League_Id)),
                       }).ToList();
                    return query;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }

        //public List<League> GetleagueByUseID(string UserID)
        //{
        //    List<League> leagues = new List<League>();
        //    using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
        //    {
        //        try
        //        {
        //            int _id = Convert.ToInt32(UserID);
        //            FileUpload fileService = new FileUpload();
        //            var query = (from lg in db.LEAGUEs
        //                         where lg.UserId.Equals(_id)
        //                         select
        //   new League
        //   {
        // ID = lg.League_Id,
        //       //foreignID = Convert.ToInt32(lg.UserId),
        //       Name = lg.Name,
        //       //AdminName = lg.USER.Name,
        //       //Price = Convert.ToDecimal(lg.WinningPrice),
        //       //Desc = lg.Description,
        //       //sDate = Convert.ToDateTime(lg.sDate),
        //       //eDate = Convert.ToDateTime(lg.eDate),
        //       //NumTeams = Convert.ToInt32(lg.NumTeams),
        //       //Category = lg.Category,
        //       //ImagePath = fileService.getLeagueImagePath(Convert.ToString(lg.League_Id)),
        //   }).ToList();
        //            foreach (League league in query)
        //            {
        //                leagues.Add(league);
        //            }
        //            return leagues;
        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //        }
        //    };
        //}

        /// <summary>
        /// Deletes sport league bridging table
        /// </summary>
        /// <param name="leagueID"></param>
        /// <returns></returns>
        public string DeletSportLeagueByID(string leagueID)
        {
            int l_ID = Convert.ToInt32(leagueID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<SPORT_LEAGUE> toDelete = (from dl in db.SPORT_LEAGUEs where dl.League_Id.Equals(l_ID) select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.SPORT_LEAGUEs.DeleteAllOnSubmit(toDelete);
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

        public string DL_LeagueBYID(string ID)
        {
            FileUpload fileservice = new FileUpload();
            GameService gameservice = new GameService();
            LogService logservice = new LogService();
            int _ID = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    string dl_image = fileservice.deleteLeagueImageByID(ID);  //League Image
                    string dl_BT = DeletSportLeagueByID(ID); //Delete League Briging table
                    string dl_log = logservice.DeletLogbyLeagueID(ID); //Delete Log
                    var query = (from gm in db.GAMEs where gm.League_Id.Equals(_ID) select gm).ToList();
                    if(query.Count() != 0 || query != null)
                    {
                        foreach (GAME games in query) //Delete game stats and images for all league games
                        {
                            string dl_gmImage = fileservice.deleteImageByID(Convert.ToString(games.Game_Id));  //Delete Game Image
                            string dl_gmStats = gameservice.DeleteGameStatsGameByID(Convert.ToString(games.Game_Id)); //Delete Game Stats
                        }
                    }
                    string dl_game = gameservice.DeleteGameByLeague(ID); //Delete Game By League ID
                    string dl_BestPlayers = gameservice.dl_BestPlayer(ID); //Delete League Best Players
                    List<LEAGUE> toDelete = (from dl in db.LEAGUEs where dl.League_Id == _ID select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.LEAGUEs.DeleteAllOnSubmit(toDelete);
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

        public string DeletSportInBT(string sportID)
        {
            int S_ID = Convert.ToInt32(sportID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<SPORT_LEAGUE> toDelete = (from dl in db.SPORT_LEAGUEs where dl.Sport_Id == S_ID select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.SPORT_LEAGUEs.DeleteAllOnSubmit(toDelete);
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
