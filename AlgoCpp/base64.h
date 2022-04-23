#pragma once
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
#include "CheckTextMatch.h"
#include "RectanglePoint.h"
using json = nlohmann::json;
using namespace cv;
using namespace cv::ml;
using namespace std;
using namespace System;
#ifndef BASE64_H_C0CE2A47_D10E_42C9_A27C_C883944E704A
#define BASE64_H_C0CE2A47_D10E_42C9_A27C_C883944E704A

#include <string>

std::string base64_encode(unsigned char const*, unsigned int len);
std::string base64_decode(std::string const& s);
std::string mat2str(const cv::Mat& img);

#endif