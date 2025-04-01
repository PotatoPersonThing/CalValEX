using CalValEX.Tiles.Plants;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Plants
{
    public class PottedDecapoditaSprout : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Potted Decapodita Sprout");
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Fungus");
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
            Item.createTile = ModContent.TileType<DecapoditaSproutPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Green;
        }
    }
}