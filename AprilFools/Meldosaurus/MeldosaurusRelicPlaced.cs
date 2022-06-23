using System;
using CalamityMod.Tiles.BaseTiles;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class MeldosaurusRelicPlaced : BaseBossRelic //ADVANCED code theft!!!!!!(!(!(!
    {
        public override string RelicTextureName => "CalValEX/AprilFools/Meldosaurus/MeldosaurusRelicPlaced";

        public override int AssociatedItem => ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusRelic>();
    }
}