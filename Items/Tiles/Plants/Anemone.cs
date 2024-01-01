using Terraria.ModLoader;
using CalValEX.Tiles.Plants;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Plants
{
    public class Anemone : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Potted Anemone");
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
            Item.createTile = ModContent.TileType<AnemonePlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
        }
    }
}