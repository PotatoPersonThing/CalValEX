using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class BestInstrumentBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            player.GetModPlayer<CalValEXPlayer>().BestInst = true;
            player.GetModPlayer<CalValEXPlayer>().mClam = true;
            player.GetModPlayer<CalValEXPlayer>().SmolCrab = true;
            player.GetModPlayer<CalValEXPlayer>().mPerf = true;
            player.GetModPlayer<CalValEXPlayer>().mHive = true;
            player.GetModPlayer<CalValEXPlayer>().Dstone = true;

            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<ClamHermit>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ClamHermit>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<SmolCrab>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SmolCrab>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<Fistuloid>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Fistuloid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<Hiveling>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Hiveling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<Dstone>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Dstone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}