#include "pch.h"
#include "AlgoCpp.h"
#include <string>
#include <iostream>
#include "opencv2/opencv.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui.hpp"
#include <fstream>
#include <nlohmann\json.hpp>
#include "InspectAlgo.h"
#include "Utils.h"
#include "base64.h"
#ifndef DEBUG 
#define DEBUG 1 // set debug mode
#endif
#include "Utils.h"
#include "TestAlgo.h"
#include <filesystem>
#include "ModelData.h"
using namespace std;
#if DEBUG
#define log(...) {\
    char str[100];\
    sprintf(str, __VA_ARGS__);\
    std::cout << "[" << __FILE__ << "][" << __FUNCTION__ << "][Line " << __LINE__ << "] " << str << std::endl;\
    }
#else
#define log(...)
#endif
using json = nlohmann::json;
using namespace cv;
using namespace cv::ml;
using namespace std;
using namespace System;
InspectAlgo _InspectAlgo_obj;
Utils  _Utils_obj;
TestAlgo  _TestAlgo_obj;
std::vector<cv::Mat>  _vector_template;

vector <Utils::modelTemplVars> modelData;
json _SalcomJsonData;
cv::Mat smaller_template_match_result;
cv::Mat  bigger_template_match_result;
cv::Mat BitmapToMatAgain(System::Drawing::Bitmap^ bitmap);
float distancePoint(Point p, Point q)
{
	Point diff = p - q;
	return cv::sqrt(diff.x * diff.x + diff.y * diff.y);
}



cv::Mat   bigger_templateM;
cv::Mat   smaller_templateM;
cv::Mat   bigger_template;
cv::Mat   smaller_template;
Mat biggerTemplateMask;
std::string   _model_path;
std::string  data_baseFolder = "C:\\Database\\";
cv::Mat source_image_mat;
std::string _model_path_full;
std::vector<RectanglePoint_namespace::RectanglePoint>  _rectangle_points_vect;//
RectanglePoint_namespace::RectanglePoint   _bigger;
RectanglePoint_namespace::RectanglePoint   _smaller;
Mat imageColorShow;
int modelColor = 0; //0 -white //1 - black

