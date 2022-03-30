using Terraria;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;


namespace CalValEX.Items.Tiles.Blocks
{
    public class Bloodstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodstone (placeable)");
            Tooltip.SetDefault("It's back");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = -1;
            Item.createTile = ModContent.TileType<BloodstonePlaced>();
        }
    }
}