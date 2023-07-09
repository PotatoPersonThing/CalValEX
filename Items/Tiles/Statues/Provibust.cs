using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Tiles.Statues;

namespace CalValEX.Items.Tiles.Statues {
    public class Provibust : ModItem {
        public override void SetStaticDefaults() => 
            Item.ResearchUnlockCount = 1;

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<ProfanedIdolPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = 11;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            foreach (TooltipLine tooltipLine in tooltips) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                    tooltipLine.OverrideColor = new Color(0, 255, 200);
            }
        }
    }
}