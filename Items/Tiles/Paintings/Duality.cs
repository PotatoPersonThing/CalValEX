using Terraria.ID; using CalValEX.Tiles.Paintings;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Paintings
{
    public class Duality : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Duality");
            // Tooltip.SetDefault("'Mathew Maple'");
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
            Item.createTile = ModContent.TileType<DualityPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 3;
        }
    }
}