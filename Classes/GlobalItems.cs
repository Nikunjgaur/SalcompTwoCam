using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SalcompTwoCam
{
    public class GlobalItems
    {
   
        static public DirectoryInfo data_base_folder = new DirectoryInfo(@"C:\Database\");
        static public string icon = data_base_folder + @"iconNew.ico";
        static public string default_image = data_base_folder + @"IMG0008.bmp";
        
        static public string password_json = data_base_folder + @"_pass.json";

        static public string report_data = @"C:\Database\report_data\";

        public static vCheckTester _vCheckTester { get; set; } = new vCheckTester();

        public static Model _Model { get; set; } = new Model();
        public static LogInModel _LogInModel { get; set; } = new LogInModel();

        public static  XmlElement _unit_node { get; set; }

        static public bool operator_access =false;
        static public bool admin_access = false;
        static public bool engineer_access = false;
        public static bool edit_page_access = false;


    }
}
