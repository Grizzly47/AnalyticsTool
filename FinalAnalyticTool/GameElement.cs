using System.IO;

namespace FinalTool
{
    public class GameElement
    {
        public string Name { get; set; }
        public Dictionary<string, float> Metrics { get; private set; }
        public GameElement() 
        {
            Name = string.Empty;
            Metrics = new Dictionary<string, float>();
        }

        public GameElement(string _name)
        {
            Name = _name;
            Metrics = new Dictionary<string, float>();
        }

        public void AddOrUpdateMetric(string _metricName, float _value)
        {
            Metrics[_metricName] = _value;
        }
    }
}
