using System;
using System.Drawing;
using System.Windows.Forms;

namespace PACMAN
{
    class Ghosts
    {
        #region PROPS
        //BLINKY PROPS
        private bool blinkyRight { get; set; }
        private bool blinkyLeft { get; set; }
        private bool blinkyUp { get; set; }
        private bool blinkyDown { get; set; }

        //INKY PROPS
        private bool inkyRight { get; set; }
        private bool inkyLeft { get; set; }
        private bool inkyUp { get; set; }
        private bool inkyDown { get; set; }

        //OTHER PROPS
        private int blinkySpeed { get; set; }
        private int inkySpeed { get; set; }
        private int refX { get; set; }
        private int refY { get; set; }

        private string GhostName { get; set; }
        #endregion

        #region GLOBAL VARIABLES
        PictureBox blinky;
        PictureBox inky;
        string stateBlinky;
        string stateInky;
        Form screen;
        #endregion

        //Init Ghosts
        public Ghosts(Form instance)
        {
            screen = instance;
        }

        //Load Ghosts
        public void Load()
        {
            //Blinky Load Commits
            blinky = new PictureBox();
            blinky.Location = new Point(1200, 190);
            blinky.Size = new Size(32, 32);
            blinky.BackColor = Color.Red;
            stateBlinky = "idle";
            blinkySpeed = 2;
            blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\idleblinky.jpg");
            blinky.Tag = "Blinky";
            screen.Controls.Add(blinky);


            //Inky Load Commits
            inky = new PictureBox();
            inky.Location = new Point(1200, 190);
            inky.Size = new Size(32, 32);
            inky.BackColor = Color.Blue;
            stateInky = "idle";
            inkySpeed = 2;
            inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\idleinky.jpg");
            inky.Tag = "Inky";
            screen.Controls.Add(inky);
        }

        //Update Ghosts
        public void Update(PacMan player, PictureBox[] walls)
        {
            MoveBlinky(player, walls);
            MoveInky(player, walls);
        }


        //Each Frame Set An Object Ghost's Directions
        private void SetDirections(PictureBox[] walls, string ghostName)
        {
            #region RED GHOST DIRECTION PROPS
            if (Collider2D.Detect(blinky, walls, "right") && ghostName == "blinky")
            {
                blinkyRight = false;
            }
            else if (Collider2D.Detect(inky, walls, "right") && ghostName == "inky")
            {
                inkyRight = false;
            }

            if (Collider2D.Detect(blinky, walls, "left") && ghostName == "blinky")
            {
                blinkyLeft = false;
            }
            else if (Collider2D.Detect(inky, walls, "left") && ghostName == "inky")
            {
                inkyLeft = false;
            }

            if (Collider2D.Detect(blinky, walls, "up") && ghostName == "blinky")
            {
                blinkyUp = false;
            }
            else if (Collider2D.Detect(inky, walls, "up") && ghostName == "inky")
            {
                inkyUp = false;
            }

            if (Collider2D.Detect(blinky, walls, "down") && ghostName == "blinky")
            {
                blinkyDown = false;
            }
            else if (Collider2D.Detect(inky, walls, "down") && ghostName == "inky")
            {
                inkyDown = false;
            }

            if (!Collider2D.Detect(blinky, walls, "right") && ghostName == "blinky")
            {
                blinkyRight = true;
            }
            else if (!Collider2D.Detect(inky, walls, "right") && ghostName == "inky")
            {
                inkyRight = true;
            }

            if (!Collider2D.Detect(blinky, walls, "left") && ghostName == "blinky")
            {
                blinkyLeft = true;
            }
            else if (!Collider2D.Detect(inky, walls, "left") && ghostName == "inky")
            {
                inkyLeft = true;
            }

            if (!Collider2D.Detect(blinky, walls, "up") && ghostName == "blinky")
            {
                blinkyUp = true;
            }
            else if (!Collider2D.Detect(inky, walls, "up") && ghostName == "inky")
            {
                inkyUp = true;
            }

            if (!Collider2D.Detect(blinky, walls, "down") && ghostName == "blinky")
            {
                blinkyDown = true;
            }
            else if (!Collider2D.Detect(inky, walls, "down") && ghostName == "inky")
            {
                inkyDown = true;
            }
            #endregion
        }

