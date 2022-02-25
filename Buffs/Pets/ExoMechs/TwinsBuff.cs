using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets.ExoMechs
{
    public class TwinsBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Toy XS-Apollo and XS-Artemis");
            Description.SetDefault("Here they are"); 
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().twins = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ExoMechs.TwinsPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Pets.ExoMechs.TwinsPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}