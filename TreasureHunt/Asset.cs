namespace TreasureHunt
{
    public abstract class Asset
    {
        public enum AssetType
        {
            Treasure,
            Trap
        }
        public AssetType Type { get; set; }      // Type of asset (Treasure or Trap)
        public int Size { get; set; }            // Number of cells it occupies
        public Image Image { get; set; }         // Display image for the asset
        public List<Point> Position { get; set; } // List of grid points it occupies
        public bool IsFound { get; set; }        // Indicates if the asset has been found

        public Asset(AssetType type, int size, Image image, string description)
        {
            Type = type;
            Size = size;
            Image = image;
            Position = new List<Point>();
            IsFound = false;
        }

        public void PlaceAsset(Point startingPoint, int direction)
        {
            // Calculates positions based on starting point and size
            Position.Clear();

            for (int i = 0; i < Size; i++)
            {
                Point cell;
                if (direction == 0) // Horizontal placement
                {
                    cell = new Point(startingPoint.X + i, startingPoint.Y);
                }
                else // Vertical placement
                {
                    cell = new Point(startingPoint.X, startingPoint.Y + i);
                }
                Position.Add(cell);
            }
        }

    }
}
