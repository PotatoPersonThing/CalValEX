using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Blocks;
using Terraria;

namespace CalValEX.Items.Tiles.Blocks {
    public class ThanatosPlating : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 100;

        public override void SetDefaults() {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.rare = 0;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<ThanatosPlatingPlaced>();
        }
    }

    public class ThanatosPlatingVent : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 100;

        public override void SetDefaults() {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.rare = 0;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<ThanatosPlatingVentPlaced>();
        }
    }
}