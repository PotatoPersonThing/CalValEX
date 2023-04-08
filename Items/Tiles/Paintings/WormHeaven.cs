using Terraria.ID; using CalValEX.Tiles.Paintings;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Paintings
{
    public class WormHeaven : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Worm to the Heavens");
            // Tooltip.SetDefault("'Mathew Maple'\nOne day...");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<WormHeavenPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 9;
        }
    }
}