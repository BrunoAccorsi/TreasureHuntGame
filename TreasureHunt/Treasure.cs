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

    public static class TreasureImageLoader
    {
        private static readonly Dictionary<TreasureImage, Image> treasureImages = new Dictionary<TreasureImage, Image>();

        static TreasureImageLoader()
        {
            treasureImages[TreasureImage.RedGem] = ByteArrayToImage(Properties.Resources.RedGem);
            treasureImages[TreasureImage.GoldPile] = ByteArrayToImage(Properties.Resources.GoldPile);
            treasureImages[TreasureImage.GoldChalice] = ByteArrayToImage(Properties.Resources.GoldChalice);
            treasureImages[TreasureImage.BlueGem] = ByteArrayToImage(Properties.Resources.BlueGem);
            treasureImages[TreasureImage.CrystalPot] = ByteArrayToImage(Properties.Resources.CrystalPot);
            treasureImages[TreasureImage.GoldPot] = ByteArrayToImage(Properties.Resources.GoldPot);
            treasureImages[TreasureImage.GoldBox] = ByteArrayToImage(Properties.Resources.GoldBox);
            treasureImages[TreasureImage.HeartGem] = ByteArrayToImage(Properties.Resources.HeartGem);
        }

        private static Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public static Image GetImage(TreasureImage imageType)
        {
            return treasureImages[imageType];
        }
    }
    public class Treasure : Asset
    {
        public TreasureImage TreasureType { get; private set; } // Specific treasure type
        public int Points { get; private set; } // Points awarded when found

        public Treasure(TreasureImage treasureType, int size, int points, int goldAmount = 0, bool isRare = false)
            : base(AssetType.Treasure, size, TreasureImageLoader.GetImage(treasureType), $"A {treasureType} treasure")
        {
            TreasureType = treasureType;
            Points = points;
        }

        public void DisplayTreasureMessage()
        {
            string message = $"Points: {Points}";

            System.Windows.Forms.MessageBox.Show(message, "Treasure Found");
        }
    }
}
