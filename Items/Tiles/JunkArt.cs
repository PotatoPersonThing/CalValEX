using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    internal class JunkArt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reconstructed Particle Accelerator");
            Tooltip.SetDefault("'Reassembled from old blueprints. The flower inside has grown vibrantly after five years.'");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<JunkArtPlaced>();
            item.width = 48;
            item.height = 32;
            item.rare = ItemRarityID.LightRed;
        }
    }
}