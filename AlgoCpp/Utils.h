#pragma once
#ifndef Utils_H
#define Utils_H 
#include<iostream>
#include "opencv2/opencv.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/highgui.hpp"
#include <list>
#include <time.h>
#include <string>
#include <vector>
#include <iostream>
#include <nlohmann/json.hpp>
using json = nlohmann::json;
using namespace cv;
using namespace std;
public class Utils
{


public:

	struct modelTemplVars
	{
		int width;
		int height;
		double FGmean;
		double BGmean;
		double thLinear;
		double thMult;
		cv::Mat ub;
		cv::Mat lb;
		cv::Point2f vertices2fT[4];
		float templateAngle = 0;
		float fontHeight = 0;
		float fontWidth = 0;
	};
	float distanceBtwnPointsS(Point2f p, Point2f q)
	{
		Point2f diff = p - q;
		return cv::sqrt(diff.x * diff.x + diff.y * diff.y);
	}
	Mat getSobelImg(Mat img, int kSize)
	{
		Mat grad_x, grad_y, img_sobel;
		Mat abs_grad_x, abs_grad_y;
		int ddepth = CV_16S;

		Sobel(img, grad_x, ddepth, 1, 0, kSize, 1, 0, BORDER_DEFAULT);
		Sobel(img, grad_y, ddepth, 0, 1, kSize, 1, 0, BORDER_DEFAULT);
		// converting back to CV_8U
		convertScaleAbs(grad_x, abs_grad_x);
		convertScaleAbs(grad_y, abs_grad_y);
		addWeighted(abs_grad_x, 1, abs_grad_y, 1, 0, img_sobel);
		return img_sobel;
	}
	Mat showRegionCont(Mat imageIn)
	{
		Mat contImg;
		Mat drawImg;
		if (imageIn.channels() > 1)
		{
			cvtColor(imageIn, contImg, COLOR_BGR2GRAY);
			drawImg = imageIn.clone();
		}
		else
		{
			cvtColor(imageIn, drawImg, COLOR_GRAY2BGR);
			contImg = imageIn.clone();
		}
		vector<vector<Point> > contours;
		vector<Vec4i> hierarchy;
		Mat conts;
		threshold(contImg, conts, 0, 255, THRESH_OTSU + THRESH_BINARY_INV);
		// findContours( contImg, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);
		findContours(conts, contours, hierarchy, RETR_LIST, CHAIN_APPROX_NONE);
		for (int i = 0; i < contours.size(); i++)
		{
			if (contourArea(contours[i]) > 10)
				drawContours(drawImg, contours, i, Scalar(0, 0, 255), 1);

		}
		return drawImg;
	}
	int  createVarImages(Mat baseImg, Mat boundaryImg, int ith, float xth, Mat& ub, Mat& lb)
	{
		ub = baseImg + max(ith, xth * boundaryImg);
		lb = baseImg - max(ith, xth * boundaryImg);
		return 1;
	}
	int getmeansBgFg(Mat image, float& BGmean, float& FGmean, Mat& BGimage, Mat& FGimage)
	{
		Mat imageTh;
		threshold(image, imageTh, 0, 255, THRESH_OTSU + THRESH_BINARY_INV);  //nonzero is print
		//imshow("threshold Image", imageTh);
		//waitKey(0);
		double fgPixz = countNonZero(imageTh);
		double bgPixz = (imageTh.cols * imageTh.rows) - fgPixz;

		BGimage = image.clone();
		FGimage = image.clone();
		BGimage.setTo(0, imageTh > 0);
		FGimage.setTo(0, imageTh == 0);
		BGmean = sum(BGimage)[0] / bgPixz;
		FGmean = sum(FGimage)[0] / fgPixz;
		return 1;
	}
	vector<vector<Point> >  getContourVecExt(Mat imageIn, string winName, int* shape, int baseColor)
	{

		Mat contImg = imageIn.clone();
		vector<vector<Point> > contours;
		vector<vector<Point> > contSort(1);
		vector<Vec4i> hierarchy;
		//Mat drawImg;
		//cvtColor(imageIn, drawImg, COLOR_GRAY2BGR);
		//Mat allConts = drawImg.clone();
		if(baseColor==0)
		threshold(imageIn, contImg, 0, 255, THRESH_OTSU + THRESH_BINARY_INV); //FOR WHITE
		else
		threshold(imageIn, contImg, 0, 255, THRESH_OTSU + THRESH_BINARY);//FOR BLACK CHARGER

		findContours(contImg, contours, hierarchy, RETR_EXTERNAL, CHAIN_APPROX_NONE);
		RotatedRect r;
		int biggestIdx = -1;
		double biggestAr = 0;
		bool circFlag = false;
		Rect brBig;
		for (int i = 0; i < contours.size(); i++)
		{
			r = minAreaRect(contours[i]);
			double contAr = contourArea(contours[i]);
			if (contAr > 40 && (r.center.x > 10) && (r.center.x < (contImg.cols - 10)) && (r.center.y < (contImg.rows - 10)) && (r.center.y > 10))
			{
				if (contAr > biggestAr)
				{
					biggestAr = contAr;
					biggestIdx = i;
					if ((biggestAr > 0.74 * r.size.area()) && (biggestAr < 0.85 * r.size.area()) && abs(r.size.height - r.size.width) < 0.1 * r.size.width)
					{
						circFlag = true;
					}
				}
				//drawContours(drawImg, contours, i, Scalar(0, 0, 255), 1);
				contSort[0].insert(contSort[0].end(), contours[i].begin(), contours[i].end());
			}

		}
		if (biggestIdx == -1 || contours.size() == 0)
		{
			*shape = -1;
		}
		if (biggestIdx != -1)
		{
			RotatedRect br = minAreaRect(contSort[0]);
			if ((abs(br.size.height - r.size.height) < 0.1 * r.size.height) && (abs(br.size.width - r.size.width) < 0.1 * r.size.width) && circFlag == true)
			{
				*shape = 0;
				//	putText(allConts, "Circ", Point(10, 20), CV_FONT_HERSHEY_SIMPLEX, 1, Scalar(0, 200, 0), 1);
			}
			else
			{

				*shape = 1;
				//	putText(allConts, "R", Point(10, 20), CV_FONT_HERSHEY_SIMPLEX, 1, Scalar(0, 200, 0), 1);
			}
		}
		//drawContours(allConts, contSort, -1, Scalar(0, 0, 255), 1);
		//imshow("All" + winName, allConts);
		return contSort;
	}
	vector<vector<Point> >  getContourVec(Mat imageIn, string winName)
	{
		Mat contImg = imageIn.clone();
		vector<vector<Point> > contours;
		vector<vector<Point> > contSort(1);
		vector<Vec4i> hierarchy;
		//Mat drawImg;
		threshold(imageIn, contImg, 0, 255, THRESH_OTSU + THRESH_BINARY_INV);
		//cvtColor(imageIn, drawImg, COLOR_GRAY2BGR);
		// findContours( contImg, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE);
		findContours(contImg, contours, hierarchy, RETR_LIST, CHAIN_APPROX_NONE);
		RotatedRect r;// = minAreaRect(contours);
		for (int i = 0; i < contours.size(); i++)
		{
			r = minAreaRect(contours[i]);
			if (contourArea(contours[i]) > 40 && (r.center.x > 10) && (r.center.x < (contImg.cols - 10)) && (r.center.y < (contImg.rows - 10)) && (r.center.y > 10))
			{
				//drawContours(drawImg, contours, i, Scalar(0, 0, 255), 1);
				contSort[0].insert(contSort[0].end(), contours[i].begin(), contours[i].end());
				//contSort.push_back(contours[i]);
			}

		}
		//	imshow("Contss"+winName, drawImg);
		return contSort;
	}
	int gerOrderedVertices(Point2f vertices[], Point center)
	{
		vector <Point2f> lf;
		vector<Point2f> rh;
		for (int i = 0; i < 4; i++)
		{
			if (vertices[i].x < center.x)
				lf.push_back(vertices[i]);
			else
				rh.push_back(vertices[i]);
		}
		if (lf.size() == 2 && rh.size() == 2)
		{
			if (lf[0].y < lf[1].y)
			{
				vertices[0] = lf[0];
				vertices[2] = lf[1];
			}
			else
			{
				vertices[0] = lf[1];
				vertices[2] = lf[0];
			}

			if (rh[0].y < rh[1].y)
			{
				vertices[1] = rh[0];
				vertices[3] = rh[1];
			}
			else
			{
				vertices[1] = rh[1];
				vertices[3] = rh[0];
			}
		}
		return 1;
	}
	Utils::modelTemplVars generateModelData(Mat modelTemplate,int scaleTh, float offsetTh,int ChargerColor)
	{
		Utils::modelTemplVars model;
		model.width = modelTemplate.cols;
		model.height = modelTemplate.rows;
		Mat ub = Mat::ones(modelTemplate.size(), modelTemplate.type());
		Mat lb = ub.clone();
		Mat imageGauss;
		GaussianBlur(modelTemplate, imageGauss, Size(5, 5), 1, 1, BORDER_DEFAULT);
		//GaussianBlur(imageGauss, imageGauss, Size(5, 5), 1,1, BORDER_DEFAULT);
		//imshow("gauss " + to_string(i), imageGauss);
		Mat sobelm = getSobelImg(imageGauss, 3);
		createVarImages(modelTemplate, sobelm, scaleTh, offsetTh, ub, lb);
		model.ub = ub.clone();
		model.lb = lb.clone();
		float BGmean, FGmean = 0;
		getmeansBgFg(modelTemplate, BGmean, FGmean, ub, lb);
		model.BGmean = BGmean;
		model.FGmean = FGmean;
		int shape = -1;
		vector<vector<Point>> contTempl;
		contTempl = getContourVecExt(modelTemplate, "templ",&shape, ChargerColor);

		
		cv::Point2f vertices2fT[4];
		if (shape==-1)
		{
			vertices2fT[0] = Point(0, 0);
			vertices2fT[1] = Point(modelTemplate.cols, 0);
			vertices2fT[2] = Point(0, modelTemplate.rows);
			vertices2fT[3] = Point(modelTemplate.cols, modelTemplate.rows);
			for (int i = 0; i < 4; i++)
			{
				model.vertices2fT[i] = vertices2fT[i];
			}
			float templAngle = atan2(vertices2fT[0].y - vertices2fT[1].y, vertices2fT[0].x - vertices2fT[1].x);
			model.templateAngle = templAngle;
			return model;
			
		}


		RotatedRect rrr = minAreaRect(contTempl[0]);
		if (shape==0)
		{
			Rect br = boundingRect(contTempl[0]);
			vertices2fT[0] = Point(br.x, br.y);
			vertices2fT[1] = Point(br.x + br.width, br.y);
			vertices2fT[2] = Point(br.x, br.y + br.height);
			vertices2fT[3] = Point(br.x + br.width, br.y + br.height);
		}
		else
		{
			rrr.points(vertices2fT);
			gerOrderedVertices(vertices2fT, rrr.center);
		}
		model.fontHeight = distanceBtwnPointsS(vertices2fT[0], vertices2fT[2]);
		 model.fontWidth = distanceBtwnPointsS(vertices2fT[0], vertices2fT[1]);

		for (int i = 0; i < 4; i++)
		{
			model.vertices2fT[i] = vertices2fT[i];
		}
		float templAngle = atan2(vertices2fT[0].y - vertices2fT[1].y, vertices2fT[0].x - vertices2fT[1].x);
		model.templateAngle = templAngle;
		return model;
	}
	std::string Utils::get_cuurent_time();

