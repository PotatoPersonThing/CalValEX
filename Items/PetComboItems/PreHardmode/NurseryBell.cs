/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;
using CalValEX.Items.Pets.Scuttlers;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Scuttlers;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.PetComboItems.PreHardmode {
    public class NurseryBell : ModItem {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.buffType = ModContent.BuffType<NurseryBellBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<Buppy>();
            ProjectileType<Catfish>();
            ProjectileType<Angrypup>();
            ProjectileType<RedPanda>();
            ProjectileType<Puppo>();
            ProjectileType<BabyCnidrion>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}*/