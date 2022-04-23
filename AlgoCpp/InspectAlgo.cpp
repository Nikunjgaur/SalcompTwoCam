#include "pch.h"
#include "InspectAlgo.h"
#include <filesystem>
#ifndef DEBUG 
#define DEBUG 1 // set debug mode
#endif
#include "Utils.h"
#include "CheckTextMatch.h"
#include "CheckPins.h"
#include "AlgoCpp.h"
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
//namespace cv {
//	namespace cuda {
//		class Stream::Impl {};
//	}
//}

Utils  _Utils;
InspectAlgo _InspectAlgo;
//source_image   camera captured image 
//temp   bigger template 
#pragma region  Template_match_first

double match_percent;

double minVal_T;
double maxVal_T;
Point minLoc_T;
Point maxLoc_T;
Mat temp_g;
Mat img_g;
Point matchLoc;
int match_method = TM_CCORR_NORMED;// TM_CCOEFF_NORMED;
cv::Mat  result_img;
Mat prnt_crp;

float distanceBtwnPoints(Point2f p, Point2f q)
{
	Point2f diff = p - q;
	return cv::sqrt(diff.x * diff.x + diff.y * diff.y);
}

//cv::Mat InspectAlgo::Template_match_first(cv::Mat source_image, cv::Mat temp,Mat mask, cv::Rect &_rect, int rotaion_degree)
//{
//	//log(" >>>>>>>>>>   : ");
//	//_Utils.show_resize_image("source_image  in Template_match_first  ", source_image);
//	//_Utils.show_resize_image("template image in Template_match_first ", temp);
//	
//	//int match_method;
//
//
//	//log(" >>>>>>>>>>   : ");
//
//	if (source_image.channels() > 2) 
//	{
//		cvtColor(source_image, img_g, COLOR_BGR2GRAY);
//	}
//	else 
//	{
//		img_g = source_image.clone();
//	}
//	//Mat img_g_th;
//	//   threshold(img_g, img_g_th, threshld, 255, THRESH_BINARY);
//	if (temp.channels() > 2) 
//	{
//		cvtColor(temp, temp_g, COLOR_BGR2GRAY);
//	}
//	else 
//	{
//		temp_g = temp.clone();
//	}
//	//Mat temp_g_th;
//	//Point matchLoc;
//	//match_method = TM_CCOEFF_NORMED;
//	//cv::Mat  result_img;
//	//cout << "match temp called" << endl;
//	matchTemplate(img_g, temp_g, result_img, match_method, mask);
//	//cout << "returned from templ" << endl;
//	//  match_method==3;
//
//	minMaxLoc(result_img, &minVal_T, &maxVal_T, &minLoc_T, &maxLoc_T, Mat());
//	Rect r1 = Rect(maxLoc_T, Point(maxLoc_T.x + temp.cols, maxLoc_T.y + temp.rows));
//	 prnt_crp = source_image(r1);
//	
//	//log(" >>>>>>>>>>   : ");
//	//_Utils.image_details("Template_match_first  source  image details :  ", source_image);
//	//_Utils.image_details("Template_match_first  template  image details  ", temp);
//	//_Utils.image_details("Template_match_first  Template_match_first_result   image details ", prnt_crp);
//
//	//log(" >>>>>>>>>>   : ");
//	_rect = r1;
//	//cout << "rect r1::" << r1.x << "  " << r1.y << endl;
//
//	return prnt_crp;
//}//Template_match_first

