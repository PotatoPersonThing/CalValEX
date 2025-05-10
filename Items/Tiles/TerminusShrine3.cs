using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;
using Terraria;

namespace CalValEX.Items.Tiles
{
    public class TerminusShrine3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Terminus Shrine Level 3");
            // Tooltip.SetDefault("The End.");
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
            Item.width = 16;
            Item.height = 28;
            Item.rare = CalamityID.CalRarityID.HotPink;
            Item.createTile = ModContent.TileType<TerminusShrineLevel3Placed>();
        }
    }
}
