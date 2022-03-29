using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.PetComboItems.PreHardmode;
using CalValEX.Items.PetComboItems.Hardmode;
using CalValEX.Items.PetComboItems.PostMoonLord;
using CalValEX.Items.Pets.ExoMechs;

namespace CalValEX.Items.PetComboItems
{
    public class PandemoniumBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pandemonium Box");
            Tooltip.SetDefault("And I wish I was the only one to leave\nSummons every pet you've met in your path\nThe end of our journey, your zenith");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("");
            item.value = Item.sellPrice(8, 8, 1, 9);
            item.rare = 12;
            item.buffType = mod.BuffType("PandoraBuff");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                List<Color> devColors = new List<Color>()
                {
                    new Color(213, 68, 255),
                    new Color(255, 122, 40),
                    new Color(112, 48, 250),
                    new Color(241, 119, 184),
                    new Color(255, 109, 109),
                    new Color(160, 160, 160),
                    new Color(132, 37, 147),
                    new Color(0, 199, 182)
                };
                int colorIndex = (int)(Main.GlobalTime / 2 % devColors.Count);
                Color currentColor = devColors[colorIndex];
                Color nextColor = devColors[(colorIndex + 1) % devColors.Count];
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = Color.Lerp(currentColor, nextColor, Main.GlobalTime % 2f > 1f ? 1f : Main.GlobalTime % 1f);
                }
            }
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            string[] summonedPets = new string[] {};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NurseryBell>());
            recipe.AddIngredient(ModContent.ItemType<DustChime>());
            recipe.AddIngredient(ModContent.ItemType<AlarmClock>());
            recipe.AddIngredient(ModContent.ItemType<BestInstrument>());
            recipe.AddIngredient(ModContent.ItemType<MaladyBells>());
            recipe.AddIngredient(ModContent.ItemType<HarbingerOfWork>());
            recipe.AddIngredient(ModContent.ItemType<SpiritDinerBell>());
            recipe.AddIngredient(ModContent.ItemType<VaselineBell>());
            recipe.AddIngredient(ModContent.ItemType<WormBell>());
            recipe.AddIngredient(ModContent.ItemType<AltarBell>());
            recipe.AddIngredient(ModContent.ItemType<ScratchedGong>());
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}