vector <Mat> mainTempl1;
vector <Mat> mainTempl2;
vector <Mat> toolTemplateC1;
vector <Mat> toolTemplateC2;
System::String^ __clrcall AlgoCpp::SalcomCpp::ProcessImage(System::Drawing::Bitmap^ sourceImage_bitmap, System::String^ json_model_data, int camCode)
{
	bool resultArray[] = { true, true };

	using System::Runtime::InteropServices::Marshal;
	System::IntPtr pointer_for_model_name = Marshal::StringToHGlobalAnsi(json_model_data);
	char* charPointer_json = reinterpret_cast<char*> (pointer_for_model_name.ToPointer());
	std::string json_model_data_std_string(charPointer_json, json_model_data->Length);
	ModelData::ModelDataClass modelData = json::parse(json_model_data_std_string);
	Mat imageIn = BitmapToMatAgain(sourceImage_bitmap);
	Mat draw;
	Mat gray;

	if (imageIn.channels() > 2)
	{
		cvtColor(imageIn, gray, COLOR_BGR2GRAY);
		draw = imageIn.clone();
	}
	else
	{
		cvtColor(imageIn, draw, COLOR_GRAY2BGR);
		gray = imageIn.clone();
	}
	try
	{
		/*cout << "------------------------------------------" << endl;

		cout << json_model_data_std_string << endl;

		cout << "------------------------------------------" << endl;*/

		Mat cropped;// = imageIn(roiCrop).clone();
		Rect rect_partLoc;
		Mat rotImg = imageIn.clone();
		if (camCode == 0)
			rotImg = _Utils_obj.partLocation(gray, mainTempl1[0], rotImg, &cropped, &rect_partLoc);
		else
			rotImg = _Utils_obj.partLocation(gray, mainTempl2[0], rotImg, &cropped, &rect_partLoc);

		draw = rotImg.clone();
		rectangle(draw, rect_partLoc, Scalar(0, 0,0), 2, 8, 0);
		cout << "imageIn chaneels::" << rotImg.channels() << endl;
		cvtColor(cropped, cropped, COLOR_BGR2GRAY);
		Rect region;
		region.x = modelData.get_template_coordinate().get_point_x();
		region.y = modelData.get_template_coordinate().get_point_y();
		region.height = modelData.get_template_coordinate().get_image_height();
		region.width = modelData.get_template_coordinate().get_image_width();
		rectangle(draw, region, Scalar(255, 0, 0), 2);
		cout << "This is value " << modelData.get_check_template()[0].get_binary_threshold() << endl;
		int idxT = 0;
		for each (ModelData::CheckTemplate var in modelData.get_check_template())
		{
			//var.set_match_score(70);
			//rectangle(draw,)
			Rect r;
			r.x = var.get_temp_region().get_point_x() ;
			r.y = var.get_temp_region().get_point_y();
			r.height = var.get_temp_region().get_image_height();
			r.width = var.get_temp_region().get_image_width();
			//rectangle(draw(region),r, Scalar(0, 120,120), 2);
			int matchTh = var.get_temp_threshold(); //85   //0-100
			double scoreL = 0; //output return value of match score % 0 -100
			int shiftTolX = 10; // input par //0-120
			int shiftTolY = 10;// input par  //0-120

			Rect locL = Rect(0, 0, 10, 10);

			cout << "--------------------------------------------" << endl;


			cout << "This is Match Thresh "<< matchTh << endl;

			cout << "--------------------------------------------" << endl;


			bool resultL=false;
			if (camCode == 0) {
				resultL = _Utils_obj.toolTempMatch_withScore(cropped, toolTemplateC1[idxT], r, matchTh, Point(shiftTolX, shiftTolY), &scoreL, &locL);
			}
			else
			{
				resultL = _Utils_obj.toolTempMatch_withScore(cropped, toolTemplateC2[idxT], r, matchTh, Point(shiftTolX, shiftTolY), &scoreL, &locL);
			}
			Scalar color_res = Scalar(0, ((int)resultL) * 255, ((int)(!resultL)) * 255);
			rectangle(draw(rect_partLoc), locL, color_res, 2);
			cout << "match score L " << scoreL << endl;
			putText(draw, cv::format("%3.2f", scoreL), Point(rect_partLoc.x + locL.x, rect_partLoc.y + locL.y), FONT_HERSHEY_COMPLEX, 1, color_res, 2);
			idxT++;
			
			resultArray[0] = resultL;
		}
		//_Utils_obj.resShow("result", draw, 1);
		for each (ModelData::CheckCheckEdge var in modelData.get_check_check_edges())
		{
			cout << var.get_direction() << endl;
			Rect r;
			r.x = var.get_edge_region().get_point_x();
			r.y = var.get_edge_region().get_point_y();
			r.height = var.get_edge_region().get_image_height();
			r.width = var.get_edge_region().get_image_width();
			//rectangle(draw(region),r, Scalar(255, 0, 0), 2);

			int edgeTH = var.get_threshold();//th 2-230 //default = 40
			int edgeDir = var.get_direction();//pose 0 or 1
			int polarity = var.get_polarity(); // transition //0 = dark --> light 1= light --> dark 2 = both  
			float strength = var.get_strength();// 0.6;// val 0.6  //strength 0 to 1 float

			

			cout << "Edge strength ::" << strength << endl;
			vector <Point> p1Pts = { Point(0,0),Point(0,0) };
			int resEdge = 0;
			Mat pinImgL = _Utils_obj.checkChargerPins(cropped(r), "left"+to_string(r.x), edgeTH, polarity, &p1Pts[0], &p1Pts[1], edgeDir, &resEdge, strength);
			Scalar color_res = Scalar(0, (resEdge) * 255, (1 - resEdge) * 255);
			cv::line(draw(rect_partLoc)(r), p1Pts[0], p1Pts[1], color_res,1, 8, 0);
			rectangle(draw(rect_partLoc), r, color_res, 1);

			bool resultE = (resEdge == 1);
			resultArray[1] = resultE;

		}

		cout << "Result Arr 1 " << resultArray[0] << "Result Arr 2 " << resultArray[1] << endl;

		//modelData.set_results(resultList);
		for (size_t i = 0; i < sizeof(resultArray); i++)
		{
			if (resultArray[i] == true)
			{
				modelData.set_result(true);
			}
			else
			{
				modelData.set_result(false);
				break;
			}
		}


		resize(draw, imageIn, imageIn.size());
		json j = modelData;
		std::string s = j.dump();
		return gcnew System::String(s.c_str());
		/*imshow("regions ", imageIn);
		waitKey(10);*/
	}
	catch (const std::exception& ex)
	{
		cout << ex.what() << endl;
	}

	
	//std::cout << std::endl;
	//std::cout << std::endl;	
	//source_image_mat = _Utils_obj.BitmapToMat(sourceImage_bitmap);
	//cout << "input image channels print :" << source_image_mat.channels() << endl;
	
}//ProcessImage