Mat rz;
cv::Point minLoc;
Mat big_sizee_roi;
Mat big_sizee_roi_gray;
//cv::Mat InspectAlgo::Template_match_second(cv::Mat source_image, cv::Mat temp, cv::Rect &_rect, int rotaion_degree)
//{
//	//_Utils.show_resize_image("source_image  in Template_match_second  ", source_image);
//	//_Utils.show_resize_image("template image in Template_match_second ", temp);
//	//waitKey(0);
//
//
//	//big_sizee_roi = Mat::zeros(Size(source_image.cols + 1000, source_image.rows + 1000), CV_8UC3);
//	//source_image.copyTo(big_sizee_roi(Rect(500, 500, source_image.cols, source_image.rows)));
//	big_sizee_roi = Mat::zeros(Size(source_image.cols , source_image.rows ), CV_8UC3);
//	source_image.copyTo(big_sizee_roi(Rect(0,0, source_image.cols, source_image.rows)));
//	//resize(big_sizee_roi, rz, Size(), 0.3, 0.3);
//	//imshow("big_sizee_roi", rz);
//	if (big_sizee_roi.channels() > 2) 
//	{
//		cvtColor(big_sizee_roi, big_sizee_roi_gray, COLOR_BGR2GRAY);
//	}
//	else 
//	{
//		big_sizee_roi_gray = big_sizee_roi.clone();
//	}
//	Mat ImgToBeRotated = source_image.clone();
//
//	Mat temp_new = temp(Rect(0, 0, temp.cols / 2, temp.rows / 2));
//
//	Mat temp_new_gray;
//	if (temp_new.channels())
//	{
//		cvtColor(temp, temp_new_gray, COLOR_BGR2GRAY);
//	}
//	else
//	{
//		temp_new_gray = temp_new.clone();
//	}
//
//
//
//
//	/*Mat temp_gray;
//	if (temp.channels()) 
//	{
//		cvtColor(temp, temp_gray, COLOR_BGR2GRAY);
//	}
//	else 
//	{
//		temp_gray = temp.clone();
//	}*/
//
//	Mat roi2;
//	int rotationAngles = rotaion_degree;
//	resize(big_sizee_roi_gray, roi2, cv::Size(big_sizee_roi_gray.cols / 4, big_sizee_roi_gray.rows / 4));
//	Mat temp_roi2;
//	resize(temp_new_gray, temp_roi2, cv::Size(temp.cols / 4, temp.rows / 4));
//	cv::Point2f center1(temp_roi2.cols / 2.0, temp_roi2.rows / 2.0);
//	cv::Size a1 = cv::Size(temp_roi2.cols, temp_roi2.rows);
//	std::vector<double> Minvalues(360);
//	Mat roi_rot;
//	int result_cols = roi2.cols - temp_roi2.cols + 1;
//	int result_rows = roi2.rows - temp_roi2.rows + 1;
//	Mat dstImage;
//	dstImage.create(result_rows, result_cols, CV_8UC3);
//	int match_method = 0; //0-4
//	double matchTemp;
//	double minVal = 1000000000000;
//	double maxVal = 0;
//	double maxValBest = 2;
//	double angleBest = 0;
//	double minValBest = 1000000000000;
//	cv::Point maxLoc;
//	double angleInc = 0;
//	float indexer;
//
//	for (int i = -1 * 2 * rotationAngles; i < 2 * rotationAngles; i++) 
//	{
//		indexer = i;
//		if (i == 0)
//			angleInc = 0;
//		else {
//			angleInc = indexer;
//		}
//	
//		Mat rot_mat = getRotationMatrix2D(center1, double(angleInc), 1.0);
//		cv::Rect bbox = cv::RotatedRect(cv::Point2f(), temp_roi2.size(), double(angleInc)).boundingRect();
//		// adjust transformation matrix
//		rot_mat.at<double>(0, 2) += bbox.width / 2.0 - temp_roi2.cols / 2.0;
//		rot_mat.at<double>(1, 2) += bbox.height / 2.0 - temp_roi2.rows / 2.0;
//		// warpAffine(edgeImage2, edgeImage2_rot, rot_mat, a, 1);
//		//warpAffine(roi2, roi_rot, rot_mat, a1, 1);
//		Mat templRot;
//		warpAffine(temp_roi2, templRot, rot_mat, bbox.size());
//		//draw mask----------------
//		Mat mask = Mat::zeros(templRot.size(), CV_8UC1);
//		cv::RotatedRect rotatedRectangle(cv::Point2f(templRot.cols / 2, templRot.rows / 2), temp_roi2.size(), double(180 - angleInc));
//		cv::Point2f vertices2f[4];
//		rotatedRectangle.points(vertices2f);
//		cv::Point vertices[4];
//		for (int i = 0; i < 4; ++i) 
//		{
//			vertices[i] = vertices2f[i];
//		}
//		cv::fillConvexPoly(mask, vertices, 4, Scalar(255, 255, 255));
//		cv::Point matchLoc;
//		matchTemplate(roi2, templRot, dstImage, match_method, mask);
//		minMaxLoc(dstImage, &minVal, &maxVal, &minLoc, &maxLoc, Mat());
//		if (minVal < minValBest) 
//		{
//			minValBest = minVal;
//			angleBest = angleInc;
//		}
//	}
//
//	double min_temp_value = minValBest;
//	double angle = -1 * angleBest;
//	cv::Point2f center2(source_image.cols / 2.0, source_image.rows / 2.0);
//	cv::Size a2 = cv::Size(source_image.cols, source_image.rows);
//	cv::Size a3 = cv::Size(ImgToBeRotated.cols, ImgToBeRotated.rows);
//	Mat rot_mat = getRotationMatrix2D(center2, angle, 1.0);
//
//	cv::Rect2f bbox = cv::RotatedRect(cv::Point2f(), source_image.size(), angle).boundingRect();
//	// adjust transformation matrix
//
//	rot_mat.at<double>(0, 2) += bbox.width / 2.0 - source_image.cols / 2.0;
//
//	rot_mat.at<double>(1, 2) += bbox.height / 2.0 - source_image.rows / 2.0;
//
//	warpAffine(source_image, roi_rot, rot_mat, a2, 1);
//	Mat returnImage;
//
//	warpAffine(ImgToBeRotated, returnImage, rot_mat, bbox.size());
//
//	Mat dstImage_new;
//
//	matchTemplate(roi_rot, temp, dstImage_new, match_method);
//
//	minMaxLoc(dstImage_new, &minVal, &maxVal, &minLoc, &maxLoc, Mat());
//	Rect r2 = Rect(minLoc, Point(minLoc.x + temp.cols, minLoc.y + temp.rows));
//	Mat prnt_crpxx = returnImage(r2);
//	_rect = r2;
//	//cout << " Template_match_second  from _rect_smaller ::  " << _rect << endl;
//	return prnt_crpxx;
//}//Template_match_second









