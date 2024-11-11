namespace TreasureHunt
{

    public enum TrapImage
    {
        Skull,
        BombTrap,
        CursedPotion,
        CursedPotion2,
    }

    public static class TrapImageLoader
    {
        private static readonly Dictionary<TrapImage, Image> trapImages = new Dictionary<TrapImage, Image>();

        static TrapImageLoader()
        {
            trapImages[TrapImage.BombTrap] = ByteArrayToImage(Properties.Resources.BombTrap);
            trapImages[TrapImage.Skull] = ByteArrayToImage(Properties.Resources.SkullCurse);
            trapImages[TrapImage.CursedPotion] = ByteArrayToImage(Properties.Resources.CursedPotion);
            trapImages[TrapImage.CursedPotion2] = ByteArrayToImage(Properties.Resources.CursedPotion2);
        }

        private static Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public static Image GetImage(TrapImage imageType)
        {
            return trapImages[imageType];
        }
    }
    public class Trap : Asset
    {
        public TrapImage TrapType { get; private set; } // Specific treasure type
        public int Points { get; private set; } // Points awarded when found

        public Trap(TrapImage trapType, int size, int points, int goldAmount = 0, bool isRare = false)
            : base(AssetType.Treasure, size, TrapImageLoader.GetImage(trapType), $"A {trapType} treasure")
        {
            TrapType = trapType;
            Points = points;
        }

        public void DisplayTreasureMessage()
        {
            string message = $"Points: {Points}";

            System.Windows.Forms.MessageBox.Show(message, "Treasure Found");
        }
    }
}
