using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using YoutubeExtractor;


namespace iPhoneRingtoneMaker
{
    public partial class iPhoneRingtoneMaker : Form
    {
        public static string folder = null;

        public iPhoneRingtoneMaker()
        {
            InitializeComponent();
        }

        private void btnOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputFolder = new FolderBrowserDialog();
            outputFolder.RootFolder = Environment.SpecialFolder.DesktopDirectory;

            if(txtOutputDirectory.Text != "")
            {
                outputFolder.SelectedPath = txtOutputDirectory.Text;
            }

            if (outputFolder.ShowDialog() == DialogResult.OK)
            {
                txtOutputDirectory.Text = outputFolder.SelectedPath.ToString();
                folder = txtOutputDirectory.Text;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //TODO: ONCE File exists manipulate it until it can be used as a ringtone.
     
        }

      

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string link = txtYouTubeURL.Text;

            //TODO: Get YouTubeExtractor to work on a background thread

            /*
             * Get the available video formats.
             * We'll work with them in the video and audio download examples.
             */
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);
            DownloadAudio(videoInfos);
        }

        private static void DownloadAudio(IEnumerable<VideoInfo> videoInfos)
        {
            /*
             * We want the first flash (only flash audio extraction is currently supported)
             * video with the highest audio quality.
             * See the VideoFormat enum for more info about the quality.
             */
            VideoInfo video = videoInfos
                .Where(info => info.CanExtractAudio)
                .First(info =>
                       info.VideoFormat == VideoFormat.FlashAacHighQuality ||
                       info.VideoFormat == VideoFormat.FlashAacLowQuality ||
                       info.VideoFormat == VideoFormat.FlashMp3HighQuality ||
                       info.VideoFormat == VideoFormat.FlashMp3LowQuality);

            /*
             * Create the audio downloader.
             * The first argument is the video where the audio should be extracted from.
             * The second argument is the path to save the audio file.
             * Automatic video title infering will be supported later.
             */
            var audioDownloader = new AudioDownloader(video, folder + "\\test" + video.AudioExtension);

            // Register the ProgressChanged event and print the current progress
            //audioDownloader.ProgressChanged += (sender, args) => Debug.WriteLine(args.ProgressPercentage);

            /*
             * Execute the audio downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            audioDownloader.Execute();
        }
    }
}
