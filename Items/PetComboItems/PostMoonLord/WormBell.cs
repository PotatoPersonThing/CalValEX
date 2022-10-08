/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.SepulcherNeo;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.PetComboItems.PostMoonLord {
    public class WormBell : ModItem {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 20, 30, 60);
            Item.rare = ItemRarityID.Purple;
            Item.buffType = BuffType<WormBellBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<SWPet>();
            ProjectileType<StasisNaked>();
            ProjectileType<AquaPet>();
            ProjectileType<DesertPet>();
            ProjectileType<DeusPetSmall>();
            ProjectileType<DeusPet>();
            ProjectileType<DogHead>();
            ProjectileType<JaredHead>();
            ProjectileType<SepulcherHeadNeo>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}*/