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
            label1 = new Label();
            panel1 = new Panel();
            playerOneLabel = new Label();
            playerTwoLabel = new Label();
            gameStatePanel = new Panel();
            gameStateLabel = new Label();
            restartButton = new Button();
            endTurnButton = new Button();
            turnLabel = new Label();
            pictureBox1 = new PictureBox();
            sourcePanel.SuspendLayout();
            panel1.SuspendLayout();
            gameStatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // gridPanel
            // 
            gridPanel.AllowDrop = true;
            gridPanel.BackColor = Color.Wheat;
            gridPanel.Location = new Point(256, 264);
            gridPanel.Margin = new Padding(3, 4, 3, 4);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(891, 971);
            gridPanel.TabIndex = 0;
            // 
            // sourcePanel
            // 
            sourcePanel.AllowDrop = true;
            sourcePanel.AutoScroll = true;
            sourcePanel.BackColor = Color.Wheat;
            sourcePanel.Controls.Add(label1);
            sourcePanel.Location = new Point(14, 349);
            sourcePanel.Margin = new Padding(3, 4, 3, 4);
            sourcePanel.Name = "sourcePanel";
            sourcePanel.Size = new Size(229, 971);
            sourcePanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 12);
            label1.Name = "label1";
            label1.Size = new Size(203, 101);
            label1.TabIndex = 0;
            label1.Text = "Choose the Treasures and traps to place";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(playerOneLabel);
            panel1.Controls.Add(playerTwoLabel);
            panel1.Controls.Add(sourcePanel);
            panel1.Controls.Add(gameStatePanel);
            panel1.Controls.Add(gridPanel);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1454, 1040);
            panel1.TabIndex = 0;
            // 
            // playerOneLabel
            // 
            playerOneLabel.AutoSize = true;
            playerOneLabel.BackColor = Color.Transparent;
            playerOneLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playerOneLabel.ForeColor = Color.OrangeRed;
            playerOneLabel.Location = new Point(811, 127);
            playerOneLabel.Name = "playerOneLabel";
            playerOneLabel.Size = new Size(117, 46);
            playerOneLabel.TabIndex = 1;
            playerOneLabel.Text = "label2";
            // 
            // playerTwoLabel
            // 
            playerTwoLabel.AutoSize = true;
            playerTwoLabel.BackColor = Color.Transparent;
            playerTwoLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playerTwoLabel.ForeColor = Color.Lime;
            playerTwoLabel.Location = new Point(811, 176);
            playerTwoLabel.Name = "playerTwoLabel";
            playerTwoLabel.Size = new Size(117, 46);
            playerTwoLabel.TabIndex = 1;
            playerTwoLabel.Text = "label2";
            // 
            // gameStatePanel
            // 
            gameStatePanel.BackColor = Color.Wheat;
            gameStatePanel.Controls.Add(gameStateLabel);
            gameStatePanel.Controls.Add(restartButton);
            gameStatePanel.Controls.Add(endTurnButton);
            gameStatePanel.Controls.Add(turnLabel);
            gameStatePanel.Location = new Point(14, 156);
            gameStatePanel.Margin = new Padding(3, 4, 3, 4);
            gameStatePanel.Name = "gameStatePanel";
            gameStatePanel.Size = new Size(229, 185);
            gameStatePanel.TabIndex = 0;
            // 
            // gameStateLabel
            // 
            gameStateLabel.AutoSize = true;
            gameStateLabel.BackColor = Color.Transparent;
            gameStateLabel.ForeColor = Color.Red;
            gameStateLabel.Location = new Point(59, 0);
            gameStateLabel.Name = "gameStateLabel";
            gameStateLabel.Size = new Size(0, 20);
            gameStateLabel.TabIndex = 4;
            gameStateLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // restartButton
            // 
            restartButton.BackColor = Color.Tan;
            restartButton.Location = new Point(13, 95);
            restartButton.Margin = new Padding(3, 4, 3, 4);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(203, 31);
            restartButton.TabIndex = 3;
            restartButton.Text = "Restart Game";
            restartButton.UseVisualStyleBackColor = false;
            restartButton.Click += RestartButton_Click;
            // 
            // endTurnButton
            // 
            endTurnButton.BackColor = Color.Tan;
            endTurnButton.Location = new Point(11, 60);
            endTurnButton.Margin = new Padding(3, 4, 3, 4);
            endTurnButton.Name = "endTurnButton";
            endTurnButton.Size = new Size(203, 31);
            endTurnButton.TabIndex = 2;
            endTurnButton.Text = "End Turn";
            endTurnButton.UseVisualStyleBackColor = false;
            endTurnButton.Click += endTurnButton_Click;
            // 
            // turnLabel
            // 
            turnLabel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            turnLabel.Location = new Point(11, 15);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new Size(203, 39);
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
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1433, 1320);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1454, 1040);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            sourcePanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gameStatePanel.ResumeLayout(false);
            gameStatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel gridPanel;
        private Panel sourcePanel;
        private Label label1;
        private Panel panel1;
        private Panel gameStatePanel;
        private Button endTurnButton;
        private Label turnLabel;
        private Button restartButton;
        private PictureBox pictureBox1;
        private Label gameStateLabel;
        private Label playerOneLabel;
        private Label playerTwoLabel;
    }
}
