namespace PACMAN
{
    partial class LoserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.developer = new System.Windows.Forms.Label();
            this.lblGhost = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // developer
            // 
            this.developer.AutoSize = true;
            this.developer.Location = new System.Drawing.Point(346, 487);
            this.developer.Name = "developer";
            this.developer.Size = new System.Drawing.Size(186, 19);
            this.developer.TabIndex = 0;
            this.developer.Text = "Made By Ahmet Omak";
            // 
            // lblGhost
            // 
            this.lblGhost.AutoSize = true;
            this.lblGhost.Location = new System.Drawing.Point(205, 57);
            this.lblGhost.Name = "lblGhost";
            this.lblGhost.Size = new System.Drawing.Size(143, 19);
            this.lblGhost.TabIndex = 1;
            this.lblGhost.Text = "GHOST GOT YOU !";
            this.lblGhost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(157, 152);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(219, 19);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Your collected %50 of coins";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(155, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(221, 65);
            this.button2.TabIndex = 4;
            this.button2.TabStop = false;
            this.button2.Text = "Play Again";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RestartGame);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(155, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 63);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseGame);
            // 
            // LoserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(544, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblGhost);
            this.Controls.Add(this.developer);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PACMAN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Close);
            this.Load += new System.EventHandler(this.LoadScreen);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label developer;
        private System.Windows.Forms.Label lblGhost;
        private System.Windows.Forms.Label lblScore;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}