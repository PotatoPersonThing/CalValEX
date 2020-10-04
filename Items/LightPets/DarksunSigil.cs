using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalValEX.Buffs.LightPets;

namespace CalValEX.Items.LightPets
{
    public class DarksunSigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[item.type] = true;
            Tooltip.SetDefault("Summons Darksun Spirits to follow you");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 62;
            item.damage = 0;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item117;
            item.useAnimation = 20;
            item.useTime = 20;
            item.buffType = ModContent.BuffType<DarksunSpiritBuff>();
            item.rare = ItemRarityID.Red;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(108, 45, 199);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            recipe.AddIngredient(ModContent.ItemType<VanityCore>());
            recipe.AddIngredient(calamityMod.ItemType("AscendantSpiritEssence"), 2);
            recipe.AddIngredient(calamityMod.ItemType("DarksunFragment"), 5);
            recipe.AddTile(calamityMod.TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
