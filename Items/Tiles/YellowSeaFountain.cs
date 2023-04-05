using Terraria;
using Terraria.ModLoader;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ID;

namespace CalValEX.Items.Tiles {
    public class YellowSeaFountain : ModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Yellow Sea Fountain");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 16;
            Item.height = 28;
            Item.rare = ItemRarityID.Orange;
            Item.createTile = ModContent.TileType<YellowSeaFountainPlaced>();
        }
    }
}