using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ID;

namespace CalValEX.Items.Tiles
{
    public class SailfishTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sailfish Trophy");
            /* Tooltip
                .SetDefault("'What if it were you \n" + "hanging up on this wall?'"); */
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
            Item.createTile = ModContent.TileType<SailfishTrophyPlaced>();
            Item.width = 38;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
        }
    }
}