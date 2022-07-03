using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Blocks
{
    public class AstralGrass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Grass");
            SacrificeTotal = 100;
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
            Item.width = 16;
            Item.height = 28;
            Item.rare = 0;
            Item.createTile = ModContent.TileType<CalamityMod.Tiles.Astral.AstralGrass>();
        }
    }
}