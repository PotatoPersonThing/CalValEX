using Terraria.ModLoader;
using CalValEX.Tiles.Plants;

namespace CalValEX.Items.Tiles.Plants
{
    public class Anemone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potted Anemone");
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
            Item.createTile = ModContent.TileType<AnemonePlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 3;
        }
    }
}