using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SalcompTwoCam
{
    public class ServiceUtils
    {


        // print line no file name and others 
        public static void Log(string text,
                     [CallerFilePath] string file = "",
                     [CallerMemberName] string member = "",
                     [CallerLineNumber] int line = 0)
        {
            Console.WriteLine("{0}  _ {1} ({2}) :  {3}  ", Path.GetFileName(file), member, line, text);
        }


        
        public bool GetXml(vCheckTester aCT, string aSaveDir, ref string err)
        {
            try
            {
                if (aCT == null)
                {
                    return false;
                }
                if (!System.IO.Directory.Exists(aSaveDir))
                {
                    err = "The save data directory does not exist in the specified path";
                }

                aCT.TestUnit = new vCheckTester.Unit();
                aCT.TestUnit.MeasurementList = new ArrayList();




                Console.WriteLine("aSaveDir  ---------- " + aSaveDir);
                //un = aCT.TestUnit as vCheckTester.Unit;
                ServiceUtils.Log("");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                doc.AppendChild(dec);

                XmlElement root = doc.CreateElement("vCheckTester");
                ServiceUtils.Log("");

                root.SetAttribute("xmlns:xsi", vCheckTester.Xsi.ToString());
                root.SetAttribute("xmlns:xsd", vCheckTester.Xsd.ToString());
                root.SetAttribute("Version", vCheckTester.Version.ToString("F1"));
                root.SetAttribute("xmlns", vCheckTester.xmlns);
                root.SetAttribute("OperatorNumber", aCT.OperatorNumber.ToString());
                root.SetAttribute("WorkOrderNumber", aCT.WorkOrderNumber.ToString());

                ServiceUtils.Log("");


                XmlElement unitnode = doc.CreateElement("Unit");
                unitnode.SetAttribute("Timestamp", aCT.TestUnit.Timestamp.ToString("yyyy-MM-ddTHH:mm:ss"));
                unitnode.SetAttribute("SerialNumber", aCT.TestUnit.SerialNumber.ToString());
                unitnode.SetAttribute("StatusCode", aCT.TestUnit.StatusCode.ToString());
                unitnode.SetAttribute("DateTimeStart", aCT.TestUnit.DateTimeStart.ToString("yyyy-MM-ddTHH:mm:ss"));
                unitnode.SetAttribute("DateTimeEnd", aCT.TestUnit.DateTimeEnd.ToString("yyyy-MM-ddTHH:mm:ss"));
                unitnode.SetAttribute("xmlns", vCheckTester.Unit.xmlns.ToString());


                vCheckTester.Unit.Measurement ms = null;
                ms = new vCheckTester.Unit.Measurement();
                ms.OCRInspectName = "OCR Defect Area";
                ms.xmlns = "Valor.vCheckTester.xsd";
                ms.OCRDefectAreaLowerLimit = "159.99";// 
                ms.OCRDefectAreaUpperLimit = "160.01";// 
                ms.OCRInspectResult = "PASS";// PASS
                ms.OCRValueUnit = "double";// double
                ms.OCRMeasurementUnit = "mm";// mm
                ms.OCRMessage = "Unit:mm Min:159.99 Max:160.01 Value:0";// mm




                ServiceUtils.Log("");

                XmlElement symptomnode = doc.CreateElement("Symptom");

                symptomnode.SetAttribute("Type", "Unknown");
                symptomnode.SetAttribute("Name", ms.OCRInspectName);
                symptomnode.SetAttribute("xmlns", ms.xmlns);


                XmlElement msgnode = doc.CreateElement("Message");
                msgnode.SetAttribute("xmlns", ms.xmlns);
                msgnode.InnerText = ms.OCRMessage;

                XmlElement measnode = doc.CreateElement("Measurement");
                measnode = doc.CreateElement("Measurement");
                measnode.SetAttribute("DateTime", ms.DateTime.ToString("yyyy-MM-ddTHH:mm:ss"));
                measnode.SetAttribute("Value", ms.OCRDefectArea);
                measnode.SetAttribute("MeasurementUnit", ms.OCRMeasurementUnit);
                measnode.SetAttribute("LowerLimit", ms.OCRDefectAreaLowerLimit);
                measnode.SetAttribute("UpperLimit", ms.OCRDefectAreaUpperLimit);
                measnode.SetAttribute("ValueUnit", ms.OCRValueUnit);
                measnode.SetAttribute("Name", ms.OCRInspectName);
                measnode.SetAttribute("StatusCode", ms.OCRInspectResult);
                measnode.SetAttribute("xmlns", ms.xmlns);
                symptomnode.AppendChild(msgnode);
                symptomnode.AppendChild(measnode);
                unitnode.AppendChild(symptomnode);


                ServiceUtils.Log("");

                ServiceUtils.Log("");

                XmlElement headernode = doc.CreateElement("Header");
                //headernode.SetAttribute("TestProgramName", aCT.TestUnit.UnitHeader.TestProgramName);
                //headernode.SetAttribute("TestHeadNumber", aCT.TestUnit.UnitHeader.TestHeadNumber);
                //headernode.SetAttribute("TestProgramVersion", aCT.TestUnit.UnitHeader.TestProgramVersion);
                //headernode.SetAttribute("TestHeadType", aCT.TestUnit.UnitHeader.TestHeadType);
                headernode.SetAttribute("TestFixtureNumber", aCT.TestUnit.UnitHeader.TestFixtureNumber);
                headernode.SetAttribute("xmlns", ms.xmlns);
                unitnode.AppendChild(headernode);

                ServiceUtils.Log("");
                root.AppendChild(unitnode);

                doc.AppendChild(root);

                aSaveDir = System.Convert.ToString((aSaveDir.Substring(aSaveDir.Length - 2, 1) == "\\") ? aSaveDir : aSaveDir + "\\");
                string fullname = aSaveDir + "\\" + aCT.TestUnit.SerialNumber + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + "_xml.log";
                doc.Save(fullname);

                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }//public bool GetXml(vCheckTester aCT, string aSaveDir, ref string err)



        public static bool save_unit_xml(UnitReport unitReport)
        {

            vCheckTester aCT = new vCheckTester();
            aCT.OperatorNumber = "op";
            aCT.WorkOrderNumber = "";
            try
            {
                if (aCT == null)
                {
                    return false;
                }
                aCT.TestUnit = new vCheckTester.Unit();
                aCT.TestUnit.MeasurementList = new ArrayList();
                // ServiceUtils.Log("");
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                doc.AppendChild(dec);
                XmlElement root = doc.CreateElement("vCheckTester");
                // ServiceUtils.Log("");
                root.SetAttribute("xmlns:xsi", vCheckTester.Xsi.ToString());
                root.SetAttribute("xmlns:xsd", vCheckTester.Xsd.ToString());
                root.SetAttribute("Version", vCheckTester.Version.ToString("F1"));
                root.SetAttribute("xmlns", vCheckTester.xmlns);
                root.SetAttribute("OperatorNumber", aCT.OperatorNumber.ToString());
                root.SetAttribute("WorkOrderNumber", aCT.WorkOrderNumber.ToString());
                XmlElement unitnode = doc.CreateElement("Unit");
                unitnode.SetAttribute("Timestamp", unitReport.Timestamp.ToString("yyyy-MM-ddTHH:mm:ss"));
                unitnode.SetAttribute("SerialNumber", unitReport.SerialNumber.ToString());
                unitnode.SetAttribute("StatusCode", unitReport.StatusCode.ToString());
                unitnode.SetAttribute("DateTimeStart", unitReport.DateTimeStart.ToString("yyyy-MM-ddTHH:mm:ss"));
                unitnode.SetAttribute("DateTimeEnd", unitReport.DateTimeEnd.ToString("yyyy-MM-ddTHH:mm:ss"));
                unitnode.SetAttribute("xmlns", vCheckTester.Unit.xmlns.ToString());
                vCheckTester.Unit.Measurement ms = null;
                ms = new vCheckTester.Unit.Measurement();
                ms.OCRInspectName = "Laser Marking Test";
                ms.xmlns = "Valor.vCheckTester.xsd";
                ms.OCRDefectAreaLowerLimit = "0";// 
                ms.OCRDefectAreaUpperLimit = "1";// 
                ms.OCRInspectResult = "PASS";// PASS
                ms.OCRValueUnit = "Int";// double
                ms.OCRMeasurementUnit = "mm";// mm
                ms.OCRMessage = "Unit:mm Min:159.99 Max:160.01 Value:0";// mm
                //ServiceUtils.Log("");
                XmlElement symptomnode = doc.CreateElement("Symptom");
                symptomnode.SetAttribute("Type", "Unknown");
                //  symptomnode.SetAttribute("Name", ms.OCRInspectName);
                symptomnode.SetAttribute("Name", "Print Inspection AI");
                //symptomnode.SetAttribute("xmlns", ms.xmlns);
                //XmlElement msgnode = doc.CreateElement("Message");
                //msgnode.SetAttribute("xmlns", ms.xmlns);
                //msgnode.InnerText = ms.OCRMessage;
                XmlElement measnode = doc.CreateElement("Measurement");
                measnode = doc.CreateElement("Measurement");
                measnode.SetAttribute("DateTime", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                measnode.SetAttribute("Value", "1");
                measnode.SetAttribute("MeasurementUnit", ms.OCRMeasurementUnit);
                measnode.SetAttribute("LowerLimit", "0");
                measnode.SetAttribute("UpperLimit", "1");
                measnode.SetAttribute("ValueUnit", "Int");
                measnode.SetAttribute("Name", "Laser Marking Test");
                measnode.SetAttribute("StatusCode", unitReport.StatusCode);
                measnode.SetAttribute("xmlns", ms.xmlns);
                if (unitReport.StatusCode.Equals("PASS"))
                {
                    unitnode.AppendChild(measnode);
                    root.AppendChild(unitnode);
                }
                else
                {
                    //symptomnode.AppendChild(msgnode);
                    //symptomnode.AppendChild(measnode);
                    // second symptomnode
                    XmlElement symptomnodeTwo = doc.CreateElement("Symptom");
                    symptomnodeTwo.SetAttribute("Type", "Unknown");
                    symptomnodeTwo.SetAttribute("Name", "Laser Marking Test");
                    //symptomnodeTwo.SetAttribute("xmlns", ms.xmlns);
                    XmlElement msgnodeTwo = doc.CreateElement("Message");
                    msgnodeTwo = doc.CreateElement("Message");
                    msgnodeTwo.InnerText = "LowerLimit=0  UpperLimit=1 Value=0";
                    XmlElement measnodeTwo = doc.CreateElement("Measurement");
                    measnodeTwo = doc.CreateElement("Measurement");
                    measnodeTwo.SetAttribute("DateTime", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                    measnodeTwo.SetAttribute("Value", "0");
                    measnodeTwo.SetAttribute("MeasurementUnit", ms.OCRMeasurementUnit);
                    measnodeTwo.SetAttribute("LowerLimit", ms.OCRDefectAreaLowerLimit);
                    measnodeTwo.SetAttribute("UpperLimit", ms.OCRDefectAreaUpperLimit);
                    measnodeTwo.SetAttribute("ValueUnit", ms.OCRValueUnit);
                    measnodeTwo.SetAttribute("Name", ms.OCRInspectName);
                    measnodeTwo.SetAttribute("StatusCode", unitReport.StatusCode);
                    measnodeTwo.SetAttribute("xmlns", ms.xmlns);
                    symptomnodeTwo.AppendChild(msgnodeTwo);
                    symptomnodeTwo.AppendChild(measnodeTwo);
                    //msgnode.SetAttribute("xmlns", ms.xmlns);
                    //msgnode.InnerText = "  ";
                    //symptomnode.AppendChild(msgnodeTwo);
                    //symptomnode.AppendChild(measnodeTwo);
                    unitnode.AppendChild(symptomnodeTwo);


                    //unitnode.AppendChild(symptomnodeTwo);
                    // unitnode.AppendChild(measnode);
                    //unitnode.AppendChild(measnodeTwo);
                    root.AppendChild(unitnode);
                }
                // ServiceUtils.Log("");
                // ServiceUtils.Log("");
                XmlElement headernode = doc.CreateElement("Header");
                //headernode.SetAttribute("TestProgramName", aCT.TestUnit.UnitHeader.TestProgramName);
                //headernode.SetAttribute("TestHeadNumber", aCT.TestUnit.UnitHeader.TestHeadNumber);
                //headernode.SetAttribute("TestProgramVersion", aCT.TestUnit.UnitHeader.TestProgramVersion);
                //headernode.SetAttribute("TestHeadType", aCT.TestUnit.UnitHeader.TestHeadType);
                headernode.SetAttribute("TestFixtureNumber", "0");
                unitnode.AppendChild(headernode);
                //ServiceUtils.Log("");
                //root.AppendChild(unitnode);
                doc.AppendChild(root);

                //aSaveDir = System.Convert.ToString((aSaveDir.Substring(aSaveDir.Length - 2, 1) == "\\") ? aSaveDir : aSaveDir + "\\");
                //string fullname = aSaveDir + "\\" + aCT.TestUnit.SerialNumber + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + "_xml.log";

                string year_folder = GlobalItems.report_data + DateTime.Now.Year.ToString();
                string fullPath_with_day = year_folder + @"\" + DateTime.Now.ToString("MMMM") + @"\" + DateTime.Now.Day;
               // ServiceUtils.Log("full path  : " + fullPath_with_day);
                bool exists = System.IO.Directory.Exists(fullPath_with_day);
                if (exists)
                {


                    if(GlobalItems._LogInModel.Xml_location.Equals("NoSet"))
                    {
                        string xml_file = fullPath_with_day + @"\" + unitReport.SerialNumber + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + "_xml.log";
                        // ServiceUtils.Log("xml_file : " + xml_file);
                        doc.Save(xml_file);
                    }
                    else
                    {

                        string xml_file = GlobalItems._LogInModel.Xml_location + @"\" + unitReport.SerialNumber + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + "_xml.log";
                        // ServiceUtils.Log("xml_file : " + xml_file);
                        doc.Save(xml_file);
                    }
          

                }
                else
                {

                    Directory.CreateDirectory(fullPath_with_day);
                    //string xml_file = fullPath_with_day+@"\"+ unitReport.SerialNumber + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + "_xml.log";
                    ////ServiceUtils.Log("xml_file : " + xml_file);
                    //doc.Save(xml_file);

                }


                return true;
            }
            catch (Exception ex)
            {
               // ServiceUtils.Log(ex.Message);
                return false;
            }

        }//save_unit_xml

       
    }
}
