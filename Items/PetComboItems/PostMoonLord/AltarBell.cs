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

namespace CalValEX.Items.PetComboItems.PostMoonLord {
    public class AltarBell : ModItem {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 25, 80, 15);
            Item.rare = ItemRarityID.Purple;
            Item.buffType = BuffType<AltarBellBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<Dragonball>();
            ProjectileType<Godrge>();
            ProjectileType<Avalon>();
            ProjectileType<YharimSquid>();
            ProjectileType<TerminalRock>();
            ProjectileType<BejeweledScuttler>();
            ProjectileType<ProGuard1>();
            ProjectileType<ProGuard2>();
            ProjectileType<ProGuard3>();
            ProjectileType<ProviPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}*/