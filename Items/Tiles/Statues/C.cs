using Terraria.ModLoader;
using CalValEX.Tiles.Statues;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Statues
{
    public class C : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Statue of Calamity");
            /* Tooltip
                .SetDefault("A tale begins"); */
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
            Item.createTile = ModContent.TileType<CPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Blue;
        }
    }
}