bool  AlgoCpp::SalcomCpp::TestFunc() {
	
	return true;
}




System::String^ __clrcall AlgoCpp::SalcomCpp::load_template(System::String^ json_model_data, int camCode)
{

	try
	{
		if (camCode == 0)
		{
			mainTempl1.clear();
			toolTemplateC1.clear();
		}
		else
		{
			mainTempl2.clear();
			toolTemplateC2.clear();
		}
		
		//toolTemplateC1.clear();
		cout << "vectors cleared" << endl;
		using System::Runtime::InteropServices::Marshal;
		System::IntPtr pointer_for_model_name = Marshal::StringToHGlobalAnsi(json_model_data);
		char* charPointer_json = reinterpret_cast<char*> (pointer_for_model_name.ToPointer());
		std::string json_model_data_std_string(charPointer_json, json_model_data->Length);
		//cout << json_model_data_std_string << endl;
		ModelData::ModelDataClass modelData = json::parse(json_model_data_std_string);

		//using System::Runtime::InteropServices::Marshal;
		//System::IntPtr pointer_for_model_name = Marshal::StringToHGlobalAnsi(json_model_data);
		//char* charPointer_json = reinterpret_cast<char*> (pointer_for_model_name.ToPointer());
		//std::string json_model_data_std_string(charPointer_json, json_model_data->Length);
		//try
		//{
		//	ModelData::ModelDataClass modelData = json::parse(json_model_data_std_string);
		//}
		//catch (std::exception& ex)
		//{
		//	std::cout << "	 ex.what(); " << ex.what() << std::endl;
		//}
		cout << "main template path :" << modelData.get_template_image_path() << endl;
		string mtPath = modelData.get_template_image_path();
		std::replace(mtPath.begin(),mtPath.end(), '\\', '/');
		cout << "main template path ed :" << mtPath << endl;
		//mtPath = "C:/Users/nikunj/Desktop/SalcompAcPinNew/salcomp_project_v2/ChargerVivo/SalcompTwoCam/Models/Shahbaz/Template12_04_2022_15_52_20.bmp";
		Mat templ = imread(mtPath,0);
		if (camCode == 0)
			mainTempl1.push_back(templ);
		else
			mainTempl2.push_back(templ);

		/*imshow(" main templ", templ);
		waitKey(10);*/
		int idx = 0;
		for each (ModelData::CheckTemplate var in modelData.get_check_template())
		{

			//rectangle(draw,)

			string path = var.get_temp_region().get_template_image_path();
			std::replace(path.begin(), path.end(), '\\', '/');
			cout << "tool template path :" << path << endl;
			Mat templTool = imread(path, 0);
			if (camCode == 0)
			{
				toolTemplateC1.push_back(templTool);
			}
			else
			{
				toolTemplateC2.push_back(templTool);
			}
				//imshow(to_string(idx), templTool);
			idx++;
			//waitKey(10);
		}

		//cout << "template tool cnt :" << toolTemplateC1.size() << endl;
		cout << "Vector1 Size " << mainTempl1.size() << endl;
		cout << "Vector2 Size " << mainTempl2.size() << endl;
		cout << "VectorTool1 Size " << toolTemplateC1.size() << endl;
		cout << "VectorTool2 Size " << toolTemplateC2.size() << endl;
	}
	catch (const std::exception& ex)
	{
		cout << ex.what() << endl;
	}

	//std::cout << std::endl;
	//std::cout << std::endl;
	//_vector_template.clear();
	////modelData.clear();
	//_rectangle_points_vect.clear();
	
	return "";

}//ProcessImage
cv::Mat BitmapToMatAgain(System::Drawing::Bitmap^ bitmap)
{
	System::Drawing::Rectangle blank = System::Drawing::Rectangle(0, 0, bitmap->Width, bitmap->Height);
	System::Drawing::Imaging::BitmapData^ bmpdata = bitmap->LockBits(blank, System::Drawing::Imaging::ImageLockMode::ReadWrite, bitmap->PixelFormat);
	if (bitmap->PixelFormat == System::Drawing::Imaging::PixelFormat::Format8bppIndexed) {
		//tmp = cvCreateImage(cvSize(bitmap->Width, bitmap->Height), IPL_DEPTH_8U, 1);
		//tmp->imageData = (char*)bmData->Scan0.ToPointer();
		cv::Mat thisimage(cv::Size(bitmap->Width, bitmap->Height), CV_8UC1, bmpdata->Scan0.ToPointer(), cv::Mat::AUTO_STEP);
		bitmap->UnlockBits(bmpdata);
		return thisimage;
	}
	else if (bitmap->PixelFormat == System::Drawing::Imaging::PixelFormat::Format24bppRgb) {
		cv::Mat thisimage(cv::Size(bitmap->Width, bitmap->Height), CV_8UC3, bmpdata->Scan0.ToPointer(), cv::Mat::AUTO_STEP);
		bitmap->UnlockBits(bmpdata);
		return thisimage;
	}
	cv::Mat returnMat = (cv::Mat::zeros(640, 480, CV_8UC1));
	//   bitmap->UnlockBits(bmData);
	return returnMat;
}//cv::Mat CommonAlo::BitmapToMat(System::Drawing::Bitmap^ bitmap)

