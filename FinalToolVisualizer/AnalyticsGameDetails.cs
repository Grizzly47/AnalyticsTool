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

            // Load the session details
            LoadSessionDetails();
        }

        private void LoadSessionDetails()
        {
            // Clear the grid
            gameDetails_DataGrid.Rows.Clear();
            gameDetails_DataGrid.Columns.Clear();

            // Add element name to first column
            gameDetails_DataGrid.Columns.Add("Name", "Name");

            // Collect all overall metrics
            HashSet<string> allCategories = new HashSet<string>();

            // Iterate through all elements
            foreach (var element in sessionData)
            {
                // element.Value is a GameElement
                // Allowing access to the metrics
                GameElement elementData = element.Value;

                // Add each metric to the hash
                foreach (var metric in elementData.Metrics.Keys)
                {
                    allCategories.Add(metric);
                }
            }

            // Add to data grid
            foreach (var category in allCategories)
            {
                gameDetails_DataGrid.Columns.Add(category, category);
            }

            foreach (var element in sessionData)
            {
                GameElement elementData = element.Value;
                string elementName = elementData.Name; // Get element Name

                // Get all metrics
                var metrics = elementData.Metrics;

                var row = new List<string> { elementName };

                // Check element for each category
                foreach (var category in allCategories)
                {
                    if (metrics.ContainsKey(category))
                    {
                        row.Add(metrics[category].ToString());
                    }
                    else
                    {
                        row.Add("N/A");
                    }
                }

                // Add row to grid
                gameDetails_DataGrid.Rows.Add(row.ToArray());
            }
        }

        private void gameList_GridView_MouseDoubleClick(object sender, EventArgs e)
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
