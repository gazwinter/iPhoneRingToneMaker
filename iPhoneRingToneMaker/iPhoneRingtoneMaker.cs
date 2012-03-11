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

using iTunesLib;


namespace iPhoneRingtoneMaker
{
    public partial class iPhoneRingtoneMaker : Form
    {
        public static string folder = null;
        public iTunesApp itunes = new iTunesApp(); //Create instance of Itunes App

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
                txtOutputDirectory.Text = outputFolder.SelectedPath.ToString() + "\\";
                folder = txtOutputDirectory.Text;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string songfile = null;

            createPlaylist();   //Create a temporary playlist in iTunes

            // search for a certain playlist
            IITUserPlaylist playListImSearchingFor = null;
            foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
            {
                if (pl.Name.Equals("Temp"))
                {
                    playListImSearchingFor = (IITUserPlaylist)pl;
                    songfile = txtChosenFile.Text;
                    playListImSearchingFor.AddFile(songfile); // add a song to that playlist
                }
            }

            //Trim selected MP3 by setting the start and end times
            //At the moment it is just taking the first 30 seconds.
            IITTrack track = playListImSearchingFor.Tracks[1];
            txtTotalLength.Text = Convert.ToString(track.Time);
            //int length = Convert.ToInt32(txtTotalLength.Text);

            //TODO: Fix Error checking
           // if (length > 0)
            //{
                track.Start = Convert.ToInt32(txtStartTime.Text);
                track.Finish = Convert.ToInt32(txtEndTime.Text);
          //  }

          /*  if (!((track.Start < length) && (track.Finish < length)))
            {
                track.Start = 0;
                track.Finish = 30;
                MessageBox.Show("Invalid times were entered, therefore we will only take the first 30 seconds from the song!", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            string trackname = null;
            var result = itunes.ConvertFile2(songfile);
            trackname = result.trackName;
            while (result.InProgress)
            {
                //Something needs to go here!
            }
            trackname += ".m4a";

            //Find iTunes Directory
            string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            userDirectory = userDirectory.Replace("Documents", "Music");
            userDirectory = userDirectory.TrimEnd();

            //Find the newly created file
            string[] files = Directory.GetFiles(userDirectory, "*"+trackname, SearchOption.AllDirectories);
            
            //Delete Playlist
            playListImSearchingFor.Delete();

            //Copy File to chosen output Directory

            //If the file already exists, delete it!
            if(File.Exists(txtOutputDirectory.Text + trackname))
            {
                File.Delete(txtOutputDirectory.Text + trackname);
            }
            
            File.Move(files[0].ToString(), txtOutputDirectory.Text + trackname);

            string trackname2 = trackname.Replace(".m4a", ".m4r");
            string renamed = txtOutputDirectory.Text + trackname2;

            //Rename File
            //If the file already exists, delete it!
            if (File.Exists(renamed))
            {
                File.Delete(renamed);
            }

            //Copy File
            File.Move(txtOutputDirectory.Text + trackname, renamed);

            //Move File
            string newLocation = files[0].ToString();
            int last = newLocation.LastIndexOf("\\") + 1;
            newLocation = newLocation.Remove(last);
            newLocation = newLocation + trackname2;

            if(File.Exists(newLocation))
            {
                File.Delete(newLocation);
            }
            File.Move(renamed, newLocation);

            //Close iTunes again
            itunes.Quit();

            //Open File to import into iTunes
            Process.Start(newLocation);            
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                txtChosenFile.Text = openFileDlg.FileName;
            }
        }

        private void txtEndTimeTextChanged(object sender, EventArgs e)
        {
            int start, end;
            start = Convert.ToInt32(txtStartTime.Text);
            end = Convert.ToInt32(txtEndTime.Text);

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
            IITUserPlaylist newPlayList = (IITUserPlaylist)itunes.CreatePlaylist("Temp");
        }

        public void createPlaylist(string name)
        {
            // create a new playList
            IITUserPlaylist newPlayList = (IITUserPlaylist)itunes.CreatePlaylist(name);
        }

        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {
            int start, end;
            start = Convert.ToInt32(txtStartTime.Text);
            end = Convert.ToInt32(txtEndTime.Text);

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
    }
}