	void write_log(const std::string& msg);

	std::vector<std::string> get_directories(const std::string& s);
	void Utils::image_details(std::string string_name, cv::Mat img);
	void show_resize_image_auto(std::string string_name, cv::Mat img);
	void Utils::show_resize_image(std::string string_name, cv::Mat img);

	cv::Mat Utils::BitmapToMat(System::Drawing::Bitmap^ bitmap);



	//-----tool fns
	void resShow(string name, Mat img, float scale)
	{
		Mat res;
		//scale = 0.2;
		resize(img, res, Size(), scale, scale);
		imshow(name, res);
		waitKey(5);
	}
	Mat getRotation15AugRotateTemplRect(Mat roi, Mat temp, Mat ImgToBeRotated, float* matchValue, cv::Point* matchCoord, float* angleRet) //roi,temp ----image and template in any form i.e. edge,inrange etc, grayImagetoberotated--original image which will be rotated and returned
	{
		Mat roi2;
		int rotationAngles = 2;
		resize(roi, roi2, cv::Size(roi.cols / 6, roi.rows / 6));
		Mat temp_roi2;
		resize(temp, temp_roi2, cv::Size(temp.cols / 6, temp.rows / 6));

		//imshow("template_fn",temp_roi2);
		//imshow("image_fn", roi2);
		//cv::Point2f center1(roi2.cols / 2.0, roi2.rows / 2.0);
		cv::Point2f center1(temp_roi2.cols / 2.0, temp_roi2.rows / 2.0);
		cv::Size a1 = cv::Size(temp_roi2.cols, temp_roi2.rows);
		vector<double> Minvalues(360);
		Mat roi_rot;
		int result_cols = roi2.cols - temp_roi2.cols + 1;
		int result_rows = roi2.rows - temp_roi2.rows + 1;
		Mat dstImage;
		dstImage.create(result_rows, result_cols, CV_32FC1);
		int match_method = 0; //0-4
		double matchTemp;
		double minVal = 1000000000000;
		double angleBest = 0;
		double minValBest = 1000000000000;
		double maxVal;  cv::Point minLoc; cv::Point maxLoc;
		double angleInc = 0;
		float indexer;
		for (int i = -1 * 2 * rotationAngles; i < 2 * rotationAngles; i++)
		{
			indexer = i;
			if (i == 0)
				angleInc = 0;
			else
			{
				angleInc = indexer / 2;
			}

			//		 cout<<angleInc<<endl;
			Mat rot_mat = getRotationMatrix2D(center1, double(angleInc), 1.0);
			cv::Rect bbox = cv::RotatedRect(cv::Point2f(), temp_roi2.size(), double(angleInc)).boundingRect();
			// adjust transformation matrix
			rot_mat.at<double>(0, 2) += bbox.width / 2.0 - temp_roi2.cols / 2.0;
			rot_mat.at<double>(1, 2) += bbox.height / 2.0 - temp_roi2.rows / 2.0;
			// warpAffine(edgeImage2, edgeImage2_rot, rot_mat, a, 1);
				//warpAffine(roi2, roi_rot, rot_mat, a1, 1);
			Mat templRot;
			warpAffine(temp_roi2, templRot, rot_mat, bbox.size());

			//draw mask----------------
			Mat mask = Mat::zeros(templRot.size(), CV_8UC1);
			cv::RotatedRect rotatedRectangle(cv::Point2f(templRot.cols / 2, templRot.rows / 2), temp_roi2.size(), double(180 - angleInc));

			// We take the edges that OpenCV calculated for us
			cv::Point2f vertices2f[4];
			rotatedRectangle.points(vertices2f);

			// Convert them so we can use them in a fillConvexPoly
			cv::Point vertices[4];
			for (int i = 0; i < 4; ++i) {
				vertices[i] = vertices2f[i];
			}

			// Now we can fill the rotated rectangle with our specified color
			cv::fillConvexPoly(mask,
				vertices,
				4,
				Scalar(255));
			//----------draw mask end

		  ///  cout << "Template size:" << templRot.size() << endl;
		  //  cout << "ROI size:" << roi2.size() << endl;
			cv::Point matchLoc;
			matchTemplate(roi2, templRot, dstImage, match_method, mask);
			minMaxLoc(dstImage, &minVal, &maxVal, &minLoc, &maxLoc, Mat());
			//Minvalues[i] = minVal;
			//rectangle(roi2, minLoc, cv::Point(minLoc.x + temp_roi2.cols, minLoc.y + temp_roi2.rows), Scalar(0, 0, 0), 2, 8, 0);
		  //  imshow("rotImg", templRot);
		  ////  imshow("mask", mask);
			//waitKey(5);
			if (minVal < minValBest)
			{
				minValBest = minVal;

				angleBest = angleInc;
			}

			// waitKey();
			// waitKey(0);
			//cout << "min_temp_value: "<< minVal2 << "\t" << i<<endl;
		}

		double min_temp_value = minValBest;
		double angle = -1 * angleBest;
		*angleRet = angleBest;
		//	 cout<<"Angle"<<angleBest<<endl;
		//	 cout<<"Value"<<minValBest<<endl;
		//for (int i = 0; i < rotationAngles ; i++ )
		//{
		// if(Minvalues[i]  < min_temp_value)
		// {
		//	 min_temp_value = Minvalues[i] ;
		//	 angle = i;
		// }
		//}
		//  cout << "angle: " << angle <<endl;
		// cout << "min_temp_value: "<< min_temp_value <<endl;
		cv::Point2f center2(roi.cols / 2.0, roi.rows / 2.0);
		cv::Size a2 = cv::Size(roi.cols, roi.rows);
		cv::Size a3 = cv::Size(ImgToBeRotated.cols, ImgToBeRotated.rows);
		Mat rot_mat = getRotationMatrix2D(center2, angle, 1.0);

		// get rotation matrix for rotating the image around its center in pixel coordinates
	   // determine bounding rectangle, center not relevant
		cv::Rect2f bbox = cv::RotatedRect(cv::Point2f(), roi.size(), angle).boundingRect();
		// adjust transformation matrix
		rot_mat.at<double>(0, 2) += bbox.width / 2.0 - roi.cols / 2.0;
		rot_mat.at<double>(1, 2) += bbox.height / 2.0 - roi.rows / 2.0;


		warpAffine(roi, roi_rot, rot_mat, a2, 1);
		Mat returnImage;
		warpAffine(ImgToBeRotated, returnImage, rot_mat, bbox.size());
		matchTemplate(roi_rot, temp, dstImage, match_method);
		minMaxLoc(dstImage, &minVal, &maxVal, &minLoc, &maxLoc, Mat());
		*matchCoord = minLoc;
		*matchValue = minVal;
		return  returnImage;
	}
	Mat template_with_match_score(Mat img_1, Mat temp, double* match_score1, Rect* location)
	{
		Mat result_img;

		double minVal_T;
		double maxVal_T;
		Point minLoc_T;
		Point maxLoc_T;

		Rect PositionR;
		cout << "im chnl====" << img_1.channels() << endl;
		cout << "temp chnl===" << temp.channels() << endl;
		Mat temp_g;
		int match_method;

		Mat img_g;
		if (img_1.channels() > 2) {
			cvtColor(img_1, img_g, COLOR_BGR2GRAY);
		}
		else {
			img_g = img_1.clone();
		}
		Mat img_g_th;
		//   threshold(img_g, img_g_th, threshld, 255, THRESH_BINARY);

		if (temp.channels() > 2) {
			cvtColor(temp, temp_g, COLOR_BGR2GRAY);
		}
		else {
			temp_g = temp.clone();
		}

		Mat temp_g_th;
		// threshold(temp_g, temp_g_th, threshld, 255, THRESH_BINARY);
		//imshow("img_1",img_1);
		// imshow("temp",temp);

		Point matchLoc;
		match_method = TM_CCOEFF_NORMED;
		// imshow("img_g_th", img_g_th);
		// imshow("temp_g_th", temp_g_th);
		matchTemplate(img_g, temp_g, result_img, match_method);
		//  match_method==3;
		double match_percent;
		minMaxLoc(result_img, &minVal_T, &maxVal_T, &minLoc_T, &maxLoc_T, Mat());

		cout << "maxVal......" << maxVal_T << endl;
		cout << "minVal......" << minVal_T << endl;

		*match_score1 = maxVal_T * 100;
		Rect r1 = Rect(maxLoc_T, Point(maxLoc_T.x + temp.cols, maxLoc_T.y + temp.rows));
		PositionR = r1;
		*location = r1;
		Mat prnt_crp = img_1(r1);
		//  imshow("prnt_crp", prnt_crp);
		// waitKey(0);
		return prnt_crp;
	}
	bool toolTempMatch_withScore(Mat image, Mat templ, Rect setRegion, float mathcTh, Point xyShiftTolerance, double* score, Rect* rect_location)
	{
		Rect searchRegion = setRegion;
		if ((float)setRegion.x - (0.25 * (float)setRegion.width) > 0)
			searchRegion.x = (int)((float)setRegion.x - 0.25 * (float)setRegion.width);
		else
			searchRegion.x = 0;

		if ((setRegion.x + 1.25 * (float)setRegion.width) < image.cols)
			searchRegion.width = (setRegion.x - searchRegion.x) + (int)(1.25 * (float)setRegion.width);
		else
			searchRegion.width = image.cols - searchRegion.x - 1;

		//resShow(to_string(setRegion.x), image(searchRegion), 1);

		searchRegion.y = 0;
		searchRegion.height = image.rows;

		template_with_match_score(image(searchRegion), templ, score, rect_location);
		(*rect_location).x += searchRegion.x;
		(*rect_location).y += searchRegion.y;

		Point shift = Point(abs(setRegion.x - (*rect_location).x), abs(setRegion.y - (*rect_location).y));
		cout << "in threshold:" << mathcTh << "score:" << *score << endl;
		if (shift.x > xyShiftTolerance.x || shift.y > xyShiftTolerance.y || *score < mathcTh)
		{
			cout << "False XYShift tolerance " << xyShiftTolerance.x << " " << xyShiftTolerance.y << "Shift " << shift.x << " " << shift.y << endl;
			return false;
		}
		else
		{
			cout << "True XYShift tolerance " << xyShiftTolerance.x << " " << xyShiftTolerance.y << "Shift " << shift.x << " " << shift.y << endl;
			return true;
		}

	}

