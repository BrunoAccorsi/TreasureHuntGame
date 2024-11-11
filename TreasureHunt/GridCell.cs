namespace TreasureHunt
{
    public class GridCell : PictureBox
    {
        public GridCell() { }
        public GridCell(Size size, Point location)
        {
            Size = size;
            Location = location;
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.Zoom;
            AllowDrop = true;
            Image = GetDefaultImage();
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
