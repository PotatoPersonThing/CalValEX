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
            DisplayName.SetDefault("Calamitous Ritual Basin");
            SacrificeTotal = 1;
            Tooltip.SetDefault("The fire dances above it with entertaining intent");
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