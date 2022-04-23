using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalcompTwoCam
{

    public class Settings
    {
        public string nodeName;
        private decimal nodeValue;

        public decimal[] nodeRange = { 0, 255 };

        public Settings(string name, decimal val, decimal lb, decimal ub)
        {
            nodeName = name;
            nodeVal = val;
            nodeRange[0] = lb;
            nodeRange[1] = ub;
        }

        public decimal nodeVal
        {
            get => nodeValue;
            set
            {
                if (value < nodeRange[0] || value > nodeRange[1])
                {
                    nodeValue = nodeRange[0];
                }
                else
                {
                    nodeValue = value;
                }
            }
        }
    }

    //class CameraParameters
    //{
    //    public static List<Settings> List = new List<Settings>();

        
    //    public static int overlap { get; set; }

    //    public CameraParameters()
    //    {
    //        List = new List<Settings>();
    //    }

    //    public void updatePara()
    //    {
    //        List = new List<Settings>();
    //        List.Add(new Settings("PreDiv", 50, 1, 128));
    //        List.Add(new Settings("Mul", 50, 1, 32));
    //        List.Add(new Settings("PostDiv", 50, 1, 128));
    //        List.Add(new Settings("FrameDelay", 50, 1, 128));
    //        List.Add(new Settings("Cam1Expo", 500, 100, 7000));
    //        List.Add(new Settings("Cam2Expo", 300, 100, 7000));
    //        List.Add(new Settings("Overlap", 50, 0, 3000));
    //        List.Add(new Settings("LineRateCam1", 500, 0, 5000));
    //        List.Add(new Settings("LineRateCam2", 500, 0, 5000));
    //    }
    //}
    public class Tools
    {
        public class CheckEdge
        {
            public class Region
            {
                [JsonProperty("point_x")]
                public long PointX { get; set; }

                [JsonProperty("point_y")]
                public long PointY { get; set; }

                [JsonProperty("imageWidth")]
                public long imageWidth { get; set; }

                [JsonProperty("imageHeight")]
                public long imageHeight { get; set; }

                [JsonProperty("template_image_path")]
                public string TemplateImagePath { get; set; }
                //[JsonProperty("regionName")]
                //public string regionName { get; set; }

                public Region(Region region)
                {
                    this.PointX = region.PointX;
                    this.PointY = region.PointY;
                    this.imageWidth = region.imageWidth;
                    this.imageHeight = region.imageHeight;
                    this.TemplateImagePath = region.TemplateImagePath;
                    //this.regionName = region.regionName;
                }

                public Region()
                {

                }
            }

            [JsonProperty]
            public Region edgeRegion = new Region();

            public List<Settings> List = new List<Settings>();

            public CheckEdge()
            {
                List = new List<Settings>();

            }

            public decimal angleTolerance = 0;
            public decimal angle = 0;
            public decimal threshold = 0;
            public decimal distance = 0;
            public decimal distanceTolerance = 0;
            public decimal polarity = 0;
            public decimal strength = 0;
            public int direction = 0;

            

            public void updatePara()
            {
                List = new List<Settings>();
                List.Add(new Settings("AngleTolerance", 3, 1, 128));
                List.Add(new Settings("Angle", 50, 1, 128));
                List.Add(new Settings("EdgeThreshold", 40, 2, 228));
                List.Add(new Settings("Polarity", 2, 0, 3));
                List.Add(new Settings("Strength", 1, 0, 2));
                //List.Add(new Settings("Direction", 0, 0, 1));
               
            }

        }
        public class CheckTemplate
        {
            public class Region
            {
                [JsonProperty("point_x")]
                public long PointX { get; set; }

                [JsonProperty("point_y")]
                public long PointY { get; set; }

                [JsonProperty("imageWidth")]
                public long imageWidth { get; set; }

                [JsonProperty("imageHeight")]
                public long imageHeight { get; set; }

                [JsonProperty("template_image_path")]
                public string TemplateImagePath { get; set; }
                

                public Region(Region region)
                {
                    this.PointX = region.PointX;
                    this.PointY = region.PointY;
                    this.imageWidth = region.imageWidth;
                    this.imageHeight = region.imageHeight;
                    this.TemplateImagePath = region.TemplateImagePath;
                }

                public Region()
                {

                }
            }

            [JsonProperty("MatchScore")]
            public decimal matchScore { get; set; }

            [JsonProperty("TempThreshold")]
            public decimal threshold { get; set; }

            [JsonProperty("BinaryThreshold")]
            public decimal binaryThreshold { get; set; }

            [JsonProperty("template_image_path")]
            public string templateImagePath { get; set; }

            [JsonProperty("ShiftToleranceX")]
            public decimal shiftToleranceX { get; set; }

            [JsonProperty("ShiftToleranceY")]
            public decimal shiftToleranceY { get; set; }

            public List<Settings> List = new List<Settings>();

            public CheckTemplate()
            {
                List = new List<Settings>();

            }
            public void updatePara()
            {
                List = new List<Settings>();
                List.Add(new Settings("MatchScore", 85, 1, 100));
                List.Add(new Settings("TempThreshold", 85, 1, 100));
                List.Add(new Settings("BinaryThreshold", 50, 1, 128));
                List.Add(new Settings("ShiftToleranceX", 10, 5, 128));
                List.Add(new Settings("ShiftToleranceY", 10, 5, 128));
            }

            

            [JsonProperty]
            public Region tempRegion = new Region();


        }

    }
    
}
