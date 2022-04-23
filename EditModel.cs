using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvCamCtrl.NET;
using Newtonsoft.Json;
using AlgoCpp;
using System.IO;

namespace SalcompTwoCam
{
    public partial class EditModel : Form
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
        Tools.CheckEdge checkEdge = new Tools.CheckEdge();
        Tools.CheckTemplate checkTemplate = new Tools.CheckTemplate();
        bool mouseDown;
        Point lastLocation;
        Point startPoint;
        Point endPoint;
        string modelResult1 = "";
        string modelResult2 = "";
        string selectedTool = "";
        Rectangle cropRect = new Rectangle();
        bool loaded = false;
        Bitmap templateImage;

        int totalInspected = 0;
        int okCount1 = 0;
        int okCount2 = 0;
        int ngCount1 = 0;
        int ngCount2 = 0;

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
            grabbedImage[nIndex] = new System.Drawing.Bitmap((int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, (int)pFrameInfo.nWidth * 3,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb, pData);
            Console.WriteLine("image captured from Cam  " + nIndex.ToString() + "   frame no:" + m_nFrames[nIndex].ToString());
            //-----color end

            Rectangle rect = new Rectangle(0, 0, grabbedImage[nIndex].Width, grabbedImage[nIndex].Height);
            Bitmap grabbedImageColor = grabbedImage[nIndex].Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Bitmap grabbedImageRet = grabbedImage[nIndex].Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
          
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
        public EditModel()
        {
            InitializeComponent();
        }

        private void EditModel_Load(object sender, EventArgs e)
        {

        }

        private void cb_cam_live_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EditModel_Load_1(object sender, EventArgs e)
        {
            connectAllCams(2);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Default Model not found. Select model before inspection");
            }
            comboBoxCam.SelectedIndex = 0;
        }

