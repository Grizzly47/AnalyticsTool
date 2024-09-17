using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;
using FinalTool;
using System.Windows.Forms;

namespace FinalToolVisualizer
{
    public partial class AnalyticMain : Form
    {
        private GameData gameData = new GameData();
        private Dictionary<string, Dictionary<string, GameElement>> overallData;

        public AnalyticMain()
        {
            InitializeComponent();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Select a JSON File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    string fileContent = File.ReadAllText(filePath);

                    overallData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, GameElement>>>(fileContent);

                    gameList_GridView.Rows.Clear();
                    gameList_GridView.Columns.Clear();
                    gameList_GridView.Columns.Add("SessionName", "Session Name");

                    foreach (var session in overallData)
                    {
                        // Add session name (the key) to the DataGridView
                        gameList_GridView.Rows.Add(session.Key);
                    }

                    MessageBox.Show("JSON file imported and session names displayed.");
                }
            }
        }

        private void mergeButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Select a JSON File to Merge";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Deserialize the second JSON file into a temporary dictionary
                    var tempData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, GameElement>>>(File.ReadAllText(filePath));

                    if (tempData != null)
                    {
                        // Merge the tempData into the overallData dictionary
                        foreach (var session in tempData)
                        {
                            // If the session already exists, merge its players
                            if (overallData.ContainsKey(session.Key))
                            {
                                foreach (var player in session.Value)
                                {
                                    // If the player exists, update their metrics; otherwise, add them
                                    if (overallData[session.Key].ContainsKey(player.Key))
                                    {
                                        // Merge the metrics for existing players
                                        foreach (var metric in player.Value.Metrics)
                                        {
                                            overallData[session.Key][player.Key].AddOrUpdateMetric(metric.Key, metric.Value);
                                        }
                                    }
                                    else
                                    {
                                        // Add new players
                                        overallData[session.Key].Add(player.Key, player.Value);
                                    }
                                }
                            }
                            else
                            {
                                // If the session doesn't exist, add the whole session
                                overallData.Add(session.Key, session.Value);
                            }
                        }

                        // Update the main session list to reflect merged sessions
                        gameList_GridView.Rows.Clear();
                        gameList_GridView.Columns.Clear();
                        gameList_GridView.Columns.Add("SessionName", "Session Name");

                        foreach (var session in overallData)
                        {
                            // Add session name (the key) to the DataGridView
                            gameList_GridView.Rows.Add(session.Key);
                        }

                        MessageBox.Show("Merge completed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error: Could not load or deserialize the JSON file.");
                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.Title = "Save JSON File";
                saveFileDialog.FileName = "GameData.json"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string saveFilePath = saveFileDialog.FileName;

                    // Serialize the existing overallData to JSON
                    if (overallData != null && overallData.Count > 0)
                    {
                        // Prepare data for export
                        var exportData = new Dictionary<string, Dictionary<string, object>>();

                        foreach (var session in overallData)
                        {
                            string sessionKey = session.Key; // The session name
                            var sessionData = session.Value; // The inner dictionary of players

                            // Create a dictionary to hold all player data for this session
                            var sessionExportData = new Dictionary<string, object>();

                            foreach (var player in sessionData)
                            {
                                string playerName = player.Key; // Player's name
                                GameElement playerData = player.Value; // Player's GameElement data

                                // Create a dictionary for the player's metrics
                                var metricsData = new Dictionary<string, float>();

                                // Loop through metrics in GameElement
                                foreach (var metric in playerData.Metrics)
                                {
                                    metricsData[metric.Key] = metric.Value;
                                }

                                // Add player data to the session export structure
                                sessionExportData[playerName] = new Dictionary<string, object>
                        {
                            { "Name", playerName },
                            { "Metrics", metricsData }
                        };
                            }

                            // Add session data to export data
                            exportData[sessionKey] = sessionExportData;
                        }

                        // Serialize the exportData to JSON and write to the selected file
                        string jsonData = JsonConvert.SerializeObject(exportData, Formatting.Indented);
                        File.WriteAllText(saveFilePath, jsonData);

                        MessageBox.Show("File saved successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No data available to export.");
                    }
                }
            }
        }


        private void sortByContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gameID_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numPlayer_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gameList_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gameList_GridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gameList_GridView.SelectedRows.Count > 0)
            {
                // Get the session name from the selected row
                string selectedSessionKey = gameList_GridView.SelectedRows[0].Cells["SessionName"].Value.ToString();

                // Open the AnalyticsGameDetails form with the selected session details
                OpenGameDetails(selectedSessionKey);
            }
            else
            {
                MessageBox.Show("Please select a session to view.");
            }
        }

        private void OpenGameDetails(string sessionKey)
        {
            // Assume that overallData is the dictionary with all the session data
            if (overallData.ContainsKey(sessionKey))
            {
                var sessionData = overallData[sessionKey];

                // Open the AnalyticsGameDetails form and pass the session data
                AnalyticsGameDetails detailsForm = new AnalyticsGameDetails(sessionKey, sessionData);
                detailsForm.Show();  // Show the details form
            }
            else
            {
                MessageBox.Show("Session data not found.");
            }
        }

        private void viewGameButton_Click(object sender, EventArgs e)
        {

        }

        private void removeGameButton_Click(object sender, EventArgs e)
        {

        }
    }
}