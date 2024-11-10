namespace TreasureHunt
{

    public enum TreasureImage
    {
        RedGem,
        GoldPile,
        //BlueGem,
        //Skull,
        //TreasureChestClosed,
        //TreasureChestOpen,
    }

    public static class TreasureImageLoader
    {
        private static readonly Dictionary<TreasureImage, Image> treasureImages = new Dictionary<TreasureImage, Image>();

        static TreasureImageLoader()
        {
            treasureImages[TreasureImage.RedGem] = ByteArrayToImage(Properties.Resources.RedGem);
            treasureImages[TreasureImage.GoldPile] = ByteArrayToImage(Properties.Resources.GoldPile);
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
