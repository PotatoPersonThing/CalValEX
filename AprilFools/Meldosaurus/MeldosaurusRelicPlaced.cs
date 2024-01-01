using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    [ExtendsFromMod("CalamityMod")]
    public class MeldosaurusRelicPlaced : CalamityMod.Tiles.BaseTiles.BaseBossRelic //ADVANCED code theft!!!!!!(!(!(!
    {
        public override string RelicTextureName => "CalValEX/AprilFools/Meldosaurus/MeldosaurusRelicPlaced";

        public override int AssociatedItem => ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusRelic>();
    }
}