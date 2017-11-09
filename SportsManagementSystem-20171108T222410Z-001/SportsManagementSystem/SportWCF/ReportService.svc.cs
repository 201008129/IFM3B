using SportClient.Definition;
using SportClient.Definition.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportService.svc or ReportService.svc.cs at the Solution Explorer and start debugging.
    public class ReportService : IReportService
    {
     //=========GENERAL REPORT===============================================================
        /// <summary>
        /// Get game stats
        /// </summary>
        /// <param name="Game_ID"></param>
        /// <param name="type"> type of game stat request</param>
        /// <returns> list of number of yellow cards, position 0 stores team 1 and position 1 stores team 2'a card</returns>
        public List<int> gt_GameStats(string Game_ID, string type)
        {
            List<int> stats = new List<int>();
            int g_id = Convert.ToInt32(Game_ID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    
                    var query = (from gs in db.GAME_STATs
                                 where gs.Game_Id.Equals(g_id)
                                 select
                                new gamestats
                                {
                                    g_id = Convert.ToInt32(gs.Game_Id),
                                   
                                    t1_Corner_Kicks = Convert.ToInt32(gs.Team1_NumCornerKick),
                                    t1_fouls = Convert.ToInt32(gs.Team1_Fouls),
                                    t1_goalScored = Convert.ToInt32(gs.Team1_GoalScored),
                                    t1_pos = Convert.ToInt32(gs.Team1_Position),
                                    t1_Red_Card = Convert.ToInt32(gs.Team1_RedCard),
                                    t1_Yellow_Card = Convert.ToInt32(gs.Team1_YellowCard),

                                    t2_fouls = Convert.ToInt32(gs.Team2_Fouls),
                                    t2_Corner_Kicks = Convert.ToInt32(gs.Team2_NumCornerKick),
                                    t2_goalScored = Convert.ToInt32(gs.Team2_GoalScored),
                                    t2_pos = Convert.ToInt32(gs.Team2_Position),
                                    t2_Red_Card = Convert.ToInt32(gs.Team2_RedCard),
                                    t2_Yellow_Card = Convert.ToInt32(gs.Team2_YellowCard),
                                }).First();
                   if(query != null || type != null)
                    {
                        //Check stats type
                        if(type.Equals("YellowCards"))
                        {
                            stats.Add(query.t1_Yellow_Card);
                            stats.Add(query.t2_Yellow_Card);
                        }else if (type.Equals("RedCards"))
                        {
                            stats.Add(query.t1_Red_Card);
                            stats.Add(query.t2_Red_Card);
                        }
                        else if (type.Equals("Fouls"))
                        {
                            stats.Add(query.t1_fouls);
                            stats.Add(query.t2_fouls);
                        }
                        else if (type.Equals("Position"))
                        {
                            stats.Add(query.t1_pos);
                            stats.Add(query.t2_pos);
                        }
                        else if (type.Equals("CornerKicks"))
                        {
                            stats.Add(query.t1_Corner_Kicks);
                            stats.Add(query.t2_Corner_Kicks);
                        }
                        else if (type.Equals("GoalsScored"))
                        {
                            stats.Add(query.t1_goalScored);
                            stats.Add(query.t2_goalScored);
                        }
                        else
                        {
                            stats.Add(0);
                            stats.Add(0);
                        }
                    }
                    else
                    {
                        stats.Add(0);
                        stats.Add(0);
                    }
                    return stats;
                }
                catch (Exception)
                {
                    stats.Add(0);
                    stats.Add(0);
                    return stats;
                }
            };
        }

        //ADMIN REPORTS===========================================================================
        //type param to specify either 10 top goal scorer or overal best player
        //ID = League ID
        public List<bestplayer> gt_LeagueBestPlayer(string ID, string type)
        {
            int id = Convert.ToInt32(ID);

            List<bestplayer> data = new List<bestplayer>();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    if(type.Equals("Goals"))
                    {

                        var query = (from bp in db.BEST_PLAYERs
                                     where bp.LEAGUE.League_Id.Equals(ID)
                                     select new bestplayer
                                     {
                                         Name = bp.ScorerName,
                                         Goals = Convert.ToInt32(bp.Goals),
                                         Average = Convert.ToDecimal(bp.Average),
                                     }).OrderByDescending(t => t.Goals).ToList();
                        data = query;
                    }
                    else if (type.Equals("Average"))
                    {

                        var query = (from bp in db.BEST_PLAYERs
                                     where bp.LEAGUE.League_Id.Equals(ID)
                                     select new bestplayer
                                     {
                                         Name = bp.ScorerName,
                                         Goals = Convert.ToInt32(bp.Goals),
                                         Average = Convert.ToDecimal(bp.Average),
                                     }).OrderByDescending(t => t.Average).ToList();
                        data = query;
                    }
                    List<bestplayer> results = new List<bestplayer>();
                 //   Take best 10 players
                 if(data.Count() > 10)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            results.Add(data[i]);
                        }
                        return results;
                    }else
                    {
                          return data;
                    }
                }
                catch(Exception)
                {
                    return null;
                }
            };
        }

        //Get teams in the league with highest average
        public List<rep_Teams> gt_LeagueBestTeam(string leagueID)
        {
          //  List<rep_Teams> res = new List<rep_Teams>();
            int id = Convert.ToInt32(leagueID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from sl in db.SPORT_LEAGUEs where sl.LEAGUE.League_Id.Equals(id) select new
                                 rep_Teams
                                {
                                    Name = sl.SPORT.Name,
                                    numPlayers = Convert.ToInt32(sl.SPORT.NumPlayers),
                                    Average = Convert.ToDecimal(sl.SPORT.Average),
                                    Manager = sl.SPORT.USER.Name,
                                }).OrderByDescending(t => t.Average).ToList();
                    if(query != null)
                    {
                        return query;
                    }else
                    {
                        return null;
                    }
                }catch(Exception)
                {
                    return null;
                }
            }
        }

        //Comparing all registered leagues
        public List<rep_league> gt_LeaguesStats()
        {
            List<rep_league> data = new List<rep_league>();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from log in db.LEAGUEs select log).ToList();
                    if(query != null)
                    {
                        foreach(LEAGUE leagues in query)
                        {

                            var res = (from sums in db.LOGs
                                       where sums.LEAGUE.League_Id.Equals(leagues.League_Id)
                                       select sums).ToList();
                            int wins = Convert.ToInt32(res.Sum(p => p.Wins));
                            int looses = Convert.ToInt32(res.Sum(p => p.Loose));
                            int draws = Convert.ToInt32(res.Sum(p => p.Draws));

                            rep_league items = new rep_league();
                            items.LeagueName = leagues.Name;
                            items.Wins = wins;
                            items.Lose = looses;
                            items.Draws = draws;
                            data.Add(items);
                        }
                        return data;
                    }
                    return null;
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        //Comparing all registered leagues for each administrator
        //ID = League ID
        public List<rep_league> gt_LeaguesStatsForAdmin(string ID)
        {

            int id = Convert.ToInt32(ID);//league ID
            List<rep_league> data = new List<rep_league>();
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                
                try
                {
                    //Find User ID
                    int leagueID = (from lg in db.LEAGUEs where lg.League_Id.Equals(id) select lg.USER.UserId).First();
                  
                    var query = (from log in db.LEAGUEs where log.USER.UserId.Equals(leagueID) select log).ToList();
                    if (query != null)
                    {
                        foreach (LEAGUE leagues in query)
                        {

                            var res = (from sums in db.LOGs
                                       where sums.LEAGUE.League_Id.Equals(leagues.League_Id)
                                       select sums).ToList();
                            int wins = Convert.ToInt32(res.Sum(p => p.Wins));
                            int looses = Convert.ToInt32(res.Sum(p => p.Loose));
                            int draws = Convert.ToInt32(res.Sum(p => p.Draws));

                            rep_league items = new rep_league();
                            items.LeagueName = leagues.Name;
                            items.Wins = wins;
                            items.Lose = looses;
                            items.Draws = draws;
                            data.Add(items);
                        }
                        return data;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }


        //TEAM ANAGER REPORT=============================================================

        //Top 5 highest player ranking
        public List<rep_Teams> gt_PlayerRanking(string sportID)
        {
            int id = Convert.ToInt32(sportID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from tm in db.TEAMPLAYERs where tm.Sport_Id.Equals(id)
                                 select new rep_Teams
                                 {
                                     Name = tm.Name,
                                     Average = Convert.ToDecimal(tm.PerformanceRate),
                                 }).OrderByDescending(t => t.Average).ToList();
                    return query;
                }catch(Exception)
                {
                    return null;
                }
            };
        }

        //Get Team Average for every league ever involved in
        public List<rep_Teams> gt_TeamAverage(string sportID)
        {
            int id = Convert.ToInt32(sportID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from tm in db.SPORT_LEAGUEs
                                 where tm.Sport_Id.Equals(id)
                                 select new rep_Teams
                                 {
                                     LeagueName = tm.LeagueName,
                                     Average = Convert.ToDecimal(tm.TeamAverage),
                                 }).OrderByDescending(t => t.Average).ToList();
                    return query;
                }
                catch(Exception)
                {
                    return null;
                }
            };
        }
    }
}
