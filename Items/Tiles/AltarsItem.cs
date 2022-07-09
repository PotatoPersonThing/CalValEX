using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles {
    public class MoulderingAltarItem : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mouldering Altar");
            Tooltip.SetDefault("Counts as a demon altar");
            SacrificeTotal = 5;
        }

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<MoulderingAltarPlaced>();
            Item.width = 32;
            Item.height = 50;
            Item.rare = ItemRarityID.Green;
        }
    }
    public class VisceralAltarItem : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Visceral Altar");
            Tooltip.SetDefault("Counts as a crimson altar");
            SacrificeTotal = 5;
        }

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<VisceralAltarPlaced>();
            Item.width = 32;
            Item.height = 50;
            Item.rare = ItemRarityID.Green;
        }
    }
}
