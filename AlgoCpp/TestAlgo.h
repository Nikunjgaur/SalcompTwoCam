#pragma once
#include<iostream>
#include "opencv2/opencv.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/highgui.hpp"
#include <list>
#include <time.h>
#include <string>
#include <vector>
#include <iostream>
#include "CheckTextMatch.h"
#include "CheckClean.h"
#include "CheckPins.h"
#include "ModelData.h"
#include <nlohmann/json.hpp>
using json = nlohmann::json;
public class TestAlgo
{


public:

	ModelData::CheckCheckEdge  TestAlgo::CheckEdge(cv::Mat source_image, ModelData::CheckCheckEdge   checkEdge);
	ModelData::CheckTemplate  TestAlgo::CheckTemp(cv::Mat source_image, ModelData::CheckTemplate  checkEdge);

	cv::Mat TestAlgo::Exception(cv::Mat roi, cv::Mat temp, cv::Rect r1, int rotaion_degree);
	cv::Mat GetImage();




};
