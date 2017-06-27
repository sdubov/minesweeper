namespace Minesweeper
{
    partial class Minesweeper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Minesweeper));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.timerTextBox = new System.Windows.Forms.TextBox();
            this.timerPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.bombsNumberTextBox = new System.Windows.Forms.TextBox();
            this.restartPictureBox = new System.Windows.Forms.PictureBox();
            this.playfieldArea = new System.Windows.Forms.PictureBox();
            this.winnersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playfieldArea)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(200, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.difficultyToolStripMenuItem,
            this.winnersToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.expertToolStripMenuItem});
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.difficultyToolStripMenuItem.Text = "Difficulty";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Checked = true;
            this.easyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.easyToolStripMenuItem.Text = "Easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.easyToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.expertToolStripMenuItem.Text = "Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // timerTextBox
            // 
            this.timerTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.timerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timerTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.timerTextBox.Enabled = false;
            this.timerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.timerTextBox.Location = new System.Drawing.Point(134, 35);
            this.timerTextBox.Name = "timerTextBox";
            this.timerTextBox.Size = new System.Drawing.Size(37, 15);
            this.timerTextBox.TabIndex = 2;
            this.timerTextBox.Text = "000";
            this.timerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timerPictureBox
            // 
            this.timerPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("timerPictureBox.Image")));
            this.timerPictureBox.Location = new System.Drawing.Point(175, 32);
            this.timerPictureBox.Name = "timerPictureBox";
            this.timerPictureBox.Size = new System.Drawing.Size(20, 20);
            this.timerPictureBox.TabIndex = 3;
            this.timerPictureBox.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(5, 32);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(20, 20);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // bombsNumberTextBox
            // 
            this.bombsNumberTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.bombsNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bombsNumberTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bombsNumberTextBox.Enabled = false;
            this.bombsNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bombsNumberTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.bombsNumberTextBox.Location = new System.Drawing.Point(30, 35);
            this.bombsNumberTextBox.Name = "bombsNumberTextBox";
            this.bombsNumberTextBox.Size = new System.Drawing.Size(37, 15);
            this.bombsNumberTextBox.TabIndex = 5;
            this.bombsNumberTextBox.Text = "00";
            // 
            // restartPictureBox
            // 
            this.restartPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("restartPictureBox.Image")));
            this.restartPictureBox.Location = new System.Drawing.Point(86, 27);
            this.restartPictureBox.Name = "restartPictureBox";
            this.restartPictureBox.Size = new System.Drawing.Size(30, 30);
            this.restartPictureBox.TabIndex = 6;
            this.restartPictureBox.TabStop = false;
            this.restartPictureBox.Click += new System.EventHandler(this.restartPictureBox_Click);
            // 
            // playfieldArea
            // 
            this.playfieldArea.Location = new System.Drawing.Point(0, 60);
            this.playfieldArea.Name = "playfieldArea";
            this.playfieldArea.Size = new System.Drawing.Size(200, 200);
            this.playfieldArea.TabIndex = 0;
            this.playfieldArea.TabStop = false;
            this.playfieldArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playfieldArea_MouseDown);
            // 
            // winnersToolStripMenuItem
            // 
            this.winnersToolStripMenuItem.Name = "winnersToolStripMenuItem";
            this.winnersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.winnersToolStripMenuItem.Text = "Winners...";
            this.winnersToolStripMenuItem.Click += new System.EventHandler(this.winnersToolStripMenuItem_Click);
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 260);
            this.Controls.Add(this.playfieldArea);
            this.Controls.Add(this.restartPictureBox);
            this.Controls.Add(this.bombsNumberTextBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.timerPictureBox);
            this.Controls.Add(this.timerTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playfieldArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox timerTextBox;
        private System.Windows.Forms.PictureBox timerPictureBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox bombsNumberTextBox;
        private System.Windows.Forms.PictureBox restartPictureBox;
        private System.Windows.Forms.PictureBox playfieldArea;
        private System.Windows.Forms.ToolStripMenuItem winnersToolStripMenuItem;
    }
}

