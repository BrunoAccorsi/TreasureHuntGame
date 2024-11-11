namespace TreasureHunt
{

    public enum TrapTypes
    {
        Skull,
        BombTrap,
        CursedPotion,
        CursedPotion2,
    }
    public class Trap
    {
        public Image Image { get; set; }
        public Trap(TrapTypes type)
        {
            Image = GetImage(type);
        }
        private static readonly Dictionary<TrapTypes, byte[]> trapImages = new Dictionary<TrapTypes, byte[]>
        {
            { TrapTypes.BombTrap, Properties.Resources.BombTrap },
            { TrapTypes.Skull, Properties.Resources.SkullCurse },
            { TrapTypes.CursedPotion, Properties.Resources.CursedPotion },
            { TrapTypes.CursedPotion2, Properties.Resources.CursedPotion2 }
        };

        private Image GetImage(TrapTypes imageType)
        {
            return Utils.ByteToImage(trapImages[imageType]);
        }
    }
}
