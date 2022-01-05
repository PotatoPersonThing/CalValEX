using Terraria.ModLoader;
using CalValEX.Tiles.Statues;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Statues
{
    public class Knight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthen Knight Statue");
            Tooltip
                .SetDefault("'Not tournament legal'");
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
            item.createTile = ModContent.TileType<KnightPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = ItemRarityID.Pink;
        }
    }
}