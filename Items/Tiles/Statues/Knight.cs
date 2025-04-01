using Terraria.ModLoader;
using CalValEX.Tiles.Statues;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Statues
{
    public class Knight : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Earthen Knight Statue");
            /* Tooltip
                .SetDefault("'Not tournament legal'"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<KnightPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Pink;
        }
    }
}