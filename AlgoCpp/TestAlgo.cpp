#include "pch.h"
#include "TestAlgo.h"
#include <filesystem>
#ifndef DEBUG 
#define DEBUG 1 // set debug mode
#endif
#include "Utils.h"
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
using namespace System;
using namespace cv;
namespace cv {
	namespace cuda {
		class Stream::Impl {};
	}
}
namespace cv {
	namespace cuda {
		class Event::Impl {};
	}
}

Utils _Utils_obj2;
cv::Mat    _return_image;

#pragma endregion Template_match_second


ModelData::CheckCheckEdge  TestAlgo::CheckEdge(cv::Mat source_image, ModelData::CheckCheckEdge  checkEdge) {

	Mat imageIn =source_image;
	Mat draw;
	Mat gray;
	cout << "checkEdge func" << endl;
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

		Rect r;
		r.x = checkEdge.get_edge_region().get_point_x();
		r.y = checkEdge.get_edge_region().get_point_y();
		r.height = checkEdge.get_edge_region().get_image_height();
		r.width = checkEdge.get_edge_region().get_image_width();
	//	rectangle(draw, r, Scalar(255, 0, 0), 2);

		int edgeTH = checkEdge.get_threshold();//th 2-230 //default = 40
		int edgeDir = checkEdge.get_direction();//pose 0 or 1
		int polarity = checkEdge.get_polarity(); // transition //0 = dark --> light 1= light --> dark 2 = both  
		float strength = 0.6;//checkEdge.get_strength();// 0.6;// val 0.6  //strength 0 to 1 float
		cout << "edge strength ::" << strength << endl;
		vector <Point> p1Pts = { Point(0,0),Point(0,0) };
		int resEdge = 0;
		Mat pinImgL = _Utils_obj2.checkChargerPins(gray(r), "left" + to_string(r.x), edgeTH, polarity, &p1Pts[0], &p1Pts[1], edgeDir, &resEdge, strength);
		Scalar color_res = Scalar(0, (resEdge) * 255, (1 - resEdge) * 255);
		cv::line(draw(r), p1Pts[0], p1Pts[1], color_res, 1, 8, 0);
		rectangle(draw, r, color_res, 1);

		bool resultE = (resEdge == 1);

		/*imshow("regions ", draw);
		waitKey(10);*/
		resize(draw, imageIn, imageIn.size());
	}
	catch (const std::exception& ex)
	{
		cout << ex.what() << endl;
	}

	return checkEdge;
}
ModelData::CheckTemplate  TestAlgo::CheckTemp(cv::Mat source_image, ModelData::CheckTemplate  checkTemp) {

	Mat imageIn = source_image;
	Mat draw;
	Mat gray;
	cout << "checkTemp func" << endl;

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

		Rect r;
		r.x = checkTemp.get_temp_region().get_point_x();
		r.y = checkTemp.get_temp_region().get_point_y();
		r.height = checkTemp.get_temp_region().get_image_height();
		r.width = checkTemp.get_temp_region().get_image_width();
		//rectangle(draw(imageIn), r, Scalar(255, 0, 0), 2);

		//rectangle(draw(region),r, Scalar(0, 120,120), 2);
		int matchTh = checkTemp.get_temp_threshold(); //85   //0-100
		double scoreL = 0; //output return value of match score % 0 -100
		int shiftTolX = 10; // input par //0-120
		int shiftTolY = 10;// input par  //0-120

		string path = checkTemp.get_temp_region().get_template_image_path();
		std::replace(path.begin(), path.end(), '\\', '/');
		cout << "tool template path :" << path << endl;
		Mat templTool = imread(path, 0);
		cout << "image read" << endl;
		//imshow("template test ", templTool);
		Rect locL = Rect(0, 0, 10, 10);
		bool resultL = _Utils_obj2.toolTempMatch_withScore(gray, templTool, r, matchTh, Point(shiftTolX, shiftTolY), &scoreL, &locL);
		cout << "calledTempMatch" << endl;
		Scalar color_res = Scalar(0, ((int)resultL) * 255, ((int)(!resultL)) * 255);
		rectangle(draw, locL, color_res, 2);
		cout << "match score L " << scoreL << endl;
		putText(draw, cv::format("%3.2f", scoreL), Point(locL.x,locL.y), FONT_HERSHEY_COMPLEX, 1, color_res, 2);

		checkTemp.set_match_score(scoreL);

		/*imshow("regions ", draw);
		waitKey(10);*/
		resize(draw, imageIn, imageIn.size());
	}
	catch (const std::exception& ex)
	{
		cout << ex.what() << endl;
	}

	return checkTemp;
}


