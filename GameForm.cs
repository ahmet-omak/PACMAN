using System;
using System.Threading;
using System.Windows.Forms;

namespace PACMAN
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            ghosts = new Ghosts(this);
            ghosts.Load();

            player = new PacMan(this);
            player.Load();

            InitializeComponent();
        }

        #region PACMAN MOVEMENT KEYS
        private void isKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                player.right = true;
            }
            if (e.KeyCode == Keys.A)
            {
                player.left = true;
            }
            if (e.KeyCode == Keys.W)
            {
                player.up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                player.down = true;
            }
        }
        private void isKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                player.right = false;
            }
            if (e.KeyCode == Keys.A)
            {
                player.left = false;
            }
            if (e.KeyCode == Keys.W)
            {
                player.up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                player.down = false;
            }
        }
        #endregion

        #region GLOBAL VARIABLES
        WinnerForm formWinner;
        LoserForm formnLoser;
        Thread playLoadingSound;
        Thread closeLoadingSound;
        LevelManager level;
        PacMan player;
        Ghosts ghosts;
        bool isGameOver;
        string ghostName;
        double score;
        #endregion

        //Load Screen
        private void LoadScreen(object sender, EventArgs e)
        {
            level = new LevelManager(this);
            playLoadingSound = new Thread(new ThreadStart(level.PlaySound));
            closeLoadingSound = new Thread(new ThreadStart(level.CloseSound));
            playLoadingSound.Start();
            level.Load();
            GameTimer.Enabled = true;
        }

        //Update Game Per 20 ms.
        private void Update(object sender, EventArgs e)
        {
            if (level.gameState == "starting")
            {
                Thread.Sleep(5050);
                level.gameState = "running";
                closeLoadingSound.Start();
            }
            if (level.gameState == "running")
            {
                isGameOver = level.Update(player.direction, player.refX, player.refY);
                if (isGameOver)
                {
                    formWinner = new WinnerForm();
                    formWinner.Show();
                    GameTimer.Stop();
                }
                isGameOver = level.IsGameOver(ghosts, player);
                if (isGameOver)
                {
                    ghostName = level.WhoFinds();
                    score = level.GetScore();
                    formnLoser = new LoserForm(ghostName, score);
                    formnLoser.Show();
                    GameTimer.Stop();
                }
                #region PLAYER MOVEMENT UPDATE
                if (player.right)
                {
                    player.Update("right", level.GetWalls());
                }
                else if (player.left)
                {
                    player.Update("left", level.GetWalls());
                }
                else if (player.up)
                {
                    player.Update("up", level.GetWalls());
                }
                else if (player.down)
                {
                    player.Update("down", level.GetWalls());
                }
                #endregion
                ghosts.Update(player, level.GetWalls());
            }
        }
    }
}
