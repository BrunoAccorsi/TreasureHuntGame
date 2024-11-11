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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            gridPanel = new Panel();
            sourcePanel = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            endTurnButton = new Button();
            label2 = new Label();
            sourcePanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // gridPanel
            // 
            gridPanel.AllowDrop = true;
            gridPanel.BackColor = Color.Wheat;
            gridPanel.Location = new Point(278, 276);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(780, 728);
            gridPanel.TabIndex = 0;
            // 
            // sourcePanel
            // 
            sourcePanel.AllowDrop = true;
            sourcePanel.AutoScroll = true;
            sourcePanel.BackColor = Color.Wheat;
            sourcePanel.Controls.Add(label1);
            sourcePanel.Location = new Point(12, 276);
            sourcePanel.Name = "sourcePanel";
            sourcePanel.Size = new Size(200, 728);
            sourcePanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(178, 76);
            label1.TabIndex = 0;
            label1.Text = "Choose the Treasures and traps to place";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1272, 1109);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Wheat;
            panel2.Controls.Add(endTurnButton);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 124);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 100);
            panel2.TabIndex = 0;
            // 
            // endTurnButton
            // 
            endTurnButton.BackColor = Color.Tan;
            endTurnButton.Location = new Point(10, 64);
            endTurnButton.Name = "endTurnButton";
            endTurnButton.Size = new Size(178, 23);
            endTurnButton.TabIndex = 2;
            endTurnButton.Text = "End Turn";
            endTurnButton.UseVisualStyleBackColor = false;
            endTurnButton.Click += endTurnButton_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 11);
            label2.Name = "label2";
            label2.Size = new Size(178, 76);
            label2.TabIndex = 1;
            label2.Text = " Player 1 (Hider) turn";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1272, 1109);
            Controls.Add(sourcePanel);
            Controls.Add(gridPanel);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            sourcePanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel gridPanel;
        private Panel sourcePanel;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Button endTurnButton;
        private Label label2;
    }
}
