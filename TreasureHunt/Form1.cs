namespace TreasureHunt
{
    public partial class Form1 : Form
    {
        private enum GameState { Hiding, Searching }
        private GameState currentState = GameState.Hiding;

        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        private const int GridSize = 6; // 6x6 grid
        private const int ImageSize = 130; // Size of each cell (adjust as needed)
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
                        Size = new Size(ImageSize, ImageSize),
                        Location = new Point(col * ImageSize, row * ImageSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Tag = new Point(row, col)
                    };

                    picBox.Image = GetDefaultImage(); //this is the empty cell image

                    picBox.MouseDown += PictureBox_MouseDown;
                    picBox.DragEnter += PictureBox_DragEnter;
                    picBox.DragDrop += PictureBox_DragDrop;
                    picBox.MouseEnter += (s, e) => PictureBox_MouseEnter(picBox, e);
                    picBox.MouseLeave += (s, e) => PictureBox_MouseLeave(picBox, e);

                    gridPanel.Controls.Add(picBox);
                }
            }
        }

        private void InitializeSourcePanel()
        {
            sourcePanel.Controls.Clear();

            // Select a few random treasures from the available list (e.g., 3 treasures for simplicity)
            Random random = new Random();
            var treasureTypes = Enum.GetValues(typeof(TreasureImage)).Cast<TreasureImage>().OrderBy(x => random.Next()).Take(2);

            int yOffset = 0;
            foreach (var treasureType in treasureTypes)
            {
                // Create a PictureBox for each treasure
                PictureBox sourcePicBox = new PictureBox
                {
                    Size = new Size(100, 100),
                    Location = new Point(10, yOffset),
                    Image = TreasureImageLoader.GetImage(treasureType),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = treasureType, // Store the treasure type in the Tag property for identification
                    AllowDrop = true
                };

                // Enable drag for each treasure image
                sourcePicBox.MouseDown += (s, e) => SourcePictureBox_MouseDown(sourcePicBox, e);

                // Add the PictureBox to the sourcePanel
                sourcePanel.Controls.Add(sourcePicBox);
                yOffset += 110;
            }
        }

        private void SourcePictureBox_MouseDown(PictureBox sourcePicBox, MouseEventArgs e)
        {
            if (sourcePicBox.Image != null)
            {
                // Start dragging the image from the source panel
                sourcePicBox.DoDragDrop(sourcePicBox.Image, DragDropEffects.Copy);
            }
        }

        private Image GetDefaultImage()
        {
            return new Bitmap(ImageSize, ImageSize);
        }

        private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            PictureBox? picBox = sender as PictureBox;
            if (picBox != null && picBox.Image != null)
            {
                picBox.DoDragDrop(picBox.Image, DragDropEffects.Move);
            }
        }

        private void PictureBox_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Image)))
            {
                e.Effect = DragDropEffects.Copy; // Allow copying the image onto the grid cell
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

        private void PictureBox_DragDrop(object? sender, DragEventArgs e)
        {
            PictureBox? targetPicBox = sender as PictureBox;

            if (targetPicBox != null && e.Data.GetDataPresent(typeof(Image)))
            {
                targetPicBox.Image = (Image)e.Data.GetData(typeof(Image));
            }
        }
    }

}
