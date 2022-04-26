using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Scuttlers;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class AltarBellBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            //Mod clamMod = ModLoader.GetMod("CalamityMod");
            //clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);

            player.GetModPlayer<CalValEXPlayer>().AltarBell = true;
            player.GetModPlayer<CalValEXPlayer>().dBall = true;
            player.GetModPlayer<CalValEXPlayer>().GeorgeII = true;
            player.GetModPlayer<CalValEXPlayer>().avalon = true;
            player.GetModPlayer<CalValEXPlayer>().ySquid = true;
            player.GetModPlayer<CalValEXPlayer>().TerminalRock = true;
            player.GetModPlayer<CalValEXPlayer>().rainbow = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard1 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard2 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard3 = true;
            player.GetModPlayer<CalValEXPlayer>().ProviPet = true;

            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Dragonball>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Dragonball>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<Godrge>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Godrge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<Avalon>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Avalon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<YharimSquid>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<YharimSquid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<TerminalRock>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<TerminalRock>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedF = player.ownedProjectileCounts[ModContent.ProjectileType<BejeweledScuttler>()] <= 0;
            if (petProjectileNotSpawnedF && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BejeweledScuttler>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedG = player.ownedProjectileCounts[ModContent.ProjectileType<ProGuard1>()] <= 0 &&
                                            player.ownedProjectileCounts[ModContent.ProjectileType<ProGuard2>()] <= 0 &&
                                            player.ownedProjectileCounts[ModContent.ProjectileType<ProGuard3>()] <= 0 &&
                                            player.ownedProjectileCounts[ModContent.ProjectileType<ProviPet>()] <= 0;
            if (petProjectileNotSpawnedG && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProGuard1>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProGuard2>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProGuard3>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProviPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}