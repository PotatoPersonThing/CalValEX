using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Paintings
{
    public class SwearingShroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angry Shroom");
            Tooltip.SetDefault("'Mathew Maple'");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<SwearingShroomPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 3;
        }
    }
}