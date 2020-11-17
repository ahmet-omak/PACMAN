using System;
using System.Drawing;
using System.Windows.Forms;

namespace PACMAN
{
    class PacMan
    {
        #region Props
        private Point location { get; set; }
        private Size size { get; set; }
        public int refX { get; set; }
        public int refY { get; set; }
        public string direction { get; set; }

        //MOVEMENT PROPS
        public bool right { get; set; }
        public bool left { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public int speed { get; set; }

        #endregion

        #region GLOBAL VARIABLES
        PictureBox player;
        Form screen;
        #endregion

        //Init PacMan
        public PacMan(Form instance)
        {
            player = new PictureBox();
            screen = new Form();
            this.location = new Point(0, 190);
            this.size = new Size(32, 32);
            this.speed = 4;
            screen = instance;
        }

        //Load Pac-Man 
        public void Load()
        {
            player.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\pacman.jpg");
            player.Location = this.location;
            player.Width = this.size.Width;
            player.Height = this.size.Height;
            this.refX = player.Left;
            this.refY = player.Top;
            this.direction = "idle";
            player.Tag = "PacMan";
            screen.Controls.Add(player);
        }

        //Update Pac-Man Per 20 ms.
        public void Update(string direction, PictureBox[] walls)
        {
            //Set refX and refY Props
            this.refX = player.Left;
            this.refY = player.Top;

            //Moves The Player
            Move(direction, walls);

            //Teleports The Player In Case
            Teleport();
        }

        //Move Pac-Man
        private void Move(string direction, PictureBox[] walls)
        {
            if (right && !Collider2D.Detect(player, walls, "right"))
            {
                player.Left += speed;
                SetPlayerImage(direction);
            }
            else if (left && !Collider2D.Detect(player, walls, "left"))
            {
                player.Left -= speed;
                SetPlayerImage(direction);
            }
            else if (up && !Collider2D.Detect(player, walls, "up"))
            {
                player.Top -= speed;
                SetPlayerImage(direction);
            }
            else if (down && !Collider2D.Detect(player, walls, "down"))
            {
                player.Top += speed;
                SetPlayerImage(direction);
            }
        }

        //Set Pac-Man Image For The Given Direction
        void SetPlayerImage(string direction)
        {
            if (direction == "right")
            {
                player.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\pacman.jpg");
                this.direction = "right";
                return;
            }
            if (direction == "left")
            {
                player.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\pacman.jpg");
                this.direction = "left";
                player.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                return;
            }
            if (direction == "up")
            {
                player.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\pacman.jpg");
                this.direction = "up";
                player.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
                return;
            }
            if (direction == "down")
            {
                player.Image = Image.FromFile($@"C:\Users\{Environment.UserName}\OneDrive\Desktop\Pac-Man\Sprites\pacman.jpg");
                this.direction = "down";
                player.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                return;
            }
        }

        //Teleport PacMan If Neccessary
        void Teleport()
        {
            if (player.Location.X <= -32 && (player.Location.Y >= 185 || player.Location.Y <= 195))
            {
                player.Location = new Point(1200, 190);
                return;
            }
            if (player.Location.X >= 1200 && (player.Location.Y >= 185 || player.Location.Y <= 195))
            {
                player.Location = new Point(-32, 190);
                return;
            }
        }

        //Get Pac-Man Bounds 
        public Rectangle GetBounds() { return player.Bounds; }
    }
}
