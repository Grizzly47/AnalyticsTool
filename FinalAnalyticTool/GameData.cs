using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FinalTool
{
    public class GameData
    {
        public string Version { get; set; } = "1.0.0";  // Placeholder version number (Change it? Set to private var with getter/setter)
        public int PlayerCount { get; set; } = 0;        // Not used anywhere

        // Dictionary to store GameElement objects
        private Dictionary<string, GameElement> gameElements = new Dictionary<string, GameElement>();

        // Method to add a new GameElement
        public void AddElement(string elementName)
        {
            if (!gameElements.ContainsKey(elementName))
            {
                gameElements[elementName] = new GameElement(elementName);
            }
        }

        // Method to retrieve a GameElement
        public GameElement? GetElement(string elementName)
        {
            return gameElements.ContainsKey(elementName) ? gameElements[elementName] : null;
        }

        // Method to save a specific metric for a GameElement
        public void SaveMetric(string _elementName, string _metricName, float _value)
        {
            if (!gameElements.ContainsKey(_elementName))
            {
                gameElements[_elementName] = new GameElement(_elementName);
                Console.WriteLine($"Created new element: {_elementName}");
            }

            GameElement element = gameElements[_elementName];
            element.AddOrUpdateMetric(_metricName, _value);

            SaveToJson("gameData_" + Version + ".json");
            Console.WriteLine($"Save {_metricName} for {_elementName}: {_value}");
        }

        // Method to increment a specific metric for a GameElement
        public void IncrementMetric(string _elementName, string _metricName, float _value)
        {
            GameElement element = GetElement(_elementName);
            if (element != null)
            {
                float currentValue = element.Metrics.ContainsKey(_metricName) ? element.Metrics[_metricName] : 0;
                float newValue = currentValue + _value;
                element.AddOrUpdateMetric(_metricName, newValue);
                SaveToJson("gameData_" + Version + ".json");
                Console.WriteLine($"Incremented {_metricName} for {_elementName} by {_value}: New value = {newValue}");
            }
            else
            {
                Console.WriteLine($"Element {_elementName} not found.");
            }
        }

        // Method to save the game elements to a JSON file
        public void SaveToJson(string _filePath)
        {
            Dictionary<string, Dictionary<string, GameElement>>? overallData = null;
            if (File.Exists(_filePath))
            {
                string existingData = File.ReadAllText(_filePath);
                overallData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, GameElement>>>(existingData);
            }

            if (overallData == null)
            {
                overallData = new Dictionary<string, Dictionary<string, GameElement>>();
            }

            // Create a session key based on current date and time
            string sessionKey = "Session_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Add the current game elements as a new session
            overallData[sessionKey] = new Dictionary<string, GameElement>(gameElements);

            // Serialize the updated data back to the file
#if DEBUG
            string json = JsonConvert.SerializeObject(overallData, Formatting.Indented);
#else
            string json = JsonConvert.SerializeObject(overallData);
#endif
            File.WriteAllText(_filePath, json);

            Console.WriteLine($"Game session added to {_filePath}");
        }
    }
}
