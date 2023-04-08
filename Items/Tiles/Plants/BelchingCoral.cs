using Terraria.ModLoader;
using CalValEX.Tiles.Plants;

namespace CalValEX.Items.Tiles.Plants
{
    public class BelchingCoral : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sulphuric Coral");
            /* Tooltip
                .SetDefault("Don't put your bare hand into it"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<BelchingCoralPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 5;
        }
    }
}