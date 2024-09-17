using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalTool;


namespace FinalToolVisualizer
{
    public partial class AnalyticsGameDetails : Form
    {
        private string sessionKey;
        private Dictionary<string, GameElement> sessionData;

        public AnalyticsGameDetails(string _sessionKey, Dictionary<string, GameElement> _data)
        {
            InitializeComponent();
            this.sessionKey = _sessionKey;
            this.sessionData = _data;

            // Set the form's title to display the session name
            this.Text = $"Analytics: {_sessionKey}";

            // Load the session details into the gameDetails_DataGrid
            LoadSessionDetails();
        }

        private void LoadSessionDetails()
        {
            // Clear existing data in the gameDetails_DataGrid
            gameDetails_DataGrid.Rows.Clear();
            gameDetails_DataGrid.Columns.Clear();

            // Add the first column for player names
            gameDetails_DataGrid.Columns.Add("Name", "Name");

            // Collect all unique metric categories from all players
            HashSet<string> allCategories = new HashSet<string>();

            // Iterate through all players to gather unique metric keys
            foreach (var player in sessionData)
            {
                // player.Value is a GameElement, so access the Metrics dictionary
                GameElement playerData = player.Value;

                // Add each unique metric key to the set
                foreach (var metric in playerData.Metrics.Keys)
                {
                    allCategories.Add(metric);
                }
            }

            // Now add each unique metric as a column
            foreach (var category in allCategories)
            {
                gameDetails_DataGrid.Columns.Add(category, category);
            }

            // Loop through each player and add their name and metrics to the gameDetails_DataGrid
            foreach (var player in sessionData)
            {
                GameElement playerData = player.Value;
                string playerName = playerData.Name; // Get player name from GameElement

                // Get the player's metrics from GameElement's Metrics dictionary
                var metrics = playerData.Metrics;

                // Create a new row starting with the player's name
                var row = new List<string> { playerName };

                // Add each metric value to the row, checking against the full set of categories
                foreach (var category in allCategories)
                {
                    // If the player has the metric, add it; otherwise, add "N/A"
                    if (metrics.ContainsKey(category))
                    {
                        row.Add(metrics[category].ToString());
                    }
                    else
                    {
                        row.Add("N/A");
                    }
                }

                // Add the row to the gameDetails_DataGrid
                gameDetails_DataGrid.Rows.Add(row.ToArray());
            }
        }


        private void sortBy_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchBar_TextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = searchBar_TextBox.Text.ToLower();  // Get the search text and convert it to lowercase for case-insensitive comparison

            foreach (DataGridViewRow row in gameDetails_DataGrid.Rows)
            {
                // Skip the new row (used for adding new rows)
                if (row.IsNewRow)
                {
                    continue;
                }

                bool rowMatches = false;

                // Loop through each cell in the row
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(filterText))
                    {
                        rowMatches = true;  // If any cell matches the filter text, show the row
                        break;
                    }
                }

                // Show or hide the row based on whether it matches the search text
                row.Visible = rowMatches;
            }
        }
    }
}
