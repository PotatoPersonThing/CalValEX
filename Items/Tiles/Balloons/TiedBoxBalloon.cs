using Terraria.ModLoader;
using CalValEX.Tiles.Balloons;

namespace CalValEX.Items.Tiles.Balloons
{
    internal class TiedBoxBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tied Box Balloon");
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
            item.createTile = ModContent.TileType<TiedBoxBalloonPlaced>();
            item.width = 16;
            item.height = 40;
            item.rare = 4;
        }
    }
}