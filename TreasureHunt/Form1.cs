namespace TreasureHunt
{
    public partial class Form1 : Form
    {
        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
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

            ChangeButtonColor(0, 0, Color.DarkGray); // example on how to change a button color
        }

        private void CreateButtonGrid(Panel gridPanel)
        {

            int gridSize = 6;

            this.tableLayoutPanel.RowCount = gridSize;
            this.tableLayoutPanel.ColumnCount = gridSize;
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.BackColor = Color.Transparent;

            for (int i = 0; i < gridSize; i++)
            {
                this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
                this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
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
                        Name = $"btn_{row}_{col}",
                    };
                    this.tableLayoutPanel.Controls.Add(btn, col, row);
                }
            }


            // Add the TableLayoutPanel to the panel
            gridPanel.Controls.Add(this.tableLayoutPanel);
        }

        private void ChangeButtonColor(int row, int col, Color color)
        {
            // Construct the button name using the same pattern you used to name them
            string buttonName = $"btn_{row}_{col}";

            // Find the button in the TableLayoutPanel by its name
            Control[] controls = this.tableLayoutPanel.Controls.Find(buttonName, true);

            if (controls.Length > 0 && controls[0] is Button)
            {
                Button btn = (Button)controls[0];
                btn.BackColor = color;
            }
            else
            {
                MessageBox.Show($"Button {buttonName} not found!");
            }
        }

    }

}
