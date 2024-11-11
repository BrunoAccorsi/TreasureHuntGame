namespace TreasureHunt
{

    public enum TrapImage
    {
        Skull,
        BombTrap,
        CursedPotion,
        CursedPotion2,
    }
    public class Trap
    {
        private static readonly Dictionary<TrapImage, byte[]> trapImages = new Dictionary<TrapImage, byte[]>
        {
            { TrapImage.BombTrap, Properties.Resources.BombTrap },
            { TrapImage.Skull, Properties.Resources.SkullCurse },
            { TrapImage.CursedPotion, Properties.Resources.CursedPotion },
            { TrapImage.CursedPotion2, Properties.Resources.CursedPotion2 }
        };

        public static Image GetImage(TrapImage imageType)
        {
            return Utils.ByteToImage(trapImages[imageType]);
        }
    }
}
