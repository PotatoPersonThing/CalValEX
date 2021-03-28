using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class Aestheticrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aestheticrest");
            //Tooltip.SetDefault("AAAAAAAAAAAAAAAAAAA");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 10;
            item.vanity = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise) = new Color(0, 255, 200)
            //rarity 13 (Pure Green) = new Color(0, 255, 0)
            //rarity 14 (Dark Blue) = new Color(43, 96, 222)
            //rarity 15 (Violet) = new Color(108, 45, 199)
            //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
            //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
            //rarity rare variant = new Color(255, 140, 0)
            //rarity dedicated(patron items) = new Color(139, 0, 0)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(107, 240, 255); //change the color accordingly to above
                }
            }
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().aesthetic = true;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<CalValEXPlayer>().aesthetic = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            recipe.AddIngredient(calamityMod.ItemType("AerialiteBar"), 2);
            recipe.AddIngredient((ItemID.Glass), 7);
            recipe.AddIngredient((ItemID.Gel), 5);
            recipe.AddIngredient((ItemID.MeteoriteBar), 3);
            recipe.AddIngredient((ItemID.HellstoneBar), 3);
            recipe.AddIngredient((ItemID.FallenStar), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}