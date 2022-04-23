#pragma once
#include <string>
#include <iostream>
#include "opencv2/opencv.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include "opencv2/highgui.hpp"
#include <fstream>
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
using namespace cv;
using namespace cv::ml;
using namespace std;
using namespace System;

namespace AlgoCpp {
	public ref class SalcomCpp
	{
	public:



		System::String^ __clrcall AlgoCpp::SalcomCpp::ProcessImage(System::Drawing::Bitmap^ sourceImage_bitmap, System::String^ json_model_data, int camCode);
		System::String^ __clrcall AlgoCpp::SalcomCpp::load_template(System::String^ json_model_data, int camCode);
		System::String^ __clrcall AlgoCpp::SalcomCpp::TestAlgo_On_image(System::Drawing::Bitmap^ sourceImage_bitmap, System::String^ json_model_data, System::String^ tools_name);

		bool  AlgoCpp::SalcomCpp::TestFunc();
		static bool check_text_match_ok_ng_prop =false;


		int procTime = 0;
		property int procTimeProp
		{
			int get()
			{
				return procTime;
			}
			void set(int  value)
			{
				procTime = value;
			};
		};

	};

	
}
