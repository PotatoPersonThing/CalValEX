using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Blocks
{
    public class AstralGrass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Grass");
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
            item.width = 16;
            item.height = 28;
            item.rare = 0;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                item.createTile = (calamityMod.TileType("AstralGrass"));
            }
        }
    }
}