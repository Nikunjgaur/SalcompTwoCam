using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvCamCtrl.NET;
using Newtonsoft.Json;
using System.IO;
using AlgoCpp;
using System.Drawing.Imaging;
using System.Threading;

namespace SalcompTwoCam
{
    public partial class CreateModel : Form
    {
        SalcomCpp salcomCpp = new SalcomCpp();
        bool mouseDown;
        Point lastLocation;
        Point startPoint;
        Point endPoint;

        Padding picBoxPadding = new Padding(0, 0, 0, 0);
        Model modelData = new Model();
        Tools.CheckEdge checkEdge = new Tools.CheckEdge();
        Tools.CheckTemplate checkTemplate = new Tools.CheckTemplate();

        Bitmap templateImage = null;

        Rectangle cropRect = new Rectangle();
       
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        bool camStarted = true;
        float camExpGlobal = 11100.0f;
        HRcamFns camController = new HRcamFns();
        HRcam c0 = new HRcam();
        private MyCamera[] m_pMyCamera;
        bool camerasStarted = false;
        int connectAllCams(int expectedCamCnt)
        {
            camController = new HRcamFns();
            camController.listOfCamObs_u.Clear();
            c0.name = CommonParameters.camCode;
            c0.serialNo = CommonParameters.camSrNum;
            c0.expTime = camExpGlobal;

            camController.listOfCamObs_u.Add(c0);
            try
            {
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

            
            grabbedImage[nIndex] = new System.Drawing.Bitmap((int)pFrameInfo.nWidth, (int)pFrameInfo.nHeight, (int)pFrameInfo.nWidth * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, pData);
            Console.WriteLine("image captured from Cam  " + nIndex.ToString() + "   frame no:" + m_nFrames[nIndex].ToString());
            //-----color end

            Rectangle rect = new Rectangle(0, 0, grabbedImage[nIndex].Width, grabbedImage[nIndex].Height);
            Bitmap grabbedImageColor = grabbedImage[nIndex].Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Bitmap grabbedImageRet = grabbedImage[nIndex].Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            if (nIndex == 0)
            {
                //globalVars.algo.drawROI(grabbedImageColor, grabbedImageColor, 100, 100, grabbedImageRet.Width - 200, grabbedImageRet.Height - 200);
                grabbedImageColor.Save("imageCam0.bmp");

                Task.Factory.StartNew(() => {
                    pictureBoxZoom.Invoke(new Action(() => pictureBoxZoom.Size = new Size(1055, 767)));
                    pictureBoxZoom.Invoke(new Action(() => pictureBoxZoom.Invalidate()));
                    pictureBoxZoom.Invoke(new Action(() => pictureBoxZoom.Image = grabbedImageColor));
                });
             
                


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
        public CreateModel()
        {
            InitializeComponent();
        }

        private void picboxOne_Click(object sender, EventArgs e)
        {

        }
        Bitmap bitmapCharger;
        private void CreateModel_Load(object sender, EventArgs e)
        {
            bitmapCharger = new Bitmap(String.Format(@"{0}\Resources\image\Left\Image_20220406115613936.bmp", CommonParameters.projectDirectory));
            pictureBoxZoom.Image = bitmapCharger;
            pictureBoxZoom.MouseWheel += PictureBoxZoom_MouseWheel;
            comboBoxDirection.SelectedIndex = 0;
            connectAllCams(1);
            modelData = JsonConvert.DeserializeObject<Model>(File.ReadAllText(string.Format(@"{0}\Models\{1}\{2}\ModelData.json", 
                CommonParameters.projectDirectory, Model.ModelName, CommonParameters.camCode)));

            checkTemplate.updatePara();
            checkEdge.updatePara();
            startCamAcq();
            camerasStarted = true;


            if (CommonParameters.camCode == "SecondCam")
            {
                buttonRegCam2.Visible = false;
            }
            numeric_exposure_time.Value = Convert.ToDecimal(camExpGlobal);
            tools_option_gb.Visible = false;
            modelData.Camera_exposer = (float)numeric_exposure_time.Value;


        }

        private void PictureBoxZoom_MouseWheel(object sender, MouseEventArgs e)
        {
            if (pictureBoxZoom.Image != null)
            {
                // Mouse Wheel is Moved
                if (e.Delta > 0)
                {
                    //PictureBox Dimensions Are range in 15
                    if (pictureBoxZoom.Width < (10 * this.Width) && (pictureBoxZoom.Height < (10 * this.Height)))
                    {
                        //Change pictureBox Size and Multiply Zoomfactor
                        pictureBoxZoom.Width = (int)(pictureBoxZoom.Width * 2);
                        pictureBoxZoom.Height = (int)(pictureBoxZoom.Height * 2);

                        


                        pictureBoxZoom.Invalidate();
                        //Move Picture box
                        //pictureBoxZoom.Top = (int)(e.Y - 1.25 * (e.Y - pictureBoxZoom.Top));
                        //pictureBoxZoom.Left = (int)(e.X - 1.25 * (e.X - pictureBoxZoom.Left));
                    }
                }
                else if ((pictureBoxZoom.Width > panelPbZoom.Width) && (pictureBoxZoom.Height > panelPbZoom.Height))

                // {  //PictureBox Dimensions Are range in 15
                //if (pictureBoxZoom.Width > (CableImgPanel.Width) && (pictureBoxZoom.Height > (CableImgPanel.Height)))
                {
                    //Change pictureBox Size and Multiply Zoomfactor
                    pictureBoxZoom.Width = (int)(pictureBoxZoom.Width / 2);
                    pictureBoxZoom.Height = (int)(pictureBoxZoom.Height / 2);

                   
                    pictureBoxZoom.Invalidate();
                    //Move Picture box
                    //pictureBoxZoom.Top = (int)(e.Y - 0.80 * (e.Y - pictureBoxZoom.Top));
                    //pictureBoxZoom.Left = (int)(e.X - 0.80 * (e.X - pictureBoxZoom.Left));
                }

                //}
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
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public string bitmap_to_base_64_string(Bitmap _image)
        {
            string base64String = "";
            using (MemoryStream m = new MemoryStream())
            {
                _image.Save(m, ImageFormat.Bmp);
                byte[] imageBytes = m.ToArray();
                base64String = Convert.ToBase64String(imageBytes);

            }

            return base64String;

        }

        private void btn_test_algo_Click(object sender, EventArgs e)
        {
            
            try
            {
                pictureBoxZoom.Image = templateImage;
                switch (comboBoxTool.SelectedItem.ToString())
                {
                    case "Temp Match":

                        checkTemplate.matchScore = numericUpDownMatchScore.Value;
                        checkTemplate.threshold = numericUpDownTempThreshold.Value;
                        checkTemplate.shiftToleranceX = numericUpDownShiftToleranceX.Value;
                        checkTemplate.shiftToleranceY = numericUpDownShiftToleranceY.Value;
                        
                        modelData.CheckTemplates.Add(checkTemplate);


                        string path = string.Format(@"{0}\Models\{1}\{2}\{3}.bmp", CommonParameters.projectDirectory,
                            Model.ModelName, CommonParameters.camCode, "tempcheck" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                        Tools.CheckTemplate.Region region = new Tools.CheckTemplate.Region();

                        region.PointX = cropRect.X;
                        region.PointY = cropRect.Y;
                        region.imageWidth = cropRect.Width;
                        region.imageHeight = cropRect.Height;
                        region.TemplateImagePath = path;
                        modelData.CheckTemplates.Last().tempRegion = region;
                        modelData.CheckTemplates.Last().templateImagePath = path;
                        Bitmap bitmap = (Bitmap)pictureBoxZoom.Image.Clone();
                        Bitmap cropped = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        cropped.Save(path);



                        string j = JsonConvert.SerializeObject(modelData.CheckTemplates.Last());

                        //Console.WriteLine("This is temp json {0}", j);

                        Bitmap bitmap1 = bitmap.Clone(new Rectangle(0,0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        
                        

                        string jResult = salcomCpp.TestAlgo_On_image(bitmap1, j, "CheckTemp");

                        
                        pictureBoxZoom.Image = bitmap1;

                        int index = modelData.CheckTemplates.Count() - 1;

                        modelData.CheckTemplates[index] = JsonConvert.DeserializeObject<Tools.CheckTemplate>(jResult);
                        numericUpDownMatchScore.Value = modelData.CheckTemplates[index].matchScore;
                        modelData.CheckTemplates.RemoveAt(index);
                        //modelData.CheckTemplates.Add(checkTemplate);
                        //checkTemplate.SetValues(ref checkTemplate);

                        break;
                    case "Check Edge":

                        checkEdge.threshold = numericUpDownEdgeThreshold.Value;
                        checkEdge.polarity = numericUpDownPolarity.Value;
                        checkEdge.strength = numericUpDownStrength.Value;

                        modelData.CheckEdges.Add(checkEdge);
                        modelData.CheckEdges.Last().direction = comboBoxDirection.SelectedIndex;
                        //modelData.CheckEdges.Last().SetValues();
                        Console.WriteLine("Direction {0} Index {1}", modelData.CheckEdges.Last().direction, comboBoxDirection.SelectedIndex);
                        path = string.Format(@"{0}\Models\{1}\{2}\{3}.bmp", CommonParameters.projectDirectory,
                            Model.ModelName, CommonParameters.camCode, "edgecheck" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                        Tools.CheckEdge.Region regionEdge = new Tools.CheckEdge.Region();

                        regionEdge.PointX = cropRect.X;
                        regionEdge.PointY = cropRect.Y;
                        regionEdge.imageWidth = cropRect.Width;
                        regionEdge.imageHeight = cropRect.Height;
                        regionEdge.TemplateImagePath = path;

                        modelData.CheckEdges.Last().edgeRegion = regionEdge;

                        bitmap = (Bitmap)pictureBoxZoom.Image;
                        cropped = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        cropped.Save(path);

                        j = JsonConvert.SerializeObject(modelData.CheckEdges.Last());
                        //Console.WriteLine("This is edge json {0}", j);


                        bitmap1 = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);


                        jResult = salcomCpp.TestAlgo_On_image(bitmap1, j, "CheckEdge");

                        pictureBoxZoom.Image = bitmap1;


                        //checkEdge = JsonConvert.DeserializeObject<Tools.CheckEdge>(jResult);
                        modelData.CheckEdges.RemoveAt(modelData.CheckEdges.Count - 1);
                        //modelData.CheckEdges.Add(checkEdge);
                        //checkEdge.SetValues();
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxZoom_MouseDown(object sender, MouseEventArgs e)
        {
            if (templateImage != null)
            {
                pictureBoxZoom.Image = templateImage;
                btn_test_algo.Enabled = true;

            }
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                startPoint.X = e.X;
                startPoint.Y = e.Y;

            }
            if (e.Button == MouseButtons.Right)
            {
                mouseDown = false;
                lastLocation = e.Location;

            }

            if (comboBoxTool.Enabled)
            {

            }
        }

        private void pictureBoxZoom_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true && e.Button == MouseButtons.Left)
            {
                endPoint.X = e.X;
                endPoint.Y = e.Y;
                pictureBoxZoom.Invalidate();
            }
        }


        private void pictureBoxZoom_MouseUp(object sender, MouseEventArgs e)
        {
           
            mouseDown = false;
            DialogResult dialogResult = MessageBox.Show("Is cropped area correct ?", "Confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes && modelData.OriginalImagePath == null)
            {
                Console.WriteLine("This is templ");
                string path = string.Format(@"{0}\Models\{1}\{2}\{3}.bmp", CommonParameters.projectDirectory, Model.ModelName, CommonParameters.camCode, "Original" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                Bitmap bitmap = (Bitmap)pictureBoxZoom.Image;
                bitmap.Save(path);
                modelData.OriginalImagePath = path;

                path = string.Format(@"{0}\Models\{1}\{2}\{3}.bmp", CommonParameters.projectDirectory, Model.ModelName, CommonParameters.camCode, "Template" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));

                Bitmap cropped = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                cropped.Save(path);
                templateImage = (Bitmap)cropped.Clone();
                pictureBoxZoom.Image = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                Tools.CheckEdge.Region regionTempCord = new Tools.CheckEdge.Region();

                regionTempCord.PointX = cropRect.X;
                regionTempCord.PointY = cropRect.Y;
                regionTempCord.imageWidth = cropRect.Width;
                regionTempCord.imageHeight = cropRect.Height;
                regionTempCord.TemplateImagePath = path;

                modelData.TemplateCoordinate = regionTempCord;
                modelData.TemplateImagePath = path;
                startPoint = new Point(0, 0);
                endPoint = new Point(0, 0);
                pictureBoxZoom.Invalidate();
                comboBoxTool.SelectedIndex = 0;
                MessageBox.Show("First Template cropped. Select tool and set parameters.");
                comboBoxTool.Enabled = true;
                //btn_test_algo.Enabled = true;
                //buttonSaveTool.Enabled = true;
                //btn_save_model.Enabled = true;
                comboBoxTool.SelectedIndex = 0;
                tools_option_gb.Visible = true;
            }
            else if(dialogResult == DialogResult.Yes && modelData.OriginalImagePath != null)
            {
                btn_test_algo.Enabled = true;
                buttonSaveTool.Enabled = true;
                //switch (comboBoxTool.SelectedItem.ToString())
                //{
                //    case "Temp Match":
                //        modelData.CheckTemplates.Add(new Tools.CheckTemplate());
                //        modelData.CheckTemplates.Last().updatePara();
                //        modelData.CheckTemplates.Last().SetValues();


                //        string path = string.Format(@"{0}\Models\{1}\{2}.bmp", CommonParameters.projectDirectory, 
                //            Model.ModelName, "tempcheck" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                //        Tools.CheckTemplate.Region region = new Tools.CheckTemplate.Region();

                //        region.PointX = cropRect.X;
                //        region.PointY = cropRect.Y;
                //        region.imageWidth = cropRect.Width;
                //        region.imageHeight = cropRect.Height;
                //        region.TemplateImagePath = path;
                //        modelData.CheckTemplates.Last().tempRegion = region;
                //        Bitmap bitmap = (Bitmap)pictureBoxZoom.Image;
                //        Bitmap cropped = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //        cropped.Save(path);

                //        break;
                //    case "Check Edge":

                //        modelData.CheckEdges.Add(new Tools.CheckEdge());
                //        modelData.CheckEdges.Last().updatePara();
                //        modelData.CheckEdges.Last().SetValues();

                //        path = string.Format(@"{0}\Models\{1}\{2}.bmp", CommonParameters.projectDirectory,
                //            Model.ModelName, "edgecheck" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss"));
                //        Tools.CheckEdge.Region regionEdge = new Tools.CheckEdge.Region();

                //        regionEdge.PointX = cropRect.X;
                //        regionEdge.PointY = cropRect.Y;
                //        regionEdge.imageWidth = cropRect.Width;
                //        regionEdge.imageHeight = cropRect.Height;
                //        regionEdge.TemplateImagePath = path;

                //        modelData.CheckEdges.Last().edgeRegion = regionEdge;

                //        bitmap = (Bitmap)pictureBoxZoom.Image;
                //        cropped = bitmap.Clone(cropRect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //        cropped.Save(path);


                //        break;
                //    default:
                //        break;
                //}
            }
            
        }

        private void pictureBoxZoom_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.DeepSkyBlue, 2);

            var rc = new Rectangle(
                    Math.Min(startPoint.X, endPoint.X),
                    Math.Min(startPoint.Y, endPoint.Y),
                    Math.Abs(endPoint.X - startPoint.X),
                    Math.Abs(endPoint.Y - startPoint.Y));


           

            if (rc.Width > 0 && rc.Height > 0 )
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

            //Console.WriteLine("CR Width B4 {0} CR Height B4 {1}", cropRect.Width, cropRect.Height);


            pen = new Pen(Color.Orange, 2);
            e.Graphics.DrawRectangle(pen, rc);
            
        }

        private void CreateModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectAllCams();
            if (CommonParameters.camCode == "SecondCam")
            {
                Forms.registerModel = null;
            }
        }

        void SetControlsOnCheckEdge()
        {
            panelEdge.Location = new Point(16, 38);
            panelEdge.Visible = true;
            panelCheckTemp.Visible = false;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var trackBars = GetAll(this, typeof(TrackBar));
            TextBox textBox = (TextBox)sender;

            if (e.KeyCode == Keys.Enter && textBox.Text != "" && float.TryParse(textBox.Text, out float n) == true)
            {
                for (int i = 0; i < modelData.CheckTemplates.Count; i++)
                {
                    for (int j = 0; j < modelData.CheckTemplates[i].List.Count; i++)
                    {
                        if (textBox.Name.Remove(0, 7) == modelData.CheckTemplates[i].List[0].nodeName)
                        {

                            modelData.CheckTemplates[i].List[i].nodeVal = decimal.Parse(textBox.Text);
                            textBox.Text = modelData.CheckTemplates[i].List[i].nodeVal.ToString();

                            
                        }
                    }
                    
                }
            }
        }


        void SetTempControls()
        {

            try
            {
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

        void SetEdgeControls()
        {
            
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
                        Console.WriteLine("Node name {0} nud value {1} node value {3}", checkEdge.List[i].nodeName, numericUpDown.Value, checkEdge.List[i].nodeVal);

                        checkEdge.List[i].nodeVal = numericUpDown.Value;
                        numericUpDown.Value = checkEdge.List[i].nodeVal;
                        Console.WriteLine("Node value {0}", checkEdge.List[i].nodeVal);

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            

        }
        private void comboBoxTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTool.SelectedItem.ToString())
            {
                case "Temp Match":
                    SetTempControls();

                    break;

                case "Check Edge":
                    SetEdgeControls();

                    break;

                default:
                    break;
            }
        }

        private void btn_save_model_Click(object sender, EventArgs e)
        {
            if (modelData.CheckTemplates.Count > 0 || modelData.CheckEdges.Count > 0)
            {
                Console.WriteLine("Temp Coord {0}", modelData.TemplateCoordinate);

                string path = string.Format(@"{0}\Models\{1}\{2}", CommonParameters.projectDirectory, Model.ModelName, CommonParameters.camCode);
                string modelResult = JsonConvert.SerializeObject(modelData, Formatting.Indented);
                File.WriteAllText(path + @"\ModelData.json", modelResult);
                tools_option_gb.Visible = false;
                MessageBox.Show("Model Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Add any tools before saving.");
            }
           

        }

        private void btn_set_Click(object sender, EventArgs e)
        {

            modelData.Camera_exposer = (float)numeric_exposure_time.Value;
            camController.setCamExposure(ref m_pMyCamera[0], (float)numeric_exposure_time.Value);
        }

        

        private void comboBoxDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panelEdge.Visible)
            {

            }
        }
        public static void DeleteDirectoryRecursively(string target_dir)
        {
            foreach (string file in Directory.GetFiles(target_dir))
            {
                File.Delete(file);
            }

            foreach (string subDir in Directory.GetDirectories(target_dir))
            {
                DeleteDirectoryRecursively(subDir);
            }

            Thread.Sleep(1); // This makes the difference between whether it works or not. Sleep(0) is not enough.
            Directory.Delete(target_dir);
        }

        private void buttonRegCam2_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Register for Cam2 ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dR == DialogResult.OK)
            {
                this.Close();
                CommonParameters.camSrNum = "02J06350890";
                CommonParameters.camCode = "SecondCam";


                string path = string.Format(@"{0}\Models\{1}\{2}", CommonParameters.projectDirectory, Model.ModelName, CommonParameters.camCode);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Directory.CreateDirectory(path + @"\Images");

                    Model model = new Model();
                    //model.CheckEdges.Add(new Tools.CheckEdge());
                    //model.CheckTemplates.Add(new Tools.CheckTemplate());
                    string modelResult = JsonConvert.SerializeObject(model);
                    File.WriteAllText(path + @"\ModelData.json", modelResult);

                    CreateModel createModel = new CreateModel();
                    createModel.Show();

                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Model already exists. Overwrite model data and delete model Images ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        DeleteDirectoryRecursively(path);
                        Directory.CreateDirectory(path);
                        Directory.CreateDirectory(path + @"\Images");
                        Model model = new Model();
                        //model.CheckTemplates.Add(new Tools.CheckTemplate());
                        //model.CheckEdges.Add(new Tools.CheckEdge());
                        string modelResult = JsonConvert.SerializeObject(model, Formatting.Indented);
                        File.WriteAllText(path + @"\ModelData.json", modelResult);
                        Cursor.Current = Cursors.Default;
                        CreateModel createModel = new CreateModel();
                        createModel.Show();

                    }
                    else
                    {
                        return;
                    }

                }
            }
            
            
        }

        private void buttonSaveTool_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxTool.SelectedItem.ToString())
                {
                    case "Temp Match":
                        modelData.CheckTemplates.Add(checkTemplate);
                        break;
                    case "Check Edge":
                        modelData.CheckEdges.Add(checkEdge);
                        break;
                    default:
                        break;
                }

                labelToolsCount.Text = (modelData.CheckEdges.Count + modelData.CheckTemplates.Count).ToString();
                btn_test_algo.Enabled = false;

                checkEdge = new Tools.CheckEdge();
                checkEdge.updatePara();
                checkTemplate = new Tools.CheckTemplate();
                checkTemplate.updatePara();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void checkBoxCreateMode_CheckedChanged(object sender, EventArgs e)
        {
                
        }

        

        private void cb_cam_live_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        
        

        private void rdbLive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLive.Checked)
            {
                camController.setTriggerMode(ref m_pMyCamera[0], !rdbLive.Checked, true);

            }
        }

        private void rdbCM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCM.Checked)
            {
                camController.setTriggerMode(ref m_pMyCamera[0], rdbCM.Checked, true);

            }
        }
    }
}
