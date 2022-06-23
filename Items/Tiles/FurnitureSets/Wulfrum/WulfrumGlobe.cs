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
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<WulfrumGlobePlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 2;
        }
    }
}