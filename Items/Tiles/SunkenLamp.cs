using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ID;

namespace CalValEX.Items.Tiles
{
    public class SunkenLamp : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sunken Lamp");
            // Tooltip.SetDefault("Trippy");
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
            Item.createTile = ModContent.TileType<SunkenLampPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Green;
        }
    }
}