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
    public partial class ViewGameStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["L_ID"];
            MatchServiceClient msc = new MatchServiceClient();
            List<Game> gm = new List<Game>();
            gm = msc.LeagueStats(ID);

          

        }

        private void CreateDynamicTable(int Rows, int Columns, List<Game> gm)
        {
            
            PlaceHolder1.Controls.Clear();

            // Fetch the number of Rows and Columns for the table 
            // using the properties
            int tblRows = Rows;
            int tblCols = 6;
            // Create a Table and set its properties 
            Table tbl = new Table();
            
            // Add the table to the placeholder control
            PlaceHolder1.Controls.Add(tbl);
            // Now iterate through the table and add your controls 
            for (int i = 0; i < tblRows; i++)
            {
                TableRow tr = new TableRow();
                for (int j = 0; j < tblCols; j++)
                {
                    if (i == 0)
                    {
                        //Header Row

                        TableCell headerCell = new TableCell();
                        TextBox txtHeader = new TextBox();
                        txtHeader.Text = " ";

                        // Add the control to the TableCell
                        headerCell.Controls.Add(txtHeader);
                        // Add the TableCell to the TableRow
                        tr.Cells.Add(headerCell);
                    }else
                    {
                        TableCell tc = new TableCell();
                        TextBox txtBox = new TextBox();
                        txtBox.Text = "RowNo:" + i + " " + "ColumnNo:" + " " + j;

                        // Add the control to the TableCell
                        tc.Controls.Add(txtBox);
                        // Add the TableCell to the TableRow
                        tr.Cells.Add(tc);
                    }
                }
                // Add the TableRow to the Table
                tbl.Rows.Add(tr);
            }

            // This parameter helps determine in the LoadViewState event,
            // whether to recreate the dynamic controls or not

            ViewState["dynamictable"] = true;
        }
    }
}