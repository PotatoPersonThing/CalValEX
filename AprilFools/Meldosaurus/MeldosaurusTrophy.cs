using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class MeldosaurusTrophy : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<MeldosaurusTrophyPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Cyan;
        }
    }
}