using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;
using Terraria;

namespace CalValEX.Items.Tiles {
    public class CalamityLamp : ModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Brimstone Flambeau");
            // Tooltip.SetDefault("Something malicious is brewing");
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
            Item.createTile = ModContent.TileType<CalamityLampPlaced>();
            Item.width = 32;
            Item.height = 50;
            Item.rare = ItemRarityID.Purple;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            foreach (TooltipLine tooltipLine in tooltips) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                    tooltipLine.OverrideColor = new Color(108, 45, 199);
            }
        }
    }
}