System::String^ __clrcall AlgoCpp::SalcomCpp::TestAlgo_On_image(System::Drawing::Bitmap^ sourceImage_bitmap, System::String^ json_model_data, System::String^ tools_name)
{
	std::cout << std::endl;
	std::cout << std::endl;
//	std::cout << "***************** TestAlgo_On_image  output from c++ ************* " << std::endl;
	using System::Runtime::InteropServices::Marshal;
	System::IntPtr pointer_for_model_name = Marshal::StringToHGlobalAnsi(json_model_data);
	char* charPointer_json = reinterpret_cast<char*> (pointer_for_model_name.ToPointer());
	std::string json_model_data_std_string(charPointer_json, json_model_data->Length);
	std::cout << std::endl;
	
	using System::Runtime::InteropServices::Marshal;
	System::IntPtr pointer_for_tools_name = Marshal::StringToHGlobalAnsi(tools_name);
	char* charPointer_toolsname = reinterpret_cast<char*> (pointer_for_tools_name.ToPointer());
	std::string tools_name_std_string(charPointer_toolsname, tools_name->Length);
	//std::cout << "json_model_data     " << json_model_data_std_string << std::endl;
	//std::cout << "tools_name   " << tools_name_std_string << std::endl;
	//std::cout << "imagestring length    " << sourceImage_string_std_string.length() << std::endl;
	json _Json_Data;
	try
	{
		_Json_Data = json::parse(json_model_data_std_string);
	}
	catch (std::exception& ex)
	{
		std::cout << "	 ex.what(); " << ex.what() << std::endl;
	}

	cv::Mat  source_image = BitmapToMatAgain(sourceImage_bitmap);
	
	if ("CheckTemp" == tools_name_std_string)
	{
		//log(" >>>>>>>>>>   :  CheckClean");
		ModelData::CheckTemplate checkTemp = _Json_Data;
		json j = _TestAlgo_obj.CheckTemp(source_image, checkTemp);;
		std::string s = j.dump();
		return gcnew System::String(s.c_str());
	}
	if ("CheckEdge" == tools_name_std_string)
	{
		//log(" >>>>>>>>>>   :  CheckClean");
		ModelData::CheckCheckEdge checkEdge = _Json_Data;
		json j = _TestAlgo_obj.CheckEdge(source_image, checkEdge);;
		std::string s = j.dump();
		return gcnew System::String(s.c_str());
	}
	if ("Exception" == tools_name_std_string)
	{
		log(" >>>>>>>>>>   :  Exception");
	}
	//_Utils_obj.show_resize_image("test image  image  ", source_image);
	//waitKey(0);
	//cv::putText(source_image_mat, //target image
	//	_Utils_obj.get_cuurent_time(), //text
	//	cv::Point(1, 1), //top-left position
	//	cv::FONT_HERSHEY_DUPLEX,
	//	1.0,
	//	CV_RGB(255, 0, 0), //font color
	//	1);
	//std::cout << "***************** TestAlgo_On_image  output from c++   End  ************* " << std::endl;
	return gcnew System::String("Hello  ");
}//ProcessImage
