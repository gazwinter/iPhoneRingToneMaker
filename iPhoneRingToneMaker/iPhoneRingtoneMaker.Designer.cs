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
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtChosenFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalLength = new System.Windows.Forms.TextBox();
            this.tabLayout = new System.Windows.Forms.TabControl();
            this.tabCreateRingtone = new System.Windows.Forms.TabPage();
            this.tabYouTubeMP3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtMP3Path = new System.Windows.Forms.TextBox();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.btnCreateMP3 = new System.Windows.Forms.Button();
            this.txtYouTubeURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabLayout.SuspendLayout();
            this.tabCreateRingtone.SuspendLayout();
            this.tabYouTubeMP3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(6, 37);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(103, 23);
            this.btnOutputDir.TabIndex = 2;
            this.btnOutputDir.Text = "Choose Output Dir";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnOutputDir_Click);
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(142, 39);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.Size = new System.Drawing.Size(323, 20);
            this.txtOutputDirectory.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(174, 142);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create Ringtone";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(6, 8);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile.TabIndex = 10;
            this.btnChooseFile.Text = "Choose File";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtChosenFile
            // 
            this.txtChosenFile.Location = new System.Drawing.Point(141, 10);
            this.txtChosenFile.Name = "txtChosenFile";
            this.txtChosenFile.ReadOnly = true;
            this.txtChosenFile.Size = new System.Drawing.Size(323, 20);
            this.txtChosenFile.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Start Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "End Time:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(148, 87);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(35, 20);
            this.txtStartTime.TabIndex = 14;
            this.txtStartTime.Text = "0";
            this.txtStartTime.TextChanged += new System.EventHandler(this.txtStartTime_TextChanged);
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(253, 87);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(35, 20);
            this.txtEndTime.TabIndex = 15;
            this.txtEndTime.Text = "30";
            this.txtEndTime.TextChanged += new System.EventHandler(this.txtEndTimeTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Total Length:";
            // 
            // txtTotalLength
            // 
            this.txtTotalLength.Location = new System.Drawing.Point(370, 87);
            this.txtTotalLength.Name = "txtTotalLength";
            this.txtTotalLength.ReadOnly = true;
            this.txtTotalLength.Size = new System.Drawing.Size(35, 20);
            this.txtTotalLength.TabIndex = 17;
            // 
            // tabLayout
            // 
            this.tabLayout.Controls.Add(this.tabCreateRingtone);
            this.tabLayout.Controls.Add(this.tabYouTubeMP3);
            this.tabLayout.Location = new System.Drawing.Point(6, 7);
            this.tabLayout.Name = "tabLayout";
            this.tabLayout.SelectedIndex = 0;
            this.tabLayout.Size = new System.Drawing.Size(480, 289);
            this.tabLayout.TabIndex = 18;
            // 
            // tabCreateRingtone
            // 
            this.tabCreateRingtone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabCreateRingtone.Controls.Add(this.btnChooseFile);
            this.tabCreateRingtone.Controls.Add(this.txtTotalLength);
            this.tabCreateRingtone.Controls.Add(this.btnOutputDir);
            this.tabCreateRingtone.Controls.Add(this.label3);
            this.tabCreateRingtone.Controls.Add(this.txtOutputDirectory);
            this.tabCreateRingtone.Controls.Add(this.txtEndTime);
            this.tabCreateRingtone.Controls.Add(this.btnCreate);
            this.tabCreateRingtone.Controls.Add(this.txtStartTime);
            this.tabCreateRingtone.Controls.Add(this.txtChosenFile);
            this.tabCreateRingtone.Controls.Add(this.label2);
            this.tabCreateRingtone.Controls.Add(this.label1);
            this.tabCreateRingtone.Location = new System.Drawing.Point(4, 22);
            this.tabCreateRingtone.Name = "tabCreateRingtone";
            this.tabCreateRingtone.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateRingtone.Size = new System.Drawing.Size(472, 263);
            this.tabCreateRingtone.TabIndex = 0;
            this.tabCreateRingtone.Text = "Create Ringtone";
            this.tabCreateRingtone.UseVisualStyleBackColor = true;
            // 
            // tabYouTubeMP3
            // 
            this.tabYouTubeMP3.Controls.Add(this.textBox1);
            this.tabYouTubeMP3.Controls.Add(this.label5);
            this.tabYouTubeMP3.Controls.Add(this.progressBar1);
            this.tabYouTubeMP3.Controls.Add(this.txtMP3Path);
            this.tabYouTubeMP3.Controls.Add(this.btnChooseDir);
            this.tabYouTubeMP3.Controls.Add(this.btnCreateMP3);
            this.tabYouTubeMP3.Controls.Add(this.txtYouTubeURL);
            this.tabYouTubeMP3.Controls.Add(this.label4);
            this.tabYouTubeMP3.Location = new System.Drawing.Point(4, 22);
            this.tabYouTubeMP3.Name = "tabYouTubeMP3";
            this.tabYouTubeMP3.Padding = new System.Windows.Forms.Padding(3);
            this.tabYouTubeMP3.Size = new System.Drawing.Size(472, 263);
            this.tabYouTubeMP3.TabIndex = 1;
            this.tabYouTubeMP3.Text = "YouTube to MP3";
            this.tabYouTubeMP3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(104, 121);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(256, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // txtMP3Path
            // 
            this.txtMP3Path.Location = new System.Drawing.Point(104, 38);
            this.txtMP3Path.Name = "txtMP3Path";
            this.txtMP3Path.ReadOnly = true;
            this.txtMP3Path.Size = new System.Drawing.Size(354, 20);
            this.txtMP3Path.TabIndex = 4;
            this.txtMP3Path.Visible = false;
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Location = new System.Drawing.Point(10, 38);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(83, 23);
            this.btnChooseDir.TabIndex = 3;
            this.btnChooseDir.Text = "Choose Folder";
            this.btnChooseDir.UseVisualStyleBackColor = true;
            this.btnChooseDir.Visible = false;
            this.btnChooseDir.Click += new System.EventHandler(this.btnChooseDir_Click);
            // 
            // btnCreateMP3
            // 
            this.btnCreateMP3.Location = new System.Drawing.Point(192, 92);
            this.btnCreateMP3.Name = "btnCreateMP3";
            this.btnCreateMP3.Size = new System.Drawing.Size(83, 23);
            this.btnCreateMP3.TabIndex = 2;
            this.btnCreateMP3.Text = "Create MP3";
            this.btnCreateMP3.UseVisualStyleBackColor = true;
            this.btnCreateMP3.Click += new System.EventHandler(this.btnCreateMP3_Click);
            // 
            // txtYouTubeURL
            // 
            this.txtYouTubeURL.Location = new System.Drawing.Point(104, 7);
            this.txtYouTubeURL.Name = "txtYouTubeURL";
            this.txtYouTubeURL.Size = new System.Drawing.Size(354, 20);
            this.txtYouTubeURL.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "YouTube URL:";
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 168);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(256, 74);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Please note, once the MP3 file is created, you will need to edit its properties m" +
                "anually at the moment. ie change the title and artist etc. This must be done bef" +
                "ore you create a ringtone from the MP3.";
            // 
            // iPhoneRingtoneMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(494, 305);
            this.Controls.Add(this.tabLayout);
            this.Name = "iPhoneRingtoneMaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iPhoneRingtoneMaker";
            this.TransparencyKey = System.Drawing.Color.White;
            this.tabLayout.ResumeLayout(false);
            this.tabCreateRingtone.ResumeLayout(false);
            this.tabCreateRingtone.PerformLayout();
            this.tabYouTubeMP3.ResumeLayout(false);
            this.tabYouTubeMP3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txtChosenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalLength;
        private System.Windows.Forms.TabControl tabLayout;
        private System.Windows.Forms.TabPage tabCreateRingtone;
        private System.Windows.Forms.TabPage tabYouTubeMP3;
        private System.Windows.Forms.TextBox txtMP3Path;
        private System.Windows.Forms.Button btnChooseDir;
        private System.Windows.Forms.Button btnCreateMP3;
        private System.Windows.Forms.TextBox txtYouTubeURL;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
    }
}

