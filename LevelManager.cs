using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace PACMAN
{
    class LevelManager
    {
        #region PROPS
        private int score { get; set; }
        private int wallCount { get; set; }
        private int coinCount { get; set; }
        private int takenCoinCount { get; set; }
        private string gameTitle { get; set; }
        private int playerWidth { get; set; }
        private int playerHeight { get; set; }
        private string ghostName { get; set; }
        public string gameState { get; set; }
        #endregion

        #region GLOBAL VARIABLES
        Form screen;
        PictureBox[] walls;
        PictureBox[] coins;
        PictureBox[] collectedCoins;
        WindowsMediaPlayer gameSound;
        #endregion

        //Init Level Manager
        public LevelManager(Form instance)
        {
            screen = new Form();
            screen = instance;
            gameTitle = " - Made By Ahmet Omak";
            screen.Text = "PACMAN" + gameTitle;
            takenCoinCount = score = wallCount = coinCount = 0;
            playerWidth = 32;
            playerHeight = 32;
        }

        //Load Level
        public void Load()
        {
            //Set Game State As Follows
            gameState = "starting";

            //Init walls array
            walls = new PictureBox[wallCount];

            //Init coins array
            coins = new PictureBox[coinCount];

            //İnit collectedCoins array
            collectedCoins = new PictureBox[takenCoinCount];

            foreach (Control item in screen.Controls)
            {
                if ((string)item.Tag == "Walls")
                {
                    wallCount++;
                    Array.Resize(ref walls, wallCount);
                    walls[wallCount - 1] = (PictureBox)item;
                    continue;
                }
                if ((string)item.Tag == "Coin")
                {
                    coinCount++;
                    Array.Resize(ref coins, coinCount);
                    coins[coinCount - 1] = (PictureBox)item;
                    continue;
                }
            }
        }

        public bool Update(string direction, int refX, int refY)
        {
            object[] Params = new object[] { direction, refX, refY };
            Collect(Params);
            TakeCoin();
            return IsGameOver();
        }

        //Collect Coins 
        private void Collect(object[] Params)
        {
            string direction = (string)Params[0];
            int refX = (int)Params[1];
            int refY = (int)Params[2];
            InitCollect(direction, refX, refY);
        }

        //Collect Coins
        private void InitCollect(string direction, int refX, int refY)
        {
            if (direction == "right")
            {
                PictureBox tempPlayer = new PictureBox();
                tempPlayer.Left = refX + playerWidth + 1;
                tempPlayer.Top = refY + 7;
                tempPlayer.Width = 2;
                tempPlayer.Height = 12;
                tempPlayer.Visible = false;
                screen.Controls.Add(tempPlayer);
                for (int i = 0; i < coins.Length; i++)
                {
                    if (coins[i].Bounds.IntersectsWith(tempPlayer.Bounds))
                    {
                        coins[i].Visible = false;
                    }
                }
                screen.Controls.Remove(tempPlayer);
                return;
            }

            if (direction == "left")
            {
                PictureBox tempPlayer = new PictureBox();
                tempPlayer.Left = refX - 1;
                tempPlayer.Top = refY + 7;
                tempPlayer.Width = 2;
                tempPlayer.Height = 12;
                tempPlayer.Visible = false;
                screen.Controls.Add(tempPlayer);
                for (int i = 0; i < coins.Length; i++)
                {
                    if (coins[i].Bounds.IntersectsWith(tempPlayer.Bounds))
                    {
                        coins[i].Visible = false;
                    }
                }
                screen.Controls.Remove(tempPlayer);
                return;
            }

            if (direction == "up")
            {
                PictureBox tempPlayer = new PictureBox();
                tempPlayer.Left = refX + 11;
                tempPlayer.Top = refY - 2;
                tempPlayer.Width = 2;
                tempPlayer.Height = 12;
                tempPlayer.Visible = false;
                screen.Controls.Add(tempPlayer);
                for (int i = 0; i < coins.Length; i++)
                {
                    if (coins[i].Bounds.IntersectsWith(tempPlayer.Bounds))
                    {
                        coins[i].Visible = false;
                    }
                }
                screen.Controls.Remove(tempPlayer);
                return;
            }

            if (direction == "down")
            {
                PictureBox tempPlayer = new PictureBox();
                tempPlayer.Left = refX + 11;
                tempPlayer.Top = refY + playerHeight + 2;
                tempPlayer.Width = 2;
                tempPlayer.Height = 12;
                tempPlayer.Visible = false;
                screen.Controls.Add(tempPlayer);
                for (int i = 0; i < coins.Length; i++)
                {
                    if (coins[i].Bounds.IntersectsWith(tempPlayer.Bounds))
                    {
                        coins[i].Visible = false;
                    }
                }
                screen.Controls.Remove(tempPlayer);
                return;
            }
        }

        //Store Taken Coins In An Array
        void TakeCoin()
        {
            foreach (Control item in screen.Controls)
            {
                if ((string)item.Tag == "Coin" && !item.Visible)
                {
                    takenCoinCount++;
                    Array.Resize(ref collectedCoins, takenCoinCount);
                    collectedCoins[takenCoinCount - 1] = (PictureBox)item;
                    item.Tag = "takenCoin";
                }
            }
        }

        //Check If Game is over
        public bool IsGameOver(Ghosts ghosts, PacMan player)
        {
            bool isGameOver = false;
            if (ghosts.GetBounds("blinky").IntersectsWith(player.GetBounds()))
            {
                isGameOver = true;
                ghostName = "Blinky";
                score = takenCoinCount;
            }
            if (ghosts.GetBounds("inky").IntersectsWith(player.GetBounds()))
            {
                isGameOver = true;
                ghostName = "Pinky";
                score = takenCoinCount;
            }
            return isGameOver;
        }

        //If PacMan Collects All Coins
        private bool IsGameOver()
        {
            //TODO
            bool isGameOver = false;
            if (takenCoinCount == coinCount)
            {
                isGameOver = true;
                score = takenCoinCount;
            }
            return isGameOver;
        }

        //Get Ghost Name Who Finds Pac Man
        public string WhoFinds()
        {
            return ghostName;
        }

        //Get Score
        public double GetScore()
        {
            return (100 * score / coinCount);
        }

        //Get PictureBoxes Tagged With Walls
        public PictureBox[] GetWalls() { return walls; }

        //Play Game Sound
        public void PlaySound()
        {
            gameSound = new WindowsMediaPlayer();
            gameSound.URL = $@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sounds\loadingsound.mp3";
            gameSound.controls.play();
        }

        //Close Game Sound
        public void CloseSound()
        {
            gameSound.controls.stop();
        }
    }
}
