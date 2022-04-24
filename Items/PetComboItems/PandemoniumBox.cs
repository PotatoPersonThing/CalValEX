using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Projectiles.Pets;
using CalValEX.Items.PetComboItems.PreHardmode;
using CalValEX.Items.PetComboItems.Hardmode;
using CalValEX.Items.PetComboItems.PostMoonLord;
using System.Collections.Generic;

namespace CalValEX.Items.PetComboItems
{
    public class PandemoniumBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pandemonium Box");
            Tooltip.SetDefault("And I wish I was the only one to leave\nThe end of our journey, your zenith\nSummons every pet you've met in your path");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(8, 8, 1, 9);
            Item.rare = 9;//12;
            Item.buffType = ModContent.BuffType<PandoraBuff>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                List<Color> devColors = new List<Color>()
                {
                    new Color(213, 68, 255), //YuH
                    new Color(255, 122, 40), //Hype
                    new Color(112, 48, 250), //Tri
                    new Color(241, 119, 184), //Mochi
                    new Color(255, 109, 109), //Heart
                    new Color(255, 140, 54), //Tomat
                    new Color(160, 160, 160), //Goat
                    new Color(132, 37, 147), //Willow
                    new Color(0, 199, 182) //Iban
                };
                int colorIndex = (int)(Main.GlobalTimeWrappedHourly / 2 % devColors.Count);
                Color currentColor = devColors[colorIndex];
                Color nextColor = devColors[(colorIndex + 1) % devColors.Count];
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = Color.Lerp(currentColor, nextColor, Main.GlobalTimeWrappedHourly % 2f > 1f ? 1f : Main.GlobalTimeWrappedHourly % 1f);
                }
            }
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<NurseryBell>())
                .AddIngredient(ModContent.ItemType<DustChime>())
                .AddIngredient(ModContent.ItemType<BestInstrument>())
                .AddIngredient(ModContent.ItemType<MaladyBells>())
                .AddIngredient(ModContent.ItemType<SpiritDinerBell>())
                .AddIngredient(ModContent.ItemType<VaselineBell>())
                .AddIngredient(ModContent.ItemType<WormBell>())
                .AddIngredient(ModContent.ItemType<AltarBell>())
                .AddIngredient(ModContent.ItemType<ScratchedGong>())
                .AddIngredient(ModContent.ItemType<TubRune>())
                //.AddTile(ModLoader.GetMod("CalamityMod").TileType<DraedonsForge>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}