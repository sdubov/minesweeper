using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        private int pointRow;
        private int pointCol;
        private int seconds;

        private static Game game = Game.GameInstance;

        private static GameSettings gameSettings = GameSettings.GameSettingsInstance;

        private Bitmap playfieldImage;

        public Minesweeper()
        {
            InitializeComponent();

            //Cell cell = new Cell(); // TODO: Probably need to move it somewhere. 
            //                        // It is placed here because not clear where we should create an array with opened cells.
            
            // Drawing playfiled with closed cells.
            playfieldImage = new Bitmap(gameSettings.FieldSize * 20, gameSettings.FieldSize * 20);
            Graphics g = Graphics.FromImage(playfieldImage);
            
            // Start game.
            game.StartGame(g);

            // Assign generated image as image for playfield.
            playfieldArea.Image = playfieldImage;

            // Set value of bombs in the text field.
            bombsNumberTextBox.Text = gameSettings.BombsNumber.ToString().PadLeft(2, '0');

            // Subscribe on stop timer and disable field methods.
            game.TimerStopDelegate += this.StopTimer;
            game.TimerStopDelegate += this.DisablePlayfield;
            
            // Subscribe on Update bombs textfield method.
            game.UpdateBombsNumberDelegate += this.UpdateBombsTextfield;
        }

        #region Mouse click handlers

        /// <summary>
        /// Mouse click handler for playfield area.
        /// </summary>
        /// <param name="sender">sender param.</param>
        /// <param name="e">e param.</param>
        private void playfieldArea_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine an index in the array according to clicked coordinates.
            // '20' is a constant value that is determined by cell image size.
            pointRow = e.X / 20;
            pointCol = e.Y / 20;

            Graphics g = Graphics.FromImage(playfieldImage);

            // Left button handler.
            if (e.Button == MouseButtons.Left)
            {
                // Start the timer after first click.
                gameTimer.Start();

                Cell.OpenCell(pointRow, pointCol, g);
            }

            // Right button handler.
            if (e.Button == MouseButtons.Right)
            {
                Cell.SetFlag(pointRow, pointCol, g);
            }

            // Middle button handler.
            if (e.Button == MouseButtons.Middle)
            {
                Cell.OpenFlagArea(pointRow, pointCol, g);
            }

            // Update image of playfield.
            playfieldArea.Image = playfieldImage;
        }

        #endregion

        #region Menu Handlers

        #region New Game

        /// <summary>
        /// New game menu handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartPictureBox_Click(sender, e);
        }

        #endregion

        #region Difficulty

        /// <summary>
        /// Handle changing difficulty to 'easy'.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event object.</param>
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if current difficulty is already set.
            if (!easyToolStripMenuItem.Checked)
            {
                // Set difficulty property for Game Settings.
                GameSettings.ChangeDifficulty(0);

                // Re-set all checkboxes for other difficulty.
                this.easyToolStripMenuItem.CheckState = CheckState.Checked;
                this.normalToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.expertToolStripMenuItem.CheckState = CheckState.Unchecked;

                // Restart game.
                restartPictureBox_Click(sender, e);
            }
        }

        /// <summary>
        /// Handle changing difficulty to 'normal'.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event object.</param>
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if current difficulty is already set.
            if (!normalToolStripMenuItem.Checked)
            {
                // Set difficulty property for Game Settings.
                GameSettings.ChangeDifficulty(1);

                // Re-set all checkboxes for other difficulty.
                this.easyToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.normalToolStripMenuItem.CheckState = CheckState.Checked;
                this.expertToolStripMenuItem.CheckState = CheckState.Unchecked;

                // Restart game.
                restartPictureBox_Click(sender, e);
            }
        }

        /// <summary>
        /// Handle changing difficulty to 'expert'.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event object.</param>
        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if current difficulty is already set.
            if (!expertToolStripMenuItem.Checked)
            {
                // Set difficulty property for Game Settings.
                GameSettings.ChangeDifficulty(2);

                // Re-set all checkboxes for other difficulty.
                this.easyToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.normalToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.expertToolStripMenuItem.CheckState = CheckState.Checked;

                // Restart game.
                restartPictureBox_Click(sender, e);
            }
        }

        #endregion

        #region Winners

        /// <summary>
        /// Show winners form.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void winnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show winners form.
            Winners winnersForms = new Winners();
            winnersForms.Show();
            winnersForms.ShowWinners();
        }

        #endregion

        #region Exit

        /// <summary>
        /// Exit of the application from menu.
        /// </summary>
        /// <param name="sender">Sender parameter.</param>
        /// <param name="e">Even argument.</param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region About

        /// <summary>
        /// About menu item handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event args.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create and show About form.
            About aboutForm = new About();
            aboutForm.Show();
        }

        #endregion

        #endregion

        #region Static elements (timer, bombs number, playfield)

        /// <summary>
        /// Handling timer tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            seconds++;
            timerTextBox.Text = seconds.ToString().PadLeft(3, '0');
        }

        /// <summary>
        /// Stop current timer.
        /// </summary>
        public void StopTimer()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.StopTimer));
                return;
            }

            gameTimer.Stop();

            // Store timer value.
            game.TimerValue = this.timerTextBox.Text;
        }

        /// <summary>
        /// Disable playfield image.
        /// </summary>
        public void DisablePlayfield()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.DisablePlayfield));
                return;
            }

            this.playfieldArea.Enabled = false;
        }

        /// <summary>
        /// Set bombs text field.
        /// </summary>
        public void UpdateBombsTextfield()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.UpdateBombsTextfield));
                return;
            }

            bombsNumberTextBox.Text = Game.GameInstance.BombsCounter.ToString();
        }

        #endregion

        #region Restart Button

        /// <summary>
        /// Restart button click handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartPictureBox_Click(object sender, EventArgs e)
        {
            // Reset timer value;
            gameTimer.Stop();
            seconds = 0;
            timerTextBox.Text = seconds.ToString().PadLeft(3, '0');
            
            // Enable playfiled area.
            this.playfieldArea.Enabled = true;

            // Change position of static controls (timer picture, timer text, restart button).
            this.timerPictureBox.Location = new Point(20 * GameSettings.GameSettingsInstance.FieldSize - 25, 32);
            this.timerTextBox.Location = new Point(20 * GameSettings.GameSettingsInstance.FieldSize - 66, 35);
            this.restartPictureBox.Location = new Point(20 * GameSettings.GameSettingsInstance.FieldSize / 2 - 14, 27);
            
            // Changing the form and playfield size.
            this.ClientSize = new System.Drawing.Size(20 * GameSettings.GameSettingsInstance.FieldSize, 60 + 20 * GameSettings.GameSettingsInstance.FieldSize);
            this.playfieldArea.Size = new Size(20 * GameSettings.GameSettingsInstance.FieldSize, 20 * GameSettings.GameSettingsInstance.FieldSize);

            

            // Invoke restart game method and re-drawing the playfield.
            playfieldImage = new Bitmap(GameSettings.GameSettingsInstance.FieldSize * 20, GameSettings.GameSettingsInstance.FieldSize * 20);

            Graphics g = Graphics.FromImage(playfieldImage);

            // Start game.
            game.StartGame(g);

            // Assign generated image as image for playfield.
            playfieldArea.Image = playfieldImage;
            


            

            // Set value of bombs in the text field and reset the counter for bombs.
            bombsNumberTextBox.Text = GameSettings.GameSettingsInstance.BombsNumber.ToString().PadLeft(2, '0');
            Game.GameInstance.BombsCounter = GameSettings.GameSettingsInstance.BombsNumber;
        }

        #endregion
    }
}
