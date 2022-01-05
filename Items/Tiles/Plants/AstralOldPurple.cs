using Terraria.ModLoader;
using CalValEX.Tiles.Plants;

namespace CalValEX.Items.Tiles.Plants
{
    public class AstralOldPurple : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potted Purple Xenomonolith");
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
            item.createTile = ModContent.TileType<AstralOldPurplePlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 5;
        }
    }
}