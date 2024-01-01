using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Items.Pets
{
    [LegacyName("AstralStar")]
    public class Geminga : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Geminga");
            // Tooltip.SetDefault("A highly condensed star\n" + "Summons a swarm of 11 lesser star deities");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.DeusPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.buffType = ModContent.BuffType<Buffs.Pets.DeusBuff>();
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

        private int scourge2 = 180;

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<DeusPet>(), damage, knockback, player.whoAmI);
            for (int i = 0; i < 10; i++)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<DeusPetSmall>(), damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}