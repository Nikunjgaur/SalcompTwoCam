using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalcompTwoCam
{
    public class Model:Tools
    {

        [JsonProperty("model_name")]
        public static string ModelName { get; set; }

        [JsonProperty("camera_exposer")]
        public float Camera_exposer { get; set; }


        [JsonProperty("TemplateImagePath")]
        public string TemplateImagePath { get; set; }

        [JsonProperty("OriginalImagePath")]
        public string OriginalImagePath { get; set; }

        [JsonProperty("CheckTemplate")]
        public List<CheckTemplate> CheckTemplates { get; set; }

        [JsonProperty("CheckCheckEdges")]
        public List<CheckEdge> CheckEdges { get; set; }

        public bool result = false;

        [JsonProperty("TemplateCoordinate")]
        public Tools.CheckEdge.Region TemplateCoordinate { get; set; }

        public Model()
        {
            CheckTemplates = new List<CheckTemplate>();
            TemplateCoordinate = new Tools.CheckEdge.Region();
            CheckEdges = new List<CheckEdge>();
        }

    }
}
