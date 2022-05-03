namespace SalcompTwoCam
{
    partial class DeleteModelPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewModel = new System.Windows.Forms.DataGridView();
            this.SrNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDelModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModel)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewModel
            // 
            this.dataGridViewModel.AllowUserToAddRows = false;
            this.dataGridViewModel.AllowUserToDeleteRows = false;
            this.dataGridViewModel.AllowUserToResizeColumns = false;
            this.dataGridViewModel.AllowUserToResizeRows = false;
            this.dataGridViewModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNum,
            this.Model});
            this.dataGridViewModel.Location = new System.Drawing.Point(95, 56);
            this.dataGridViewModel.Name = "dataGridViewModel";
            this.dataGridViewModel.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewModel.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewModel.RowHeadersVisible = false;
            this.dataGridViewModel.Size = new System.Drawing.Size(301, 418);
            this.dataGridViewModel.TabIndex = 0;
            // 
            // SrNum
            // 
            this.SrNum.HeaderText = "Sr Num";
            this.SrNum.Name = "SrNum";
            this.SrNum.ReadOnly = true;
            this.SrNum.Width = 80;
            // 
            // Model
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Model.DefaultCellStyle = dataGridViewCellStyle5;
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.Width = 200;
            // 
            // buttonDelModel
            // 
            this.buttonDelModel.BackColor = System.Drawing.Color.Red;
            this.buttonDelModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelModel.ForeColor = System.Drawing.Color.White;
            this.buttonDelModel.Location = new System.Drawing.Point(182, 511);
            this.buttonDelModel.Name = "buttonDelModel";
            this.buttonDelModel.Size = new System.Drawing.Size(111, 43);
            this.buttonDelModel.TabIndex = 1;
            this.buttonDelModel.Text = "Delete";
            this.buttonDelModel.UseVisualStyleBackColor = false;
            this.buttonDelModel.Click += new System.EventHandler(this.buttonDelModel_Click);
            // 
            // DeleteModelPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SalcompTwoCam.Properties.Resources.Black_and_Blue;
            this.ClientSize = new System.Drawing.Size(510, 637);
            this.Controls.Add(this.buttonDelModel);
            this.Controls.Add(this.dataGridViewModel);
            this.MaximumSize = new System.Drawing.Size(526, 676);
            this.MinimumSize = new System.Drawing.Size(526, 676);
            this.Name = "DeleteModelPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Model for Inspection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeleteModelPage_FormClosing);
            this.Load += new System.EventHandler(this.DeleteModelPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.Button buttonDelModel;
    }
}