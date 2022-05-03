
namespace SalcompTwoCam
{
    partial class EditModel
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
            this.lbl_rect = new System.Windows.Forms.Label();
            this.lbl_points = new System.Windows.Forms.Label();
            this.tools_option_gb = new System.Windows.Forms.GroupBox();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.numericUpDownStrength = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownPolarity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEdgeThreshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngleTolerance = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.btnSelectROI = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxEdge = new System.Windows.Forms.CheckBox();
            this.checkBoxTemp = new System.Windows.Forms.CheckBox();
            this.cb_is_match = new System.Windows.Forms.CheckBox();
            this.btn_test_algo = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.timer_camera_status = new System.Windows.Forms.Timer(this.components);
            this.live_timer = new System.Windows.Forms.Timer(this.components);
            this.cb_model_name = new System.Windows.Forms.ComboBox();
            this.cb_region_name = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_cam_live = new System.Windows.Forms.CheckBox();
            this.checkBoxCreate = new System.Windows.Forms.CheckBox();
            this.comboBoxCam = new System.Windows.Forms.ComboBox();
            this.panelPbZoom = new System.Windows.Forms.Panel();
            this.pictureBoxZoom = new System.Windows.Forms.PictureBox();
            this.buttonSaveModel = new System.Windows.Forms.Button();
            this.buttonTestImage = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.panelPbZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save_model
            // 
            this.btn_save_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_model.ForeColor = System.Drawing.Color.Black;
            this.btn_save_model.Location = new System.Drawing.Point(133, 329);
            this.btn_save_model.Name = "btn_save_model";
            this.btn_save_model.Size = new System.Drawing.Size(121, 35);
            this.btn_save_model.TabIndex = 4;
            this.btn_save_model.Text = "Update";
            this.btn_save_model.UseVisualStyleBackColor = true;
            this.btn_save_model.Click += new System.EventHandler(this.btn_save_model_Click);
            // 
            // lbl_rect
            // 
            this.lbl_rect.AutoSize = true;
            this.lbl_rect.Location = new System.Drawing.Point(1190, 396);
            this.lbl_rect.Name = "lbl_rect";
            this.lbl_rect.Size = new System.Drawing.Size(31, 13);
            this.lbl_rect.TabIndex = 37;
            this.lbl_rect.Text = "- - - - ";
            // 
            // lbl_points
            // 
            this.lbl_points.AutoSize = true;
            this.lbl_points.Location = new System.Drawing.Point(1143, 396);
            this.lbl_points.Name = "lbl_points";
            this.lbl_points.Size = new System.Drawing.Size(31, 13);
            this.lbl_points.TabIndex = 36;
            this.lbl_points.Text = "- - - - ";
            // 
            // tools_option_gb
            // 
            this.tools_option_gb.Controls.Add(this.panelCheckTemp);
            this.tools_option_gb.Controls.Add(this.panelEdge);
            this.tools_option_gb.Controls.Add(this.btnSelectROI);
            this.tools_option_gb.Controls.Add(this.label4);
            this.tools_option_gb.Controls.Add(this.checkBoxEdge);
            this.tools_option_gb.Controls.Add(this.checkBoxTemp);
            this.tools_option_gb.Controls.Add(this.cb_is_match);
            this.tools_option_gb.Controls.Add(this.btn_save_model);
            this.tools_option_gb.Controls.Add(this.btn_test_algo);
            this.tools_option_gb.Location = new System.Drawing.Point(1140, 435);
            this.tools_option_gb.Name = "tools_option_gb";
            this.tools_option_gb.Size = new System.Drawing.Size(396, 375);
            this.tools_option_gb.TabIndex = 70;
            this.tools_option_gb.TabStop = false;
            this.tools_option_gb.Text = "Parameters";
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
            this.panelCheckTemp.Location = new System.Drawing.Point(19, 61);
            this.panelCheckTemp.Name = "panelCheckTemp";
            this.panelCheckTemp.Size = new System.Drawing.Size(363, 184);
            this.panelCheckTemp.TabIndex = 103;
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
            this.panelEdge.Controls.Add(this.label2);
            this.panelEdge.Controls.Add(this.label3);
            this.panelEdge.Controls.Add(this.label8);
            this.panelEdge.Controls.Add(this.comboBoxDirection);
            this.panelEdge.Controls.Add(this.numericUpDownStrength);
            this.panelEdge.Controls.Add(this.label7);
            this.panelEdge.Controls.Add(this.numericUpDownPolarity);
            this.panelEdge.Controls.Add(this.numericUpDownEdgeThreshold);
            this.panelEdge.Controls.Add(this.numericUpDownAngleTolerance);
            this.panelEdge.Controls.Add(this.numericUpDownAngle);
            this.panelEdge.Location = new System.Drawing.Point(21, 31);
            this.panelEdge.Name = "panelEdge";
            this.panelEdge.Size = new System.Drawing.Size(363, 244);
            this.panelEdge.TabIndex = 102;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 72;
            this.label2.Text = "Threshold";
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
            this.comboBoxDirection.Size = new System.Drawing.Size(137, 21);
            this.comboBoxDirection.TabIndex = 71;
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
            this.numericUpDownStrength.Size = new System.Drawing.Size(137, 20);
            this.numericUpDownStrength.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 24);
            this.label7.TabIndex = 72;
            this.label7.Text = "AngleTolerance";
            // 
            // numericUpDownPolarity
            // 
            this.numericUpDownPolarity.Location = new System.Drawing.Point(196, 86);
            this.numericUpDownPolarity.Name = "numericUpDownPolarity";
            this.numericUpDownPolarity.Size = new System.Drawing.Size(137, 20);
            this.numericUpDownPolarity.TabIndex = 70;
            // 
            // numericUpDownEdgeThreshold
            // 
            this.numericUpDownEdgeThreshold.Location = new System.Drawing.Point(196, 54);
            this.numericUpDownEdgeThreshold.Name = "numericUpDownEdgeThreshold";
            this.numericUpDownEdgeThreshold.Size = new System.Drawing.Size(137, 20);
            this.numericUpDownEdgeThreshold.TabIndex = 70;
            // 
            // numericUpDownAngleTolerance
            // 
            this.numericUpDownAngleTolerance.Location = new System.Drawing.Point(196, 156);
            this.numericUpDownAngleTolerance.Name = "numericUpDownAngleTolerance";
            this.numericUpDownAngleTolerance.Size = new System.Drawing.Size(137, 20);
            this.numericUpDownAngleTolerance.TabIndex = 70;
            // 
            // numericUpDownAngle
            // 
            this.numericUpDownAngle.Location = new System.Drawing.Point(196, 188);
            this.numericUpDownAngle.Name = "numericUpDownAngle";
            this.numericUpDownAngle.Size = new System.Drawing.Size(137, 20);
            this.numericUpDownAngle.TabIndex = 70;
            // 
            // btnSelectROI
            // 
            this.btnSelectROI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectROI.Location = new System.Drawing.Point(282, 281);
            this.btnSelectROI.Name = "btnSelectROI";
            this.btnSelectROI.Size = new System.Drawing.Size(108, 30);
            this.btnSelectROI.TabIndex = 101;
            this.btnSelectROI.Text = "Select ROI";
            this.btnSelectROI.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Add Tool ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxEdge
            // 
            this.checkBoxEdge.AutoSize = true;
            this.checkBoxEdge.Location = new System.Drawing.Point(282, 347);
            this.checkBoxEdge.Name = "checkBoxEdge";
            this.checkBoxEdge.Size = new System.Drawing.Size(85, 17);
            this.checkBoxEdge.TabIndex = 2;
            this.checkBoxEdge.Text = "Edge Check";
            this.checkBoxEdge.UseVisualStyleBackColor = true;
            this.checkBoxEdge.CheckedChanged += new System.EventHandler(this.checkBoxEdge_CheckedChanged);
            // 
            // checkBoxTemp
            // 
            this.checkBoxTemp.AutoSize = true;
            this.checkBoxTemp.Location = new System.Drawing.Point(282, 329);
            this.checkBoxTemp.Name = "checkBoxTemp";
            this.checkBoxTemp.Size = new System.Drawing.Size(86, 17);
            this.checkBoxTemp.TabIndex = 90;
            this.checkBoxTemp.Text = "Temp Match";
            this.checkBoxTemp.UseVisualStyleBackColor = true;
            this.checkBoxTemp.CheckedChanged += new System.EventHandler(this.checkBoxTemp_CheckedChanged);
            // 
            // cb_is_match
            // 
            this.cb_is_match.AutoSize = true;
            this.cb_is_match.Location = new System.Drawing.Point(315, 280);
            this.cb_is_match.Name = "cb_is_match";
            this.cb_is_match.Size = new System.Drawing.Size(69, 17);
            this.cb_is_match.TabIndex = 88;
            this.cb_is_match.Text = "IS Match";
            this.cb_is_match.UseVisualStyleBackColor = true;
            // 
            // btn_test_algo
            // 
            this.btn_test_algo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test_algo.ForeColor = System.Drawing.Color.Black;
            this.btn_test_algo.Location = new System.Drawing.Point(6, 329);
            this.btn_test_algo.Name = "btn_test_algo";
            this.btn_test_algo.Size = new System.Drawing.Size(121, 35);
            this.btn_test_algo.TabIndex = 69;
            this.btn_test_algo.Text = "Test Algo ";
            this.btn_test_algo.UseVisualStyleBackColor = true;
            this.btn_test_algo.Click += new System.EventHandler(this.btn_test_algo_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Red;
            this.btn_exit.Location = new System.Drawing.Point(1411, 816);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(161, 33);
            this.btn_exit.TabIndex = 76;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // cb_model_name
            // 
            this.cb_model_name.BackColor = System.Drawing.Color.White;
            this.cb_model_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_model_name.FormattingEnabled = true;
            this.cb_model_name.Location = new System.Drawing.Point(1138, 11);
            this.cb_model_name.Name = "cb_model_name";
            this.cb_model_name.Size = new System.Drawing.Size(193, 32);
            this.cb_model_name.TabIndex = 79;
            this.cb_model_name.Text = "Select model ";
            this.cb_model_name.SelectedIndexChanged += new System.EventHandler(this.cb_model_name_SelectedIndexChanged);
            // 
            // cb_region_name
            // 
            this.cb_region_name.BackColor = System.Drawing.Color.White;
            this.cb_region_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_region_name.FormattingEnabled = true;
            this.cb_region_name.Location = new System.Drawing.Point(1140, 400);
            this.cb_region_name.Name = "cb_region_name";
            this.cb_region_name.Size = new System.Drawing.Size(223, 32);
            this.cb_region_name.TabIndex = 80;
            this.cb_region_name.Text = "Select Region Name";
            this.cb_region_name.SelectedIndexChanged += new System.EventHandler(this.cb_region_name_SelectedIndexChanged);
            this.cb_region_name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cb_region_name_MouseDown);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.Location = new System.Drawing.Point(1399, 400);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(95, 32);
            this.btn_delete.TabIndex = 89;
            this.btn_delete.Text = "Delete Selected";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 840);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 90;
            this.label1.Text = "Time ....";
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadImage.ForeColor = System.Drawing.Color.Black;
            this.buttonLoadImage.Location = new System.Drawing.Point(1399, 56);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(95, 31);
            this.buttonLoadImage.TabIndex = 99;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
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
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1138, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 59);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Charger Color";
            this.groupBox1.Visible = false;
            // 
            // cb_cam_live
            // 
            this.cb_cam_live.AutoSize = true;
            this.cb_cam_live.BackColor = System.Drawing.SystemColors.Control;
            this.cb_cam_live.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cam_live.Location = new System.Drawing.Point(1140, 130);
            this.cb_cam_live.Name = "cb_cam_live";
            this.cb_cam_live.Size = new System.Drawing.Size(60, 24);
            this.cb_cam_live.TabIndex = 75;
            this.cb_cam_live.Text = "Live";
            this.cb_cam_live.UseVisualStyleBackColor = false;
            this.cb_cam_live.CheckedChanged += new System.EventHandler(this.cb_cam_live_CheckedChanged);
            // 
            // checkBoxCreate
            // 
            this.checkBoxCreate.AutoSize = true;
            this.checkBoxCreate.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCreate.Location = new System.Drawing.Point(1210, 130);
            this.checkBoxCreate.Name = "checkBoxCreate";
            this.checkBoxCreate.Size = new System.Drawing.Size(131, 24);
            this.checkBoxCreate.TabIndex = 97;
            this.checkBoxCreate.Text = "Create Mode";
            this.checkBoxCreate.UseVisualStyleBackColor = false;
            // 
            // comboBoxCam
            // 
            this.comboBoxCam.BackColor = System.Drawing.Color.White;
            this.comboBoxCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCam.FormattingEnabled = true;
            this.comboBoxCam.Items.AddRange(new object[] {
            "FirstCam",
            "SecondCam"});
            this.comboBoxCam.Location = new System.Drawing.Point(1338, 12);
            this.comboBoxCam.Name = "comboBoxCam";
            this.comboBoxCam.Size = new System.Drawing.Size(184, 32);
            this.comboBoxCam.TabIndex = 79;
            // 
            // panelPbZoom
            // 
            this.panelPbZoom.AutoScroll = true;
            this.panelPbZoom.Controls.Add(this.pictureBoxZoom);
            this.panelPbZoom.Location = new System.Drawing.Point(16, 11);
            this.panelPbZoom.Name = "panelPbZoom";
            this.panelPbZoom.Size = new System.Drawing.Size(1077, 796);
            this.panelPbZoom.TabIndex = 144;
            this.panelPbZoom.TabStop = true;
            // 
            // pictureBoxZoom
            // 
            this.pictureBoxZoom.BackColor = System.Drawing.Color.White;
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
            // buttonSaveModel
            // 
            this.buttonSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveModel.Location = new System.Drawing.Point(1146, 816);
            this.buttonSaveModel.Name = "buttonSaveModel";
            this.buttonSaveModel.Size = new System.Drawing.Size(116, 41);
            this.buttonSaveModel.TabIndex = 145;
            this.buttonSaveModel.Text = "Save Model";
            this.buttonSaveModel.UseVisualStyleBackColor = true;
            this.buttonSaveModel.Click += new System.EventHandler(this.buttonSaveModel_Click);
            // 
            // buttonTestImage
            // 
            this.buttonTestImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTestImage.Location = new System.Drawing.Point(1399, 93);
            this.buttonTestImage.Name = "buttonTestImage";
            this.buttonTestImage.Size = new System.Drawing.Size(95, 34);
            this.buttonTestImage.TabIndex = 146;
            this.buttonTestImage.Text = "Test Image";
            this.buttonTestImage.UseVisualStyleBackColor = true;
            this.buttonTestImage.Click += new System.EventHandler(this.buttonTestImage_Click);
            // 
            // EditModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.buttonTestImage);
            this.Controls.Add(this.buttonSaveModel);
            this.Controls.Add(this.panelPbZoom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_cam_live);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.cb_region_name);
            this.Controls.Add(this.comboBoxCam);
            this.Controls.Add(this.cb_model_name);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.tools_option_gb);
            this.Controls.Add(this.lbl_rect);
            this.Controls.Add(this.lbl_points);
            this.Controls.Add(this.buttonLoadImage);
            this.Name = "EditModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Model";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditModel_FormClosing);
            this.Load += new System.EventHandler(this.EditModel_Load_1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPbZoom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_save_model;
        private System.Windows.Forms.Label lbl_rect;
        private System.Windows.Forms.Label lbl_points;
        private System.Windows.Forms.GroupBox tools_option_gb;
        private System.Windows.Forms.Button btn_test_algo;
        private System.Windows.Forms.CheckBox cb_is_match;
        private System.Windows.Forms.Timer timer_camera_status;
        private System.Windows.Forms.Timer live_timer;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ComboBox cb_model_name;
        private System.Windows.Forms.ComboBox cb_region_name;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.CheckBox checkBoxEdge;
        private System.Windows.Forms.CheckBox checkBoxTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectROI;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_cam_live;
        private System.Windows.Forms.CheckBox checkBoxCreate;
        private System.Windows.Forms.ComboBox comboBoxCam;
        private System.Windows.Forms.Panel panelCheckTemp;
        private System.Windows.Forms.NumericUpDown numericUpDownMatchScore;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftToleranceY;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftToleranceX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownTempThreshold;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelEdge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.NumericUpDown numericUpDownStrength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownPolarity;
        private System.Windows.Forms.NumericUpDown numericUpDownEdgeThreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownAngleTolerance;
        private System.Windows.Forms.NumericUpDown numericUpDownAngle;
        private System.Windows.Forms.Panel panelPbZoom;
        private System.Windows.Forms.PictureBox pictureBoxZoom;
        private System.Windows.Forms.Button buttonSaveModel;
        private System.Windows.Forms.Button buttonTestImage;
    }
}