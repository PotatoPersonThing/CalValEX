using Terraria.ID; using CalValEX.Tiles.Paintings;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Paintings
{
    public class RogueExtractor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rogue Extractor");
            // Tooltip.SetDefault("'Maple'\n");
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
            Item.createTile = ModContent.TileType<RogueExtractorPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Yellow;
        }
    }
}