namespace TreasureHunt
{

    public enum TreasureTyles
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
    public class Treasure
    {
        public int Points { get; set; }
        public Image Image { get; set; }

        public Treasure(TreasureTyles type)
        {
            Image = GetImage(type);
        }

        private static readonly Dictionary<TreasureTyles, byte[]> treasureImages = new Dictionary<TreasureTyles, byte[]>
        {
            { TreasureTyles.RedGem, Properties.Resources.RedGem },
            { TreasureTyles.GoldPile, Properties.Resources.GoldPile },
            { TreasureTyles.GoldChalice, Properties.Resources.GoldChalice },
            { TreasureTyles.BlueGem, Properties.Resources.BlueGem },
            { TreasureTyles.CrystalPot, Properties.Resources.CrystalPot },
            { TreasureTyles.GoldPot, Properties.Resources.GoldPot },
            { TreasureTyles.GoldBox, Properties.Resources.GoldBox },
            { TreasureTyles.HeartGem, Properties.Resources.HeartGem }
        };

        private Image GetImage(TreasureTyles imageType)
        {
            return Utils.ByteToImage(treasureImages[imageType]);
        }
    }
}
