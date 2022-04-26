using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalcompTwoCam
{
    class XmlModel
    {
    }

	public class vCheckTester
	{
		public class Unit
		{
			public class Symptom
			{
				public string Name = "";
				public string Type = "";
				public string Unknown = "";

				public string Message = "";
			}

			public class Measurement
			{
				public Symptom Sym = null;
				public string Name = "TEST";// 
				public DateTime DateTime = System.Convert.ToDateTime(null);
				public string MeasurementUnit = "Unit";
				public string ValueUnit = "Double";
				public string xmlns = "Valor.vCheckTester.xsd";
				public string Barcode2DCodeData;//  ]
				public string ResultOCR;//  

				public string OCRInspectName;// 
				public string OCRDefectArea;// 
				public string OCRDefectAreaLowerLimit;// 
				public string OCRDefectAreaUpperLimit;// 
				public string OCRInspectResult;// PASS
				public string OCRValueUnit;// double
				public string OCRMeasurementUnit;// mm
				public string OCRMessage;// mm


				public string PinDistanceName;// 
				public string PinDistance;// 
				public string PinDistanceLowerLimit;// 
				public string PinDistanceUpperLimit;// 
				public string PinDistanceResult;// PASS
				public string PinDistanceValueUnit;// double
				public string PinDistanceMeasurementUnit;// mm
				public string PinMessage;// mm

				public string LeftPinName;// 
				public string LeftPinHeight;// 
				public string LeftPinLowerLimit;// 
				public string LeftPintUpperLimit;// 
				public string LeftPinResult;// PASS
				public string LeftPinValueUnit;// double
				public string LeftPinMeasurementUnit;// mm
				public string LeftPinMessage;// mm

				public string RightPinName;// 
				public string RightPinHeight;// 
				public string RightPinLowerLimit;// 
				public string RightPintUpperLimit;// 
				public string RightPinResult;// PASS
				public string RightPinValueUnit;// double
				public string RightPinMeasurementUnit;// mm
				public string RightPinMessage;// mm

				public string LeftAngleName;// 
				public string LeftAngle;// 
				public string LeftAngleHeight;// 
				public string LeftAngleLowerLimit;// 
				public string LeftAngleUpperLimit;// 
				public string LeftAngleResult;//
				public string LeftAngleValueUnit;// double
				public string LeftAngleMeasurementUnit;// mm
				public string LeftAngleMessage;// mm

				public string RightAngleName;// 
				public string RightAngle;// 
				public string RightAngleHeight;// 
				public string RightAngleLowerLimit;// 
				public string RightAngleUpperLimit;// 
				public string RightAngleResult;//
				public string RightAngleValueUnit;// double
				public string RightAngleMeasurementUnit;// mm
				public string RightAngleMessage;// mm

				public string StatusCode;

			}

			public class Header
			{
				public string TestProgramName = "GD_Vision";
				public string TestHeadNumber = "GD_Vision";
				public string TestProgramVersion = "1.0.0.0";
				public string TestHeadType = "Testser Information";
				/// <summary>
				/// 治具id
				/// </summary>
				/// <remarks></remarks>
				public string TestFixtureNumber = "0005377304";
			}

			public DateTime Timestamp = System.Convert.ToDateTime(null);
			/// <summary>
			/// 产品序列号
			/// </summary>
			/// <remarks></remarks>
			public string SerialNumber = "";
			public DateTime DateTimeStart = System.Convert.ToDateTime(null);
			public DateTime DateTimeEnd = System.Convert.ToDateTime(null);
			public const string xmlns = "Valor.vCheckTester.xsd";
			public string StatusCode = "";

			public Header UnitHeader = new Header();
			public ArrayList MeasurementList = new ArrayList();
		}

		public const string Xsi = "http://www.w3.org/2001/XMLSchema-instance";
		public const string Xsd = "http://www.w3.org/2001/XMLSchema";
		public const double Version = 4.0;
		public const string xmlns = "Valor.vCheckTester.xsd";
		public string OperatorNumber = "";
		public string WorkOrderNumber = "";

		public Unit TestUnit = null;
	}
}
