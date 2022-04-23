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
#include <nlohmann/json.hpp>
#include "CheckClean.h"
#include "CheckPins.h"
#include "Utils.h"
using json = nlohmann::json;
using namespace cv;
public class InspectAlgo
{


public:


	//cv::Mat InspectAlgo::Template_match_for_CheckTextMatch(cv::Mat source_image, cv::Mat temp, double* match_score1);
	bool InspectAlgo::load_template( CheckTextMatch_namespace::CheckTextMatch _CheckTextMatch_Object,int i);


};