	Mat partLocation(Mat image, Mat templ, Mat imageToRotate, Mat* locatedImage, Rect* rect_partLoc)
	{
		float minV;
		cv::Point minLoc;
		float angle;
		Mat returnRotImg = getRotation15AugRotateTemplRect(image, templ, imageToRotate, &minV, &minLoc, &angle);
		*rect_partLoc = Rect(Point((minLoc.x), (minLoc.y)), Point((minLoc.x) + (templ.cols), (minLoc.y) + (templ.rows)));
		imageToRotate = returnRotImg.clone();
		//cout << "region :" << *rect_partLoc << endl;
		*locatedImage = returnRotImg(*rect_partLoc).clone();
		return returnRotImg.clone();
	}
	//edge tools
	void getLine(double x1, double y1, double x2, double y2, double& a, double& b, double& c)
	{
		// (x- p1X) / (p2X - p1X) = (y - p1Y) / (p2Y - p1Y) 
		a = y1 - y2; // Note: this was incorrectly "y2 - y1" in the original answer
		b = x2 - x1;
		c = x1 * y2 - x2 * y1;
	}

	double dist(double pct1X, double pct1Y, double pct2X, double pct2Y, double pct3X, double pct3Y)
	{
		double a, b, c;
		getLine(pct2X, pct2Y, pct3X, pct3Y, a, b, c);
		return abs(a * pct1X + b * pct1Y + c) / sqrt(a * a + b * b);
	}

