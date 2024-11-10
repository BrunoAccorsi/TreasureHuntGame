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
            sourcePanel.SuspendLayout();
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
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1272, 1109);
            panel1.TabIndex = 0;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel gridPanel;
        private Panel sourcePanel;
        private Label label1;
        private Panel panel1;
    }
}
