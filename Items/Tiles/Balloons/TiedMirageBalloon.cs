using Terraria.ModLoader;
using CalValEX.Tiles.Balloons;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Balloons
{
    public class TiedMirageBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tied Mirage Balloon");
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
            Item.createTile = ModContent.TileType<TiedMirageBalloonPlaced>();
            Item.width = 16;
            Item.height = 40;
            Item.rare = ItemRarityID.LightPurple;
        }
    }
}