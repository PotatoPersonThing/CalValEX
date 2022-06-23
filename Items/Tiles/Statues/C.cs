using Terraria.ModLoader;
using CalValEX.Tiles.Statues;

namespace CalValEX.Items.Tiles.Statues
{
    public class C : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Statue of Calamity");
            Tooltip
                .SetDefault("A tale begins");
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
            Item.createTile = ModContent.TileType<CPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 1;
        }
    }
}