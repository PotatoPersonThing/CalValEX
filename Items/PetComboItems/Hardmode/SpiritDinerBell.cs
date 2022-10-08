/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Elementals;
using CalValEX.Items.Pets.Elementals;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.PetComboItems.Hardmode {
    public class SpiritDinerBell : ModItem {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 12, 70, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.buffType = ModContent.BuffType<SpiritDinerBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<Pillager>();
            ProjectileType<SolarBunny>();
            ProjectileType<RareBrimling>();
            ProjectileType<CloudMini>();
            ProjectileType<RaresandMini>();
            ProjectileType<Sandmini>();
            ProjectileType<BabyWaterClone>();
            ProjectileType<StarJelly>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}*/