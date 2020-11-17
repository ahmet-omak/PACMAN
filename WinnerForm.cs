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
    public partial class WinnerForm : Form
    {
        public WinnerForm()
        {
            InitializeComponent();
        }

        #region GLOBAL VARIABLES
        WindowsMediaPlayer formSound;
        #endregion

        //Load Screen
        private void LoadScreen(object sender, EventArgs e)
        {
            formSound = new WindowsMediaPlayer();
            formSound.URL= $@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sounds\loadingsound.mp3";
            formSound.settings.setMode("loop", true);
            formSound.controls.play();
        }

        //Restart Game
        private void RestartGame(object sender, EventArgs e)
        {
            Application.Restart();
        }

        //Close Game
        private void CloseScreen(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Close Form Event
        private void Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
