using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class MeldosaurusRelic : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<MeldosaurusRelicPlaced>();
            Item.width = 48;
            Item.height = 32;
            Item.rare = ItemRarityID.Master;
        }
    }
}