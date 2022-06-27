using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Monoliths;

namespace CalValEX.Items.Tiles.Monoliths
{
    public class CalamitousMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;
            //Tooltip.SetDefault("Infuses the nearby air with harmless Brimstone magic when activated\n" + "Cannot be used if any other Calamity monoliths are currently active");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 32;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.createTile = ModContent.TileType<CalamitousMonolithPlaced>();
        }
    }
}