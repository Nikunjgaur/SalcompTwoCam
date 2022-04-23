
#include "pch.h"
#include "Utils.h"
#include <fstream>
#include<ctime> 
#include<direct.h>

#ifndef DEBUG 
#define DEBUG 1 // set debug mode
#endif

#if DEBUG
#define log(...) {\
    char str[100];\
    sprintf(str, __VA_ARGS__);\
    std::cout << "[" << __FILE__ << "][" << __FUNCTION__ << "][Line " << __LINE__ << "] " << str << std::endl;\
    }
#else
#define log(...)
#endif






#include <filesystem>  
using namespace std;
using namespace System;
namespace fs = std::filesystem;







std::string Utils::get_cuurent_time()
{
	time_t t; // t passed as argument in function time()
	struct tm* tt; // decalring variable for localtime()
	time(&t); //passing argument to time()
	tt = localtime(&t);
	return std::string(asctime(tt));
}
void Utils::write_log(const std::string& msg)
{
	time_t     now = time(0);
	struct tm  tstruct;
	char       buf[80];
	tstruct = *localtime(&now);
	strftime(buf, sizeof(buf), "%Y-%m-%d", &tstruct);

	std::string date = buf;
	std::ofstream outfile;
	std::string  path = "" + date + ".txt";
	outfile.open(path, std::ios_base::app); // append instead of overwrite
	outfile << msg;
	outfile << "\n";
}
std::vector<std::string> Utils::get_directories(const std::string& start_path)
{

	try
	{

		std::vector<std::string>    vect_dir;

		for (const auto& entry : fs::directory_iterator(start_path)) {
			const auto filenameStr = entry.path().filename().string();
			if (entry.is_directory()) {
				std::cout << "dir:  " << filenameStr << '\n';
				vect_dir.push_back(filenameStr);
			}
			else if (entry.is_regular_file()) {
				std::cout << "file: " << filenameStr << '\n';
			}
			else
				std::cout << "??    " << filenameStr << '\n';
		}


		return vect_dir;

	}
	catch (const std::filesystem::filesystem_error & e)
	{

		log((" >>>>>>>>>>   : Exception filesystem_error "));

		std::cout << e.what();
	}




}//get_directories
cv::Mat Utils::BitmapToMat(System::Drawing::Bitmap^ bitmap)
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
void Utils::show_resize_image(std::string string_name, cv::Mat img)
{

	cv::Mat dst;
	cv::resize(img, dst, cv::Size(400, 400));
	cv::imshow(string_name, dst);

}//void show_resize_image(std::string string_name, cv::Mat img)
void Utils::image_details(std::string string_name, cv::Mat img)
{

	std::cout << string_name << "  channels is " << img.channels() << std::endl;
	std::cout << string_name << " size is     " << img.size() << std::endl;

	//Console::WriteLine(" channels is  is {0} ", img.channels());

	////Console::WriteLine(" x is {0} ", img.size().x);
	////Console::WriteLine(" y is {0} ", img.size().y);
	//Console::WriteLine(" width is {0} ", img.size().width);
	//Console::WriteLine(" height is {0} ", img.size().height);



}//void show_resize_image(std::string string_name, cv::Mat img)


void Utils::show_resize_image_auto(std::string string_name, cv::Mat img)
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