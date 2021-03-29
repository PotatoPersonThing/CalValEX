using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Monoliths
{
    public class AquaticMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Emits dark briny mist when activated\n" + "Cannot be used if two Monoliths are currently active");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 32;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.createTile = ModContent.TileType<AquaticMonolithPlaced>();
        }
    }
}