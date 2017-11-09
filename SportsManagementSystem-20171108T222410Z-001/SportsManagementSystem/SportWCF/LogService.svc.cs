using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SportClient.Definition;
using SportClient.Definition.Reporting;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LogService.svc or LogService.svc.cs at the Solution Explorer and start debugging.
    public class LogService : ILogService
    {
        public string CreateLog(Log log)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = (from res in db.LOGs where res.TeamName.Equals(log.TeamName) && res.League_Id.Equals(log.League_ID) select res);
                    if (query.Count() == 0) //AddTeam
                    {
                        LOG toinsert = new LOG();
                        toinsert.TeamName = log.TeamName;
                        toinsert.Position = log.Position;
                        toinsert.MatchPlayed = log.MatchPlayed;
                        toinsert.Wins = log.Wins;
                        toinsert.Loose = log.Loose;
                        toinsert.Draws = log.Draws;
                        toinsert.Points = log.Points;
                        toinsert.League_Id = log.League_ID;
                        db.LOGs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return "success";
                    }else
                    {
                        return UpdateLog(log);
                    }
                };
            }
            catch (Exception)
            {
                return "failed: catched";
            }
        }

        public string DeletLogbyLeagueID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<LOG> toDelete = (from dl in db.LOGs where dl.League_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Log Not Found";
                    }
                    else
                    {
                        db.LOGs.DeleteAllOnSubmit(toDelete);
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

        public List<Log> GetLogByLeagueID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from log in db.LOGs where log.League_Id.Equals(_id)
                                 select new Log
                                 {
                                     ID = log.Log_Id,
                                     TeamName = log.TeamName,
                                     League_ID = log.LEAGUE.League_Id,
                                     Position = Convert.ToInt32(log.Position),
                                     MatchPlayed = Convert.ToInt32(log.MatchPlayed),
                                     Wins = Convert.ToInt32(log.Wins),
                                     Loose = Convert.ToInt32(log.Loose),
                                     Draws = Convert.ToInt32(log.Draws),
                                     Points = Convert.ToInt32(log.Points),
                                 }).OrderByDescending(t => t.Points).ToList();
                    return query;
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        public string UpdateLog(Log log)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from tm in db.LOGs where tm.Log_Id.Equals(log.ID) || tm.TeamName.Equals(log.TeamName) select tm);
                    if (query.Count() != 0)
                    {
                        LOG toinsert = query.Single();
                        toinsert.TeamName = log.TeamName;
                        toinsert.Position = log.Position;
                        toinsert.MatchPlayed = log.MatchPlayed;
                        toinsert.Wins = log.Wins;
                        toinsert.Loose = log.Loose;
                        toinsert.Draws = log.Draws;
                        toinsert.Points = log.Points;
                     //   toinsert.League_Id = log.League_ID;
                        db.SubmitChanges();
                        return "success";
                    }
                    else
                    {
                        return CreateLog(log);
                    }
                }
                catch (Exception)
                {
                    return "failed";
                }
            };
        }

        public List<Log> gt_LogByLeagueID(string LeagueID)
        {
            List<Log> data = new List<Log>();
            int id = Convert.ToInt32(LeagueID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {

                    var query = GetLogByLeagueID(LeagueID);
                    if (query.Count != 0)   //If Data Exists, return it
                    {
                        data = query;
                    }
                    else   //Return a log with teams but entries set to zero
                    {
                        //Check if league teams exist in SPORT_LEAGUE table
                        var sptLeague = (from tm in db.SPORT_LEAGUEs
                                         where tm.League_Id.Equals(id)
                                         select new rep_Teams
                                         {
                                             Name = tm.TeamName,
                                             S_ID = tm.LEAGUE.League_Id,
                                         }).ToList();
                        if (sptLeague.Count == 0)   //No Teams Exist in SPORT_LEAGUE
                        {
                            return null;
                        }
                        else
                        {
                            foreach (rep_Teams teams in sptLeague) //Copy teams from SPORT_LEAGUE table to LOG table
                            {
                                Log lg = new Log();
                                lg.TeamName = teams.Name;
                                lg.League_ID = teams.S_ID;
                                lg.Position = 0;
                                lg.MatchPlayed = 0;
                                lg.Wins = 0;
                                lg.Loose = 0;
                                lg.Draws = 0;
                                lg.Points = 0;
                                string res = CreateLog(lg);
                                if (res.ToLower().Contains("success"))
                                {
                                    Log newLog = GetLastInput();
                                    data.Add(newLog);
                                }
                            }
                        }
                    }
                    return data;
                }
                catch(Exception)
                {
                    return null;
                }
               
            };
        }

        public Log GetLastInput()
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from lg in db.LOGs
                                 select new Log
                                 {
                                     ID = lg.Log_Id,
                                     League_ID = Convert.ToInt32(lg.League_Id),
                                     TeamName = lg.TeamName,
                                     Position = Convert.ToInt32(lg.Position),
                                     MatchPlayed = Convert.ToInt32(lg.MatchPlayed),
                                     Wins = Convert.ToInt32(lg.Wins),
                                     Loose = Convert.ToInt32(lg.Loose),
                                     Draws = Convert.ToInt32(lg.Draws),
                                     Points = Convert.ToInt32(lg.Points),
                                 }).ToList();
                    return query.Last();

                }
                catch (Exception)
                {
                    return null;
                }
            };
        }
    }
}
