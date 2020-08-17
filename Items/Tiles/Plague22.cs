using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class Plague22 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("22");
            Tooltip.SetDefault("'Willow'\n22");
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
            item.createTile = ModContent.TileType<Plague22Placed>();
            item.width = 12;
            item.height = 12;
            item.rare = ItemRarityID.LightRed;
        }
    }
}