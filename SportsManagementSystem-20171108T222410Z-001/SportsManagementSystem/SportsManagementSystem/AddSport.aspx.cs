using OfficeOpenXml;
using SportClient.Definition;
using SportClient.Definition.Users;
using SportClient.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagementSystem
{
    public partial class AddSport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkAddTeam_Click(object sender, EventArgs e)
        {
            string role = Convert.ToString(Session["Level"]);
            int LoggedID = Convert.ToInt32(Session["ID"]);
            if (role.ToLower().Equals("manager"))
            {
                TeamServiceClient teamClient = new TeamServiceClient();
                Team _team = new Team();
                _team.foreignID = LoggedID;
                  _team.Type = txtCategory.Value;
                _team.Name = txtName.Value;
                _team.Desc = txtDesc.Value;
                _team.NumPlayers = Convert.ToInt32(txtNumPlayer.Text);
                int TeamID = teamClient.AddTeam(_team);
                makeDirectory(Convert.ToString(TeamID));

                string res = ImportData(flExcel, TeamID);
                if(res.ToLower().Contains("success"))
                {
                    //Alert players loaded succesfully
                }
                //Upload Team Image
                ImageFile img = new ImageFile();
                img = UploadFile(flImage, Convert.ToString(TeamID), "Team_Images", "Teams"); //Upload Event Main's Image to client directory
                FileClient fc = new FileClient();
                string res1 = fc.saveTeamImage(img); //Upload Event Main's Image to Database
                string number = res1;
        //        Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }


        //HELPER METHOD=================================================
        private ImageFile UploadFile(FileUpload fileToUpload, string ID, string subfolder, string pathSubFolder)
        {
            int teamID = Convert.ToInt32(ID);
            if (fileToUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileToUpload.FileName);
                    string serverLocation = "~/" + pathSubFolder + "/" + teamID.ToString() + "/" + subfolder + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    int fileSize = fileToUpload.PostedFile.ContentLength;
                    string fileExtention = Path.GetExtension(fileToUpload.FileName);

                    if (fileExtention.ToLower() == ".jpg" || fileExtention.ToLower() == ".png" || fileExtention.ToLower() == ".jpeg" && fileSize <= 15728640)
                    {
                        fileToUpload.SaveAs(SaveLoc);
                        ImageFile file = new ImageFile()
                        {
                            foreignID = Convert.ToString(teamID),
                            Name = filename,
                            path = "SportsManagementSystem/SportsManagementSystem/" + pathSubFolder + "/" + teamID.ToString() + "/" + subfolder + "/" + filename,
                        };

                        return file;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        protected void makeDirectory(string teamID)
        {
            string directoryPath = Server.MapPath(string.Format("~/{0}/", "Teams/" + teamID));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(Path.Combine(directoryPath, "Team_Images"));

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
            }
        }
        //Validating Spreadsheet
        public bool ValidatePlayerColumns(ExcelWorksheet worksheet)
        {
            int startColumn = 1;  //where the file in the class excel start
            int startRow = 1;
            int Hitscount = 0;  //Checks number of matching columns
            List<string> columnNames = new List<string>();
            //foreach (var startRowCell in worksheet.Cells[worksheet.Dimension.Start.Row, worksheet.Dimension.Start.Column, 1, worksheet.Dimension.End.Column])
            foreach (var startRowCell in worksheet.Cells[startRow, startColumn, 1, worksheet.Dimension.End.Column])
            {
                columnNames.Add(startRowCell.Text);
            }
            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames[i].Contains("Name") || columnNames[i].Contains("Position") || columnNames[i].Contains("Performance") || columnNames[i].Contains("Description"))
                {
                    Hitscount++;
                }
            }
            if (Hitscount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Uplaoding player spreadsheet
        string ImportData(FileUpload flInfo, int SportID)
        {
            string path = "";
            string response = "";
            bool isValidGuestColumn = false;
            int startColumn;
            int startRow;
            ExcelWorksheet PlayersSheet;
            int count = 0;
            if (flInfo.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(flInfo.FileName);
                    string serverLocation = "~/temp/" + "/" + filename;
                    string SaveLoc = Server.MapPath(serverLocation);
                    flInfo.SaveAs(SaveLoc);
                    path = Server.MapPath("/") + "\\temp\\" + filename;

                    var package = new ExcelPackage(new System.IO.FileInfo(path));
                    startColumn = 1;  //where the file in the class excel start
                    startRow = 2;
                    PlayersSheet = package.Workbook.Worksheets[1]; //read sheet one
                    isValidGuestColumn = ValidatePlayerColumns(PlayersSheet);
                    // isValidColumn = true;
                }
                catch
                {
                    response = "Failed";
                    return response;
                }
                //check staff sheet
                object data = null;
                if ( isValidGuestColumn == true)
                {
                    do
                    {
                        data = PlayersSheet.Cells[startRow, startColumn].Value; //column Number 
                        if (data == null)
                        {
                            continue;
                        }
                        //read column class name
                        object Name = PlayersSheet.Cells[startRow, startColumn].Value;
                        object Position = PlayersSheet.Cells[startRow, startColumn + 1].Value;
                        object Performance = PlayersSheet.Cells[startRow, startColumn + 2].Value;
                        object Description = PlayersSheet.Cells[startRow, startColumn + 3].Value;
                        Player player = new Player();
                        player.Name = Name.ToString();
                        player.Position = Position.ToString();
                        player.PerformanceRate = Convert.ToDecimal(Performance.ToString());
                        player.Desc = Description.ToString();
                        player.SportID = SportID;
                        //import db
                        RegServiceClient reg = new RegServiceClient();
                        response = reg.InsertTeamPlayer(player);
                        if (response.Contains("succes"))
                        {
                            count++;
                        }
                        startRow++;
                    } while (data != null);
                }
                else
                {
                    response += " Failed to upload Exceel: Check columns";
                }

            }
            else
            {
                response = "Failed: File not found";
            }

            return response;
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            string role = Convert.ToString(Session["Level"]);
            int LoggedID = Convert.ToInt32(Session["ID"]);
            if (role.ToLower().Equals("manager"))
            {
                TeamServiceClient teamClient = new TeamServiceClient();
                Team _team = new Team();
                _team.foreignID = LoggedID;
                _team.Type = txtCategory.Value;
                _team.Name = txtName.Value;
                _team.Desc = txtDesc.Value;
                _team.NumPlayers = Convert.ToInt32(txtNumPlayer.Text);
               
                int TeamID = teamClient.AddTeam(_team);
                makeDirectory(Convert.ToString(TeamID));

                string res = ImportData(flExcel, TeamID);
                if (res.ToLower().Contains("success"))
                {
                    //Alert players loaded succesfully
                }
                //Upload Team Image
                ImageFile img = new ImageFile();
                img = UploadFile(flImage, Convert.ToString(TeamID), "Team_Images", "Teams"); //Upload Event Main's Image to client directory
                FileClient fc = new FileClient();
                string res1 = fc.saveTeamImage(img); //Upload Event Main's Image to Database
                string number = res1;
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}