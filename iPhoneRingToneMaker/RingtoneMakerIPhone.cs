using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using iTunesLib;
using YoutubeExtractor;

namespace iPhoneRingtoneMaker
{
    public partial class RingtoneMakerIPhone : Form
    {
        public static string Folder = null;
        public iTunesApp Itunes = new iTunesApp(); //Create instance of Itunes App
        public VideoInfo Video = null;
	    public FolderBrowserDialog OutputFolder;

        delegate void updatePercentageCallback(double percentage);

        public RingtoneMakerIPhone()
        {
            InitializeComponent();
        }

        private void btnOutputDir_Click(object sender, EventArgs e)
        {
            OutputFolder = new FolderBrowserDialog
	            {
		            RootFolder = Environment.SpecialFolder.DesktopDirectory
	            };

	        if(!string.IsNullOrEmpty(txtOutputDirectory.Text))
            {
                OutputFolder.SelectedPath = txtOutputDirectory.Text;
            }

            if (OutputFolder.ShowDialog() == DialogResult.OK)
            {
                txtOutputDirectory.Text = string.Concat(OutputFolder.SelectedPath, "\\");
                Folder = txtOutputDirectory.Text;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string songfile = null;

            createPlaylist();   //Create a temporary playlist in iTunes

	        var outputPath = string.Concat(OutputFolder.SelectedPath, "\\", tbNewFilename.Text);

			var startTime = Convert.ToInt32(txtStartTime.Text);
			var endTime = Convert.ToInt32(txtEndTime.Text);

			TrimMp3(txtChosenFile.Text, outputPath, TimeSpan.FromSeconds(startTime), TimeSpan.FromSeconds(endTime));

            // search for a certain playlist
            IITUserPlaylist playListImSearchingFor = null;
            foreach (var pl in Itunes.LibrarySource.Playlists.Cast<IITPlaylist>().Where(pl => pl.Name.Equals("Temp")))
            {
	            playListImSearchingFor = (IITUserPlaylist)pl;
	            songfile = outputPath;
	            playListImSearchingFor.AddFile(songfile); // add a song to that playlist
            }

			if (playListImSearchingFor == null)
				throw new Exception("Sorry the playlist was not found correctly");

            //Trim selected MP3 by setting the start and end times
            //At the moment it is just taking the first 30 seconds.
            IITTrack track = playListImSearchingFor.Tracks[1];
	        IITFileOrCDTrack fileTrack = null;

			if (track.Kind == ITTrackKind.ITTrackKindFile)
			{
				fileTrack = (IITFileOrCDTrack)track;
			}

			if(fileTrack == null)
				throw new FileNotFoundException("There was a problem locating the file you requested.");
			
            txtTotalLength.Text = Convert.ToString(track.Time);
			track.Start = Convert.ToInt32(txtStartTime.Text);
            track.Finish = Convert.ToInt32(txtEndTime.Text);
         
			var result = Itunes.ConvertFile2(songfile);
            
            while (result.InProgress)
            {
				////Something needs to go here!
            }
            var trackname = string.Concat(Path.GetFileNameWithoutExtension(fileTrack.Location), ".m4a");

            //Find iTunes Directory
	        var userDirectory = Path.GetDirectoryName(fileTrack.Location);

			if(userDirectory == null || !Directory.Exists(userDirectory))
				throw new DirectoryNotFoundException(string.Concat("The following directory could not be found", userDirectory));		

			//Find the newly created file
            var files = Directory.GetFiles(userDirectory, trackname, SearchOption.AllDirectories);
            
            //Delete Playlist
            playListImSearchingFor.Delete();

            //Copy File to chosen output Directory
			//If the file already exists, delete it!
            if(File.Exists(txtOutputDirectory.Text + trackname))
            {
                File.Delete(txtOutputDirectory.Text + trackname);
            }
            
            File.Move(files[0], txtOutputDirectory.Text + trackname);

            var trackname2 = trackname.Replace(".m4a", ".m4r");
            var renamed = txtOutputDirectory.Text + trackname2;

            //Rename File
            //If the file already exists, delete it!
            if (File.Exists(renamed))
            {
                File.Delete(renamed);
            }

            //Copy File
            File.Move(txtOutputDirectory.Text + trackname, renamed);

            //Move File
            var newLocation = files[0];
            var last = newLocation.LastIndexOf("\\", StringComparison.Ordinal) + 1;
            newLocation = newLocation.Remove(last);
            newLocation = newLocation + trackname2;

            if(File.Exists(newLocation))
            {
                File.Delete(newLocation);
            }
            File.Move(renamed, newLocation);

            //Close iTunes again
            Itunes.Quit();

            //Open File to import into iTunes
            Process.Start(newLocation);            
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var openFileDlg = new OpenFileDialog();

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                txtChosenFile.Text = openFileDlg.FileName;
            }
        }

