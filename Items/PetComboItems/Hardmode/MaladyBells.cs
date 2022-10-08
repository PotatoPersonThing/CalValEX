/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.PetComboItems.Hardmode {
    public class MaladyBells : ModItem {

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 8, 40, 15);
            Item.rare = ItemRarityID.LightPurple;
            Item.buffType = BuffType<MaladyBellsBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<Cryokid>();
            ProjectileType<PhantomPet>();
            ProjectileType<Hoodieidolist>();
            ProjectileType<FathomEelHead>();
            ProjectileType<MoistScourgePet>();
            ProjectileType<BoldLizard>();
            ProjectileType<SkaterPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}*/