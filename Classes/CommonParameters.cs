using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalcompTwoCam
{
    class CommonParameters
    {
        private static string workingDirectory = Environment.CurrentDirectory;

        // This will get the current PROJECT directory
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public static string camSrNum { get; set; }
        public static string camCode{ get; set; }

        
    }

    class Forms
    {
        public static InspectModel inspectModel = null;
        public static CreateModel createModel = null;
        public static ReportPage reportPage = null;
        public static EditModel editModel = null;
        public static RegisterModel registerModel = null;
        public static LoginPage loginPage = null;
        public static DeleteModelPage deleteModelPage = null;
    }
}
