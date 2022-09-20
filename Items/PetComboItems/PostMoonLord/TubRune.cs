using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.PetComboItems.PostMoonLord {
    public class TubRune : ModItem {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(7, 7, 7, 0);
            Item.rare = ItemRarityID.Purple;
            Item.buffType = BuffType<TubRuneBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<CalamityBABY>();
            ProjectileType<CoolBlueSignut>();
            ProjectileType<CoolBlueSlime>();
            ProjectileType<GoozmaPet>();
            ProjectileType<UngodlySerpent>();
            ProjectileType<Projectiles.Pets.Sirember>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}