///////////  print check 

float angle_1(Point pt1s, Point pt1e, Point pt2s, Point pt2e) {

	if (pt2e.x == pt2s.x) {
		return 90;
	}
	float m1 = (pt1e.y - pt1s.y) / (pt1e.x - pt1s.x);
	float m2 = (pt2e.y - pt2s.y) / (pt2e.x - pt2s.x);
	float angle = abs((m2 - m1) / (1 + (m2 * m1)));

	return atan(angle) * (180.0 / 3.14);

}
float distance_Point_1(Point p1, Point p2) {
	return sqrtf(pow((p1.x - p2.x), 2) + pow((p1.y - p2.y), 2));
}

Mat checkChargerPins(Mat image, cv::String pinName, int edgeTh, int edgeDir, Point* p1, Point* p2)
{
	Mat colorImg;
	cvtColor(image, colorImg, COLOR_GRAY2BGR);
	//imshow(pinName, image);

	vector<Point> edgePts;
	float avgY = 0;
	float avgLeft = 0;
	float sizeL = 0;
	*p1 = Point(0, 0);
	*p2 = Point(0, 0);
	//int th =30;
	//vector <Point> edgePts;
	for (int i = 0; i < image.rows; i++)
	{
		for (int j = 5; j < image.cols - 5; j++)
			//for (int j = image.cols - 5; j > 5; j--)
		{
			float sumL = 0;
			float  sumU = 0;
			int pixVal = 0;
			for (int p = j - 5; p < j + 5; p++)
			{
				pixVal = image.at<uchar>(i, p);
				if (p < j)
					sumL += pixVal;
				else
					sumU += pixVal;
			}
			sumL = sumL / 5.0;
			sumU = sumU / 5.0;
			int diff = 0;
			if (edgeDir == 0)
				diff = sumU - sumL;
			else if (edgeDir == 1)
				diff = sumL - sumU;
			else
				diff = abs(sumL - sumU);

			if (diff > edgeTh)
			{
				circle(colorImg, Point(j, i), 1, Scalar(0, 255, 255), -1);
				edgePts.push_back(Point(j, i));
				break;
			}
		}
	}
	if (edgePts.size() > 2)
	{
		cv::Vec4f line_para;
		cv::fitLine(edgePts, line_para, cv::DIST_L2, 0, 1e-2, 1e-2);
		cv::Point point0;
		point0.x = line_para[2];
		point0.y = line_para[3];

		double k = line_para[1] / line_para[0];

		//Calculate end of line(y = k(x - x0) + y0)
		cv::Point point1, point2;
		//point1.x = 0;
		//point1.y = k * (0 - point0.x) + point0.y;
		//point2.x = 200; 
		//point2.y = k * (200 - point0.x) + point0.y;
		point1.y = 1;
		point1.x = point0.x + ((float)(1 - point0.y) / k);
		point2.y = image.rows;
		point2.x = point0.x + ((float)((image.rows - point0.y)) / k);
		circle(colorImg, point1, 3, Scalar(0, 0, 255), -1);
		circle(colorImg, point2, 3, Scalar(0, 0, 255), -1);
		//cv::line(colorImg, point1, point2, cv::Scalar(0, 255, 0), 2, 8, 0);
		*p1 = point1;
		*p2 = point2;

	}
	//imshow(pinName, colorImg);
	return colorImg;
}

cv::Mat TestAlgo::Exception(cv::Mat roi, cv::Mat temp, cv::Rect r1, int rotaion_degree)
{
	return cv::Mat();
}




void show_resize_image_testalgo(std::string string_name, cv::Mat img)
{

	cv::Mat dst;

	if (img.rows > 400 && img.cols > 400)
	{
		cv::resize(img, dst, cv::Size(400, 400));
	}
	else
	{
		cv::resize(img, dst, img.size());
	}

	cv::imshow(string_name, dst);

}//void show_resize_image(std::string string_name, cv::Mat img)




cv::Mat TestAlgo::GetImage()
{
	//show_resize_image_testalgo("_return_image image  ", _return_image);
	log("       --  >>>>>>>  ");

	return _return_image;
}




