namespace TreasureHunt
{
    public enum CellTypes
    {
        Treasure,
        Trap,
        Blank,
        None
    }
    public class GridCell : PictureBox
    {
        public CellTypes CellType { get; set; }
        public bool IsClicked { get; set; } = false;


        public GridCell() { }
        public GridCell(Size size, Point location)
        {
            Size = size;
            Location = location;
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.Zoom;
            AllowDrop = true;
            Image = GetDefaultImage();
            CellType = CellTypes.Blank;
        }

        private Image GetDefaultImage()
        {
            return new Bitmap(Size.Width, Size.Height);
        }

        public void SetDefaultImage()
        {
            Image = GetDefaultImage();
        }
    }
}
