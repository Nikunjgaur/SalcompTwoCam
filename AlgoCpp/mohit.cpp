//-------------1st
Mat template_with_match_score(Mat img_1, Mat temp, int threshld, double* match_score1)
{
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
    Mat prnt_crp = img_1(r1);
    //  imshow("prnt_crp", prnt_crp);
    // waitKey(0);
    return prnt_crp;
}

//--------------------------2nd temp------------

Mat rz;

cv::Point minLoc;

Mat Template_match_with_rotation_match0(Mat roi, Mat temp, int rotaion_degree) //roi,temp ----image and template in any form i.e. edge,inrange etc, grayImagetoberotated--original image which will be rotated and returned
{

    Mat big_sizee_roi;
    Mat big_sizee_roi_gray;

    big_sizee_roi = Mat::zeros(Size(roi.cols + 1000, roi.rows + 1000), CV_8UC3);
    roi.copyTo(big_sizee_roi(Rect(500, 500, roi.cols, roi.rows)));
    resize(big_sizee_roi, rz, Size(), 0.3, 0.3);
    imshow("big_sizee_roi", rz);
    if (big_sizee_roi.channels() > 2) {
        cvtColor(big_sizee_roi, big_sizee_roi_gray, COLOR_BGR2GRAY);
    }
    else {
        big_sizee_roi_gray = big_sizee_roi.clone();
    }

    Mat ImgToBeRotated = roi.clone();
    Mat temp_gray;
    if (temp.channels()) {
        cvtColor(temp, temp_gray, COLOR_BGR2GRAY);
    }

    else {
        temp_gray = temp.clone();
    }
    Mat roi2;
    int rotationAngles = rotaion_degree;
    resize(big_sizee_roi_gray, roi2, cv::Size(big_sizee_roi_gray.cols / 4, big_sizee_roi_gray.rows / 4));
    Mat temp_roi2;
    resize(temp_gray, temp_roi2, cv::Size(temp.cols / 4, temp.rows / 4));
    // imshow("template",temp_roi2);
    //cv::Point2f center1(roi2.cols / 2.0, roi2.rows / 2.0);
    cv::Point2f center1(temp_roi2.cols / 2.0, temp_roi2.rows / 2.0);
    cv::Size a1 = cv::Size(temp_roi2.cols, temp_roi2.rows);
    vector<double> Minvalues(360);
    Mat roi_rot;
    int result_cols = roi2.cols - temp_roi2.cols + 1;
    int result_rows = roi2.rows - temp_roi2.rows + 1;
    Mat dstImage;
    dstImage.create(result_rows, result_cols, CV_8UC1);
    int match_method = 0; //0-4
    double matchTemp;
    double minVal = 1000000000000;

    double maxVal = 0;
    double maxValBest = 2;
    double angleBest = 0;
    double minValBest = 1000000000000;

    cv::Point maxLoc;
    double angleInc = 0;
    float indexer;
    cout << "1" << endl;
    for (int i = -1 * 2 * rotationAngles; i < 2 * rotationAngles; i++) {
        indexer = i;
        if (i == 0)
            angleInc = 0;
        else {
            angleInc = indexer;
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
        cv::fillConvexPoly(mask, vertices, 4, Scalar(255, 255, 255));
        //----------draw mask end

        cv::Point matchLoc;
        /*    cout<<"roi2vvvv---"<<roi2.size()<<endl;
            cout<<"templRotvvvv---"<<templRot.size()<<endl;

            cout << "roi2vvvv---" << roi2.channels() << endl;
            cout << "templRotvvvv---" << templRot.channels() << endl;
            cout << "mask---" << mask.channels() << endl;;*/

        /*   imshow("roi2wwe",roi2);
            imshow("templRotwwe",templRot);
            imshow("dstImage", dstImage);
            waitKey(0);*/
        matchTemplate(roi2, templRot, dstImage, match_method, mask);
        minMaxLoc(dstImage, &minVal, &maxVal, &minLoc, &maxLoc, Mat());
        //Minvalues[i] = minVal;
        //rectangle(roi2, minLoc, cv::Point(minLoc.x + temp_roi2.cols, minLoc.y + temp_roi2.rows), Scalar(0, 0, 0), 2, 8, 0);
        //		imshow("rotImg",templRot);
        //		imshow("mask",mask);
        //	waitKey(0);

        //		cout<<"maxVal=========="<<maxVal<<endl;
        //		cout<<"angleInc=========="<<angleInc<<endl;

        if (minVal < minValBest) {
            minValBest = minVal;

            angleBest = angleInc;
        }

        // waitKey();
        // waitKey(0);
        //cout << "min_temp_value: "<< minVal2 << "\t" << i<<endl;
    }

    double min_temp_value = minValBest;
    double angle = -1 * angleBest;
    //*angleRet = angleBest;

    //	cout<<"min_temp_value=========="<<min_temp_value<<endl;
    //	cout<<"angle=========="<<angle<<endl;

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
    //	*matchCoord = maxLoc;
    //	*matchValue = maxVal;
    //	cout<<"match value------------"<<maxVal<<endl;
    //	imwrite("C:/Users/VisionSystem/Pictures/Saved Pictures/new rot.bmp",returnImage);

    //	resize(returnImage,resz,Size(),0.5,0.5);
    /*  Rect r1 = Rect(Point(minLoc.x, minLoc.y),Point(minLoc.x + temp.cols, minLoc.y + (temp.rows+900)));
    Mat prnt_crp = ImgToBeRotated(r1);*/

    cout << "208" << endl;
    Rect r2 = Rect(minLoc, Point(minLoc.x + temp.cols, minLoc.y + temp.rows));
    Mat prnt_crpxx = returnImage(r2);

    // resize(prnt_crpxx, rz, Size(), 0.3, 0.3);
    //imshow("prnt_crpxx", prnt_crpxx);

    // waitKey(0);
    return prnt_crpxx;
}

//----------------------

Mat template_with_match_score_vivo(Mat img_1, Mat temp, double* match_score1)
{
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

    Point matchLoc;
    match_method = TM_CCOEFF_NORMED;

    matchTemplate(img_g, temp_g, result_img, match_method);
    //  match_method==3;
    double match_percent;
    minMaxLoc(result_img, &minVal_T, &maxVal_T, &minLoc_T, &maxLoc_T, Mat());

    cout << "maxVal......" << maxVal_T << endl;
    cout << "minVal......" << minVal_T << endl;

    *match_score1 = maxVal_T * 100;
    Rect r1 = Rect(maxLoc_T, Point(maxLoc_T.x + temp.cols, maxLoc_T.y + temp.rows));
    Mat prnt_crp = img_1(r1);
    //  imshow("prnt_crp", prnt_crp);
    // waitKey(0);
    return prnt_crp;
}

Mat training_print_chck(Mat inimg, Rect r, Mat temp, int thresh, bool* print_result)
{
    Mat inimg_gray;
    Mat img = inimg(r);
    imshow("img", img);
    if (img.channels() > 2) {
        cvtColor(img, inimg_gray, COLOR_BGR2GRAY);
    }
    else {
        inimg_gray = img.clone();
    }
    Mat th;
    //threshold(inimg_gray, th, 100, 255, THRESH_BINARY);
    //imshow("th", th);
    //waitKey(0);
    double match_score;
    Mat model_print_return_img = template_with_match_score_vivo(inimg, temp, &match_score);

    Mat img1 = model_print_return_img.clone();

    cout << "match_score===" << match_score << endl; //-------------------------------from c++ to c#

    Scalar avgColor = sum(img1) / (img1.cols * img1.rows);
    cout << "avgColor-----------------::" << avgColor[0] << endl; //----------------------from c++ to c#

    Mat inimg_thrs;

    Mat model_print_return_img_gray;
    if (model_print_return_img.channels() > 2) {
        cvtColor(model_print_return_img, model_print_return_img_gray, COLOR_BGR2GRAY);
    }
    else {
        model_print_return_img_gray = model_print_return_img.clone();
    }

    Mat temp_gray;
    if (temp.channels() > 2) {
        cvtColor(temp, temp_gray, COLOR_BGR2GRAY);
    }
    else {
        temp_gray = temp.clone();
    }

    Mat absolute_diff_img;

    absdiff(model_print_return_img_gray, temp_gray, absolute_diff_img);
    imshow("absolute_diff", absolute_diff_img);

    Mat abs_diff_th;
    threshold(absolute_diff_img, abs_diff_th, thresh, 255, THRESH_BINARY);
    imshow("abs_diff_th", abs_diff_th);

    vector<vector<Point> > contours;
    vector<Vec4i> hierarchy;

    findContours(abs_diff_th, contours, hierarchy, CV_RETR_TREE, CV_CHAIN_APPROX_SIMPLE, cv::Point(0, 0));

    Rect br;
    for (int i = 0; i < contours.size(); i++) {
        double area = contourArea(contours[i], false);

        br = boundingRect(contours[i]);

        /*if (area>20)
        {*/

        cout << "height::::::::::::" << br.height << endl;
        cout << "width::::::::::" << br.width << endl;
        cout << "area:::::::::::" << area << endl;

        if (br.height > 3 && br.width > 3 && area > 2) {

            *print_result = false;
            drawContours(img1, contours, i, Scalar(0, 0, 255), 2, 8, hierarchy, 0, Point());
        }
    }

    imshow("imgimg11 v", img1);

    waitKey(0);
    return img1;
}

Mat testing_print_chck(Mat inimg, Rect r, Mat temp, int thresh, int match_score_value, int average_color, int height_tol, int width_tol, int area_tol, bool* print_result)
{
    Mat inimg_gray;
    Mat img = inimg(r);
    imshow("img", img);
    if (img.channels() > 2) {
        cvtColor(img, inimg_gray, COLOR_BGR2GRAY);
    }
    else {
        inimg_gray = img.clone();
    }
    Mat th;
    //threshold(inimg_gray, th, 100, 255, THRESH_BINARY);
    //imshow("th", th);
    //waitKey(0);
    double match_score;
    Mat model_print_return_img = template_with_match_score_vivo(inimg, temp, &match_score);

    Mat img1 = model_print_return_img.clone();

    cout << "match_score===" << match_score << endl; //-------------------------------from c++ to c#
    bool defect_chck = 0;
    if (match_score < match_score_value) {
        *print_result = 0;
        putText(img1, "Defect", Point(20, 20), FONT_HERSHEY_SIMPLEX, 1, Scalar(0, 0, 250), 2);
        return img1;
    }

    Scalar avgColor = sum(img1) / (img1.cols * img1.rows);
    cout << "avgColor-----------------::" << avgColor[0] << endl; //----------------------from c++ to c#

    if (average_color + 5 > avgColor[0] > average_color - 5) {
    }
    else {
        *print_result = 0;
        putText(img1, "Defect", Point(20, 20), FONT_HERSHEY_SIMPLEX, 1, Scalar(0, 0, 250), 2);
        return img1;
    }

    Mat inimg_thrs;

    Mat model_print_return_img_gray;
    if (model_print_return_img.channels() > 2) {
        cvtColor(model_print_return_img, model_print_return_img_gray, COLOR_BGR2GRAY);
    }
    else {
        model_print_return_img_gray = model_print_return_img.clone();
    }

    Mat temp_gray;
    if (temp.channels() > 2) {
        cvtColor(temp, temp_gray, COLOR_BGR2GRAY);
    }
    else {
        temp_gray = temp.clone();
    }

    Mat temp_th;

    //   threshold(temp_gray, temp_th, 100, 255, THRESH_BINARY);

    Mat absolute_diff_img;

    absdiff(model_print_return_img_gray, temp_gray, absolute_diff_img);
    imshow("absolute_diff", absolute_diff_img);

    Mat abs_diff_th;
    threshold(absolute_diff_img, abs_diff_th, thresh, 255, THRESH_BINARY);
    imshow("abs_diff_th", abs_diff_th);

    vector<vector<Point> > contours;
    vector<Vec4i> hierarchy;

    findContours(abs_diff_th, contours, hierarchy, CV_RETR_TREE, CV_CHAIN_APPROX_SIMPLE, cv::Point(0, 0));

    Rect br;
    for (int i = 0; i < contours.size(); i++) {
        double area = contourArea(contours[i], false);

        br = boundingRect(contours[i]);

        /*if (area>20)
        {*/

        cout << "height::::::::::::" << br.height << endl;
        cout << "width::::::::::" << br.width << endl;
        cout << "area:::::::::::" << area << endl;

        if (br.height > height_tol && br.width > width_tol && area > area_tol) {

            *print_result = false;
            drawContours(img1, contours, i, Scalar(0, 0, 255), 2, 8, hierarchy, 0, Point());
        }
    }

    imshow("imgimg11 v", img1);

    waitKey(0);
    return img1;
}
