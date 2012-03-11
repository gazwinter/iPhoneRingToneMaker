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
            //TODO: Split into a smaller functions

            //Create an instance of iTunes
            iTunesApp itunes = new iTunesApp();
            string songfile = null;

            // create a new playList
            IITUserPlaylist newPlayList = (IITUserPlaylist)itunes.CreatePlaylist("Temp");

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
            //TODO: Enable manual choice of start and end times, as long as it is 40 seconds or less.
            IITTrack track = playListImSearchingFor.Tracks[1];
            track.Start = 0;
            track.Finish = 30;

            string trackname = null;
            var result = itunes.ConvertFile2(songfile);
            trackname = result.trackName;
            while (result.InProgress)
            {
                
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
            File.Move(files[0].ToString(), txtOutputDirectory.Text + trackname);

            string trackname2 = trackname.Replace(".m4a", ".m4r");

            string renamed = txtOutputDirectory.Text + trackname2;

            //Rename File
            File.Move(txtOutputDirectory.Text + trackname, renamed);

            //Move File
            string newLocation = files[0].ToString();
            int last = newLocation.LastIndexOf("\\") + 1;
            newLocation = newLocation.Remove(last);

            newLocation = newLocation + trackname2;
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
    }
}
