using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace PACMAN
{
    public partial class LoserForm : Form
    {
        public LoserForm(string ghostName, double score)
        {
            InitializeComponent();
            GhostName = ghostName;
            Score = score;
        }

        #region GLOBAL VARIABLES
        WindowsMediaPlayer formSound;
        string GhostName;
        double Score;
        #endregion

        //Load Screen
        private void LoadScreen(object sender, EventArgs e)
        {
            formSound = new WindowsMediaPlayer();
            formSound.URL = $@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sounds\loadingsound.mp3";
            formSound.settings.setMode("loop", true);
            formSound.controls.play();
            lblGhost.Text = GhostName + " Got You !";
            lblScore.Text = $"You Collected %{Score} of Coins";
        }

        //Close Form Event
        private void Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Restart Game
        private void RestartGame(object sender, EventArgs e)
        {
            Application.Restart();
        }

        //Close Game
        private void CloseGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
