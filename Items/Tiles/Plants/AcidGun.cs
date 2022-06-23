using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Plants
{
    public class AcidGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Tape Dispenser");
            Tooltip.SetDefault("Places an infinite amount of Sulphurous Vines");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 4;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.width = 16;
            Item.height = 28;
            Item.rare = 4;
            Item.createTile = ModContent.TileType<CalamityMod.Tiles.Abyss.SulphurousVines>();
        }
    }
}