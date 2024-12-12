namespace TreasureHunt
{
    public partial class Form1 : Form
    {

        private enum GameState { Hiding, Searching }
        GameControl gameControl = new GameControl("Player A", "Player B");

        Dictionary<(int, int), GridCell> cellPosition = new Dictionary<(int, int), GridCell>(); //dictionary so we can retrieve the cell by its row and col
        Dictionary<TreasureTyles, Treasure> treasuresByImage = new Dictionary<TreasureTyles, Treasure>(); //dictionary so we can retrieve the treasures by its row and col
        Dictionary<TrapTypes, Trap> trapsByImage = new Dictionary<TrapTypes, Trap>(); //dictionary so we can retrieve the trap by its row and col

        private static int MAX_MOVES = 20;

        private int SearchMoves = MAX_MOVES;
        private int TotalPoints = 0;
        private int FoundTreasures = 0;
        private const int TotalTreasures = 4;

        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        private const int GridSize = 6; // 6x6 grid
        private const int ImageSizeW = 130; // Width of each cell
        private const int ImageSizeH = 120; // Height of each cell 



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitializeGrid();
            InitializeSourcePanel();
            UpdateScoreDisplay();
        }

        private void InitializeGrid()
        {
            gridPanel.Controls.Clear();
            gridPanel.AllowDrop = true;

            int gridWidth = GridSize * ImageSizeW;
            int gridHeigh = GridSize * ImageSizeH;
            gridPanel.MaximumSize = new Size(gridWidth, gridHeigh);
            gridPanel.Size = new Size(gridWidth, gridHeigh);

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
                    cellPosition[(row, col)] = gridCell;
                }
            }
        }

        private void GridCell_MouseDown(GridCell gridCell, MouseEventArgs e)
        {
            if (gameControl.CurrentState == (int)GameState.Hiding)
                gridCell.DoDragDrop(gridCell, DragDropEffects.Move);
        }

        private void InitializeSourcePanel()
        {
            sourcePanel.Controls.Clear();

            var sourcePanelTitle = new Label()
            {
                Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0),
                Location = new Point(10, 10),
                Size = new Size(sourcePanel.Width - 20, 100),
                Text = "Choose the Treasures and traps to place",
                TextAlign = ContentAlignment.TopCenter,
                Name = "StaticLabel"
            };
            sourcePanel.Controls.Add(sourcePanelTitle);

            sourcePanel.DragEnter += (s, e) => SourcePanel_MouseDown(sourcePanel, e);

            Random random = new Random();
            var treasureTypes = Enum.GetValues(typeof(TreasureTyles)).Cast<TreasureTyles>().OrderBy(x => random.Next()).Take(4);
            var trapTypes = Enum.GetValues(typeof(TrapTypes)).Cast<TrapTypes>().OrderBy(x => random.Next()).Take(3);

            int yOffset = 110;

            sourcePanel.Controls.Add(new Label()
            {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new Point(10, yOffset),
                Size = new Size(178, 40),
                Text = "Treasures",
                TextAlign = ContentAlignment.TopCenter,
                Name = "TreasuresLabel"
            });
            yOffset += 40;

            foreach (var treasureType in treasureTypes)
            {
                treasuresByImage[treasureType] = new Treasure(treasureType)
                {
                    Points = 10
                };

                GridCell sourceCell = new GridCell
                {
                    Size = new Size(ImageSizeW, ImageSizeH),
                    Location = new Point(30, yOffset),
                    Image = treasuresByImage[treasureType].Image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = treasureType,
                    BackColor = Color.Gold,
                    CellType = CellTypes.Treasure
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
                TextAlign = ContentAlignment.TopCenter,
                Name = "TrapsLabel"
            });
            yOffset += 40;

            foreach (var trapType in trapTypes)
            {
                trapsByImage[trapType] = new Trap(trapType);

                GridCell sourceGridCell = new GridCell
                {
                    Size = new Size(ImageSizeW, ImageSizeH),
                    Location = new Point(30, yOffset),
                    Image = trapsByImage[trapType].Image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = trapType,
                    AllowDrop = true,
                    BackColor = Color.DarkRed,
                    CellType = CellTypes.Trap
                };

                sourceGridCell.MouseDown += (s, e) => SourceGridCell_MouseDown(sourceGridCell, e);

                sourcePanel.Controls.Add(sourceGridCell);
                yOffset += ImageSizeH + 20;
            }

            turnLabel.Text = $"{gameControl.currentPlayer()} turn";
            gameStateLabel.Text = gameControl.currentGameState();

            Dictionary<int, int> score = gameControl.getUpdatedScore();

            playerOneLabel.Text = $"{gameControl.getPlayerName(1)} : {score[1]}";
            playerTwoLabel.Text = $"{gameControl.getPlayerName(2)} : {score[2]}";
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
            if (sourceGridCell.Tag != null && sourceGridCell.Tag.ToString() == "Clicked")
            {
                MessageBox.Show("This cell has already been clicked.");
                return;
            }

            if (gameControl.CurrentState == (int)GameState.Searching)
            {
                UpdatePLayerMoves();

                if (sourceGridCell.CellType == CellTypes.Treasure)
                {
                    if (treasuresByImage.TryGetValue((TreasureTyles)sourceGridCell.Tag, out var treasure))
                    {
                        sourceGridCell.Image = treasure.Image;
                        TotalPoints += treasure.Points;
                        FoundTreasures++;
                        UpdateScoreDisplay();

                        if (FoundTreasures == TotalTreasures)
                        {
                            MessageBox.Show($"Player {gameControl.currentPlayer()} is the winner! All treasures found.");
                            gameControl.hasWinner(gameControl.currentPlayer());
                            RestartGame();
                            return;
                        }
                    }
                }
                else if (sourceGridCell.CellType == CellTypes.Trap)
                {
                    if (sourceGridCell.Tag is TrapTypes trapType && trapsByImage.TryGetValue(trapType, out var trap))
                    {
                        sourceGridCell.Image = trap.Image;
                        MessageBox.Show("Trap! You lose 1 move");
                        UpdatePLayerMoves();
                    }
                }
                else
                {
                    //When cell is clicked it change the color cell and keep it by the game over
                    sourceGridCell.BackColor = Color.LightGray;
                    sourceGridCell.IsClicked = true;
                }

                sourceGridCell.Tag = "Clicked";

                if (SearchMoves <= 0)
                {
                    string winner = FoundTreasures == TotalTreasures
                        ? gameControl.currentPlayer()
                        : gameControl.iddlePlayer();

                    gameControl.hasWinner(winner);
                    MessageBox.Show($"Game Over! The winner is {winner}");
                    RestartGame();
                }
            }
        }

        private void UpdateScoreDisplay()
        {
            var scoreLabel = gameStatePanel.Controls.Find("scoreLabel", true).FirstOrDefault() as Label;
            if (scoreLabel != null)
            {
                scoreLabel.Text = $"Total Points: {TotalPoints}";
            }
            else
            {
                scoreLabel = new Label
                {
                    Text = $"Total Points: {TotalPoints}",
                    Location = new Point(10, 100),
                    Size = new Size(200, 20),
                    ForeColor = Color.Green,
                    Name = "scoreLabel"
                };
                gameStatePanel.Controls.Add(scoreLabel);
            }
        }

        private void UpdatePLayerMoves()
        {
            if (gameControl.CurrentState == (int)GameState.Searching && SearchMoves > 0)
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
            if (!gridCell.IsClicked)
            {
                gridCell.BackColor = Color.Moccasin;
            }
        }

        private void GridCell_MouseLeave(GridCell gridCell, EventArgs e)
        {
            if (!gridCell.IsClicked)
            {
                gridCell.BackColor = Color.Wheat;
            }
        }

        private void GridCell_DragDrop(GridCell targetGridCell, DragEventArgs e)
        {
            GridCell sourceGridCell = e.Data.GetData(typeof(GridCell)) as GridCell;
            if (sourceGridCell != null && targetGridCell != sourceGridCell)
            {
                if (targetGridCell.Tag != null)
                {
                    return;
                }
                if (sourceGridCell.Parent == sourcePanel)
                {
                    // Move image from source to target
                    targetGridCell.Image = sourceGridCell.Image;
                    targetGridCell.CellType = sourceGridCell.CellType;
                    targetGridCell.Tag = sourceGridCell.Tag;

                    // Remove source grid cell from sourcePanel
                    sourcePanel.Controls.Remove(sourceGridCell);
                    sourceGridCell.Dispose();
                }
                else
                {
                    // Swap images between grid cells
                    Image tempImage = targetGridCell.Image;
                    targetGridCell.Image = sourceGridCell.Image;
                    sourceGridCell.Image = tempImage;

                    // Swap types between grid cells
                    CellTypes tempType = targetGridCell.CellType;
                    targetGridCell.CellType = sourceGridCell.CellType;
                    sourceGridCell.CellType = tempType;

                    // Swap tags between grid cells
                    object tempTag = targetGridCell.Tag;
                    targetGridCell.Tag = sourceGridCell.Tag;
                    sourceGridCell.Tag = tempTag;
                }
            }
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            var remainingAssets = sourcePanel.Controls.OfType<GridCell>().Any();
            if (gameControl.CurrentState == (int)GameState.Hiding && remainingAssets)
            {
                MessageBox.Show("You need to place all treasures and traps before ending your turn!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            gameControl.endTurn();
            turnLabel.Text = $"{gameControl.currentPlayer()} turn";
            gameStateLabel.Text = gameControl.currentGameState();


            if (gameControl.CurrentState == (int)GameState.Searching)
            {
                // Hide the source panel
                sourcePanel.Visible = false;
                endTurnButton.Text = "End Game";
                turnLabel.Text = gameControl.currentPlayer(); // "Player 2 (Finder) turn";

                Label playerMoves = new Label
                {
                    Text = $"{SearchMoves} moves left",
                    Location = new Point(10, 122),
                    Size = new Size(200, 20),
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
                    var gridCell = cellPosition[(row, col)];

                    if (gridCell.Tag != null && gridCell.Tag.ToString() == "Clicked")
                    {
                        if (gridCell.CellType == CellTypes.None)
                        {
                            gridCell.BackColor = Color.Gray;
                        }
                        continue;
                    }

                    gridCell.SetDefaultImage();
                }
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to restart the game?", "Confirm Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (gameControl.CurrentState == (int)GameState.Searching)
            {
                gameControl.hasWinner(gameControl.iddlePlayer(), true);
            }

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            //currentState = GameState.Hiding;
            SearchMoves = MAX_MOVES;
            TotalPoints = 0;
            FoundTreasures = 0;
            sourcePanel.Visible = true;
            endTurnButton.Text = "End Turn";
            //turnLabel.Text = $"{gameControl.currentPlayer()} turn";

            gameStatePanel.Controls.RemoveByKey("playerMoves");
            gameStatePanel.Controls.RemoveByKey("scoreLabel");

            var playerMovesControl = gameStatePanel.Controls.Find("playerMoves", true).FirstOrDefault();
            if (playerMovesControl != null)
            {
                playerMovesControl.Text = $"{SearchMoves} moves left";
            }

            InitializeGrid();
            InitializeSourcePanel();
            UpdateScoreDisplay();
        }

        private void btn_startOver_Click(object sender, EventArgs e)
        {
            gameControl.resetGame();
            RestartGame();
        }
    }

}
