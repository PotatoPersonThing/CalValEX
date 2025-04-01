using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class PlagueDialysis : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Swarmer Conservation Tube");
            /* Tooltip
                .SetDefault("'Sealed away for eternity'"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<PlagueDialysisPlaced>();
            Item.width = 32;
            Item.height = 50;
            Item.rare = ItemRarityID.Purple;
        }
    }
}