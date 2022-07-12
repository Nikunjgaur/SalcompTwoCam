using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvCamCtrl.NET;
using Newtonsoft.Json;
using AlgoCpp;
using System.Threading;

namespace SalcompTwoCam
{
    public partial class InspectModel : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        bool camStarted = true;
        float camExpGlobal = 11100.0f;
        HRcamFns camController = new HRcamFns();
        HRcam c0 = new HRcam();
        HRcam c1 = new HRcam();
        private MyCamera[] m_pMyCamera;
        bool camerasStarted = false;
        SalcomCpp salcomCpp1 = new SalcomCpp();
        SalcomCpp salcomCpp2 = new SalcomCpp();
        Model modelData1 = new Model();
        Model modelData2 = new Model();
        string modelResult1 = "";
        string modelResult2 = "";

        int totalInspected = 0;
        int okCount1 = 0;
        int okCount2 = 0;
        int ngCount1 = 0;
        int ngCount2 = 0;

        UnitReport _UnitReport = new UnitReport();
        UnitReport _UnitReport2 = new UnitReport();


        int connectAllCams(int expectedCamCnt)
        {
            camController = new HRcamFns();
            camController.listOfCamObs_u.Clear();
            c0.name = "FirstCam";
            c0.serialNo = "02J53804511";
            c0.expTime = camExpGlobal;
            
            c1.name = "SecondCam";
            c1.serialNo = "02J06350890";
            c1.expTime = camExpGlobal;

            


            camController.listOfCamObs_u.Add(c0);
            camController.listOfCamObs_u.Add(c1);


            m_pMyCamera = new MyCamera[camController.listOfCamObs_u.Count]; //CREATE CAMERA ARRAY 

            int resp = camController.SearchAllCameras();
           


            if (resp < expectedCamCnt) // no cameras detected
            {
                MessageBox.Show("unable to find all cameras." + Environment.NewLine + "Cameras found :" + resp.ToString());
                return 0;

            }
            else
            {
                for (int cams = 0; cams < camController.listOfCamObs_u.Count; cams++)
                {
                    int r = camController.connectListedCam(ref m_pMyCamera[cams], cams);
                    if (r == 0)
                    {
                        // MessageBox.Show("Unable to connect Camera : " + camController.listOfCamObs_u[cams].name);
                        Console.WriteLine("Unable to connect Camera : " + camController.listOfCamObs_u[cams].name);
                    }
                    else //read some parameter 
                    {
                        MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
                        stParam.fCurValue = 111.0F;
                        Console.WriteLine("default Exposure of connected camera :" + stParam.fCurValue.ToString());
                        int nRet = m_pMyCamera[cams].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
                        if (MyCamera.MV_OK == nRet)
                        {
                            Console.WriteLine("Exposure of connected camera :" + stParam.fCurValue.ToString());
                        }
                        camController.setTriggerMode(ref m_pMyCamera[cams], false, true);
                        camController.SetOutLine(ref m_pMyCamera[cams]);
                    }
                }
            }

            return 1;
        }

        int disconnectAllCams()
        {
            int resp = 0;
            for (int cams = 0; cams < camController.listOfCamObs_u.Count; cams++)
            {
                if (camController.listOfCamObs_u[cams].isConnected)
                {
                    resp = camController.disconnectCam(ref m_pMyCamera[cams]);
                    if (resp == 1)
                    {
                        camController.listOfCamObs_u[cams].isConnected = false;
                    }

                }
            }

            return 1;

        }
        //-------------------------------grab event 
        MyCamera.cbOutputExdelegate cbImage;
        IntPtr[] m_hDisplayHandle = new IntPtr[3];
        int[] m_nFrames = new int[3];
        public UInt32[] m_nSaveImageBufSize = new UInt32[3] { 0, 0, 0 };
        public IntPtr[] m_pSaveImageBuf = new IntPtr[3] { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero };
        private Object[] m_BufForSaveImageLock = new Object[3];
        MyCamera.MV_FRAME_OUT_INFO_EX[] m_stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX[3];

