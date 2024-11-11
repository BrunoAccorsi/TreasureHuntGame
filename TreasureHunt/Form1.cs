namespace TreasureHunt
{
    public partial class Form1 : Form
    {
        private enum GameState { Hiding, Searching }
        private GameState currentState = GameState.Hiding;
        Dictionary<(int, int), GridCell> assetPosition = new Dictionary<(int, int), GridCell>(); //dictionary where we store the treasure and traps in the row, col that it its
        private int SearchMoves = 5;

        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        private const int GridSize = 6; // 6x6 grid
        private const int ImageSizeW = 132; // Width of each cell
        private const int ImageSizeH = 122; // Height of each cell 
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
                    GridCell gridCell = new GridCell(new Size(ImageSizeW, ImageSizeH), new Point(col * ImageSizeW, row * ImageSizeH));

                    gridCell.MouseDown += (s, e) => GridCell_MouseDown(gridCell, e);
                    gridCell.DragEnter += (s, e) => GridCell_DragEnter(gridCell, e);
                    gridCell.DragDrop += (s, e) => GridCell_DragDrop(gridCell, e);
                    gridCell.MouseEnter += (s, e) => GridCell_MouseEnter(gridCell, e); //hover effect
                    gridCell.MouseLeave += (s, e) => GridCell_MouseLeave(gridCell, e); //remove hover effect
                    gridCell.MouseClick += (s, e) => GridCell_MouseClick(gridCell, e);

                    gridPanel.Controls.Add(gridCell);
                    assetPosition[(row, col)] = gridCell;
                }
            }
        }

        private void GridCell_MouseDown(GridCell gridCell, MouseEventArgs e)
        {
            if (currentState == GameState.Hiding)
                gridCell.DoDragDrop(gridCell, DragDropEffects.Move);
        }

        private void InitializeSourcePanel()
        {
            //remove only the assets
            foreach (var control in sourcePanel.Controls.OfType<GridCell>().ToArray())
            {
                sourcePanel.Controls.Remove(control);
                control.Dispose();
            }

            sourcePanel.DragEnter += (s, e) => SourcePanel_MouseDown(sourcePanel, e);

            Random random = new Random();
            var treasureTypes = Enum.GetValues(typeof(TreasureImage)).Cast<TreasureImage>().OrderBy(x => random.Next()).Take(3);
            var trapTypes = Enum.GetValues(typeof(TrapImage)).Cast<TrapImage>().OrderBy(x => random.Next()).Take(2);

            int yOffset = 100;

            sourcePanel.Controls.Add(new Label()
            {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new Point(10, yOffset),
                Size = new Size(178, 40),
                Text = "Treasures",
                TextAlign = ContentAlignment.TopCenter
            });
            yOffset += 40;

            foreach (var treasureType in treasureTypes)
            {
                // Create a grid cell for each treasure
                GridCell sourceCell = new GridCell
                {
                    Size = new Size(ImageSizeW, ImageSizeH),
                    Location = new Point(30, yOffset),
                    Image = Treasure.GetImage(treasureType),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = treasureType, // Store the treasure type in the Tag property for identification
                    BackColor = Color.Gold
                };
                sourceCell.MouseDown += (s, e) => SourceGridCell_MouseDown(sourceCell, e);

                sourcePanel.Controls.Add(sourceCell);
                yOffset += ImageSizeH + 20;
            }

            sourcePanel.Controls.Add(new Label()
            {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new Point(10, yOffset),
                Size = new Size(178, 40),
                Text = "Traps",
                TextAlign = ContentAlignment.TopCenter
            });
            yOffset += 40;

            foreach (var trapType in trapTypes)
            {
                // Create a grid cell for each treasure
                GridCell sourceGridCell = new GridCell
                {
                    Size = new Size(ImageSizeW, ImageSizeH),
                    Location = new Point(30, yOffset),
                    Image = Trap.GetImage(trapType),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = trapType, // Store the treasure type in the Tag property for identification
                    AllowDrop = true,
                    BackColor = Color.DarkRed
                };

                sourceGridCell.MouseDown += (s, e) => SourceGridCell_MouseDown(sourceGridCell, e);

                sourcePanel.Controls.Add(sourceGridCell);
                yOffset += ImageSizeH + 20;
            }
        }

        private void SourceGridCell_MouseDown(GridCell sourceGridCell, MouseEventArgs e)
        {
            sourceGridCell.DoDragDrop(sourceGridCell, DragDropEffects.Move);
        }

        private void SourcePanel_MouseDown(Panel sourcePanel, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void GridCell_MouseClick(GridCell sourceGridCell, MouseEventArgs e)
        {
            if (currentState == GameState.Searching)
            {

                UpdatePLayerMoves();
                if (sourceGridCell.Tag != null && sourceGridCell.Tag is TreasureImage)
                {
                    TreasureImage treasureImage = (TreasureImage)sourceGridCell.Tag;
                    sourceGridCell.Image = Treasure.GetImage(treasureImage);
                }
                else if (sourceGridCell.Tag != null && sourceGridCell.Tag is TrapImage)
                {
                    TrapImage trapImage = (TrapImage)sourceGridCell.Tag;
                    sourceGridCell.Image = Trap.GetImage(trapImage);
                    MessageBox.Show("Trap! You lose 1 move");
                    UpdatePLayerMoves();
                }
                else
                {
                    sourceGridCell.BackColor = Color.BurlyWood;
                }

                if (SearchMoves <= 0)
                {
                    //end Game
                    MessageBox.Show("Game Over");
                }
            }
        }

        private void UpdatePLayerMoves()
        {
            if (currentState == GameState.Searching)
            {
                SearchMoves--;
                gameStatePanel.Controls.Find("playerMoves", true).First().Text = $"{SearchMoves} moves left";
            }
        }

        private void GridCell_DragEnter(GridCell targetGridCell, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridCell)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GridCell_MouseEnter(GridCell gridCell, EventArgs e)
        {
            gridCell.BackColor = Color.Moccasin;
        }

        private void GridCell_MouseLeave(GridCell gridcell, EventArgs e)
        {
            gridcell.BackColor = Color.Wheat;
        }

        private void GridCell_DragDrop(GridCell targetGridCell, DragEventArgs e)
        {
            GridCell sourceGridCell = e.Data.GetData(typeof(GridCell)) as GridCell;
            if (sourceGridCell != null && targetGridCell != sourceGridCell)
            {
                if (sourceGridCell.Parent == sourcePanel)
                {
                    // Move image from source to target
                    targetGridCell.Image = sourceGridCell.Image;
                    targetGridCell.Tag = sourceGridCell.Tag;

                    // Remove source grid cell from sourcePanel
                    sourcePanel.Controls.Remove(sourceGridCell);
                    sourceGridCell.Dispose(); // Optionally dispose of the control
                }
                else
                {
                    // Swap images between grid cells
                    Image tempImage = targetGridCell.Image;
                    targetGridCell.Image = sourceGridCell.Image;
                    sourceGridCell.Image = tempImage;

                    // Swap tags between grid cells
                    object tempTag = targetGridCell.Tag;
                    targetGridCell.Tag = sourceGridCell.Tag;
                    sourceGridCell.Tag = tempTag;
                }
            }
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            GameState nextStage = currentState == GameState.Hiding ? GameState.Searching : GameState.Hiding;
            currentState = nextStage;

            if (nextStage == GameState.Searching)
            {
                // Hide the source panel
                sourcePanel.Visible = false;
                endTurnButton.Text = "End Game";
                turnLabel.Text = "Player 2 (Finder) turn";

                Label playerMoves = new Label
                {
                    Text = $"{SearchMoves} moves left",
                    Location = new Point(10, 40),
                    Size = new Size(179, 29),
                    ForeColor = Color.Red,
                    Name = "playerMoves"
                };
                gameStatePanel.Controls.Add(playerMoves);

                handleSearchState();
            }
        }

        private void handleSearchState()
        {
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    assetPosition[(row, col)].SetDefaultImage();
                }
            }
        }
    }

}
