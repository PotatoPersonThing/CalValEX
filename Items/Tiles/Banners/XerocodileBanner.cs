using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Tiles.Banners;

namespace CalValEX.Items.Tiles.Banners
{
    public class XerocodileBanner : ModItem
    {
        // The tooltip for this item is automatically assigned from .lang files
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = 4;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.createTile = TileType<XerocodileBannerPlaced>();
            Item.placeStyle = 0;
        }
    }
}