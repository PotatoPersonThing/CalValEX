using Terraria.ModLoader;
using CalValEX.Tiles.Plants;

namespace CalValEX.Items.Tiles.Plants
{
    public class BrainCoral : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potted Brain Coral");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<BrainCoralPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 3;
        }
    }
}