        Bitmap[] grabbedImage = new Bitmap[3];
        delegate void SetTextCallback(string text);
        private void ImageCallBack(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {

            _UnitReport.Timestamp = DateTime.Now;
            _UnitReport2.Timestamp = DateTime.Now;


            int nIndex = (int)pUser;

            // ch:抓取的帧数 | en:Aquired Frame Number
            ++m_nFrames[nIndex];

            lock (m_BufForSaveImageLock[nIndex])
            {
                if (m_pSaveImageBuf[nIndex] == IntPtr.Zero || pFrameInfo.nFrameLen > m_nSaveImageBufSize[nIndex])
                {
                    if (m_pSaveImageBuf[nIndex] != IntPtr.Zero)
                    {
                        Marshal.Release(m_pSaveImageBuf[nIndex]);
                        m_pSaveImageBuf[nIndex] = IntPtr.Zero;
                    }

                    m_pSaveImageBuf[nIndex] = Marshal.AllocHGlobal((Int32)pFrameInfo.nFrameLen);
                    if (m_pSaveImageBuf[nIndex] == IntPtr.Zero)
                    {
                        return;
                    }
                    m_nSaveImageBufSize[nIndex] = pFrameInfo.nFrameLen;
                }

                m_stFrameInfo[nIndex] = pFrameInfo;
                CopyMemory(m_pSaveImageBuf[nIndex], pData, pFrameInfo.nFrameLen);
            }

            MyCamera.MV_DISPLAY_FRAME_INFO stDisplayInfo = new MyCamera.MV_DISPLAY_FRAME_INFO();
            stDisplayInfo.hWnd = m_hDisplayHandle[nIndex];
            stDisplayInfo.pData = pData;
            stDisplayInfo.nDataLen = pFrameInfo.nFrameLen;
            stDisplayInfo.nWidth = pFrameInfo.nWidth;
            stDisplayInfo.nHeight = pFrameInfo.nHeight;
            stDisplayInfo.enPixelType = pFrameInfo.enPixelType;

            //------------gray
            // try
            // {
            //     grabbedImage[nIndex] = new System.Drawing.Bitmap((int)pFrameInfo.nWidth,
            //(int)pFrameInfo.nHeight,
            //(int)pFrameInfo.nWidth * 1,
            //System.Drawing.Imaging.PixelFormat.Format8bppIndexed,
            //pData);
            //     System.Drawing.Imaging.ColorPalette palette = grabbedImage[nIndex].Palette;
            //     int nColors = 256;
            //     for (int ii = 0; ii < nColors; ii++)
            //     {
            //         uint Alpha = 0xFF;
            //         uint Intensity = (uint)(ii * 0xFF / (nColors - 1));
            //         palette.Entries[ii] = System.Drawing.Color.FromArgb(
            //          (int)Alpha,
            //          (int)Intensity,
            //          (int)Intensity,
            //          (int)Intensity);
            //     }
            //     grabbedImage[nIndex].Palette = palette;

            //     Rectangle rect0 = new Rectangle(0, 0, grabbedImage[nIndex].Width, grabbedImage[nIndex].Height);
            // }
            // catch (ArgumentException ex)
            // {
            //     Console.WriteLine("exception from camera class mono conversion");
            //     System.Console.Write(ex);
            //     return;
            // }
            //---------gray End---------
            //----color 
            grabbedImage[nIndex] = new System.Drawing.Bitmap((int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, (int)pFrameInfo.nWidth * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, pData);
            Console.WriteLine("image captured from Cam  " + nIndex.ToString() + "   frame no:" + m_nFrames[nIndex].ToString());
            //-----color end

            Rectangle rect = new Rectangle(0, 0, grabbedImage[nIndex].Width, grabbedImage[nIndex].Height);
            Bitmap grabbedImageColor = grabbedImage[nIndex].Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Bitmap grabbedImageRet = grabbedImage[nIndex].Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            try
            {
                if (doInspection)
                {

                    if (nIndex == 0 && modelResult1 != "")
                    {
                        _UnitReport.DateTimeStart = DateTime.Now;

                        _UnitReport.SerialNumber = "1234";

                        Bitmap bitmap = (Bitmap)grabbedImageColor.Clone();

                        //Console.WriteLine("Model Data Results1 {0}", modelResult1);

                        if (saveImages1.Checked)
                        {
                            string path = string.Format(@"{0}\Models\{1}\FirstCam\Images\{2}.bmp",
                            CommonParameters.projectDirectory, cb_model_name.SelectedItem.ToString(), DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));

                            grabbedImageColor.Save(path);
                        }


                        modelData1 = JsonConvert.DeserializeObject<Model>(salcomCpp1.ProcessImage(bitmap, modelResult1, 0));


                        picboxOne.Image = bitmap;
                        // this.Refresh();

                    }
                    if (nIndex != 0 && modelResult2 != "")
                    {
                        _UnitReport2.DateTimeStart = DateTime.Now;
                        _UnitReport2.SerialNumber = "5678";


                        Bitmap bitmap = (Bitmap)grabbedImageColor.Clone();

                        //Console.WriteLine("Model Data Results2 {0}", modelResult2);

                        modelData2 = JsonConvert.DeserializeObject<Model>(salcomCpp2.ProcessImage(bitmap, modelResult2, 1));

                        if (saveImages2.Checked)
                        {
                            string path = string.Format(@"{0}\Models\{1}\SecondCam\Images\{2}.bmp",
                            CommonParameters.projectDirectory, cb_model_name.SelectedItem.ToString(), DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                            grabbedImageColor.Save(path);
                        }

                        pictureBoxTwo.Image = bitmap;
                    }
                    //    grabbedImageColor.Save("imageCam" + nIndex + ".bmp");
                    //  m_pMyCamera[nIndex].MV_CC_DisplayOneFrame_NET(ref stDisplayInfo);
                    if (nIndex == 0 && modelResult1 != "")
                    {

                        if (modelData1.result)
                        {
                            okCount1++;
                            totalInspected++;

                            buttonResultCam1.Invoke(new Action(() => buttonResultCam1.Text = "OK"));
                            buttonResultCam1.Invoke(new Action(() => buttonResultCam1.BackColor = Color.LimeGreen));
                            labelOkCam1.Invoke(new Action(() => labelOkCam1.Text = okCount1.ToString()));

                            camController.SetOutput(ref m_pMyCamera[0]);
                            Console.WriteLine("Single trigger cam 1");
                            _UnitReport.StatusCode = "PASS";


                        }
                        else
                        {
                            ngCount1++;
                            totalInspected++;
                            buttonResultCam1.Invoke(new Action(() => buttonResultCam1.Text = "Ng"));
                            buttonResultCam1.Invoke(new Action(() => buttonResultCam1.BackColor = Color.Red));
                            labelNgCam1.Invoke(new Action(() => labelNgCam1.Text = ngCount1.ToString()));

                            camController.SetOutput(ref m_pMyCamera[0]);
                            Thread.Sleep(150);
                            camController.SetOutput(ref m_pMyCamera[0]);
                            _UnitReport.StatusCode = "FAIL";
                            Console.WriteLine("Double trigger cam 1");



                        }

                        db.InsertRecord(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")),
                        modelName, textBoxSrNum.Text, "Def Code", "First Cam", Convert.ToInt32(modelData1.result));
                        _UnitReport.DateTimeEnd = DateTime.Now;

                    }
                    if (nIndex != 0 && modelResult2 != "")
                    {
                        if (modelData2.result)
                        {
                            okCount2++;
                            totalInspected++;
                            buttonResultCam2.Invoke(new Action(() => buttonResultCam2.Text = "OK"));
                            buttonResultCam2.Invoke(new Action(() => buttonResultCam2.BackColor = Color.LimeGreen));
                            labelOkCount.Invoke(new Action(() => labelOkCount.Text = okCount2.ToString()));
                            camController.SetOutput(ref m_pMyCamera[1]);
                            Console.WriteLine("Single trigger cam 2");

                            _UnitReport2.StatusCode = "PASS";

                        }
                        else
                        {
                            ngCount2++;
                            totalInspected++;
                            buttonResultCam2.Invoke(new Action(() => buttonResultCam2.Text = "Ng"));
                            buttonResultCam2.Invoke(new Action(() => buttonResultCam2.BackColor = Color.Red));
                            labelNgCount.Invoke(new Action(() => labelNgCount.Text = ngCount2.ToString()));

                            camController.SetOutput(ref m_pMyCamera[1]);
                            Thread.Sleep(150);
                            camController.SetOutput(ref m_pMyCamera[1]);
                            _UnitReport2.StatusCode = "FAIL";
                            Console.WriteLine("Double trigger cam 2");


                        }

                        db.InsertRecord(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")),
                        modelName, textBoxSrNum2.Text, "Def Code", "Second Cam", Convert.ToInt32(modelData2.result));
                        labelTotalCam1.Invoke(new Action(() => labelTotalCam1.Text = totalInspected.ToString()));
                        labelTotalCount.Invoke(new Action(() => labelTotalCount.Text = totalInspected.ToString()));


                        ServiceUtils.save_unit_xml(_UnitReport);
                        ServiceUtils.save_unit_xml(_UnitReport2);
                    }
                    


                    
                }
                else
                {
                    camController.SetOutput(ref m_pMyCamera[0]);
                    camController.SetOutput(ref m_pMyCamera[1]);
                    Console.WriteLine("Force ok trigger active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error in capturing or reading model values.");
            }
           

            System.Threading.Thread.Sleep(100);
        }

        int startCamAcq()
        {
            m_nFrames = new int[3];
            //m_hDisplayHandle[0] = picC0.Handle;
            //m_hDisplayHandle[1] = picC1.Handle;
            //m_hDisplayHandle[2] = picC2.Handle;
            cbImage = new MyCamera.cbOutputExdelegate(ImageCallBack);

            for (int i = 0; i < 3; ++i)
            {
                m_BufForSaveImageLock[i] = new Object();
            }
            for (int cs = 0; cs < camController.listOfCamObs_u.Count; cs++)
            {
                if (camController.listOfCamObs_u[cs].isConnected)
                {
                    m_pMyCamera[cs].MV_CC_RegisterImageCallBackEx_NET(cbImage, (IntPtr)cs);
                    int nRet = m_pMyCamera[cs].MV_CC_StartGrabbing_NET();
                    if (MyCamera.MV_OK != nRet)
                    {
                        Console.WriteLine("start grab failed");
                        camController.listOfCamObs_u[cs].isGrabbing = false;
                        //   ShowErrorMsg("Start Grabbing Fail!", nRet);
                        continue;
                    }
                    else
                    {
                        camController.listOfCamObs_u[cs].isGrabbing = true;
                        //MyCamera.MVCC_ENUMVALUE stEnumValue = new MyCamera.MVCC_ENUMVALUE();
                        //nRet = m_pMyCamera[cs].MV_CC_GetEnumValue_NET("PixelFormat", ref stEnumValue);
                        //if (MyCamera.MV_OK != nRet)
                        //{
                        //    Console.WriteLine("Get Width failed: nRet {0:x8}", nRet);
                        //}
                        //else
                        //{
                        //    Console.WriteLine("camera Pixel Format : " + stEnumValue.nCurValue.ToString());
                        //}
                    }
                }
            }

            return 1;
        }

        int stopCamAcq()
        {
            for (int cs = 0; cs < camController.listOfCamObs_u.Count; cs++)
            {
                if (camController.listOfCamObs_u[cs].isGrabbing)
                {
                    int nRet = m_pMyCamera[cs].MV_CC_StopGrabbing_NET();
                    if (nRet != MyCamera.MV_OK)
                    {
                        Console.WriteLine("stopGrab failed");
                        // ShowErrorMsg("Stop Grabbing Fail!", nRet);
                        continue;
                    }
                    camController.listOfCamObs_u[cs].isGrabbing = false;
                }
            }
            return 1;
        }
        public InspectModel()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Database db = new Database();
        private void InspectModel_Load(object sender, EventArgs e)
        {
            connectAllCams(2);
            db.TestConnection();
            try
            {
                Console.WriteLine("Path {0}", string.Format(@"{0}\Models\", CommonParameters.projectDirectory));
                DirectoryInfo obj = new DirectoryInfo(string.Format(@"{0}\Models\", CommonParameters.projectDirectory));
                DirectoryInfo[] folders = obj.GetDirectories();

                cb_model_name.DataSource = folders;
                startCamAcq();
                camerasStarted = true;
                // Settings
                cb_model_name.SelectedIndex = 0;
                modelName = cb_model_name.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Default Model not found. Select model before inspection");
            }

            GlobalItems._LogInModel.Xml_location = @"D:\XMLPath";
            buttonStart_Click(sender, e);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            totalInspected = 0;
            okCount1 = 0;
            okCount2 = 0;
            ngCount1 = 0;
            ngCount2 = 0;

            labelTotalCount.Text = "0";
            labelTotalCam1.Text = "0";
            labelOkCount.Text = "0";
            labelOkCam1.Text = "0";
            labelNgCount.Text = "0";
            labelNgCam1.Text = "0";

            
            //File.WriteAllText(path + @"\ModelData.json", modelResult);
        }

        private void InspectModel_FormClosing(object sender, FormClosingEventArgs e)
        {

            disconnectAllCams();
            Forms.inspectModel = null;

        }

        string modelName = "";

        private void cb_model_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelResult1 = "";
            modelResult2 = "";

            modelName = cb_model_name.SelectedItem.ToString();

            string path = string.Format(@"{0}\Models\{1}\FirstCam\ModelData.json", CommonParameters.projectDirectory, cb_model_name.SelectedItem.ToString());

            if (File.Exists(path))
            {
                Console.WriteLine("This is path {0}", path);
                modelData1 = JsonConvert.DeserializeObject<Model>(File.ReadAllText(path));

                camController.setCamExposure(ref m_pMyCamera[0], modelData1.Camera_exposer);

                modelResult1 = JsonConvert.SerializeObject(modelData1, Formatting.Indented);
                //Console.WriteLine(modelResult1);

                // Console.WriteLine("Model Data json {0}", modelResult1);
                //Console.WriteLine("------------------------------------------------------------------------------");

                salcomCpp1.load_template(modelResult1, 0);
                Console.WriteLine("Path 1 {0}", path);
            }
            else
            {
                MessageBox.Show("No Model for FirstCam.");
            }
            


            path = string.Format(@"{0}\Models\{1}\SecondCam\ModelData.json", CommonParameters.projectDirectory, cb_model_name.SelectedItem.ToString());

            if (File.Exists(path))
            {
                Console.WriteLine("Path 2 {0}", path);

                modelData2 = JsonConvert.DeserializeObject<Model>(File.ReadAllText(path));

                camController.setCamExposure(ref m_pMyCamera[1], modelData2.Camera_exposer);

                modelResult2 = JsonConvert.SerializeObject(modelData2, Formatting.Indented);
                //Console.WriteLine(modelResult2);

                salcomCpp2.load_template(modelResult2, 1);
            }
            else
            {
                MessageBox.Show("No Model for SecondCam.");

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string path = string.Format(@"{0}\Models\{1}\FirstCam\ModelData.json", CommonParameters.projectDirectory, cb_model_name.SelectedItem.ToString());

            //Console.WriteLine("This is path {0}", path);
            //modelData1 = JsonConvert.DeserializeObject<Model>(File.ReadAllText(path));

            //camController.setCamExposure(ref m_pMyCamera[0], modelData1.Camera_exposer);

            //modelResult1 = JsonConvert.SerializeObject(modelData1, Formatting.Indented);
            ////Console.WriteLine(modelResult1);

            //// Console.WriteLine("Model Data json {0}", modelResult1);
            ////Console.WriteLine("------------------------------------------------------------------------------");

            //salcomCpp1.obj1.load_template(modelResult1);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTN_STAR_Click(object sender, EventArgs e)
        {

        }
        private void inspectionLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Forms.reportPage == null)
            {
                Forms.reportPage = new ReportPage();
                Forms.reportPage.Show();
            }
            else
            {
                Forms.reportPage.BringToFront();
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            camController.SetOutput(ref m_pMyCamera[0]);
            camController.SetOutput(ref m_pMyCamera[1]);

        }

        private void label5_Click(object sender, EventArgs e)
        {

            camController.SetOutput(ref m_pMyCamera[0]);
            Thread.Sleep(150);
            camController.SetOutput(ref m_pMyCamera[0]);

            camController.SetOutput(ref m_pMyCamera[1]);
            Thread.Sleep(150);
            camController.SetOutput(ref m_pMyCamera[1]);

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Forms.loginPage == null)
            {
                Forms.loginPage = new LoginPage();
                Forms.loginPage.ShowDialog();
            }
            
        }

        bool doInspection = false;
        private void buttonStart_Click(object sender, EventArgs e)
        {
            doInspection = true;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            doInspection = false;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }
    }
}