	Mat checkChargerPins(Mat image, string pinName, int edgeTh, int edgeDir, Point* p1, Point* p2, int pose, int* result, float strength = 0.6)
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
		int length = 0;
		if (pose == 0) {
			length = image.rows;
			//cout << "case 1 " << endl;
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
		}
		else {
			length = image.cols;
			//cout << "case 2" << endl;
			for (int i = 0; i < image.cols; i++)
			{
				for (int j = 5; j < image.rows - 5; j++)
					//for (int j = image.cols - 5; j > 5; j--)
				{
					float sumL = 0;
					float  sumU = 0;
					int pixVal = 0;
					for (int p = j - 5; p < j + 5; p++)
					{
						pixVal = image.at<uchar>(p, i);
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
					//	circle(colorImg, Point(i, j), 1, Scalar(255,0,0), -1);
					if (diff > edgeTh)
					{
						//circle(colorImg, Point(i, j), 1, Scalar(0, 255, 255), -1);
						edgePts.push_back(Point(i, j));
						break;
					}
				}
				//	resShow("int", colorImg, 1);
					//waitKey();

			}
		}

		int validCnt = 0;
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
			if (pose == 1)
			{
				point1.x = 0;
				point1.y = k * (0 - point0.x) + point0.y;
				point2.x = image.cols;
				point2.y = k * (image.cols - point0.x) + point0.y;
			}
			else
			{
				point1.y = 1;
				point1.x = point0.x + ((float)(1 - point0.y) / k);
				point2.y = image.rows;
				point2.x = point0.x + ((float)((image.rows - point0.y)) / k);
			}
			for (int k = 0; k < edgePts.size(); k++)
			{
				double d = dist(edgePts[k].x, edgePts[k].y, point1.x, point1.y, point2.x, point2.y);
				if (abs(d) < 2)
				{
					circle(colorImg, edgePts[k], 1, Scalar(0, 255, 0), -1);
					validCnt++;
				}
				else
					circle(colorImg, edgePts[k], 1, Scalar(0, 0, 255), -1);
			}

			circle(colorImg, point1, 2, Scalar(0, 0, 255), -1);
			circle(colorImg, point2, 2, Scalar(0, 0, 255), -1);
			cout << pinName << "  point 1:" << point1 << "  point 2:" << point2 << endl;
			//cv::line(colorImg, point1, point2, cv::Scalar(0, 255, 0), 2, 8, 0);
			*p1 = point1;
			*p2 = point2;

		}
		else
		{
			cout << pinName << " no edge" << endl;
		}

		cout << "edge std :" << strength * length << "   current val :" << validCnt << endl;
		if (validCnt > (strength * length))
			*result = 1;
		else
			*result = 0;
		//resShow(pinName, colorImg,1);

		return colorImg;
	}

	//-------------

};
#endif
