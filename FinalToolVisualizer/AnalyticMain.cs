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

        private void ImportButton_Click(object sender, EventArgs e)
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

                    // Update gameList_GridView
                    gameList_GridView.Rows.Clear();
                    gameList_GridView.Columns.Clear();
                    gameList_GridView.Columns.Add("SessionName", "Session Name");

                    foreach (var session in overallData)
                    {
                        // Add ONLY sessions names to the grid
                        gameList_GridView.Rows.Add(session.Key);
                    }

                    MessageBox.Show("JSON file imported and session names displayed.");
                }
            }
        }

        private void MergeButton_Click(object sender, EventArgs e)
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
                        // Merge temp data into overallData
                        foreach (var session in tempData)
                        {
                            // If session exists (for some reason), update it
                            if (overallData.ContainsKey(session.Key))
                            {
                                foreach (var player in session.Value)
                                {
                                    // If the player exists (for some reason), add/update new metrics
                                    if (overallData[session.Key].ContainsKey(player.Key))
                                    {
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

                        // Update gameList_GridView
                        gameList_GridView.Rows.Clear();
                        gameList_GridView.Columns.Clear();
                        gameList_GridView.Columns.Add("SessionName", "Session Name");

                        foreach (var session in overallData)
                        {
                            // Add ONLY sessions names to the grid
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

        private void ExportButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.Title = "Save JSON File";
                saveFileDialog.FileName = "gameData.json"; // Default file name (redo? Scrap?)

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string saveFilePath = saveFileDialog.FileName;

                    if (overallData != null && overallData.Count > 0)
                    {
                        var exportData = new Dictionary<string, Dictionary<string, object>>();

                        foreach (var session in overallData)
                        {
                            string sessionKey = session.Key; // Session Name
                            var sessionData = session.Value; // Inner information

                            // Create second dictionary to hold elements
                            var sessionExportData = new Dictionary<string, object>();

                            foreach (var element in sessionData)
                            {
                                string elementName = element.Key; // Element Name
                                GameElement elementData = element.Value; // All information within the element

                                // Create a dictionary for the element's metrics
                                var metricsData = new Dictionary<string, float>();

                                // Loop through metrics in GameElement
                                foreach (var metric in elementData.Metrics)
                                {
                                    metricsData[metric.Key] = metric.Value;
                                }

                                // Add element data to the session export structure
                                sessionExportData[elementName] = new Dictionary<string, object>
                        {
                            { "Name", elementName },
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

        private void OpenGameDetails(string sessionKey)
        {
            // overallData contains the data of the imported .JSON
            if (overallData.ContainsKey(sessionKey))
            {
                var sessionData = overallData[sessionKey];

                AnalyticsGameDetails detailsForm = new AnalyticsGameDetails(sessionKey, sessionData);
                detailsForm.Show();  // Show the details form
            }
            else
            {
                MessageBox.Show("Session data not found.");
            }
        }

        private void GameList_GridView_MouseDoubleClick(object sender, EventArgs e)
        {
            if (gameList_GridView.SelectedRows.Count > 0)
            {
                try
                {
                    // Attempt to get the session key from the selected row
                    string selectedSessionKey = gameList_GridView.SelectedRows[0].Cells["SessionName"].Value?.ToString();
                    OpenGameDetails(selectedSessionKey);
                }
                catch (Exception ex)
                {
                    // Handle unexpected errors
                    MessageBox.Show("An error occurred while selecting the session. Please try again.\nError: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a session to view.");
            }
        }
    }
}