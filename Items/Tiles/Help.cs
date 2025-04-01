using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria;

namespace CalValEX.Items.Tiles
{
    public class Help : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Stuck Orthocera");
            /* Tooltip
                .SetDefault("Help me\n" + "Can be fed Green Mushrooms"); */
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
            Item.createTile = ModContent.TileType<Helplaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Pink;
        }
    }
}