        private void cb_model_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateRegions();
                startPoint = new Point(0, 0);
                endPoint = new Point(0, 0);
                pictureBoxZoom.Invalidate();
                loaded = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           

        }


        void UpdateRegions()
        {
            try
            {

                string path = string.Format(@"{0}\Models\{1}\{2}\ModelData.json",
                CommonParameters.projectDirectory, cb_model_name.SelectedItem.ToString(), comboBoxCam.SelectedItem.ToString());

                cb_region_name.Items.Clear();

                Console.WriteLine("This is path {0}", path);
                modelData1 = JsonConvert.DeserializeObject<Model>(File.ReadAllText(path));
                Bitmap bitmap = new Bitmap(modelData1.TemplateImagePath);
                templateImage = (Bitmap)bitmap.Clone();

                for (int i = 0; i < modelData1.CheckTemplates.Count; i++)
                {
                    cb_region_name.Items.Add(string.Format("Template {0}", i + 1));
                }
                for (int i = 0; i < modelData1.CheckEdges.Count; i++)
                {
                    cb_region_name.Items.Add(string.Format("Edge {0}", i + 1));

                }
                camController.setCamExposure(ref m_pMyCamera[0], modelData1.Camera_exposer);

                modelResult1 = JsonConvert.SerializeObject(modelData1, Formatting.Indented);
                //Console.WriteLine(modelResult1);



                pictureBoxZoom.Image = bitmap;

                // Console.WriteLine("Model Data json {0}", modelResult1);
                //Console.WriteLine("------------------------------------------------------------------------------");
                cb_region_name.SelectedIndex = 0;
                salcomCpp1.load_template(modelResult1, 0);
                //Console.WriteLine("Path 1 {0}", path);

                //path = string.Format(@"{0}\Models\{1}\SecondCam\ModelData.json", CommonParameters.projectDirectory, cb_model_name.SelectedItem.ToString());

                //Console.WriteLine("Path 2 {0}", path);

                //modelData2 = JsonConvert.DeserializeObject<Model>(File.ReadAllText(path));

                //camController.setCamExposure(ref m_pMyCamera[1], modelData2.Camera_exposer);

                //modelResult2 = JsonConvert.SerializeObject(modelData2, Formatting.Indented);
                ////Console.WriteLine(modelResult2);

                //salcomCpp2.load_template(modelResult2, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void cb_region_name_MouseDown(object sender, MouseEventArgs e)
        {
            loaded = true;

        }

        bool changesMade = false;
        private void NUD_ValueChanged(object sender, EventArgs e)
        {
            changesMade = true;
        }

        private void NUD_Leave(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown numericUpDown = (NumericUpDown)sender;

                for (int i = 0; i < checkTemplate.List.Count; i++)
                {
                    if (numericUpDown.Name.Remove(0, 13) == checkTemplate.List[i].nodeName)
                    {
                        checkTemplate.List[i].nodeVal = numericUpDown.Value;
                        numericUpDown.Value = checkTemplate.List[i].nodeVal;
                    }
                }

                for (int i = 0; i < checkEdge.List.Count; i++)
                {
                    if (numericUpDown.Name.Remove(0, 13) == checkEdge.List[i].nodeName)
                    {
                        checkEdge.List[i].nodeVal = numericUpDown.Value;
                        numericUpDown.Value = checkEdge.List[i].nodeVal;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }


        }
        void SetTempControls()
        {

            try
            {
                panelEdge.Location = new Point(16, 38);
                panelEdge.Visible = false;
                panelCheckTemp.Visible = true;

                var nm = GetAll(panelCheckTemp, typeof(NumericUpDown));
                foreach (NumericUpDown numericUpDown in nm)
                {

                    for (int i = 0; i < checkTemplate.List.Count; i++)
                    {
                        if (numericUpDown.Name.Remove(0, 13) == checkTemplate.List[i].nodeName)
                        {
                            numericUpDown.Text = checkTemplate.List[i].nodeVal.ToString();
                            //numericUpDown.KeyDown += TextBox_KeyDown;
                            numericUpDown.Leave += NUD_Leave;
                            numericUpDown.ValueChanged += NUD_ValueChanged;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        void SetEdgeControls()
        {
            panelCheckTemp.Location = new Point(16, 38);
            panelCheckTemp.Visible = false;
            panelEdge.Visible = true;

            var nm = GetAll(panelEdge, typeof(NumericUpDown));

            foreach (NumericUpDown numericUpDown in nm)
            {

                for (int i = 0; i < checkEdge.List.Count; i++)
                {
                    if (numericUpDown.Name.Remove(0, 13) == checkEdge.List[i].nodeName)
                    {
                        numericUpDown.Value = checkEdge.List[i].nodeVal;
                        //numericUpDown.KeyDown += TextBox_KeyDown;
                        numericUpDown.Leave += NUD_Leave;
                        numericUpDown.TextChanged += NUD_ValueChanged;
                    }
                }

            }
        }

        private void btn_save_model_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBoxEdge.Checked && !checkBoxTemp.Checked)
                {
                    switch (selectedTool)
                    {
                        case "Temp":
                            modelData1.CheckTemplates[index] = checkTemplate;
                            break;
                        case "Edge":
                            modelData1.CheckEdges[index] = checkEdge;
                            break;
                        default:
                            break;
                    }


                }
                else if (checkBoxEdge.Checked)
                {
                    modelData1.CheckEdges.Add(checkEdge);

                }
                else if (checkBoxTemp.Checked)
                {
                    modelData1.CheckTemplates.Add(checkTemplate);

                }
                modelResult1 = JsonConvert.SerializeObject(modelData1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        int index = -1;

        private void cb_region_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Bitmap bitmap = (Bitmap)templateImage.Clone(); ;

            pictureBoxZoom.Image = bitmap;
            if (cb_region_name.SelectedItem.ToString().Contains("Temp"))
            {
                selectedTool = "Temp";
                Console.WriteLine("Index Value Temp {0}", cb_region_name.SelectedItem.ToString().Last());
                char idx = cb_region_name.SelectedItem.ToString().Last();
                Console.WriteLine("Int Index Value temp {0}", Convert.ToInt32(idx.ToString()));
                index = Convert.ToInt32(idx.ToString()) - 1;

                string modelResult = JsonConvert.SerializeObject(modelData1.CheckTemplates[Convert.ToInt32(idx.ToString()) - 1]);


                checkTemplate = JsonConvert.DeserializeObject<Tools.CheckTemplate>(modelResult);
                SetTempControls();


                Pen pen = Pens.LimeGreen;

                Rectangle rectangle = new Rectangle(new Point((int)checkTemplate.tempRegion.PointX,
                    (int)checkTemplate.tempRegion.PointY),
                    new Size((int)checkTemplate.tempRegion.imageWidth,
                    (int)checkTemplate.tempRegion.imageHeight));

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawRectangle(pen, rectangle);
                    //Modify the image using g here... 
                    //Create a brush with an alpha value and use the g.FillRectangle function
                }


            }
            else if (cb_region_name.SelectedItem.ToString().Contains("Edge"))
            {
                selectedTool = "Edge";

                Console.WriteLine("Index Value Edge {0}", cb_region_name.SelectedItem.ToString().Last());

                char idx = cb_region_name.SelectedItem.ToString().Last();


                Console.WriteLine("Int Index Value Edge {0}", Convert.ToInt32(idx.ToString()));
                index = Convert.ToInt32(idx.ToString()) - 1;

                string modelResult = JsonConvert.SerializeObject(modelData1.CheckEdges[Convert.ToInt32(idx.ToString()) - 1]);

                checkEdge = JsonConvert.DeserializeObject<Tools.CheckEdge>(modelResult);
                SetEdgeControls();

                comboBoxDirection.SelectedIndex = checkEdge.direction;

                Rectangle rectangle = new Rectangle(new Point((int)checkEdge.edgeRegion.PointX,
                    (int)checkEdge.edgeRegion.PointY),
                    new Size((int)checkEdge.edgeRegion.imageWidth,
                    (int)checkEdge.edgeRegion.imageHeight));

                Pen pen = Pens.LimeGreen;

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawRectangle(pen, rectangle);
                    //Modify the image using g here... 
                    //Create a brush with an alpha value and use the g.FillRectangle function
                }
            }
            else
            {
                index = -1;
            }
            
        }

        private void btn_test_algo_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBoxZoom.Image = templateImage;
                switch (selectedTool)
                {
                    case "Temp":


                        checkTemplate.tempRegion = new Tools.CheckTemplate.Region(modelData1.CheckTemplates[index].tempRegion);
                        
                        Bitmap bitmap = new Bitmap(modelData1.TemplateImagePath);

                        checkTemplate.matchScore = numericUpDownMatchScore.Value;
                        checkTemplate.threshold = numericUpDownTempThreshold.Value;
                        checkTemplate.shiftToleranceX = numericUpDownShiftToleranceX.Value;
                        checkTemplate.shiftToleranceY = numericUpDownShiftToleranceY.Value;

                        modelData1.CheckTemplates.Add(checkTemplate);
                        string path = string.Format(@"{0}\Models\{1}\{2}\{3}.bmp", CommonParameters.projectDirectory,
                            Model.ModelName, CommonParameters.camCode, "tempcheck" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));

                        if (checkBoxTemp.Checked)
                        {
                            
                            Tools.CheckTemplate.Region region = new Tools.CheckTemplate.Region();

                            region.PointX = cropRect.X;
                            region.PointY = cropRect.Y;
                            region.imageWidth = cropRect.Width;
                            region.imageHeight = cropRect.Height;
                            region.TemplateImagePath = path;
                            modelData1.CheckTemplates.Last().tempRegion = region;
                            modelData1.CheckTemplates.Last().templateImagePath = path;
                            Bitmap cropped = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                            cropped.Save(path);
                        }
                        


                        string j = JsonConvert.SerializeObject(modelData1.CheckTemplates.Last());
                        Bitmap bitmap1 = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                        string jResult = salcomCpp1.TestAlgo_On_image(bitmap1, j, "CheckTemp");


                        pictureBoxZoom.Image = bitmap1;

                        checkTemplate = JsonConvert.DeserializeObject<Tools.CheckTemplate>(jResult);
                        numericUpDownMatchScore.Value = checkTemplate.matchScore;
                        modelData1.CheckTemplates.RemoveAt(modelData1.CheckTemplates.Count - 1);
                        //modelData.CheckTemplates.Add(checkTemplate);

                        break;
                    case "Edge":

                        checkEdge.edgeRegion = new Tools.CheckEdge.Region(modelData1.CheckEdges[index].edgeRegion);
                        bitmap = new Bitmap(modelData1.TemplateImagePath);

                        checkEdge.threshold = numericUpDownEdgeThreshold.Value;
                        checkEdge.polarity = numericUpDownPolarity.Value;
                        checkEdge.strength = numericUpDownStrength.Value;

                        modelData1.CheckEdges.Add(checkEdge);
                        modelData1.CheckEdges.Last().direction = comboBoxDirection.SelectedIndex;
                        //modelData1.CheckEdges.Last().SetValues();
                        Console.WriteLine("Direction {0} Index {1}", modelData1.CheckEdges.Last().direction, comboBoxDirection.SelectedIndex);
                        path = string.Format(@"{0}\Models\{1}\{2}\{3}.bmp", CommonParameters.projectDirectory,
                            Model.ModelName, CommonParameters.camCode, "edgecheck" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));


                        if (checkBoxEdge.Checked)
                        {
                            Tools.CheckEdge.Region regionEdge = new Tools.CheckEdge.Region();

                            regionEdge.PointX = cropRect.X;
                            regionEdge.PointY = cropRect.Y;
                            regionEdge.imageWidth = cropRect.Width;
                            regionEdge.imageHeight = cropRect.Height;
                            regionEdge.TemplateImagePath = path;

                            modelData1.CheckEdges.Last().edgeRegion = regionEdge;

                            bitmap = (Bitmap)pictureBoxZoom.Image;
                            Bitmap cropped = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                            cropped.Save(path);
                        }


                        j = JsonConvert.SerializeObject(modelData1.CheckEdges.Last());
                        
                        bitmap1 = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);


                        jResult = salcomCpp1.TestAlgo_On_image(bitmap1, j, "CheckEdge");

                        pictureBoxZoom.Image = bitmap1;


                        checkEdge = JsonConvert.DeserializeObject<Tools.CheckEdge>(jResult);
                        modelData1.CheckEdges.RemoveAt(modelData1.CheckEdges.Count - 1);
                        //modelData.CheckEdges.Add(checkEdge);
                        break;
                    default:
                        break;
                }

                //checkEdge = new Tools.CheckEdge();
                //checkEdge.updatePara();
                //checkTemplate = new Tools.CheckTemplate();
                //checkTemplate.updatePara();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Point GetImageCoordinates(Point mouseCoordinates, PictureBox pictureBox, Bitmap image)
        {
            Point point = new Point();
            switch (pictureBoxZoom.SizeMode)
            {
                case PictureBoxSizeMode.StretchImage:
                    point.X = (image.Width * mouseCoordinates.X / pictureBox.Width);
                    point.Y = (image.Height * mouseCoordinates.Y / pictureBox.Height);

                    break;
            }

            return point;
        }
        private void pictureBoxZoom_MouseDown(object sender, MouseEventArgs e)
        {
           
            btn_test_algo.Enabled = true;

            if (checkBoxTemp.Checked || checkBoxEdge.Checked)
            {
                pictureBoxZoom.Image = templateImage;
                if (e.Button == MouseButtons.Left)
                {
                    mouseDown = true;
                    startPoint.X = e.X;
                    startPoint.Y = e.Y;
                }
            }
            
        }

        private void pictureBoxZoom_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkBoxTemp.Checked || checkBoxEdge.Checked)
            {
                if (mouseDown == true && e.Button == MouseButtons.Left)
                {
                    endPoint.X = e.X;
                    endPoint.Y = e.Y;
                    pictureBoxZoom.Invalidate();
                }
            }
            
        }

        private void pictureBoxZoom_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (checkBoxEdge.Checked || checkBoxTemp.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Is cropped area correct ?", "Confirmation",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {

                    //startPoint = new Point(0, 0);
                    //endPoint = new Point(0, 0);
                    //pictureBoxZoom.Invalidate();
                }

            }
        }

        private void pictureBoxZoom_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Pen pen = new Pen(Color.DeepSkyBlue, 2);

                var rc = new Rectangle(
                        Math.Min(startPoint.X, endPoint.X),
                        Math.Min(startPoint.Y, endPoint.Y),
                        Math.Abs(endPoint.X - startPoint.X),
                        Math.Abs(endPoint.Y - startPoint.Y));

                if (rc.Width > 0 && rc.Height > 0)
                {
                    e.Graphics.DrawRectangle(pen, rc);
                }

                Point topLeft = GetImageCoordinates(new Point(rc.X, rc.Y), pictureBoxZoom, (Bitmap)pictureBoxZoom.Image);
                Point bottomRight = GetImageCoordinates(new Point(rc.X + rc.Width, rc.Y + rc.Height), pictureBoxZoom, (Bitmap)pictureBoxZoom.Image);

                cropRect = new Rectangle(topLeft, new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y));

                if (cropRect.Width % 4 != 0)
                    cropRect.Width += (4 - (cropRect.Width % 4));

                if (cropRect.Height % 4 != 0)
                    cropRect.Height += (4 - (cropRect.Height % 4));

                pen = new Pen(Color.Orange, 2);
                e.Graphics.DrawRectangle(pen, rc);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxTemp_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxEdge.Checked = false;
            if (checkBoxTemp.Checked)
            {
                SetTempControls();
                selectedTool = "Temp";
            }
        }

        private void checkBoxEdge_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTemp.Checked = false;
            if (checkBoxEdge.Checked)
            {
                SetEdgeControls();
                selectedTool = "Edge";
            }

        }

        private void buttonSaveModel_Click(object sender, EventArgs e)
        {

            if (modelData1.CheckTemplates.Count > 0 || modelData1.CheckEdges.Count > 0)
            {
                Console.WriteLine("Temp Coord {0}", modelData1.TemplateCoordinate);

                string path = string.Format(@"{0}\Models\{1}\{2}", CommonParameters.projectDirectory, 
                    cb_model_name.SelectedItem.ToString(), comboBoxCam.SelectedItem.ToString());
                string modelResult = JsonConvert.SerializeObject(modelData1, Formatting.Indented);
                File.WriteAllText(path + @"\ModelData.json", modelResult);
                tools_option_gb.Visible = false;
                MessageBox.Show("Model Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Add any tools before saving.");
            }
        }

        private void EditModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectAllCams();
            Forms.editModel = null;

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        Bitmap testImage;

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Select Image File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "bmp",
                Filter = "Images (*.BMP;*.JPG;,*.PNG,*.TIFF)|*.BMP;*.JPG;*.PNG;*.TIFF|" + "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

           

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                testImage = new Bitmap(openFileDialog1.FileName);
                pictureBoxZoom.Image = testImage;
            }
        }

        private void buttonTestImage_Click(object sender, EventArgs e)
        {
            try
            {
                salcomCpp1.load_template(modelResult1, 0);


                Bitmap bitmap = (Bitmap)testImage.Clone();

                //Console.WriteLine("Model Data Results1 {0}", modelResult1);

                salcomCpp1.ProcessImage(bitmap, modelResult1, 0);

                pictureBoxZoom.Image = bitmap;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
