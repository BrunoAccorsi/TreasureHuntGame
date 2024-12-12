namespace TreasureHunt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridPanel = new Panel();
            sourcePanel = new Panel();
            panel1 = new Panel();
            ScorePanel = new Panel();
            label2 = new Label();
            playerTwoLabel = new Label();
            playerOneLabel = new Label();
            label3 = new Label();
            gameStatePanel = new Panel();
            gameStateLabel = new Label();
            restartButton = new Button();
            endTurnButton = new Button();
            turnLabel = new Label();
            pictureBox1 = new PictureBox();
            btn_startOver = new Button();
            panel1.SuspendLayout();
            ScorePanel.SuspendLayout();
            gameStatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // gridPanel
            // 
            gridPanel.AllowDrop = true;
            gridPanel.BackColor = Color.Wheat;
            gridPanel.Location = new Point(256, 262);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(780, 728);
            gridPanel.TabIndex = 0;
            // 
            // sourcePanel
            // 
            sourcePanel.AllowDrop = true;
            sourcePanel.AutoScroll = true;
            sourcePanel.BackColor = Color.Wheat;
            sourcePanel.Location = new Point(12, 262);
            sourcePanel.Name = "sourcePanel";
            sourcePanel.Size = new Size(200, 728);
            sourcePanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(ScorePanel);
            panel1.Controls.Add(sourcePanel);
            panel1.Controls.Add(gameStatePanel);
            panel1.Controls.Add(gridPanel);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1272, 780);
            panel1.TabIndex = 0;
            // 
            // ScorePanel
            // 
            ScorePanel.BackColor = Color.Wheat;
            ScorePanel.Controls.Add(btn_startOver);
            ScorePanel.Controls.Add(label2);
            ScorePanel.Controls.Add(playerTwoLabel);
            ScorePanel.Controls.Add(playerOneLabel);
            ScorePanel.Controls.Add(label3);
            ScorePanel.Location = new Point(1029, 12);
            ScorePanel.Name = "ScorePanel";
            ScorePanel.Size = new Size(200, 138);
            ScorePanel.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(52, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 4;
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // playerTwoLabel
            // 
            playerTwoLabel.AutoSize = true;
            playerTwoLabel.BackColor = Color.Transparent;
            playerTwoLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playerTwoLabel.ForeColor = Color.DarkGreen;
            playerTwoLabel.Location = new Point(10, 61);
            playerTwoLabel.Name = "playerTwoLabel";
            playerTwoLabel.Size = new Size(96, 37);
            playerTwoLabel.TabIndex = 1;
            playerTwoLabel.Text = "label2";
            // 
            // playerOneLabel
            // 
            playerOneLabel.AutoSize = true;
            playerOneLabel.BackColor = Color.Transparent;
            playerOneLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playerOneLabel.ForeColor = Color.DarkRed;
            playerOneLabel.Location = new Point(10, 11);
            playerOneLabel.Name = "playerOneLabel";
            playerOneLabel.Size = new Size(96, 37);
            playerOneLabel.TabIndex = 1;
            playerOneLabel.Text = "label2";
            // 
            // label3
            // 
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 11);
            label3.Name = "label3";
            label3.Size = new Size(178, 29);
            label3.TabIndex = 1;
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // gameStatePanel
            // 
            gameStatePanel.BackColor = Color.Wheat;
            gameStatePanel.Controls.Add(gameStateLabel);
            gameStatePanel.Controls.Add(restartButton);
            gameStatePanel.Controls.Add(endTurnButton);
            gameStatePanel.Controls.Add(turnLabel);
            gameStatePanel.Location = new Point(12, 117);
            gameStatePanel.Name = "gameStatePanel";
            gameStatePanel.Size = new Size(200, 139);
            gameStatePanel.TabIndex = 0;
            // 
            // gameStateLabel
            // 
            gameStateLabel.AutoSize = true;
            gameStateLabel.BackColor = Color.Transparent;
            gameStateLabel.ForeColor = Color.Red;
            gameStateLabel.Location = new Point(52, 5);
            gameStateLabel.Name = "gameStateLabel";
            gameStateLabel.Size = new Size(0, 15);
            gameStateLabel.TabIndex = 4;
            gameStateLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // restartButton
            // 
            restartButton.BackColor = Color.Tan;
            restartButton.Location = new Point(11, 71);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(178, 23);
            restartButton.TabIndex = 3;
            restartButton.Text = "Restart Game";
            restartButton.UseVisualStyleBackColor = false;
            restartButton.Click += RestartButton_Click;
            // 
            // endTurnButton
            // 
            endTurnButton.BackColor = Color.Tan;
            endTurnButton.Location = new Point(10, 45);
            endTurnButton.Name = "endTurnButton";
            endTurnButton.Size = new Size(178, 23);
            endTurnButton.TabIndex = 2;
            endTurnButton.Text = "End Turn";
            endTurnButton.UseVisualStyleBackColor = false;
            endTurnButton.Click += endTurnButton_Click;
            // 
            // turnLabel
            // 
            turnLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            turnLabel.Location = new Point(10, 20);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new Size(178, 29);
            turnLabel.TabIndex = 1;
            turnLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.SteelBlue;
            pictureBox1.BackgroundImage = Properties.Resources.Background1;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1255, 990);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btn_startOver
            // 
            btn_startOver.BackColor = Color.Tan;
            btn_startOver.Location = new Point(10, 106);
            btn_startOver.Name = "btn_startOver";
            btn_startOver.Size = new Size(178, 23);
            btn_startOver.TabIndex = 5;
            btn_startOver.Text = "Start over";
            btn_startOver.UseVisualStyleBackColor = false;
            btn_startOver.Click += btn_startOver_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1272, 780);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ScorePanel.ResumeLayout(false);
            ScorePanel.PerformLayout();
            gameStatePanel.ResumeLayout(false);
            gameStatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel gridPanel;
        private Panel sourcePanel;
        private Panel panel1;
        private Panel gameStatePanel;
        private Button endTurnButton;
        private Label turnLabel;
        private Button restartButton;
        private PictureBox pictureBox1;
        private Label gameStateLabel;
        private Label playerOneLabel;
        private Label playerTwoLabel;
        private Panel ScorePanel;
        private Label label2;
        private Label label3;
        private Button btn_startOver;
    }
}
