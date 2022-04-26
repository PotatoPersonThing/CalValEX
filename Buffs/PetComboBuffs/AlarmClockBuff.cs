using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.Wulfrum;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class AlarmClockBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            player.GetModPlayer<CalValEXPlayer>().AlarmClock = true;
            player.GetModPlayer<CalValEXPlayer>().pylon = true;
            player.GetModPlayer<CalValEXPlayer>().drone = true;
            player.GetModPlayer<CalValEXPlayer>().rover = true;
            player.GetModPlayer<CalValEXPlayer>().hover = true;
            player.GetModPlayer<CalValEXPlayer>().worb = true;
            player.GetModPlayer<CalValEXPlayer>().RepairBot = true;

            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumPylon>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2), 
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumPylon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumDrone>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumDrone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumRover>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumRover>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBC = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumHover>()] <= 0;
            if (petProjectileNotSpawnedBC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumHover>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBD = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumOrb>()] <= 0;
            if (petProjectileNotSpawnedBD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumOrb>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<RepairBot>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RepairBot>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}