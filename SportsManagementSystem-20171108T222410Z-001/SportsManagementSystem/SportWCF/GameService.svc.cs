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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GameService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GameService.svc or GameService.svc.cs at the Solution Explorer and start debugging.
    public class GameService : IGameService
    {
        public int AddMatch(Game game)
        {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = (from res in db.GAMEs where res.Game_Id.Equals(game.ID) && res.League_Id.Equals(game.LeagueID) select res);
                    if (query.Count() == 0) //AddGame
                    {
                        GAME toinsert = new GAME();
                  //      toinsert.Game_Id = game.ID;
                        toinsert.Team1 = game.TeamOne;
                        toinsert.Team2 = game.TeamTwo;
                        toinsert.sDate = game.sDate;
                        toinsert.Venue = game.Venue;
                        toinsert.GameType = game.Type;
                        toinsert.League_Id = game.LeagueID;
                        db.GAMEs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                    }
                };

                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {

                    var queryID = (from tm in db.GAMEs 
                                   select tm).ToList();
                    GAME res = queryID.Last();
                    int ID = res.Game_Id;
                    return ID;
                };

        }

        public string CreateGameTicket(Game game)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = (from res in db.GAME_TICKETs where res.Game_Id.Equals(game.ID) && res.Ticket_Id.Equals(game.ticket_id) select res);
                    if (query.Count() == 0) //add stats
                    {
                        GAME_TICKET toinsert = new GAME_TICKET();
                        toinsert.Game_Id = game.ID;
                        toinsert.Price = game.ticket_Price;
                        toinsert.Date = game.ticket_pDate;
                        toinsert.Quantity = game.NumTicket;
                        db.GAME_TICKETs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return "success";
                    }
                    else
                    {
                        return "failed: Stats already exist";
                    }
                };
            }
            catch (Exception)
            {
                return "failed";
            }
        }

        //AddBestPlayer

        public string GameStats(Game game)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    //Update Team Average
                    string updateTeamAverage = calcAverage(game);

                    var query = (from res in db.GAME_STATs where res.Game_Id.Equals(game.ID)select res);
                    if (query.Count() == 0) //add stats
                    {

                        GAME_STAT toinsert = new GAME_STAT();
                        toinsert.Game_Id = game.ID;
                        toinsert.BestPlayer = game.BestPlayer;

                        toinsert.Team2_Position = game.TeamTwoPos;
                        toinsert.Team2_Fouls = game.TeamTwoFouls;
                        toinsert.Team2_GoalScored = game.TeamTwoGoalScored;
                        toinsert.Team2_NumCornerKick = game.TeamTwoCornerKick;
                        toinsert.Team2_RedCard = game.TeamTwoRedCard;
                        toinsert.Team2_YellowCard = game.TeamTwoYellowCard;
                        toinsert.Team2_OveralAverage = game.TeamTwo_OveralAverage;

                        toinsert.Team1_Fouls = game.TeamOneFouls;
                        toinsert.Team1_Position = game.TeamOnePos;
                        toinsert.Team1_GoalScored = game.TeamOneGoalScored;
                        toinsert.Team1_NumCornerKick = game.TeamOneCornerKick;
                        toinsert.Team1_RedCard = game.TeamOneRedCard;
                        toinsert.Team1_YellowCard = game.TeamOneYellowCard;
                        toinsert.Team1_OveralAverage = game.TeamOne_OveralAverage;

                        db.GAME_STATs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return "success";
                    }else
                    {
                        GAME_STAT toinsert = query.First();

                        //  toinsert.Game_Id = game.ID;
                        toinsert.BestPlayer = game.BestPlayer;

                     
                        toinsert.Team2_Position = game.TeamTwoPos;
                        toinsert.Team2_Fouls = game.TeamTwoFouls;
                        toinsert.Team2_GoalScored = game.TeamTwoGoalScored;
                        toinsert.Team2_NumCornerKick = game.TeamTwoCornerKick;
                        toinsert.Team2_RedCard = game.TeamTwoRedCard;
                        toinsert.Team2_YellowCard = game.TeamTwoYellowCard;
                        toinsert.Team2_OveralAverage = game.TeamTwo_OveralAverage;

                        toinsert.Team1_Fouls = game.TeamOneFouls;
                        toinsert.Team1_Position = game.TeamOnePos;
                        toinsert.Team1_GoalScored = game.TeamOneGoalScored;
                        toinsert.Team1_NumCornerKick = game.TeamOneCornerKick;
                        toinsert.Team1_RedCard = game.TeamOneRedCard;
                        toinsert.Team1_YellowCard = game.TeamOneYellowCard;
                        toinsert.Team1_OveralAverage = game.TeamOne_OveralAverage;

                        //    db.GAME_STATs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "failed";
            }
        }

        //Helper Methods
        //Updating Team Average for each team
        //Sum of averages per match devided by Number of team appearance in a league
        public string calcAverage(Game gm)
        {

            string status = "";
            int T1_NumAppearnce = 0;
            int T2_NumAppearnce = 0;
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    //Get Team Names
                    var Name = (from sl in db.GAMEs where sl.Game_Id.Equals(gm.ID) select sl).First();
                    string TeamOne = Name.Team1;
                    string TeamTwo = Name.Team2;

                    //Get Total Number of team appearance
                    var T1_query = (from game in db.GAMEs where game.Team1.Equals(TeamOne) || game.Team2.Equals(TeamOne) select game).ToList();
                    T1_NumAppearnce = T1_query.Count();
                    var T2_query = (from game in db.GAMEs where game.Team1.Equals(TeamTwo) || game.Team2.Equals(TeamTwo) select game).ToList();
                    T2_NumAppearnce = T2_query.Count();

                    //SUm of games averages per team
                    decimal sum = 0;
                    foreach (GAME game in T1_query)
                    {
                         sum += Convert.ToDecimal(game.GAME_STATs.Where(p => p.Game_Id.Equals(game.Game_Id)).Sum(p => p.Team1_OveralAverage));
                      
                    }
                    decimal T2_Sum = 0;
                    foreach (GAME game in T2_query)
                    {
                        T2_Sum += Convert.ToDecimal(game.GAME_STATs.Where(p => p.Game_Id.Equals(game.Game_Id)).Sum(p => p.Team1_OveralAverage));

                    }

                    //Now Compute The Average
                    decimal T1_Average = sum / T1_NumAppearnce;
                    decimal T2_Average = T2_Sum / T2_NumAppearnce;

                    //Insert Into DB
                    var Team_One = (from tm in db.SPORT_LEAGUEs where tm.TeamName.Equals(TeamOne) select tm).First();
                    if(Team_One != null)
                    {
                        SPORT_LEAGUE toinsert = Team_One;
                        toinsert.TeamAverage = T1_Average;
                        status = "success: updated t1";
                    }else
                    {
                        status += "failed: cant update t1";
                    }
                    var Team_Two = (from tm in db.SPORT_LEAGUEs where tm.TeamName.Equals(TeamTwo) select tm).First();
                    if (Team_Two != null)
                    {
                        SPORT_LEAGUE toinsert = Team_Two;
                        toinsert.TeamAverage = T2_Average;
                        db.SubmitChanges();
                        status += "success: updated t2";
                    }
                    else
                    {
                        status += "failed: cant update t2";
                    }
                }
                catch(Exception)
                {
                    status += "failed: catched";
                }
            };
            return status;
        }

        public List<TeamModel> GetAllGamesByCat(string Category)
        {
            List<TeamModel> data = new List<TeamModel>();
            FileUpload fl = new FileUpload();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                var query = (//from res in db.SPORTs where res.Type.Equals("Soccer")
                             //join sl in db.SPORT_LEAGUEs on res.Sport_Id equals sl.Sport_Id
                             //test league
                            from lg in db.LEAGUEs where lg.Category.Equals(Category)
                            join gm in db.GAMEs on lg.League_Id equals gm.League_Id
                            select new TeamModel
                            {
                                G_ID = Convert.ToInt32(gm.Game_Id),
                                TeamOne = gm.Team1,
                                TeamTwo = gm.Team2,
                                Date = Convert.ToString(gm.sDate),
                                Venue = gm.Venue,
                                LeagueID = Convert.ToInt32(gm.League_Id),
                                LeaguName = lg.Name,
                                ImagePath = fl.getGameImagePathById(Convert.ToString(gm.Game_Id)),
                             }).ToList();
                foreach(TeamModel lg in query)
                {
                    data.Add(lg);
                }
                return data;
            };
        }

        public TeamModel GetGameByID(string id)
        {
            int _id = Convert.ToInt32(id);
            FileUpload fileservice = new FileUpload();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                var query = from gm in db.GAMEs where gm.Game_Id.Equals(_id) select gm;
                if(query.Count() != 0)
                {
                    TeamModel data = new TeamModel();
                    GAME gm = query.First();
                    data.G_ID = gm.Game_Id;
                    data.TeamOne = gm.Team1;
                    data.TeamTwo = gm.Team2;
                    data.Date = Convert.ToString(gm.sDate);
                    data.Venue = gm.Venue;
                    data.LeaguName = gm.LEAGUE.Name;
                    data.LeagueID = Convert.ToInt32(gm.League_Id);
                    data.ImagePath = fileservice.getGameImagePathById(Convert.ToString(gm.Game_Id));
                    return data;
                }else
                {
                    return null;
                }
            };
        }

        //LeagueFixture
        public List<TeamModel> GetAllGamesByLeagueID(string ID)
        {
            FileUpload fl = new FileUpload();
            List<TeamModel> items = new List<TeamModel>();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    int _id = Convert.ToInt32(ID);
                    var query = (from gm in db.GAMEs where gm.League_Id.Equals(_id) select
                                new TeamModel
                                {
                                    G_ID = gm.Game_Id,
                                    TeamOne = gm.Team1,
                                    TeamTwo = gm.Team2,
                                    Date = Convert.ToString(gm.sDate),
                                    Venue = gm.Venue,
                                    Type = gm.GameType,
                                    LeagueID = Convert.ToInt32(gm.League_Id),
                                    ImagePath = fl.getGameImagePathById(Convert.ToString(gm.Game_Id)),
                                }).ToList();
                    foreach(TeamModel teams in query)
                    {
                        items.Add(teams);
                    }
                    return items;
                }catch
                {
                    return null;
                }
            };
        }

        //Get All  Game stats by league ID
         public  List<GameModel> GetAllGameStatByLeagueID(string L_ID)
        {
            int _id = Convert.ToInt32(L_ID);
            FileUpload fl = new FileUpload();
            List<GameModel> items = new List<GameModel>();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from gm in db.GAMEs
                                 where gm.League_Id.Equals(_id)
                                 join gs in db.GAME_STATs on gm.Game_Id equals gs.Game_Id
                                 select
                                new GameModel
                                {
                                    stats_ID = gs.stats_Id,
                                    TeamOne = gs.GAME.Team1,
                                    TeamTwo = gs.GAME.Team2,
                                    TeamOneFouls = Convert.ToInt32(gs.Team1_Fouls),
                                    TeamTwoFouls = Convert.ToInt32(gs.Team2_Fouls),
                                    TeamOnePos = Convert.ToInt32(gs.Team1_Position),
                                    TeamTwoPos = Convert.ToInt32(gs.Team2_Fouls),
                                    TeamOneAverage = Convert.ToDecimal(gs.Team1_OveralAverage),
                                    TeamTwoAverage = Convert.ToDecimal(gs.Team2_OveralAverage),
                                    TeamOneGoals = Convert.ToInt32(gs.Team1_GoalScored),
                                    TeamTwoGoals = Convert.ToInt32(gs.Team2_GoalScored),
                                    TeamTwoImage = fl.getTeamImageByTeamName(gs.GAME.Team2),
                                    TeamOneImage = fl.getTeamImageByTeamName(gs.GAME.Team1),
                                    BestPlayer = gs.BestPlayer,
                }).ToList();
                    foreach (GameModel teams in query)
                    {
                        items.Add(teams);
                    }
                    return items;
                }
                catch
                {
                    return null;
                }
            };
        }
        //Deletions=====================================>>>
        //Delete Game by game ID
        public string DeleteGameByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<GAME> toDelete = (from dl in db.GAMEs where dl.Game_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.GAMEs.DeleteAllOnSubmit(toDelete);
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
        //Delete Game Stats by game id
        public string DeleteGameStatsGameByID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<GAME_STAT> toDelete = (from dl in db.GAME_STATs where dl.Game_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Stats Not Found";
                    }
                    else
                    {
                        db.GAME_STATs.DeleteAllOnSubmit(toDelete);
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

        //Delete Best Player
        public string dl_BestPlayer(string ID)
        {
            int id = Convert.ToInt32(ID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    List<BEST_PLAYER> query = (from bp in db.BEST_PLAYERs where bp.league_ID.Equals(id) select bp).ToList();
                    if(query != null)
                    {
                        db.BEST_PLAYERs.DeleteAllOnSubmit(query);
                        db.SubmitChanges();
                        return "success";
                    }else
                    {
                        return "failed : No data found";
                    }
                }
                catch (Exception)
                {
                    return "fail: Catched";
                }
            };
        }


        //Update game stats
        public string EditGameStats(Game game)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from gm in db.GAME_STATs where gm.Game_Id.Equals(game.ID) && gm.stats_Id.Equals(game.stats_ID) select gm);
                    if (query.Count() != 0)
                    {
                        GAME_STAT toinsert = query.Single();
                        //   toinsert.Type = _team.Type;
                        toinsert.BestPlayer = game.BestPlayer;
                       
                        toinsert.Team2_Position = game.TeamTwoPos;
                        toinsert.Team2_Fouls = game.TeamTwoFouls;
                        toinsert.Team2_GoalScored = game.TeamTwoGoalScored;
                        toinsert.Team2_NumCornerKick = game.TeamTwoCornerKick;
                        toinsert.Team2_RedCard = game.TeamTwoRedCard;
                        toinsert.Team2_YellowCard = game.TeamTwoYellowCard;
                        toinsert.Team2_OveralAverage = game.TeamTwo_OveralAverage;

                        toinsert.Team1_Fouls = game.TeamOneFouls;
                        toinsert.Team1_Position = game.TeamOnePos;
                        toinsert.Team1_GoalScored = game.TeamOneGoalScored;
                        toinsert.Team1_NumCornerKick = game.TeamOneCornerKick;
                        toinsert.Team1_RedCard = game.TeamOneRedCard;
                        toinsert.Team1_YellowCard = game.TeamOneYellowCard;
                        toinsert.Team1_OveralAverage = game.TeamOne_OveralAverage;
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

        public List<TeamModel> GetAllGamesByUserID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            List<TeamModel> data = new List<TeamModel>();
            FileUpload fl = new FileUpload();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                var query = (//from res in db.SPORTs where res.Type.Equals("Soccer")
                             //join sl in db.SPORT_LEAGUEs on res.Sport_Id equals sl.Sport_Id
                             //test league
                            from lg in db.LEAGUEs
                            where lg.UserId.Equals(_id)
                            join gm in db.GAMEs on lg.League_Id equals gm.League_Id
                            select new TeamModel
                            {
                                G_ID = Convert.ToInt32(gm.Game_Id),
                                TeamOne = gm.Team1,
                                TeamTwo = gm.Team2,
                                Date = Convert.ToString(gm.sDate),
                                Venue = gm.Venue,
                                LeagueID = Convert.ToInt32(gm.League_Id),
                                LeaguName = lg.Name,
                                ImagePath = fl.getGameImagePathById(Convert.ToString(gm.Game_Id)),
                            }).ToList();
                foreach (TeamModel lg in query)
                {
                    data.Add(lg);
                }
                return data;
            };
        }

        public string DeleteGameByLeague(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<GAME> toDelete = (from dl in db.GAMEs where dl.League_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.GAMEs.DeleteAllOnSubmit(toDelete);
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

        public string AddBestPlayer(bestplayer BPlayer)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    //Update team player first
                    var teamplayer = (from tp in db.TEAMPLAYERs where tp.Name.Equals(BPlayer.Name) select tp).First();
                    if (teamplayer != null)
                    {
                        teamplayer.PerformanceRate += BPlayer.Average;
                        db.SubmitChanges();
                    }

                    var query = (from bp in db.BEST_PLAYERs where bp.league_ID.Equals(BPlayer.leagueID) && bp.ScorerName.Equals(BPlayer.Name) select bp);
                    if (query.Count() == 0)
                    {
                        BEST_PLAYER player = new BEST_PLAYER();
                        player.league_ID = BPlayer.leagueID;
                        player.ScorerName = BPlayer.Name;
                        player.Goals = BPlayer.Goals;
                        player.Average = 1;
                        db.BEST_PLAYERs.InsertOnSubmit(player);
                        db.SubmitChanges();
                        return "success: added";
                    }else
                    {
                        BEST_PLAYER player = query.Single();
                        player.league_ID = BPlayer.leagueID;
                        player.ScorerName = BPlayer.Name;
                        player.Goals = BPlayer.Goals;
                        player.Average += 1;
                        db.SubmitChanges();
                        return "success: edited";
                    }

                  
                }
                catch(Exception e)
                {
                    string msg = e.Message;
                    return msg;
                }
            };
        }


    }
}
