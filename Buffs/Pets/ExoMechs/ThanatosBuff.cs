using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets.ExoMechs
{
    public class ThanatosBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Toy XF-Thanatos");
            Description.SetDefault("T(oy t) han(at)os"); 
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().thanos = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ExoMechs.ThanatosPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Pets.ExoMechs.ThanatosPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}