        //Move Blinky 
        void MoveBlinky(PacMan player, PictureBox[] walls)
        {
            int minX = blinky.Location.X - player.refX;
            int minY = blinky.Location.Y - player.refY;

            SetDirections(walls, "blinky");

            if (stateBlinky == "idle")
            {
                if (minX > 0)
                {
                    //LEFT IDLE MOVEMENT
                    if (blinkyLeft && (blinkyUp || blinkyDown))
                    {
                        blinky.Left -= blinkySpeed;
                        blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\leftblinky.jpg");
                        return;
                    }
                    //MOVE Y AXIS

                    if (!blinkyLeft && blinkyUp)
                    {
                        blinky.Top -= blinkySpeed;
                        blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightblinky.jpg");
                        blinky.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                        return;
                    }
                }
                //RIGHT IDLE MOVEMENT
                else if (minX < 0)
                {
                    //MOVE ALONG X AXIS
                    if (blinkyRight && (blinkyUp || blinkyDown))
                    {
                        blinky.Left += blinkySpeed;
                        blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightblinky.jpg");
                        return;
                    }
                    if (!blinkyRight && blinkyUp)
                    {
                        blinky.Top -= blinkySpeed;
                        blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightblinky.jpg");
                        blinky.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                        return;
                    }
                }
            }
            // MOVE ALONG X AXIS
            if (minX > 0 && blinkyLeft)
            {
                blinky.Left += -blinkySpeed;
                blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\leftblinky.jpg");
                stateBlinky = "walking";
                return;
            }
            else if (minX < 0 && blinkyRight)
            {
                blinky.Left += blinkySpeed;
                blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightblinky.jpg");
                stateBlinky = "walking";
                return;
            }

            //MOVE ALONG Y AXIS
            if (minY > 0 && blinkyUp)
            {
                blinky.Top += -blinkySpeed;
                blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightblinky.jpg");
                blinky.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                stateBlinky = "walking";
                return;

            }
            else if (minY < 0 && blinkyDown)
            {
                blinky.Top += blinkySpeed;
                blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightblinky.jpg");
                blinky.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                stateBlinky = "walking";
                return;
            }
            else
            {
                stateBlinky = "idle";
                blinky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\idleblinky.jpg");
            }
        }

        //Move Inky
        void MoveInky(PacMan player, PictureBox[] walls)
        {
            int minX = inky.Location.X - player.refX;
            int minY = inky.Location.Y - player.refY;

            SetDirections(walls, "inky");

            if (stateInky == "idle")
            {
                if (minY < 0)
                {
                    if (!inkyDown && inkyRight)
                    {
                        inky.Left += inkySpeed;
                        inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightinky.png");
                        return;
                    }
                    if (!inkyDown && inkyLeft && inkyRight)
                    {
                        inky.Left += inkySpeed;
                        inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightinky.png");
                        return;
                    }
                }
                else if (minY > 0)
                {
                    if (!inkyUp && inkyLeft)
                    {
                        inky.Left -= inkySpeed;
                        inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\leftinky.jpg");
                        return;
                    }
                    if (!inkyUp && inkyLeft && inkyRight)
                    {
                        inky.Left -= inkySpeed;
                        inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\leftinky.jpg");
                        return;
                    }
                }
            }

            //MOVE ALONG Y AXIS
            if (minY > 0 && inkyUp)
            {
                inky.Top += -inkySpeed;
                inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightinky.png");
                inky.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                stateInky = "walking";
                return;

            }
            else if (minY < 0 && inkyDown)
            {
                inky.Top += inkySpeed;
                inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightinky.png");
                inky.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                stateInky = "walking";
                return;
            }

            // MOVE ALONG X AXIS
            if (minX > 0 && inkyLeft)
            {
                inky.Left += -inkySpeed;
                inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\leftinky.jpg");
                stateInky = "walking";
                return;
            }
            else if (minX < 0 && inkyRight)
            {
                inky.Left += inkySpeed;
                inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\rightinky.png");
                stateInky = "walking";
                return;
            }
            else
            {
                stateInky = "idle";
                inky.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\idleinky.jpg");
            }
        }

        //Get Blinky's Bounds
        public Rectangle GetBounds(string ghostName)
        {
            Rectangle tempRect = new Rectangle();
            if (ghostName == "blinky")
            {
                tempRect = blinky.Bounds;
            }
            if (ghostName == "inky")
            {
                tempRect = inky.Bounds;
            }
            return tempRect;
        }
    }
}
