﻿/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.PetComboItems.PostMoonLord {
    public class VaselineBell : ModItem {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 50, 50, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.buffType = BuffType<VaselineBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<GrandPet>();
            ProjectileType<BuffReaper>();
            ProjectileType<Smauler>();
            ProjectileType<ScoriaDuke>();
            ProjectileType<FollyPet>();
            ProjectileType<BugDoge>();
            ProjectileType<Headoge>();
            ProjectileType<MiniDoge>();
            ProjectileType<PolterChan>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}*/