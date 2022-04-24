using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class MaladyBellsBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            player.GetModPlayer<CalValEXPlayer>().MaladyBells = true;
            player.GetModPlayer<CalValEXPlayer>().Cryokid = true;
            player.GetModPlayer<CalValEXPlayer>().mDebris = true;
            player.GetModPlayer<CalValEXPlayer>().eidolist = true;
            player.GetModPlayer<CalValEXPlayer>().feel = true;
            player.GetModPlayer<CalValEXPlayer>().moistPet = true;
            player.GetModPlayer<CalValEXPlayer>().BoldLizard = true;
            player.GetModPlayer<CalValEXPlayer>().mSkater = true;

            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Cryokid>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Cryokid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<PhantomPet>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<PhantomPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<Hoodieidolist>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Hoodieidolist>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<FathomEelHead>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<FathomEelHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<MoistScourgePet>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<MoistScourgePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedF = player.ownedProjectileCounts[ModContent.ProjectileType<BoldLizard>()] <= 0;
            if (petProjectileNotSpawnedF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BoldLizard>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedG = player.ownedProjectileCounts[ModContent.ProjectileType<SkaterPet>()] <= 0;
            if (petProjectileNotSpawnedG && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SkaterPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}