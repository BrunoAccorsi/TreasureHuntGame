namespace TreasureHunt
{

    public enum TreasureImage
    {
        RedGem,
        GoldPile,
        GoldChalice,
        BlueGem,
        CrystalPot,
        GoldPot,
        GoldBox,
        HeartGem
    }
    public class Treasure : PictureBox
    {
        public int Points { get; set; }

        public Treasure(Size size, Point location)
        {
            Size = size;
            Location = location;
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.Zoom;
            AllowDrop = true;
        }

        private static readonly Dictionary<TreasureImage, byte[]> treasureImages = new Dictionary<TreasureImage, byte[]>
        {
            { TreasureImage.RedGem, Properties.Resources.RedGem },
            { TreasureImage.GoldPile, Properties.Resources.GoldPile },
            { TreasureImage.GoldChalice, Properties.Resources.GoldChalice },
            { TreasureImage.BlueGem, Properties.Resources.BlueGem },
            { TreasureImage.CrystalPot, Properties.Resources.CrystalPot },
            { TreasureImage.GoldPot, Properties.Resources.GoldPot },
            { TreasureImage.GoldBox, Properties.Resources.GoldBox },
            { TreasureImage.HeartGem, Properties.Resources.HeartGem }
        };

        public static Image GetImage(TreasureImage imageType)
        {
            return Utils.ByteToImage(treasureImages[imageType]);
        }
    }
}
