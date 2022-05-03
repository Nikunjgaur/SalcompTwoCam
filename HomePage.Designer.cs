namespace SalcompTwoCam
{
    partial class HomePage
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
            this.buttonInspect = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInspect
            // 
            this.buttonInspect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(110)))));
            this.buttonInspect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInspect.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInspect.ForeColor = System.Drawing.Color.White;
            this.buttonInspect.Location = new System.Drawing.Point(118, 67);
            this.buttonInspect.Name = "buttonInspect";
            this.buttonInspect.Size = new System.Drawing.Size(210, 171);
            this.buttonInspect.TabIndex = 1;
            this.buttonInspect.Text = "Inspect Model";
            this.buttonInspect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonInspect.UseVisualStyleBackColor = false;
            this.buttonInspect.Click += new System.EventHandler(this.buttonInspect_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(110)))));
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.ForeColor = System.Drawing.Color.White;
            this.buttonCreate.Location = new System.Drawing.Point(382, 67);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(210, 171);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Create Model";
            this.buttonCreate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(110)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(118, 269);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(210, 171);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit Model";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelModel
            // 
            this.buttonDelModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(75)))), ((int)(((byte)(110)))));
            this.buttonDelModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelModel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelModel.ForeColor = System.Drawing.Color.White;
            this.buttonDelModel.Location = new System.Drawing.Point(382, 269);
            this.buttonDelModel.Name = "buttonDelModel";
            this.buttonDelModel.Size = new System.Drawing.Size(210, 171);
            this.buttonDelModel.TabIndex = 1;
            this.buttonDelModel.Text = "Delete Model";
            this.buttonDelModel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelModel.UseVisualStyleBackColor = false;
            this.buttonDelModel.Click += new System.EventHandler(this.buttonDelModel_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 506);
            this.Controls.Add(this.buttonDelModel);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonInspect);
            this.MaximumSize = new System.Drawing.Size(1020, 550);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInspect;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelModel;
    }
}