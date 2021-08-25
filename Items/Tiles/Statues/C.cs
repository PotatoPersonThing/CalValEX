using Terraria.ModLoader;
using CalValEX.Tiles.Statues;

namespace CalValEX.Items.Tiles.Statues
{
    internal class C : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Statue of Calamity");
            Tooltip
                .SetDefault("A tale begins");
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
            item.createTile = ModContent.TileType<CPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 1;
        }
    }
}