void resShow_1(string name, Mat img, float scale)
{
	Mat res;
	//scale = 0.2;
	resize(img, res, Size(), scale, scale);
	imshow(name, res);
	waitKey(5);
}

inline float distance_Point(Point p1, Point p2) {
	return sqrtf(pow((p1.x - p2.x), 2) + pow((p1.y - p2.y), 2));
}

inline float angle(Point pt1s, Point pt1e, Point pt2s, Point pt2e) {

	if (pt2e.x == pt2s.x) {
		return 90;
	}
	float m1 = (pt1e.y - pt1s.y) / (pt1e.x - pt1s.x);
	float m2 = (pt2e.y - pt2s.y) / (pt2e.x - pt2s.x);
	float angle = abs((m2 - m1) / (1 + (m2 * m1)));

	return atan(angle) * (180.0 / 3.14);

}







bool InspectAlgo::load_template( CheckTextMatch_namespace::CheckTextMatch _CheckTextMatch_Object,int i)
{
	bool    ok_ng_flag = false;
	
	int64_t point_a_x = _CheckTextMatch_Object.get_point_a_x();
	int64_t point_a_y = _CheckTextMatch_Object.get_point_a_y();
	int64_t point_b_x = _CheckTextMatch_Object.get_point_b_x();
	int64_t point_b_y = _CheckTextMatch_Object.get_point_b_y();
	std::string template_image_path = _CheckTextMatch_Object.get_template_image_path();
	
	bool rsult_chck = true;
	//std::cout << "template_image_path -----        " << template_image_path << std::endl;
	Rect _Rect = Rect(point_a_x, point_a_y, point_b_x, point_b_y);
	cv::Mat template_image;
	if (!std::filesystem::exists(template_image_path))
	{
		std::cout << "***************** template_image_path  file not found ." << std::endl;
	}
	else
	{
		template_image = cv::imread(template_image_path);
	}
	cout << "template read done" << endl;
	return ok_ng_flag;
}//CheckTextMatch_template





