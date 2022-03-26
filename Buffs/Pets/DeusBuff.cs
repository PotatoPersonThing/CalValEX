using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class DeusBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Astrum Demus");
            Description.SetDefault("Wormheck");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deussmall = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("DeusPetSmall")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                for (int k = 0; k < 10; k++)
                {
                    Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + (32 * k), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("DeusPetSmall"), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deusmain = true;
            bool petProjectileNotSpawned2 = player.ownedProjectileCounts[mod.ProjectileType("DeusPet")] <= 0;
            if (petProjectileNotSpawned2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height * 20), 0f, 0f, mod.ProjectileType("DeusPet"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}