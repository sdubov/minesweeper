﻿namespace Minesweeper
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.okButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.aboutImagepPctureBox = new System.Windows.Forms.PictureBox();
            this.aboutText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.okButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutImagepPctureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButtonPictureBox
            // 
            this.okButtonPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("okButtonPictureBox.Image")));
            this.okButtonPictureBox.Location = new System.Drawing.Point(172, 78);
            this.okButtonPictureBox.Name = "okButtonPictureBox";
            this.okButtonPictureBox.Size = new System.Drawing.Size(60, 25);
            this.okButtonPictureBox.TabIndex = 0;
            this.okButtonPictureBox.TabStop = false;
            this.okButtonPictureBox.Click += new System.EventHandler(this.okButtonPictureBox_Click);
            // 
            // aboutImagepPctureBox
            // 
            this.aboutImagepPctureBox.Image = ((System.Drawing.Image)(resources.GetObject("aboutImagepPctureBox.Image")));
            this.aboutImagepPctureBox.Location = new System.Drawing.Point(10, 10);
            this.aboutImagepPctureBox.Name = "aboutImagepPctureBox";
            this.aboutImagepPctureBox.Size = new System.Drawing.Size(32, 32);
            this.aboutImagepPctureBox.TabIndex = 1;
            this.aboutImagepPctureBox.TabStop = false;
            // 
            // aboutText
            // 
            this.aboutText.AutoSize = true;
            this.aboutText.Location = new System.Drawing.Point(52, 20);
            this.aboutText.Name = "aboutText";
            this.aboutText.Size = new System.Drawing.Size(109, 78);
            this.aboutText.TabIndex = 2;
            this.aboutText.Text = "Minesweeper\n\nVersion: 1.0.0\nDesigned by SD\n\nMinesweeper © 2012";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 112);
            this.Controls.Add(this.aboutText);
            this.Controls.Add(this.aboutImagepPctureBox);
            this.Controls.Add(this.okButtonPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.okButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutImagepPctureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox okButtonPictureBox;
        private System.Windows.Forms.PictureBox aboutImagepPctureBox;
        private System.Windows.Forms.Label aboutText;

    }
}