using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Buffs.Pets
{
    public class ScourgeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            // DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
            DisplayName.SetDefault("Pesky Twins");
            Description.SetDefault("Blaaaargh^2");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().asPet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<AquaPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height * 10,
                    0f, 0f, ProjectileType<AquaPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().dsPet = true;
            bool petProjectileNotSpawneds = player.ownedProjectileCounts[ProjectileType<DesertPet>()] <= 0;
            if (petProjectileNotSpawneds && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ProjectileType<DesertPet>(), 0, 0f, player.whoAmI);
            }
        }
    }
}