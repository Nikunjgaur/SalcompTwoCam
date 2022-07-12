namespace SalcompTwoCam
{
    partial class InspectModel
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
            this.cb_model_name = new System.Windows.Forms.ComboBox();
            this.tmrSim = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtQue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inspectionLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lbl_footer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_camera_status = new System.Windows.Forms.Timer(this.components);
            this.timer_time = new System.Windows.Forms.Timer(this.components);
            this.picboxOne = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveImages2 = new System.Windows.Forms.CheckBox();
            this.lbl_total_inspected = new System.Windows.Forms.Label();
            this.lbl_total_ok_piece = new System.Windows.Forms.Label();
            this.lbl_total_ng_piece = new System.Windows.Forms.Label();
            this.buttonResultCam2 = new System.Windows.Forms.Button();
            this.labelNgCount = new System.Windows.Forms.Label();
            this.labelOkCount = new System.Windows.Forms.Label();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.pictureBoxTwo = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSrNum = new System.Windows.Forms.TextBox();
            this.textBoxModelNum1 = new System.Windows.Forms.TextBox();
            this.textBoxSrNum2 = new System.Windows.Forms.TextBox();
            this.textBoxModelNum2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.labelTotalCam1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelOkCam1 = new System.Windows.Forms.Label();
            this.labelNgCam1 = new System.Windows.Forms.Label();
            this.buttonResultCam1 = new System.Windows.Forms.Button();
            this.saveImages1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQue2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTwo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_model_name
            // 
            this.cb_model_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_model_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_model_name.FormattingEnabled = true;
            this.cb_model_name.Location = new System.Drawing.Point(672, 64);
            this.cb_model_name.Name = "cb_model_name";
            this.cb_model_name.Size = new System.Drawing.Size(245, 33);
            this.cb_model_name.TabIndex = 31;
            this.cb_model_name.SelectedIndexChanged += new System.EventHandler(this.cb_model_name_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(151, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Processing Time:";
            this.label10.Visible = false;
            // 
            // txtQue
            // 
            this.txtQue.AutoSize = true;
            this.txtQue.BackColor = System.Drawing.Color.Transparent;
            this.txtQue.Location = new System.Drawing.Point(245, 132);
            this.txtQue.Name = "txtQue";
            this.txtQue.Size = new System.Drawing.Size(19, 13);
            this.txtQue.TabIndex = 59;
            this.txtQue.Text = "00";
            this.txtQue.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1526, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 27);
            this.label9.TabIndex = 58;
            this.label9.Text = "Add Innovations";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1527, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 18);
            this.label8.TabIndex = 57;
            this.label8.Text = "www.addinnovations.in";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.inspectionLogToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.fileToolStripMenuItem.Text = "XML path";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // inspectionLogToolStripMenuItem
            // 
            this.inspectionLogToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.inspectionLogToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.inspectionLogToolStripMenuItem.Name = "inspectionLogToolStripMenuItem";
            this.inspectionLogToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.inspectionLogToolStripMenuItem.Text = "Inspection Log";
            this.inspectionLogToolStripMenuItem.Click += new System.EventHandler(this.inspectionLogToolStripMenuItem_Click);
            // 
            // createModelToolStripMenuItem
            // 
            this.createModelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem});
            this.createModelToolStripMenuItem.Name = "createModelToolStripMenuItem";
            this.createModelToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.createModelToolStripMenuItem.Text = "User";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(134, 30);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.createModelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1918, 24);
            this.menuStrip1.TabIndex = 56;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lbl_footer
            // 
            this.lbl_footer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_footer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_footer.Location = new System.Drawing.Point(1526, 241);
            this.lbl_footer.Name = "lbl_footer";
            this.lbl_footer.Size = new System.Drawing.Size(152, 22);
            this.lbl_footer.TabIndex = 50;
            this.lbl_footer.Text = "Developed by -";
            // 
            // timer_camera_status
            // 
            this.timer_camera_status.Interval = 2000;
            // 
            // picboxOne
            // 
            this.picboxOne.BackColor = System.Drawing.Color.White;
            this.picboxOne.Location = new System.Drawing.Point(108, 91);
            this.picboxOne.Name = "picboxOne";
            this.picboxOne.Size = new System.Drawing.Size(807, 622);
            this.picboxOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxOne.TabIndex = 2;
            this.picboxOne.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(1211, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 26);
            this.label7.TabIndex = 54;
            this.label7.Text = "Inspection Data";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(1153, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 19);
            this.label6.TabIndex = 51;
            this.label6.Text = "Inspection Result :";
            // 
            // saveImages2
            // 
            this.saveImages2.AutoSize = true;
            this.saveImages2.BackColor = System.Drawing.Color.Transparent;
            this.saveImages2.ForeColor = System.Drawing.Color.White;
            this.saveImages2.Location = new System.Drawing.Point(1157, 291);
            this.saveImages2.Name = "saveImages2";
            this.saveImages2.Size = new System.Drawing.Size(88, 17);
            this.saveImages2.TabIndex = 62;
            this.saveImages2.Text = "Save Images";
            this.saveImages2.UseVisualStyleBackColor = false;
            // 
            // lbl_total_inspected
            // 
            this.lbl_total_inspected.AutoSize = true;
            this.lbl_total_inspected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_inspected.ForeColor = System.Drawing.Color.White;
            this.lbl_total_inspected.Location = new System.Drawing.Point(1157, 135);
            this.lbl_total_inspected.Name = "lbl_total_inspected";
            this.lbl_total_inspected.Size = new System.Drawing.Size(174, 20);
            this.lbl_total_inspected.TabIndex = 0;
            this.lbl_total_inspected.Text = "Total  Inspected    :  ";
            // 
            // lbl_total_ok_piece
            // 
            this.lbl_total_ok_piece.AutoSize = true;
            this.lbl_total_ok_piece.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_ok_piece.ForeColor = System.Drawing.Color.White;
            this.lbl_total_ok_piece.Location = new System.Drawing.Point(1154, 171);
            this.lbl_total_ok_piece.Name = "lbl_total_ok_piece";
            this.lbl_total_ok_piece.Size = new System.Drawing.Size(103, 20);
            this.lbl_total_ok_piece.TabIndex = 1;
            this.lbl_total_ok_piece.Text = "Total OK   : ";
            // 
            // lbl_total_ng_piece
            // 
            this.lbl_total_ng_piece.AutoSize = true;
            this.lbl_total_ng_piece.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_ng_piece.ForeColor = System.Drawing.Color.White;
            this.lbl_total_ng_piece.Location = new System.Drawing.Point(1154, 207);
            this.lbl_total_ng_piece.Name = "lbl_total_ng_piece";
            this.lbl_total_ng_piece.Size = new System.Drawing.Size(110, 20);
            this.lbl_total_ng_piece.TabIndex = 2;
            this.lbl_total_ng_piece.Text = "Total NG    : ";
            // 
            // buttonResultCam2
            // 
            this.buttonResultCam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResultCam2.Location = new System.Drawing.Point(1374, 241);
            this.buttonResultCam2.Name = "buttonResultCam2";
            this.buttonResultCam2.Size = new System.Drawing.Size(98, 42);
            this.buttonResultCam2.TabIndex = 36;
            this.buttonResultCam2.Text = "N/A";
            this.buttonResultCam2.UseVisualStyleBackColor = true;
            // 
            // labelNgCount
            // 
            this.labelNgCount.AutoSize = true;
            this.labelNgCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNgCount.ForeColor = System.Drawing.Color.White;
            this.labelNgCount.Location = new System.Drawing.Point(1419, 207);
            this.labelNgCount.Name = "labelNgCount";
            this.labelNgCount.Size = new System.Drawing.Size(19, 20);
            this.labelNgCount.TabIndex = 41;
            this.labelNgCount.Text = "0";
            // 
            // labelOkCount
            // 
            this.labelOkCount.AutoSize = true;
            this.labelOkCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOkCount.ForeColor = System.Drawing.Color.White;
            this.labelOkCount.Location = new System.Drawing.Point(1419, 171);
            this.labelOkCount.Name = "labelOkCount";
            this.labelOkCount.Size = new System.Drawing.Size(19, 20);
            this.labelOkCount.TabIndex = 40;
            this.labelOkCount.Text = "0";
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalCount.ForeColor = System.Drawing.Color.White;
            this.labelTotalCount.Location = new System.Drawing.Point(1419, 135);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(19, 20);
            this.labelTotalCount.TabIndex = 39;
            this.labelTotalCount.Text = "0";
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.White;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.Red;
            this.btn_reset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reset.Location = new System.Drawing.Point(739, 208);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(120, 41);
            this.btn_reset.TabIndex = 38;
            this.btn_reset.Text = "Reset ";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // pictureBoxTwo
            // 
            this.pictureBoxTwo.BackColor = System.Drawing.Color.White;
            this.pictureBoxTwo.Location = new System.Drawing.Point(932, 91);
            this.pictureBoxTwo.Name = "pictureBoxTwo";
            this.pictureBoxTwo.Size = new System.Drawing.Size(881, 622);
            this.pictureBoxTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTwo.TabIndex = 2;
            this.pictureBoxTwo.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.White;
            this.buttonStart.Location = new System.Drawing.Point(672, 158);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(111, 43);
            this.buttonStart.TabIndex = 62;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.DarkRed;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.ForeColor = System.Drawing.Color.White;
            this.buttonStop.Location = new System.Drawing.Point(797, 158);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(120, 43);
            this.buttonStop.TabIndex = 63;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.textBoxSrNum);
            this.panel1.Controls.Add(this.textBoxModelNum1);
            this.panel1.Controls.Add(this.textBoxSrNum2);
            this.panel1.Controls.Add(this.textBoxModelNum2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.labelTotalCam1);
            this.panel1.Controls.Add(this.labelTotalCount);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.labelOkCam1);
            this.panel1.Controls.Add(this.labelOkCount);
            this.panel1.Controls.Add(this.lbl_footer);
            this.panel1.Controls.Add(this.cb_model_name);
            this.panel1.Controls.Add(this.labelNgCam1);
            this.panel1.Controls.Add(this.labelNgCount);
            this.panel1.Controls.Add(this.buttonResultCam1);
            this.panel1.Controls.Add(this.buttonResultCam2);
            this.panel1.Controls.Add(this.saveImages1);
            this.panel1.Controls.Add(this.btn_reset);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.saveImages2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_total_ng_piece);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_total_ok_piece);
            this.panel1.Controls.Add(this.lbl_total_inspected);
            this.panel1.Location = new System.Drawing.Point(108, 727);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1705, 322);
            this.panel1.TabIndex = 64;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBoxSrNum
            // 
            this.textBoxSrNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSrNum.Location = new System.Drawing.Point(267, 39);
            this.textBoxSrNum.Name = "textBoxSrNum";
            this.textBoxSrNum.Size = new System.Drawing.Size(142, 29);
            this.textBoxSrNum.TabIndex = 64;
            this.textBoxSrNum.Text = "Serial Number";
            // 
            // textBoxModelNum1
            // 
            this.textBoxModelNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxModelNum1.Location = new System.Drawing.Point(57, 39);
            this.textBoxModelNum1.Name = "textBoxModelNum1";
            this.textBoxModelNum1.Size = new System.Drawing.Size(142, 29);
            this.textBoxModelNum1.TabIndex = 64;
            this.textBoxModelNum1.Text = "Model Number";
            // 
            // textBoxSrNum2
            // 
            this.textBoxSrNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSrNum2.Location = new System.Drawing.Point(1374, 39);
            this.textBoxSrNum2.Name = "textBoxSrNum2";
            this.textBoxSrNum2.Size = new System.Drawing.Size(142, 29);
            this.textBoxSrNum2.TabIndex = 64;
            this.textBoxSrNum2.Text = "Serial Number";
            // 
            // textBoxModelNum2
            // 
            this.textBoxModelNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxModelNum2.Location = new System.Drawing.Point(1164, 39);
            this.textBoxModelNum2.Name = "textBoxModelNum2";
            this.textBoxModelNum2.Size = new System.Drawing.Size(142, 29);
            this.textBoxModelNum2.TabIndex = 64;
            this.textBoxModelNum2.Text = "Model Number";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(128, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 26);
            this.label13.TabIndex = 54;
            this.label13.Text = "Inspection Data";
            // 
            // labelTotalCam1
            // 
            this.labelTotalCam1.AutoSize = true;
            this.labelTotalCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalCam1.ForeColor = System.Drawing.Color.White;
            this.labelTotalCam1.Location = new System.Drawing.Point(336, 135);
            this.labelTotalCam1.Name = "labelTotalCam1";
            this.labelTotalCam1.Size = new System.Drawing.Size(19, 20);
            this.labelTotalCam1.TabIndex = 39;
            this.labelTotalCam1.Text = "0";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(70, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 19);
            this.label11.TabIndex = 51;
            this.label11.Text = "Inspection Result :";
            // 
            // labelOkCam1
            // 
            this.labelOkCam1.AutoSize = true;
            this.labelOkCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOkCam1.ForeColor = System.Drawing.Color.White;
            this.labelOkCam1.Location = new System.Drawing.Point(336, 171);
            this.labelOkCam1.Name = "labelOkCam1";
            this.labelOkCam1.Size = new System.Drawing.Size(19, 20);
            this.labelOkCam1.TabIndex = 40;
            this.labelOkCam1.Text = "0";
            // 
            // labelNgCam1
            // 
            this.labelNgCam1.AutoSize = true;
            this.labelNgCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNgCam1.ForeColor = System.Drawing.Color.White;
            this.labelNgCam1.Location = new System.Drawing.Point(336, 207);
            this.labelNgCam1.Name = "labelNgCam1";
            this.labelNgCam1.Size = new System.Drawing.Size(19, 20);
            this.labelNgCam1.TabIndex = 41;
            this.labelNgCam1.Text = "0";
            // 
            // buttonResultCam1
            // 
            this.buttonResultCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResultCam1.Location = new System.Drawing.Point(291, 241);
            this.buttonResultCam1.Name = "buttonResultCam1";
            this.buttonResultCam1.Size = new System.Drawing.Size(98, 42);
            this.buttonResultCam1.TabIndex = 36;
            this.buttonResultCam1.Text = "N/A";
            this.buttonResultCam1.UseVisualStyleBackColor = true;
            // 
            // saveImages1
            // 
            this.saveImages1.AutoSize = true;
            this.saveImages1.BackColor = System.Drawing.Color.Transparent;
            this.saveImages1.ForeColor = System.Drawing.Color.White;
            this.saveImages1.Location = new System.Drawing.Point(74, 291);
            this.saveImages1.Name = "saveImages1";
            this.saveImages1.Size = new System.Drawing.Size(88, 17);
            this.saveImages1.TabIndex = 62;
            this.saveImages1.Text = "Save Images";
            this.saveImages1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(71, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total NG    : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total OK   : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(74, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total  Inspected    :  ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1014, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 48);
            this.button2.TabIndex = 65;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(432, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 37);
            this.label4.TabIndex = 66;
            this.label4.Text = "First Cam";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1295, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 37);
            this.label5.TabIndex = 66;
            this.label5.Text = "Second Cam";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtQue2
            // 
            this.txtQue2.AutoSize = true;
            this.txtQue2.BackColor = System.Drawing.Color.Transparent;
            this.txtQue2.Location = new System.Drawing.Point(1054, 132);
            this.txtQue2.Name = "txtQue2";
            this.txtQue2.Size = new System.Drawing.Size(19, 13);
            this.txtQue2.TabIndex = 59;
            this.txtQue2.Text = "00";
            this.txtQue2.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(960, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 60;
            this.label14.Text = "Processing Time:";
            this.label14.Visible = false;
            // 
            // InspectModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::SalcompTwoCam.Properties.Resources.Black_and_Blue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1918, 1061);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtQue2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQue);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBoxTwo);
            this.Controls.Add(this.picboxOne);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InspectModel";
            this.Text = "Inspection Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InspectModel_FormClosing);
            this.Load += new System.EventHandler(this.InspectModel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTwo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_model_name;
        private System.Windows.Forms.Timer tmrSim;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtQue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inspectionLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbl_footer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer_camera_status;
        private System.Windows.Forms.Timer timer_time;
        private System.Windows.Forms.PictureBox picboxOne;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox saveImages2;
        private System.Windows.Forms.Label lbl_total_inspected;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_total_ok_piece;
        private System.Windows.Forms.Label lbl_total_ng_piece;
        private System.Windows.Forms.Button buttonResultCam2;
        private System.Windows.Forms.Label labelNgCount;
        private System.Windows.Forms.Label labelOkCount;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.PictureBox pictureBoxTwo;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelTotalCam1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelOkCam1;
        private System.Windows.Forms.Label labelNgCam1;
        private System.Windows.Forms.Button buttonResultCam1;
        private System.Windows.Forms.CheckBox saveImages1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSrNum2;
        private System.Windows.Forms.TextBox textBoxModelNum2;
        private System.Windows.Forms.TextBox textBoxSrNum;
        private System.Windows.Forms.TextBox textBoxModelNum1;
        private System.Windows.Forms.Label txtQue2;
        private System.Windows.Forms.Label label14;
    }
}