        private void txtEndTimeTextChanged(object sender, EventArgs e)
        {
	        int start = Convert.ToInt32(txtStartTime.Text);
            int end = Convert.ToInt32(txtEndTime.Text);

            if (start < end)
            {
                if ((end - start) > 40)
                {
                    end = start + 30;
                    txtEndTime.Text = Convert.ToString(end);
                    MessageBox.Show("End Time is more than 40 seconds after the start time. This has now been set to 30 seconds after the start.", "Invalid End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                end = start + 30;
                txtEndTime.Text = Convert.ToString(end);
                MessageBox.Show("End Time must be greater than the start time! End Time has been set to 30 seconds after the start time.", "Invalid End Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void createPlaylist()
        {
            // create a new playList
            var newPlayList = (IITUserPlaylist)Itunes.CreatePlaylist("Temp");
        }

        public void createPlaylist(string name)
        {
            // create a new playList
            var newPlayList = (IITUserPlaylist)Itunes.CreatePlaylist(name);
        }

        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {
	        var start = Convert.ToInt32(txtStartTime.Text);
            var end = Convert.ToInt32(txtEndTime.Text);

            if (start < 0)
            {
                start = 0;
            }

            if (start > end)
            {
                end = start + 30;
            }

            txtStartTime.Text = Convert.ToString(start);
            txtEndTime.Text = Convert.ToString(end);
        }

        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            var browse = new FolderBrowserDialog
	            {
		            RootFolder = Environment.SpecialFolder.Desktop
	            };

	        if (browse.ShowDialog() == DialogResult.OK)
            {
                txtMP3Path.Text = browse.SelectedPath.ToString();
            }
        }

        private void btnCreateMP3_Click(object sender, EventArgs e)
        {
            // Our test youtube link
            var link = txtYouTubeURL.Text;

            /*
             * Get the available video formats.
             * We'll work with them in the video and audio download examples.
             */
            var videoInfos = DownloadUrlResolver.GetDownloadUrls(link);

            /*
             * We want the first flash (only flash audio extraction is currently supported)
             * video with the highest audio quality.
             * See the VideoFormat enum for more info about the quality.
             */
            Video = videoInfos
                .Where(info => info.CanExtractAudio && info.AudioType == AudioType.Mp3)
                .OrderByDescending(info => info.AudioBitrate)
                .First();

            worker.RunWorkerAsync(Video);

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Set the path to a temp directory on the desktop.
            var folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            folderpath += "\\temp\\";

			if (!Directory.Exists(folderpath))
			{
				Directory.CreateDirectory(folderpath);
			}
            /*
              * Create the audio downloader.
              * The first argument is the video where the audio should be extracted from.
              * The second argument is the path to save the audio file.
              * Automatic video title infering will be supported later.
              */
            //var audioDownloader = new AudioDownloader(video, folderpath + video.AudioExtension);
            var audioDownloader = new AudioDownloader(Video, Path.Combine(folderpath, Video.Title + Video.AudioExtension));
            // Register the ProgressChanged event and print the current progress
            audioDownloader.DownloadProgressChanged += (senders, args) => updatePercentage(args.ProgressPercentage);
            
            /*
             * Execute the audio downloader.
             * For GUI applications note, that this method runs synchronously.
             */

            audioDownloader.Execute();
        }

        public void updatePercentage(double percent)
        {
            //This function is required so that the worker can access the progress bar from the other thread.
            int per = Convert.ToInt32(percent);
            if (this.progressBar1.InvokeRequired)
            {
                updatePercentageCallback call = new updatePercentageCallback(updatePercentage);
                this.Invoke(call, new object[] { per });
            }
            else
            {
                progressBar1.Value = per;
                label5.Text = per.ToString() + "%";
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Display a dialog when the extraction is complete.
            MessageBox.Show("MP3 file extracted!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		void TrimMp3(string inputPath, string outputPath, TimeSpan? begin, TimeSpan? end)
{
    if (begin.HasValue && end.HasValue && begin > end)
        throw new ArgumentOutOfRangeException("end", "end should be greater than begin");

    using (var reader = new Mp3FileReader(inputPath))
    using (var writer = File.Create(outputPath))
    {           
        Mp3Frame frame;
        while ((frame = reader.ReadNextFrame()) != null)
        if (reader.CurrentTime >= begin || !begin.HasValue)
        {
            if (reader.CurrentTime <= end || !end.HasValue)
                writer.Write(frame.RawData,0,frame.RawData.Length);         
            else break;
        }
    }
}
    }
}
