using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Blocks
{
    public class FrostflakeBrick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostflake Brick");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.rare = 0;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<FrostflakeBrickPlaced>();
        }
    }
}