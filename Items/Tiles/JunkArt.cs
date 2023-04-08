using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class JunkArt : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Reconstructed Particle Accelerator");
            // Tooltip.SetDefault("'Reassembled from old blueprints. The flower inside has grown vibrantly after five years.'");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<JunkArtPlaced>();
            Item.width = 48;
            Item.height = 32;
            Item.rare = ItemRarityID.LightRed;
        }
    }
}