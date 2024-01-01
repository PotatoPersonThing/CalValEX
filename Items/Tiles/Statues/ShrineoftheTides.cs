using Terraria.ModLoader;
using CalValEX.Tiles.Statues;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Statues
{
    public class ShrineoftheTides : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shrine of the Tides");
            /* Tooltip
                .SetDefault("My gift to the Water Goddess"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<ShrineoftheTidesPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Lime;
        }
    }
}