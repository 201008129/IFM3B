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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TeamService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TeamService.svc or TeamService.svc.cs at the Solution Explorer and start debugging.
    public class TeamService : ITeamService
    {
        public int AddTeam(Team _team)
        {
            try
            {
                //
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                    var query = (from tm in db.SPORTs where tm.UserId.Equals(_team.foreignID) && tm.Name.ToLower().Equals(_team.Name.ToLower()) select tm);
                    if (query.Count() == 0) //AddTeam
                    {
                        SPORT toinsert = new SPORT();
                        toinsert.Type = _team.Type;
                        toinsert.Name = _team.Name;
                        toinsert.NumPlayers = _team.NumPlayers;
                        toinsert.Description = _team.Desc;
                        toinsert.UserId = _team.foreignID;
                        toinsert.Average = 0;
                        db.SPORTs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();

                    }
            };

             using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {

                    var queryID = (from tm in db.SPORTs
                                   where tm.Type.Equals(_team.Type)
                                     && tm.Name.ToLower().Equals(_team.Name.ToLower())
                                    && tm.NumPlayers.Equals(_team.NumPlayers) && tm.Description.Equals(_team.Desc)
                                   select tm);
                    SPORT res = queryID.Single();
                    int ID = res.Sport_Id;

                    return ID;
                };

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public string EditTeam(Team _team)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from tm in db.SPORTs where tm.Sport_Id.Equals(_team.ID) select tm);
                    if (query.Count() != 0) 
                    {
                        SPORT toinsert = query.Single();
                        //   toinsert.Type = _team.Type;
                        toinsert.Name = _team.Name;
                        toinsert.NumPlayers = _team.NumPlayers;
                        toinsert.Description = _team.Desc;
                        //db.SPORTs.InsertOnSubmit(toinsert);
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

        public List<League> getAllLeaguesByCategory(string category)
        {
            List<Team> items = new List<Team>();
            FileUpload fileService = new FileUpload();
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    return db.LEAGUEs.Where(res => res.Category.Equals(category)).Select(res => new League
                    {
                        ID = res.League_Id,
                      //  Type = res.Type,
                        Name = res.Name,
                      //  NumPlayers = Convert.ToInt32(res.NumPlayers),
                       // Desc = res.Description,
                       // foreignID = Convert.ToInt32(res.UserId),
                        //  F_League  = res.UserId,
                       // ImagePath = fileService.getImagePathById(Convert.ToString(res.Sport_Id)),
                        // ImageLocation = fileService.getImageLocationByEventId(Convert.ToString(ev.E_ID)),
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        } 

        //Get All Teams by Sport Category
        public List<MyTeamModel> getAllTeamByCategory(string category)
        {
            List<MyTeamModel> items = new List<MyTeamModel>();
                FileUpload fileService = new FileUpload();
                try
                {
                    using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                    {
                    return db.SPORTs.Where(res => res.Type.Equals(category)).Select(res => new MyTeamModel
                    {
                        ID = res.Sport_Id,
                        Type = res.Type,
                        Name = res.Name,
                        NumPlayers = Convert.ToInt32(res.NumPlayers),
                        Desc = res.Description,
                       foreignID = Convert.ToInt32(res.UserId),
                     //  F_League  = res.UserId,
                     ManagerName = res.USER.Name,
                        ImagePath = fileService.getImagePathById(Convert.ToString(res.Sport_Id)),
                           // ImageLocation = fileService.getImageLocationByEventId(Convert.ToString(ev.E_ID)),
                        }).ToList();
                    }
                }
                catch (Exception)
                {
                    return null;
                }
        }

        //Get Team Info for playing game
        public List<TeamModel> getTeamsByGameID(string gID)
        {
            List<TeamModel> teams = new List<TeamModel>();
            FileUpload fileservice = new FileUpload();
            PlayerService playerervice = new PlayerService();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from gm in db.GAMEs
                                 where gm.Game_Id.Equals(gID)
                                 join lg in db.LEAGUEs on gm.League_Id equals lg.League_Id
                                 join sl in db.SPORT_LEAGUEs on lg.League_Id equals sl.League_Id
                                 select new TeamModel
                                 {
                                     s_ID = sl.SPORT.Sport_Id,
                                     TeamName = sl.SPORT.Name,
                                     NumPlayers = Convert.ToInt32(sl.SPORT.NumPlayers),
                                     Desc = sl.SPORT.Description,
                                     Type = sl.SPORT.Type,
                                     ImagePath = fileservice.getImagePathById(Convert.ToString(sl.SPORT.Sport_Id)),
                                     players = playerervice.getAllTeamPlayers(Convert.ToString(sl.SPORT.Sport_Id)),
                                     //   players = sl.SPORT.TEAMPLAYERs.Where(pe => pe.Sport_Id.Equals(sl.SPORT.Sport_Id)).ToList();
                                 }).ToList();
                    foreach(TeamModel items in query)
                    {
                        teams.Add(items);
                    }
                    return teams;
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        public TeamModel getTeamsDetails(string ID)
        {
            int _id = Convert.ToInt32(ID);
            FileUpload fileservice = new FileUpload();
            PlayerService player = new PlayerService();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    return (from tm in db.SPORTs
                            where tm.Sport_Id.Equals(_id)
                            select new TeamModel
                            {
                                s_ID = tm.Sport_Id,
                                LeaguName = tm.USER.Name,  //Manager Name
                                TeamName = tm.Name,
                                players = player.getAllTeamPlayers(Convert.ToString(tm.Sport_Id)),
                                NumPlayers = Convert.ToInt32(tm.NumPlayers),
                                Desc = tm.Description,
                                Type = tm.Type,
                                     ImagePath = fileservice.getImagePathById(Convert.ToString(tm.Sport_Id)),
                                 }).First();
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        public string DeleteSportByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<SPORT> toDelete = (from dl in db.SPORTs where dl.Sport_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed:";
                    }
                    else
                    {
                        db.SPORTs.DeleteAllOnSubmit(toDelete);
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

        public List<TeamModel> getTeamsByUserID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            List<TeamModel> teams = new List<TeamModel>();
            FileUpload fileservice = new FileUpload();
            PlayerService playerervice = new PlayerService();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from gm in db.SPORTs
                                 where gm.UserId.Equals(_id)
                                 select new TeamModel
                                 {
                                     s_ID = gm.Sport_Id,
                                     TeamName = gm.Name,
                                     NumPlayers = Convert.ToInt32(gm.NumPlayers),
                                     Desc = gm.Description,
                                     Type = gm.Type,
                                     ImagePath = fileservice.getImagePathById(Convert.ToString(gm.Sport_Id)),
                                     players = playerervice.getAllTeamPlayers(Convert.ToString(gm.Sport_Id)),
                                     //   players = sl.SPORT.TEAMPLAYERs.Where(pe => pe.Sport_Id.Equals(sl.SPORT.Sport_Id)).ToList();
                                 }).ToList();
                    foreach (TeamModel items in query)
                    {
                        teams.Add(items);
                    }
                    return teams;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }

        public List<MyTeamModel> getAllTeamByUserID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            List<MyTeamModel> items = new List<MyTeamModel>();
            FileUpload fileService = new FileUpload();
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = (from lg in db.LEAGUEs
                                 where lg.UserId.Equals(_id)
                                 join sl in db.SPORT_LEAGUEs on lg.League_Id equals sl.League_Id
                                 select new MyTeamModel
                                 {
                                     ID = Convert.ToInt32(sl.Sport_Id),
                                     Name = sl.TeamName,
                                 }).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<rep_Teams> getLeagueTeams(string leagueID)
        {
            int id = Convert.ToInt32(leagueID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from tm in db.SPORT_LEAGUEs where tm.League_Id.Equals(id) select new
                                 rep_Teams
                    {
                        Name = tm.TeamName,
                        S_ID = Convert.ToInt32(tm.Sport_Id),
                    }).ToList();
                    return query;
                }catch(Exception)
                {
                    return null;
                }
            };
        }
    }
}
