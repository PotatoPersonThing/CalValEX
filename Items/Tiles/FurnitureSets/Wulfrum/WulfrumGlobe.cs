using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles.FurnitureSets.Wulfrum
{
    public class WulfrumGlobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Globe");
            Tooltip.SetDefault("Spin spin spin");
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
            item.createTile = ModContent.TileType<WulfrumGlobePlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 2;
        }
    }
}