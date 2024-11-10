namespace TreasureHunt
{
    public partial class Form1 : Form
    {
        private enum GameState { Hiding, Searching }
        private GameState currentState = GameState.Hiding;

        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        private const int GridSize = 6; // 6x6 grid
        private const int ImageSizeW = 132; // Size of each cell
        private const int ImageSizeH = 122; // Size of each cell 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            InitializeSourcePanel();
        }

        private void InitializeGrid()
        {
            gridPanel.Controls.Clear();
            gridPanel.AllowDrop = true;

            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    PictureBox picBox = new PictureBox
                    {
                        Size = new Size(ImageSizeW, ImageSizeH),
                        Location = new Point(col * ImageSizeW, row * ImageSizeH),
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Tag = new Point(row, col),
                        AllowDrop = true
                    };
                    picBox.Image = GetDefaultImage(); //this is the empty cell image

                    picBox.MouseDown += (s, e) => PictureBox_MouseDown(picBox, e);
                    picBox.DragEnter += (s, e) => PictureBox_DragEnter(picBox, e);
                    picBox.DragDrop += (s, e) => PictureBox_DragDrop(picBox, e);
                    picBox.MouseEnter += (s, e) => PictureBox_MouseEnter(picBox, e); //hover effect
                    picBox.MouseLeave += (s, e) => PictureBox_MouseLeave(picBox, e); //remove hover effect

                    gridPanel.Controls.Add(picBox);
                }
            }
        }

        private void InitializeSourcePanel()
        {
            //remove only the assets
            foreach (var control in sourcePanel.Controls.OfType<PictureBox>().ToArray())
            {
                sourcePanel.Controls.Remove(control);
                control.Dispose();
            }

            sourcePanel.DragEnter += (s, e) => SourcePanel_MouseDown(sourcePanel, e);

            Random random = new Random();
            var treasureTypes = Enum.GetValues(typeof(TreasureImage)).Cast<TreasureImage>().OrderBy(x => random.Next()).Take(3);
            var trapTypes = Enum.GetValues(typeof(TrapImage)).Cast<TrapImage>().OrderBy(x => random.Next()).Take(2);

            int yOffset = 100;
            foreach (var treasureType in treasureTypes)
            {
                // Create a PictureBox for each treasure
                PictureBox sourcePicBox = new PictureBox
                {
                    Size = new Size(ImageSizeW, ImageSizeH),
                    Location = new Point(30, yOffset),
                    Image = TreasureImageLoader.GetImage(treasureType),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = treasureType, // Store the treasure type in the Tag property for identification
                    AllowDrop = true
                };

                sourcePicBox.MouseDown += (s, e) => SourcePictureBox_MouseDown(sourcePicBox, e);

                sourcePanel.Controls.Add(sourcePicBox);
                yOffset += ImageSizeW + 20;
            }

            foreach (var trapType in trapTypes)
            {
                // Create a PictureBox for each treasure
                PictureBox sourcePicBox = new PictureBox
                {
                    Size = new Size(ImageSizeW, ImageSizeH),
                    Location = new Point(30, yOffset),
                    Image = TrapImageLoader.GetImage(trapType),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = trapType, // Store the treasure type in the Tag property for identification
                    AllowDrop = true
                };

                sourcePicBox.MouseDown += (s, e) => SourcePictureBox_MouseDown(sourcePicBox, e);

                sourcePanel.Controls.Add(sourcePicBox);
                yOffset += ImageSizeW + 20;
            }
        }

        private void SourcePictureBox_MouseDown(PictureBox sourcePicBox, MouseEventArgs e)
        {
            sourcePicBox.DoDragDrop(sourcePicBox, DragDropEffects.Move);
        }

        private void SourcePanel_MouseDown(Panel sourcePanel, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private Image GetDefaultImage()
        {
            return new Bitmap(ImageSizeW, ImageSizeH);
        }

        private void PictureBox_MouseDown(PictureBox targetPicBox, MouseEventArgs e)
        {
            targetPicBox.DoDragDrop(targetPicBox, DragDropEffects.Move);
        }

        private void PictureBox_DragEnter(PictureBox targetPicBox, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PictureBox_MouseEnter(PictureBox pictureBox, EventArgs e)
        {
            pictureBox.BackColor = Color.Moccasin;
        }

        private void PictureBox_MouseLeave(PictureBox pictureBox, EventArgs e)
        {
            pictureBox.BackColor = Color.Wheat;
        }

        private void PictureBox_DragDrop(PictureBox targetPicBox, DragEventArgs e)
        {
            PictureBox sourcePicBox = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            if (sourcePicBox != null && targetPicBox != sourcePicBox)
            {
                if (sourcePicBox.Parent == sourcePanel)
                {
                    // Move image from source to target
                    targetPicBox.Image = sourcePicBox.Image;
                    targetPicBox.Tag = sourcePicBox.Tag;

                    // Remove source PictureBox from sourcePanel
                    sourcePanel.Controls.Remove(sourcePicBox);
                    sourcePicBox.Dispose(); // Optionally dispose of the control
                }
                else
                {
                    // Swap images between grid cells
                    Image tempImage = targetPicBox.Image;
                    targetPicBox.Image = sourcePicBox.Image;
                    sourcePicBox.Image = tempImage;

                    // Swap Tags if necessary
                    object tempTag = targetPicBox.Tag;
                    targetPicBox.Tag = sourcePicBox.Tag;
                    sourcePicBox.Tag = tempTag;
                }
            }
        }
    }

}
