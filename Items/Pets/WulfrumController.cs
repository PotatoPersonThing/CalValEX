using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace CalValEX.Items.Pets
{
    public class WulfrumController : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Control Panel");
            Tooltip.SetDefault("Allows the user to control an army of mechs");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumDrone>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
            Item.buffType = ModContent.BuffType<Buffs.Pets.WulfrumArmy>();
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
            type = ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumDrone>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
            type = ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumOrb>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
            type = ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumHover>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
            type = ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumRover>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}