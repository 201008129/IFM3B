using SportClient.Definition;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class CreateLog : System.Web.UI.Page
    {
        string leag_ID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //gt_LogByLeagueID
                 leag_ID = Convert.ToString(Request.QueryString["LeagueID"]);
                LogServiceClient logClient = new LogServiceClient();
                List<Log> logList = new List<Log>();
                logList = logClient.gt_LogByLeagueID(leag_ID);
                int Counter = 0;
                int LogCount = logList.Count();
                foreach (Log lg in logList)
                {
                    if (Counter != LogCount)
                    {
                        if (Counter == 0)
                        {
                            txtPos.Value = Convert.ToString(lg.Position);
                            txtTeam.Value = Convert.ToString(lg.TeamName);
                            txtPlays.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws.Value = Convert.ToString(lg.Draws);
                            txtWins.Value = Convert.ToString(lg.Wins);
                            txtLoose.Value = Convert.ToString(lg.Loose);
                            txtPoints.Value = Convert.ToString(lg.Points);
                        }
                        else
                   if (Counter == 1)
                        {
                            txtPos_2.Value = Convert.ToString(lg.Position);
                            txtTeam_2.Value = Convert.ToString(lg.TeamName);
                            txtPlays_2.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws_2.Value = Convert.ToString(lg.Draws);
                            txtWins_2.Value = Convert.ToString(lg.Wins);
                            txtLoose_2.Value = Convert.ToString(lg.Loose);
                            txtPoints_2.Value = Convert.ToString(lg.Points);
                        }
                        else
                   if (Counter == 2)
                        {
                            txtPos_3.Value = Convert.ToString(lg.Position);
                            txtTeam_3.Value = Convert.ToString(lg.TeamName);
                            txtPlays_3.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws_3.Value = Convert.ToString(lg.Draws);
                            txtWins_3.Value = Convert.ToString(lg.Wins);
                            txtLoose_3.Value = Convert.ToString(lg.Loose);
                            txtPoints_3.Value = Convert.ToString(lg.Points);
                        }
                        else
                   if (Counter == 3)
                        {
                            txtPos_4.Value = Convert.ToString(lg.Position);
                            txtTeam_4.Value = Convert.ToString(lg.TeamName);
                            txtPlays_4.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws_4.Value = Convert.ToString(lg.Draws);
                            txtWins_4.Value = Convert.ToString(lg.Wins);
                            txtLoose_4.Value = Convert.ToString(lg.Loose);
                            txtPoints_4.Value = Convert.ToString(lg.Points);
                        }
                        else
                   if (Counter == 4)
                        {
                            txtPos_5.Value = Convert.ToString(lg.Position);
                            txtTeam_5.Value = Convert.ToString(lg.TeamName);
                            txtPlays_5.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws_5.Value = Convert.ToString(lg.Draws);
                            txtWins_5.Value = Convert.ToString(lg.Wins);
                            txtLoose_5.Value = Convert.ToString(lg.Loose);
                            txtPoints_5.Value = Convert.ToString(lg.Points);
                        }
                        else
                   if (Counter == 5)
                        {
                            txtPos_6.Value = Convert.ToString(lg.Position);
                            txtTeam_6.Value = Convert.ToString(lg.TeamName);
                            txtPlays_6.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws_6.Value = Convert.ToString(lg.Draws);
                            txtWins_6.Value = Convert.ToString(lg.Wins);
                            txtLoose_6.Value = Convert.ToString(lg.Loose);
                            txtPoints_6.Value = Convert.ToString(lg.Points);
                        }
                        else
                   if (Counter == 6)
                        {
                            txtPos_7.Value = Convert.ToString(lg.Position);
                            txtTeam_7.Value = Convert.ToString(lg.TeamName);
                            txtPlays_7.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws_7.Value = Convert.ToString(lg.Draws);
                            txtWins_7.Value = Convert.ToString(lg.Wins);
                            txtLoose_7.Value = Convert.ToString(lg.Loose);
                            txtPoints_7.Value = Convert.ToString(lg.Points);
                        }
                        else
                   if (Counter == 7)
                        {
                            txtPos_8.Value = Convert.ToString(lg.Position);
                            txtTeam_8.Value = Convert.ToString(lg.TeamName);
                            txtPlays_8.Value = Convert.ToString(lg.MatchPlayed);
                            txtDraws_8.Value = Convert.ToString(lg.Draws);
                            txtWins_8.Value = Convert.ToString(lg.Wins);
                            txtLoose_8.Value = Convert.ToString(lg.Loose);
                            txtPoints_8.Value = Convert.ToString(lg.Points);
                        }
                        else
                        {
                            continue;
                        }
                        Counter++;
                    }
                    else
                    {
                        continue;
                    }

                }
                //CreateDynamicTable(logList.Count(), logList);
            }

        }

        //Create Dynamic Log List table
        //private void CreateDynamicTable(int Rows, List<Log> log)
        //{
        //    PlaceHolder1.Controls.Clear();
        //    // Fetch the number of Rows and Columns for the table 
        //    // using the properties
        //    int tblRows = Rows;
        //    // Create a Table and set its properties 
        //    Table tbl = new Table();
        //    // Add the table to the placeholder control
        //    PlaceHolder1.Controls.Add(tbl);
        //    // Now iterate through the table and add your controls 
        //    for (int i = 0; i <= tblRows; i++)
        //    {
        //        TableRow tr = new TableRow();
        //        for (int j = 0; j < 7; j++)
        //        {
        //            if (i == 0) //Header Row
        //            {
        //                TableCell headerCell = new TableCell();
        //                TextBox txtHeader = new TextBox();
        //                txtHeader.CssClass = "width: 1%";
        //                txtHeader.ReadOnly = true;
        //                if ( j == 0) //Position
        //                {
        //                    txtHeader.Text = "Position";
        //                }
        //                else if (j == 1) //Team
        //                {
        //                    txtHeader.Text = "Tean Name";
        //                }
        //                else if (j == 2) //Match Played
        //                {
        //                    txtHeader.Text = "Match Played";
        //                }
        //                else if (j == 3) //Draws
        //                {
        //                    txtHeader.Text = "Draws";
        //                }
        //                else if (j == 4) //Wins
        //                {
        //                    txtHeader.Text = "Wins";
        //                }
        //                else if (j == 5) //Loose
        //                {
        //                    txtHeader.Text = "Lose";
        //                }
        //                else if (j == 6) //Points
        //                {
        //                    txtHeader.Text = "Point";
        //                }
        //                // Add the control to the TableCell
        //                headerCell.Controls.Add(txtHeader);
        //                // Add the TableCell to the TableRow
        //                tr.Cells.Add(headerCell);
        //            }
        //            else
        //            {
        //                int Index = i - 1;
        //                TableCell tc = new TableCell();
        //                TextBox txtBox = new TextBox();
        //                if (j == 0) //Position
        //                {
        //                    txtBox.Text = Convert.ToString(Index);
        //                }
        //                else if (j == 1) //Team
        //                {
        //                    txtBox.Text = log[Index].TeamName;
        //                }
        //                else if (j == 2) //Match Played
        //                {
        //                    txtBox.Text = Convert.ToString(log[Index].MatchPlayed);
        //                }
        //                else if (j == 3) //Draws
        //                {
        //                    txtBox.Text = Convert.ToString(log[Index].Draws);
        //                }
        //                else if (j == 4) //Wins
        //                {
        //                    txtBox.Text = Convert.ToString(log[Index].Wins);
        //                }
        //                else if (j == 5) //Loose
        //                {
        //                    txtBox.Text = Convert.ToString(log[Index].Loose);
        //                }
        //                else if (j == 6) //Points
        //                {
        //                    txtBox.Text = Convert.ToString(log[Index].Points);
        //                }
        //                // Add the control to the TableCell
        //                tc.Controls.Add(txtBox);
        //                // Add the TableCell to the TableRow
        //                tr.Cells.Add(tc);
        //            }
        //        }
        //        // Add the TableRow to the Table
        //        tbl.Rows.Add(tr);
        //    }

        //    // This parameter helps determine in the LoadViewState event,
        //    // whether to recreate the dynamic controls or not

        //    ViewState["dynamictable"] = true;
        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           string L_ID = Convert.ToString(Request.QueryString["LeagueID"]);
            LogServiceClient logClient = new LogServiceClient();
            if(txtPos.Value != "")
            {

                Log newLog = new Log();
                newLog.Position = Convert.ToInt32(txtPos.Value);
                newLog.TeamName = Convert.ToString(txtTeam.Value);
                newLog.MatchPlayed = Convert.ToInt32(txtPlays.Value);
                newLog.Draws = Convert.ToInt32(txtDraws.Value);
                newLog.Wins = Convert.ToInt32(txtWins.Value);
                newLog.Loose = Convert.ToInt32(txtLoose.Value);
                newLog.Points = Convert.ToInt32(txtPoints.Value);
                newLog.League_ID = Convert.ToInt32(L_ID);
                string Log1 = logClient.CreateLog(newLog);
            }
            if (txtPos_2.Value != "")
            {
            Log newLog_1 = new Log();
            newLog_1.Position = Convert.ToInt32(txtPos_2.Value);
            newLog_1.TeamName = Convert.ToString(txtTeam_2.Value);
            newLog_1.MatchPlayed = Convert.ToInt32(txtPlays_2.Value);
            newLog_1.Draws = Convert.ToInt32(txtDraws_2.Value);
            newLog_1.Wins = Convert.ToInt32(txtWins_2.Value);
            newLog_1.Loose = Convert.ToInt32(txtLoose_2.Value);
            newLog_1.Points = Convert.ToInt32(txtPoints_2.Value);
            newLog_1.League_ID = Convert.ToInt32(L_ID);
            string Log_1 = logClient.CreateLog(newLog_1);
            }

            if (txtPos_3.Value != "")
            {
            Log newLog_2 = new Log();
            newLog_2.Position = Convert.ToInt32(txtPos_3.Value);
            newLog_2.TeamName = Convert.ToString(txtTeam_3.Value);
            newLog_2.MatchPlayed = Convert.ToInt32(txtPlays_3.Value);
            newLog_2.Draws = Convert.ToInt32(txtDraws_3.Value);
            newLog_2.Wins = Convert.ToInt32(txtWins_3.Value);
            newLog_2.Loose = Convert.ToInt32(txtLoose_3.Value);
            newLog_2.Points = Convert.ToInt32(txtPoints_3.Value);
            newLog_2.League_ID = Convert.ToInt32(L_ID);
            string Log_2 = logClient.CreateLog(newLog_2);
            }

            if (txtPos_4.Value != "")
            {
            Log newLog_3 = new Log();
            newLog_3.Position = Convert.ToInt32(txtPos_4.Value);
            newLog_3.TeamName = Convert.ToString(txtTeam_4.Value);
            newLog_3.MatchPlayed = Convert.ToInt32(txtPlays_4.Value);
            newLog_3.Draws = Convert.ToInt32(txtDraws_4.Value);
            newLog_3.Wins = Convert.ToInt32(txtWins_4.Value);
            newLog_3.Loose = Convert.ToInt32(txtLoose_4.Value);
            newLog_3.Points = Convert.ToInt32(txtPoints_4.Value);
            newLog_3.League_ID = Convert.ToInt32(L_ID);
            string Log_3 = logClient.CreateLog(newLog_3);
            }

            if (txtPos_5.Value != "")
            {
                Log newLog_4 = new Log();
                newLog_4.Position = Convert.ToInt32(txtPos_5.Value);
                newLog_4.TeamName = Convert.ToString(txtTeam_5.Value);
                newLog_4.MatchPlayed = Convert.ToInt32(txtPlays_5.Value);
                newLog_4.Draws = Convert.ToInt32(txtDraws_5.Value);
                newLog_4.Wins = Convert.ToInt32(txtWins_5.Value);
                newLog_4.Loose = Convert.ToInt32(txtLoose_5.Value);
                newLog_4.Points = Convert.ToInt32(txtPoints_5.Value);
                newLog_4.League_ID = Convert.ToInt32(L_ID);
                string Log_4 = logClient.CreateLog(newLog_4);
            }

            if (txtPos_6.Value != "")
            {
                Log newLog_5 = new Log();
                newLog_5.Position = Convert.ToInt32(txtPos_6.Value);
                newLog_5.TeamName = Convert.ToString(txtTeam_6.Value);
                newLog_5.MatchPlayed = Convert.ToInt32(txtPlays_6.Value);
                newLog_5.Draws = Convert.ToInt32(txtDraws_6.Value);
                newLog_5.Wins = Convert.ToInt32(txtWins_6.Value);
                newLog_5.Loose = Convert.ToInt32(txtLoose_6.Value);
                newLog_5.Points = Convert.ToInt32(txtPoints_6.Value);
                newLog_5.League_ID = Convert.ToInt32(L_ID);
                string Log_5 = logClient.CreateLog(newLog_5);
            }

            if (txtPos_7.Value != "")
            {
                Log newLog_6 = new Log();
                newLog_6.Position = Convert.ToInt32(txtPos_7.Value);
                newLog_6.TeamName = Convert.ToString(txtTeam_7.Value);
                newLog_6.MatchPlayed = Convert.ToInt32(txtPlays_7.Value);
                newLog_6.Draws = Convert.ToInt32(txtDraws_7.Value);
                newLog_6.Wins = Convert.ToInt32(txtWins_7.Value);
                newLog_6.Loose = Convert.ToInt32(txtLoose_7.Value);
                newLog_6.Points = Convert.ToInt32(txtPoints_7.Value);
                newLog_6.League_ID = Convert.ToInt32(L_ID);
                string Log_6 = logClient.CreateLog(newLog_6);
            }

            if (txtPos_8.Value != "")
            {
                Log newLog_7 = new Log();
                newLog_7.Position = Convert.ToInt32(txtPos_8.Value);
                newLog_7.TeamName = Convert.ToString(txtTeam_8.Value);
                newLog_7.MatchPlayed = Convert.ToInt32(txtPlays_8.Value);
                newLog_7.Draws = Convert.ToInt32(txtDraws_8.Value);
                newLog_7.Wins = Convert.ToInt32(txtWins_8.Value);
                newLog_7.Loose = Convert.ToInt32(txtLoose_8.Value);
                newLog_7.Points = Convert.ToInt32(txtPoints_8.Value);
                newLog_7.League_ID = Convert.ToInt32(L_ID);
                string Log_7 = logClient.CreateLog(newLog_7);
            }


            Response.Redirect("LeagueLog.aspx?L_ID=" + L_ID);
        }
    }
}