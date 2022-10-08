using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Buffs.Pets;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using CalamityMod.Items.Weapons.Summon;

namespace CalValEX.Items.Pets {
    public class BrimberryItem : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Brimstone Berry");
            Tooltip.SetDefault(CalValEX.month == 6 ? "I can double jump!" : "Summons an ancient fruit " +
                "\nOften used as offering to the Brimstone Goddess");
            SacrificeTotal = 1;
        }

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit1;
            Item.shoot = ProjectileType<BrimberryPet>();
            Item.value = Item.sellPrice(0, 2, 9, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.buffType = BuffType<BrimberryBuff>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            foreach (TooltipLine tooltipLine in tooltips) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                    tooltipLine.OverrideColor = new Color(107, 240, 255);
            }
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            type = ModContent.ProjectileType<BrimberryPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}