Mat img;
Mat inimg_gray;
Mat img1;
Mat model_print_return_img;
Mat inimg_thrs;
Mat model_print_return_img_gray;
vector<vector<Point> > contours_text;
vector<Vec4i> hierarchy_text;



Mat roi2;
int rotationAngles = 1;
int scaleFactor = 2;
Mat temp_roi2;

cv::Point2f  vertices2fI[4], vert2fMod[4], vert2fModRestore[4];
Mat getMatchRegionFromImage(Mat roi, Mat temp, cv::Point* matchCoord, Utils::modelTemplVars modelData, Rect* BoxDims, int chargerColor)
{
	int match_method = 0; //0-4

	resize(roi, roi2, cv::Size(roi.cols / scaleFactor, roi.rows / scaleFactor));

	resize(temp, temp_roi2, cv::Size(temp.cols / scaleFactor, temp.rows / scaleFactor));

	// imshow("template",temp_roi2);
	//cv::Point2f center1(roi2.cols / 2.0, roi2.rows / 2.0);
	cv::Point2f center1(temp_roi2.cols / 2.0, temp_roi2.rows / 2.0);
	cv::Size a1 = cv::Size(temp_roi2.cols, temp_roi2.rows);
	Mat roi_rot;
	int result_cols = roi2.cols - temp_roi2.cols + 1;
	int result_rows = roi2.rows - temp_roi2.rows + 1;
	Mat dstImage;
	dstImage.create(result_rows, result_cols, CV_32FC1);

	double minVal = 1;
	double angleBest = 0;
	double minValBest = 1;
	double maxVal;  cv::Point minLoc; cv::Point maxLoc;

	Point matchLocBest = Point(0, 0);


	matchTemplate(roi2, temp_roi2, dstImage, match_method);
	minMaxLoc(dstImage, &minValBest, &maxVal, &minLoc, &maxLoc, Mat());

	matchLocBest = Point(minLoc.x + temp_roi2.cols / 2, minLoc.y + temp_roi2.rows / 2);

	//*angleRet = angleBest;
	cv::Point2f center2 = matchLocBest * scaleFactor;// (roi.cols / 2.0, roi.rows / 2.0);
	roi_rot = roi.clone();
	//Rect restR = Rect(center2.x - 1.1 * (temp.cols / 2), center2.y - 1.2 * (temp.rows / 2), 1.1 * temp.cols, 1.2 * temp.rows);
	Rect restR;
	if (((center2.x - 1.2 * (temp.cols / 2) )> 0) && ((center2.y - 1.4 * (temp.rows / 2)) > 0) && (((center2.x - 1.2 * (temp.cols / 2)) + 1.2 * temp.cols) < roi_rot.cols) && (((center2.y - 1.4 * (temp.rows / 2)) + 1.4 * temp.rows) < roi_rot.rows))
		restR = Rect(center2.x - 1.2 * (temp.cols / 2), center2.y - 1.4 * (temp.rows / 2), 1.2 * temp.cols, 1.4 * temp.rows);
	else
	{
		restR = Rect(0, 0, roi_rot.cols, roi_rot.rows);
	}
	//Rect restR = Rect(center2.x - (temp.cols / 2), center2.y - (temp.rows / 2), temp.cols, temp.rows);
	Mat restROIB = roi_rot(restR);

	matchTemplate(restROIB, temp, dstImage, match_method);
	minMaxLoc(dstImage, &minVal, &maxVal, &minLoc, &maxLoc, Mat());
	Point tmpCoordInt = Point(minLoc.x + restR.x, minLoc.y + restR.y);
	Rect restR2 = Rect(tmpCoordInt.x, tmpCoordInt.y, temp.cols, temp.rows);
	Mat restROI = roi_rot(restR2);
	*matchCoord = Point(restR2.x, restR2.y);
	//cout << "restROI::" << restR2 << endl;
	//imshow("restROI", restROI);

	//----------------

	//vector<vector<Point>> contTempl;
	//contTempl = getContourVec(temp, "templ");
	//cv::Point2f vertices2fT[4], vertices2fI[4], vert2fMod[4];


	//RotatedRect rrr = minAreaRect(contTempl[0]);
	//if (abs(rrr.size.width - rrr.size.height) < 0.1 * (rrr.size.width))
	//{
	//	Rect br = boundingRect(contTempl[0]);
	//	vertices2fT[0] = Point(br.x, br.y);
	//	vertices2fT[1] = Point(br.x + br.width, br.y);
	//	vertices2fT[2] = Point(br.x, br.y + br.height);
	//	vertices2fT[3] = Point(br.x + br.width, br.y + br.height);
	//}
	//else
	//{
	//	rrr.points(vertices2fT);
	//	gerOrderedVertices(vertices2fT, rrr.center);
	//}
	/*float templAngle = atan2(vertices2fT[0].y - vertices2fT[1].y, vertices2fT[0].x - vertices2fT[1].x);*/

	//cv::Point verticesT[4], verticesI[4];
	//Mat colorTmp;
	//cvtColor(temp, colorTmp, COLOR_GRAY2BGR);
	//for (int i = 0; i < 4; ++i) {
	//	verticesT[i] = vertices2fT[i];
	//}
	//for (int i = 0; i < 4; ++i) {
	//	
	//	line(colorTmp, verticesT[i], verticesT[(i + 1) % 4], Scalar(0, 255, 0), 1);
	//}
	//drawContours(colorTmp, contTempl, 0, Scalar(255, 0, 0), 1);
	//imshow("combinedCont", colorTmp);
	/*cv::Point2f  vertices2fI[4], vert2fMod[4];*/
	//Mat colorImg;
	//cvtColor(restROI, colorImg, COLOR_GRAY2BGR);
	int shape = -1;
	vector<vector<Point>> contRoi;
	contRoi = _Utils.getContourVecExt(restROI, "roi",&shape ,chargerColor);


	if (shape==-1)
	{
		vertices2fI[0] = Point(0,0);
		vertices2fI[1] = Point(restROI.cols,0);
		vertices2fI[2] = Point(0, restROI.rows);
		vertices2fI[3] = Point(restROI.cols, restROI.rows);
		*BoxDims = Rect(0,0,100,100);
		return restROI;
	}

	RotatedRect rrr = minAreaRect(contRoi[0]);
	if (shape==0)  //circular shape
	{
		Rect br = boundingRect(contRoi[0]);
		vertices2fI[0] = Point(br.x, br.y);
		vertices2fI[1] = Point(br.x + br.width, br.y);
		vertices2fI[2] = Point(br.x, br.y + br.height);
		vertices2fI[3] = Point(br.x + br.width, br.y + br.height);
	}
	else
	{
		rrr.points(vertices2fI);
		_Utils.gerOrderedVertices(vertices2fI, rrr.center);
	}
	float fontHeight = distanceBtwnPoints(vertices2fI[0], vertices2fI[2]);
	float fontWidth = distanceBtwnPoints(vertices2fI[0], vertices2fI[1]);
	*BoxDims = Rect(restR2.x, restR2.y, fontWidth, fontHeight);
	//float StdfontHeight = distanceBtwnPoints(modelData.vertices2fT[0], modelData.vertices2fT[2]);
	//float StdfontWidth = distanceBtwnPoints(modelData.vertices2fT[0], modelData.vertices2fT[1]);

	//cout << "stdWidth ::" << modelData.fontWidth << "  actual width::" << fontWidth << "  tolerance::"<< endl;
	//cout << "stdHeight ::" << modelData.fontHeight << " actual height::" << fontHeight << endl;
	float imageAngle = atan2(vertices2fI[0].y - vertices2fI[1].y, vertices2fI[0].x - vertices2fI[1].x);
	//cout.precision(6);
	//	cout << "template Ang:::" << modelData[modelIdx].templateAngle << "      image Angle::" << imageAngle << "  difference::" <<modelData[modelIdx].templateAngle - imageAngle << endl;
	for (int ii = 0; ii < 4; ii++)
	{
		//verticesI[ii] = vertices2fI[ii];
		vert2fMod[ii].x = vertices2fI[ii].x + minLoc.x;
		vert2fMod[ii].y = vertices2fI[ii].y + minLoc.y;
	}
	//---------------

	//cv::RotatedRect rotatedRectangle(cv::Point2f(templRot.cols / 2, templRot.rows / 2), temp_roi2.size(), double(180 - angleInc));

	//// We take the edges that OpenCV calculated for us
	//cv::Point2f vertices2f[4];
	//rotatedRectangle.points(vertices2f);


	//Mat transMat = getPerspectiveTransform(vert2fMod, pointsArr);
	////	warpPerspective(imIn, dst, transMat, Size(widthIn * 2, distanceP));
	//warpPerspective(imIn, dst, transMat, Size(distanceP, widthIn * 2));
	//------------------------
	//for (int ii = 0; ii < 4; ii++)
	//{
	//	//vertices[ii] = vertices2f[ii];
	//	line(colorImg, verticesI[ii], verticesI[(ii + 1) % 4], Scalar(0, 255, 0), 1);
	//}
	//drawContours(colorImg, contRoi, 0, Scalar(255, 0, 0), 1);
	//imshow("combinedImg", colorImg);
	Mat corImg;
	Mat transMat = getPerspectiveTransform(vert2fMod, modelData.vertices2fT);
	//	warpPerspective(imIn, dst, transMat, Size(widthIn * 2, distanceP));
	warpPerspective(restROIB, corImg, transMat, temp.size());
	//imshow("corrrected", corImg);
	//waitKey();
	return corImg;
	//------------------- 

}
Mat getDefects(Mat ub, Mat lb, Mat imageCurr, Mat mask)
{
	//Mat result;
	//
	//cvtColor(imageCurr, result, COLOR_GRAY2BGR);
	//result.setTo(Scalar(0, 0, 255), imageCurr > ub);
	//result.setTo(Scalar(255, 0, 0), imageCurr <lb);
	//return result;
	mask.setTo(255, imageCurr > ub);
	mask.setTo(255, imageCurr < lb);
	return mask;

}
void Morph(const cv::Mat& src, cv::Mat& dst, int operation, int kernel_type, int size)
{
	cv::Point anchor = cv::Point(size, size);
	cv::Mat element = getStructuringElement(kernel_type, cv::Size(2 * size + 1, 2 * size + 1), anchor);
	morphologyEx(src, dst, operation, element, anchor);
}
Mat defectImg;
Mat intScaledImage;
Mat inGrey;
Mat imageP;
Mat grey, sobelm;
Mat defRet;



//// testing 


Mat img_gray;
Scalar avgColor1;
Mat comb_img;
vector<vector<Point> > contours;
vector<Vec4i> hierarchy;





