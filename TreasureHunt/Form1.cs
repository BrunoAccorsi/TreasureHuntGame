namespace TreasureHunt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Create a panel to hold the button grid
            Panel gridPanel = new Panel
            {
                Width = 720,
                Height = 720,
                BackColor = Color.Transparent,
                Location = new Point(300, 250),  // Point where the panel will be placed 
                Anchor = AnchorStyles.None
            };

            CreateButtonGrid(gridPanel);

            // Add the panel to the form
            this.Controls.Add(gridPanel);
        }

        private void CreateButtonGrid(Panel gridPanel)
        {
            int gridSize = 6;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                RowCount = gridSize,
                ColumnCount = gridSize,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            for (int i = 0; i < gridSize; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
            }

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button
                    {
                        Text = "",
                        Dock = DockStyle.Fill,
                        Margin = new Padding(1),
                        BackColor = Color.Transparent,
                        Name = $"btn_{row}_{col}"
                    };
                    tableLayoutPanel.Controls.Add(btn, col, row);
                }
            }

            // Add the TableLayoutPanel to the panel
            gridPanel.Controls.Add(tableLayoutPanel);
        }
    }

}
