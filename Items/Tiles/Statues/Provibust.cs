using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.Statues;
using Terraria.ID;
using CalValEX.CalamityID;

namespace CalValEX.Items.Tiles.Statues {
    public class Provibust : ModItem {
        public override void SetStaticDefaults() => 
            Item.ResearchUnlockCount = 1;

        public override void SetDefaults() {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<ProfanedIdolPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalRarityID.Turquoise;
        }
    }
}