namespace SalcompTwoCam
{
    partial class CreateModel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_save_model = new System.Windows.Forms.Button();
            this.comboBoxTool = new System.Windows.Forms.ComboBox();
            this.tools_option_gb = new System.Windows.Forms.GroupBox();
            this.labelToolsCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSaveTool = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCheckTemp = new System.Windows.Forms.Panel();
            this.numericUpDownMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownShiftToleranceY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownShiftToleranceX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownTempThreshold = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panelEdge = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.numericUpDownStrength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPolarity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEdgeThreshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngleTolerance = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.btn_test_algo = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_camera_status = new System.Windows.Forms.Label();
            this.numeric_exposure_time = new System.Windows.Forms.NumericUpDown();
            this.lbl_exposure_time = new System.Windows.Forms.Label();
            this.btn_set = new System.Windows.Forms.Button();
            this.timer_camera_status = new System.Windows.Forms.Timer(this.components);
            this.live_timer = new System.Windows.Forms.Timer(this.components);
            this.panelPbZoom = new System.Windows.Forms.Panel();
            this.pictureBoxZoom = new System.Windows.Forms.PictureBox();
            this.buttonRegCam2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbClrBlack = new System.Windows.Forms.RadioButton();
            this.rdbClrWhite = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbCM = new System.Windows.Forms.RadioButton();
            this.rdbLive = new System.Windows.Forms.RadioButton();
            this.picBoxThresholdImage = new System.Windows.Forms.PictureBox();
            this.picCroppedPicture = new System.Windows.Forms.PictureBox();
            this.tools_option_gb.SuspendLayout();
            this.panelCheckTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftToleranceY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftToleranceX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempThreshold)).BeginInit();
            this.panelEdge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPolarity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdgeThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_exposure_time)).BeginInit();
            this.panelPbZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThresholdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCroppedPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save_model
            // 
            this.btn_save_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_model.ForeColor = System.Drawing.Color.Brown;
            this.btn_save_model.Location = new System.Drawing.Point(1196, 875);
            this.btn_save_model.Name = "btn_save_model";
            this.btn_save_model.Size = new System.Drawing.Size(319, 41);
            this.btn_save_model.TabIndex = 4;
            this.btn_save_model.Text = "Save Model";
            this.btn_save_model.UseVisualStyleBackColor = true;
            this.btn_save_model.Click += new System.EventHandler(this.btn_save_model_Click);
            // 
            // comboBoxTool
            // 
            this.comboBoxTool.BackColor = System.Drawing.Color.White;
            this.comboBoxTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTool.Enabled = false;
            this.comboBoxTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTool.ForeColor = System.Drawing.Color.Black;
            this.comboBoxTool.FormattingEnabled = true;
            this.comboBoxTool.Items.AddRange(new object[] {
            "Temp Match",
            "Check Edge"});
            this.comboBoxTool.Location = new System.Drawing.Point(198, 32);
            this.comboBoxTool.Name = "comboBoxTool";
            this.comboBoxTool.Size = new System.Drawing.Size(157, 28);
            this.comboBoxTool.TabIndex = 69;
            this.comboBoxTool.SelectedIndexChanged += new System.EventHandler(this.comboBoxTool_SelectedIndexChanged);
            // 
            // tools_option_gb
            // 
            this.tools_option_gb.BackColor = System.Drawing.Color.White;
            this.tools_option_gb.Controls.Add(this.labelToolsCount);
            this.tools_option_gb.Controls.Add(this.label7);
            this.tools_option_gb.Controls.Add(this.buttonSaveTool);
            this.tools_option_gb.Controls.Add(this.label2);
            this.tools_option_gb.Controls.Add(this.panelCheckTemp);
            this.tools_option_gb.Controls.Add(this.panelEdge);
            this.tools_option_gb.Controls.Add(this.btn_test_algo);
            this.tools_option_gb.Controls.Add(this.comboBoxTool);
            this.tools_option_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tools_option_gb.Location = new System.Drawing.Point(1140, 419);
            this.tools_option_gb.Name = "tools_option_gb";
            this.tools_option_gb.Size = new System.Drawing.Size(396, 441);
            this.tools_option_gb.TabIndex = 70;
            this.tools_option_gb.TabStop = false;
            this.tools_option_gb.Text = "Parameters";
            // 
            // labelToolsCount
            // 
            this.labelToolsCount.AutoSize = true;
            this.labelToolsCount.Location = new System.Drawing.Point(206, 342);
            this.labelToolsCount.Name = "labelToolsCount";
            this.labelToolsCount.Size = new System.Drawing.Size(18, 20);
            this.labelToolsCount.TabIndex = 76;
            this.labelToolsCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 75;
            this.label7.Text = "Tools Saved :";
            // 
            // buttonSaveTool
            // 
            this.buttonSaveTool.Enabled = false;
            this.buttonSaveTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveTool.ForeColor = System.Drawing.Color.Green;
            this.buttonSaveTool.Location = new System.Drawing.Point(208, 375);
            this.buttonSaveTool.Name = "buttonSaveTool";
            this.buttonSaveTool.Size = new System.Drawing.Size(147, 41);
            this.buttonSaveTool.TabIndex = 74;
            this.buttonSaveTool.Text = "Save Tool";
            this.buttonSaveTool.UseVisualStyleBackColor = true;
            this.buttonSaveTool.Click += new System.EventHandler(this.buttonSaveTool_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 93;
            this.label2.Text = "Tool Selection:";
            // 
            // panelCheckTemp
            // 
            this.panelCheckTemp.Controls.Add(this.numericUpDownMatchScore);
            this.panelCheckTemp.Controls.Add(this.label12);
            this.panelCheckTemp.Controls.Add(this.label11);
            this.panelCheckTemp.Controls.Add(this.numericUpDownShiftToleranceY);
            this.panelCheckTemp.Controls.Add(this.numericUpDownShiftToleranceX);
            this.panelCheckTemp.Controls.Add(this.label10);
            this.panelCheckTemp.Controls.Add(this.numericUpDownTempThreshold);
            this.panelCheckTemp.Controls.Add(this.label9);
            this.panelCheckTemp.Location = new System.Drawing.Point(17, 79);
            this.panelCheckTemp.Name = "panelCheckTemp";
            this.panelCheckTemp.Size = new System.Drawing.Size(363, 172);
            this.panelCheckTemp.TabIndex = 73;
            this.panelCheckTemp.Visible = false;
            // 
            // numericUpDownMatchScore
            // 
            this.numericUpDownMatchScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMatchScore.Location = new System.Drawing.Point(200, 27);
            this.numericUpDownMatchScore.Name = "numericUpDownMatchScore";
            this.numericUpDownMatchScore.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownMatchScore.TabIndex = 70;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 24);
            this.label12.TabIndex = 72;
            this.label12.Text = "Shift ToleranceY";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 24);
            this.label11.TabIndex = 72;
            this.label11.Text = "Shift ToleranceX";
            // 
            // numericUpDownShiftToleranceY
            // 
            this.numericUpDownShiftToleranceY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownShiftToleranceY.Location = new System.Drawing.Point(200, 130);
            this.numericUpDownShiftToleranceY.Name = "numericUpDownShiftToleranceY";
            this.numericUpDownShiftToleranceY.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownShiftToleranceY.TabIndex = 70;
            // 
            // numericUpDownShiftToleranceX
            // 
            this.numericUpDownShiftToleranceX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownShiftToleranceX.Location = new System.Drawing.Point(200, 95);
            this.numericUpDownShiftToleranceX.Name = "numericUpDownShiftToleranceX";
            this.numericUpDownShiftToleranceX.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownShiftToleranceX.TabIndex = 70;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 24);
            this.label10.TabIndex = 72;
            this.label10.Text = "TempThreshold";
            // 
            // numericUpDownTempThreshold
            // 
            this.numericUpDownTempThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTempThreshold.Location = new System.Drawing.Point(200, 60);
            this.numericUpDownTempThreshold.Name = "numericUpDownTempThreshold";
            this.numericUpDownTempThreshold.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownTempThreshold.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 24);
            this.label9.TabIndex = 72;
            this.label9.Text = "MatchScore";
            // 
            // panelEdge
            // 
            this.panelEdge.Controls.Add(this.label6);
            this.panelEdge.Controls.Add(this.label5);
            this.panelEdge.Controls.Add(this.label4);
            this.panelEdge.Controls.Add(this.label3);
            this.panelEdge.Controls.Add(this.label8);
            this.panelEdge.Controls.Add(this.comboBoxDirection);
            this.panelEdge.Controls.Add(this.numericUpDownStrength);
            this.panelEdge.Controls.Add(this.label1);
            this.panelEdge.Controls.Add(this.numericUpDownPolarity);
            this.panelEdge.Controls.Add(this.numericUpDownEdgeThreshold);
            this.panelEdge.Controls.Add(this.numericUpDownAngleTolerance);
            this.panelEdge.Controls.Add(this.numericUpDownAngle);
            this.panelEdge.Location = new System.Drawing.Point(14, 79);
            this.panelEdge.Name = "panelEdge";
            this.panelEdge.Size = new System.Drawing.Size(363, 244);
            this.panelEdge.TabIndex = 72;
            this.panelEdge.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 24);
            this.label6.TabIndex = 72;
            this.label6.Text = "Strength";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 72;
            this.label5.Text = "Polarity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 24);
            this.label4.TabIndex = 72;
            this.label4.Text = "Threshold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 72;
            this.label3.Text = "Angle";
            this.label3.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 24);
            this.label8.TabIndex = 72;
            this.label8.Text = "Direction";
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "Vertical",
            "Horizontal"});
            this.comboBoxDirection.Location = new System.Drawing.Point(196, 11);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(137, 28);
            this.comboBoxDirection.TabIndex = 71;
            this.comboBoxDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirection_SelectedIndexChanged);
            // 
            // numericUpDownStrength
            // 
            this.numericUpDownStrength.DecimalPlaces = 1;
            this.numericUpDownStrength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownStrength.Location = new System.Drawing.Point(196, 118);
            this.numericUpDownStrength.Name = "numericUpDownStrength";
            this.numericUpDownStrength.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownStrength.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 72;
            this.label1.Text = "AngleTolerance";
            this.label1.Visible = false;
            // 
            // numericUpDownPolarity
            // 
            this.numericUpDownPolarity.Location = new System.Drawing.Point(196, 86);
            this.numericUpDownPolarity.Name = "numericUpDownPolarity";
            this.numericUpDownPolarity.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownPolarity.TabIndex = 70;
            // 
            // numericUpDownEdgeThreshold
            // 
            this.numericUpDownEdgeThreshold.Location = new System.Drawing.Point(196, 54);
            this.numericUpDownEdgeThreshold.Name = "numericUpDownEdgeThreshold";
            this.numericUpDownEdgeThreshold.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownEdgeThreshold.TabIndex = 70;
            // 
            // numericUpDownAngleTolerance
            // 
            this.numericUpDownAngleTolerance.Location = new System.Drawing.Point(196, 156);
            this.numericUpDownAngleTolerance.Name = "numericUpDownAngleTolerance";
            this.numericUpDownAngleTolerance.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownAngleTolerance.TabIndex = 70;
            this.numericUpDownAngleTolerance.Visible = false;
            // 
            // numericUpDownAngle
            // 
            this.numericUpDownAngle.Location = new System.Drawing.Point(196, 188);
            this.numericUpDownAngle.Name = "numericUpDownAngle";
            this.numericUpDownAngle.Size = new System.Drawing.Size(137, 26);
            this.numericUpDownAngle.TabIndex = 70;
            this.numericUpDownAngle.Visible = false;
            // 
            // btn_test_algo
            // 
            this.btn_test_algo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test_algo.ForeColor = System.Drawing.Color.Green;
            this.btn_test_algo.Location = new System.Drawing.Point(36, 375);
            this.btn_test_algo.Name = "btn_test_algo";
            this.btn_test_algo.Size = new System.Drawing.Size(156, 41);
            this.btn_test_algo.TabIndex = 69;
            this.btn_test_algo.Text = "Test Algo ";
            this.btn_test_algo.UseVisualStyleBackColor = true;
            this.btn_test_algo.Click += new System.EventHandler(this.btn_test_algo_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Red;
            this.btn_exit.Location = new System.Drawing.Point(1353, 932);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(183, 44);
            this.btn_exit.TabIndex = 76;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_camera_status
            // 
            this.lbl_camera_status.AutoSize = true;
            this.lbl_camera_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_camera_status.Location = new System.Drawing.Point(-4, 840);
            this.lbl_camera_status.Name = "lbl_camera_status";
            this.lbl_camera_status.Size = new System.Drawing.Size(139, 20);
            this.lbl_camera_status.TabIndex = 72;
            this.lbl_camera_status.Text = "lbl_camera_status";
            // 
            // numeric_exposure_time
            // 
            this.numeric_exposure_time.ForeColor = System.Drawing.Color.DarkGreen;
            this.numeric_exposure_time.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numeric_exposure_time.Location = new System.Drawing.Point(1243, 288);
            this.numeric_exposure_time.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numeric_exposure_time.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numeric_exposure_time.Name = "numeric_exposure_time";
            this.numeric_exposure_time.Size = new System.Drawing.Size(120, 20);
            this.numeric_exposure_time.TabIndex = 72;
            this.numeric_exposure_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numeric_exposure_time.Value = new decimal(new int[] {
            850,
            0,
            0,
            0});
            // 
            // lbl_exposure_time
            // 
            this.lbl_exposure_time.AutoSize = true;
            this.lbl_exposure_time.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_exposure_time.Location = new System.Drawing.Point(1143, 290);
            this.lbl_exposure_time.Name = "lbl_exposure_time";
            this.lbl_exposure_time.Size = new System.Drawing.Size(94, 13);
            this.lbl_exposure_time.TabIndex = 73;
            this.lbl_exposure_time.Text = "Exposure Time(us)";
            // 
            // btn_set
            // 
            this.btn_set.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_set.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_set.Location = new System.Drawing.Point(1369, 286);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(68, 22);
            this.btn_set.TabIndex = 74;
            this.btn_set.Text = "Set";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // panelPbZoom
            // 
            this.panelPbZoom.AutoScroll = true;
            this.panelPbZoom.Controls.Add(this.pictureBoxZoom);
            this.panelPbZoom.Location = new System.Drawing.Point(18, 14);
            this.panelPbZoom.Name = "panelPbZoom";
            this.panelPbZoom.Size = new System.Drawing.Size(1077, 796);
            this.panelPbZoom.TabIndex = 143;
            this.panelPbZoom.TabStop = true;
            // 
            // pictureBoxZoom
            // 
            this.pictureBoxZoom.Location = new System.Drawing.Point(14, 19);
            this.pictureBoxZoom.Name = "pictureBoxZoom";
            this.pictureBoxZoom.Size = new System.Drawing.Size(1055, 767);
            this.pictureBoxZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxZoom.TabIndex = 141;
            this.pictureBoxZoom.TabStop = false;
            this.pictureBoxZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxZoom_Paint);
            this.pictureBoxZoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxZoom_MouseDown);
            this.pictureBoxZoom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxZoom_MouseMove);
            this.pictureBoxZoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxZoom_MouseUp);
            // 
            // buttonRegCam2
            // 
            this.buttonRegCam2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegCam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegCam2.Location = new System.Drawing.Point(1158, 932);
            this.buttonRegCam2.Name = "buttonRegCam2";
            this.buttonRegCam2.Size = new System.Drawing.Size(164, 44);
            this.buttonRegCam2.TabIndex = 144;
            this.buttonRegCam2.Text = "Register Cam2";
            this.buttonRegCam2.UseVisualStyleBackColor = true;
            this.buttonRegCam2.Click += new System.EventHandler(this.buttonRegCam2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbClrBlack);
            this.groupBox2.Controls.Add(this.rdbClrWhite);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1400, 337);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 76);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Charger Color";
            this.groupBox2.Visible = false;
            // 
            // rdbClrBlack
            // 
            this.rdbClrBlack.AutoSize = true;
            this.rdbClrBlack.Location = new System.Drawing.Point(149, 23);
            this.rdbClrBlack.Name = "rdbClrBlack";
            this.rdbClrBlack.Size = new System.Drawing.Size(63, 22);
            this.rdbClrBlack.TabIndex = 1;
            this.rdbClrBlack.Text = "Black";
            this.rdbClrBlack.UseVisualStyleBackColor = true;
            // 
            // rdbClrWhite
            // 
            this.rdbClrWhite.AutoSize = true;
            this.rdbClrWhite.Checked = true;
            this.rdbClrWhite.Location = new System.Drawing.Point(27, 23);
            this.rdbClrWhite.Name = "rdbClrWhite";
            this.rdbClrWhite.Size = new System.Drawing.Size(64, 22);
            this.rdbClrWhite.TabIndex = 0;
            this.rdbClrWhite.TabStop = true;
            this.rdbClrWhite.Text = "White";
            this.rdbClrWhite.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(149, 23);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(63, 22);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Text = "Black";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(27, 23);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(64, 22);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "White";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbCM);
            this.groupBox1.Controls.Add(this.rdbLive);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1153, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 76);
            this.groupBox1.TabIndex = 145;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture Mode";
            // 
            // rdbCM
            // 
            this.rdbCM.AutoSize = true;
            this.rdbCM.Location = new System.Drawing.Point(90, 36);
            this.rdbCM.Name = "rdbCM";
            this.rdbCM.Size = new System.Drawing.Size(112, 22);
            this.rdbCM.TabIndex = 1;
            this.rdbCM.Text = "Create Mode";
            this.rdbCM.UseVisualStyleBackColor = true;
            this.rdbCM.CheckedChanged += new System.EventHandler(this.rdbCM_CheckedChanged);
            // 
            // rdbLive
            // 
            this.rdbLive.AutoSize = true;
            this.rdbLive.Checked = true;
            this.rdbLive.Location = new System.Drawing.Point(20, 36);
            this.rdbLive.Name = "rdbLive";
            this.rdbLive.Size = new System.Drawing.Size(52, 22);
            this.rdbLive.TabIndex = 0;
            this.rdbLive.TabStop = true;
            this.rdbLive.Text = "Live";
            this.rdbLive.UseVisualStyleBackColor = true;
            this.rdbLive.CheckedChanged += new System.EventHandler(this.rdbLive_CheckedChanged);
            // 
            // picBoxThresholdImage
            // 
            this.picBoxThresholdImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picBoxThresholdImage.Location = new System.Drawing.Point(1141, 179);
            this.picBoxThresholdImage.Name = "picBoxThresholdImage";
            this.picBoxThresholdImage.Size = new System.Drawing.Size(212, 98);
            this.picBoxThresholdImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxThresholdImage.TabIndex = 77;
            this.picBoxThresholdImage.TabStop = false;
            // 
            // picCroppedPicture
            // 
            this.picCroppedPicture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picCroppedPicture.Location = new System.Drawing.Point(1141, 17);
            this.picCroppedPicture.Name = "picCroppedPicture";
            this.picCroppedPicture.Size = new System.Drawing.Size(423, 260);
            this.picCroppedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCroppedPicture.TabIndex = 3;
            this.picCroppedPicture.TabStop = false;
            // 
            // CreateModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1860, 1006);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRegCam2);
            this.Controls.Add(this.panelPbZoom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_save_model);
            this.Controls.Add(this.picBoxThresholdImage);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_camera_status);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.lbl_exposure_time);
            this.Controls.Add(this.numeric_exposure_time);
            this.Controls.Add(this.tools_option_gb);
            this.Controls.Add(this.picCroppedPicture);
            this.Name = "CreateModel";
            this.Text = "CreatModel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateModel_FormClosing);
            this.Load += new System.EventHandler(this.CreateModel_Load);
            this.tools_option_gb.ResumeLayout(false);
            this.tools_option_gb.PerformLayout();
            this.panelCheckTemp.ResumeLayout(false);
            this.panelCheckTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatchScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftToleranceY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftToleranceX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempThreshold)).EndInit();
            this.panelEdge.ResumeLayout(false);
            this.panelEdge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPolarity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdgeThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_exposure_time)).EndInit();
            this.panelPbZoom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThresholdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCroppedPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picCroppedPicture;
        private System.Windows.Forms.Button btn_save_model;
        private System.Windows.Forms.ComboBox comboBoxTool;
        private System.Windows.Forms.GroupBox tools_option_gb;
        private System.Windows.Forms.Button btn_test_algo;
        private System.Windows.Forms.Label lbl_camera_status;
        private System.Windows.Forms.NumericUpDown numeric_exposure_time;
        private System.Windows.Forms.Label lbl_exposure_time;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Timer timer_camera_status;
        private System.Windows.Forms.Timer live_timer;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.PictureBox picBoxThresholdImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelPbZoom;
        private System.Windows.Forms.PictureBox pictureBoxZoom;
        private System.Windows.Forms.NumericUpDown numericUpDownAngleTolerance;
        private System.Windows.Forms.NumericUpDown numericUpDownStrength;
        private System.Windows.Forms.NumericUpDown numericUpDownPolarity;
        private System.Windows.Forms.NumericUpDown numericUpDownEdgeThreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownAngle;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.Panel panelEdge;
        private System.Windows.Forms.Panel panelCheckTemp;
        private System.Windows.Forms.NumericUpDown numericUpDownMatchScore;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftToleranceX;
        private System.Windows.Forms.NumericUpDown numericUpDownTempThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftToleranceY;
        private System.Windows.Forms.Button buttonRegCam2;
        private System.Windows.Forms.Button buttonSaveTool;
        private System.Windows.Forms.Label labelToolsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbClrBlack;
        private System.Windows.Forms.RadioButton rdbClrWhite;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbCM;
        private System.Windows.Forms.RadioButton rdbLive;
    }
}
