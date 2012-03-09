namespace iPhoneRingtoneMaker
{
    partial class iPhoneRingtoneMaker
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
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblYouTubeURL = new System.Windows.Forms.Label();
            this.txtYouTubeURL = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(31, 53);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(103, 23);
            this.btnOutputDir.TabIndex = 2;
            this.btnOutputDir.Text = "Choose Output Dir";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnOutputDir_Click);
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(156, 55);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.Size = new System.Drawing.Size(323, 20);
            this.txtOutputDirectory.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(34, 131);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create Ringtone";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblYouTubeURL
            // 
            this.lblYouTubeURL.AutoSize = true;
            this.lblYouTubeURL.Location = new System.Drawing.Point(32, 12);
            this.lblYouTubeURL.Name = "lblYouTubeURL";
            this.lblYouTubeURL.Size = new System.Drawing.Size(79, 13);
            this.lblYouTubeURL.TabIndex = 7;
            this.lblYouTubeURL.Text = "YouTube URL:";
            // 
            // txtYouTubeURL
            // 
            this.txtYouTubeURL.Location = new System.Drawing.Point(156, 13);
            this.txtYouTubeURL.Name = "txtYouTubeURL";
            this.txtYouTubeURL.Size = new System.Drawing.Size(323, 20);
            this.txtYouTubeURL.TabIndex = 8;
            this.txtYouTubeURL.Text = "URL goes here!";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(486, 9);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // iPhoneRingtoneMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 481);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtYouTubeURL);
            this.Controls.Add(this.lblYouTubeURL);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtOutputDirectory);
            this.Controls.Add(this.btnOutputDir);
            this.Name = "iPhoneRingtoneMaker";
            this.Text = "iPhoneRingtoneMaker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblYouTubeURL;
        private System.Windows.Forms.TextBox txtYouTubeURL;
        private System.Windows.Forms.Button btnSubmit;
    }
}

