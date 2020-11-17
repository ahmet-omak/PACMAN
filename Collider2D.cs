using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACMAN
{
    static class Collider2D
    {
        #region GLOBAL VARIABLES
        static PictureBox temp;
        static int tempWidth, tempHeight, scaleValue;
        #endregion

        //Detect If Given Objects Are In Collide
        public static bool Detect(PictureBox player, PictureBox[] enemies, string direction)
        {
            temp = new PictureBox();
            bool isIntersect = false;
            if (direction == "right")
            {
                temp = GetTempRect(player, direction);
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i].Bounds.IntersectsWith(temp.Bounds))
                    {
                        isIntersect = true;
                        return isIntersect;
                    }
                }
            }
            if (direction == "left")
            {
                temp = GetTempRect(player, direction);
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i].Bounds.IntersectsWith(temp.Bounds))
                    {
                        isIntersect = true;
                        return isIntersect;
                    }
                }
            }
            if (direction == "up")
            {
                temp = GetTempRect(player, direction);
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i].Bounds.IntersectsWith(temp.Bounds))
                    {
                        isIntersect = true;
                        return isIntersect;
                    }
                }
            }
            if (direction == "down")
            {
                temp = GetTempRect(player, direction);
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i].Bounds.IntersectsWith(temp.Bounds))
                    {
                        isIntersect = true;
                        return isIntersect;
                    }
                }
            }
            return isIntersect;
        }

        //Get The Temp. Rect. To Use In Detect Func.
        private static PictureBox GetTempRect(PictureBox refPic, string direction)
        {
            tempWidth = 2;
            tempHeight = 28;
            scaleValue = 2;
            PictureBox temp = new PictureBox();
            Size tempSize = new Size(tempWidth, tempHeight);
            if (direction == "right")
            {
                temp.Left = refPic.Location.X + refPic.Width + scaleValue;
                temp.Top = refPic.Location.Y + scaleValue;
                temp.Size = tempSize;
            }
            if (direction == "left")
            {
                temp.Left = refPic.Location.X - scaleValue;
                temp.Top = refPic.Location.Y + scaleValue;
                temp.Size = tempSize;
            }
            tempSize = new Size(tempHeight, tempWidth);
            if (direction == "up")
            {
                temp.Left = refPic.Location.X + scaleValue;
                temp.Top = refPic.Location.Y - scaleValue;
                temp.Size = tempSize;
            }
            if (direction == "down")
            {
                temp.Left =refPic.Location.X + scaleValue;
                temp.Top = refPic.Location.Y + refPic.Height + scaleValue;
                temp.Size = tempSize;
            }
            return temp;
        }
    }
}
