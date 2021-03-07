using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    internal class SulphurColumn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sulphurous Column");
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
            item.rare = 4;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                item.createTile = (calamityMod.TileType("SulphurousColumn"));
            }
        }
    }
}