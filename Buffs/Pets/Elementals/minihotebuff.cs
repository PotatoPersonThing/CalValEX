using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets.Elementals;

namespace CalValEX.Buffs.Pets.Elementals
{
    public class minihotebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Childish Heart");
            Description.SetDefault("Its like you're running a day-care or something.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            player.GetModPlayer<CalValEXPlayer>().rarebrimling = true;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            player.GetModPlayer<CalValEXPlayer>().raresandmini = true;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            player.GetModPlayer<CalValEXPlayer>().babywaterclone = true;

            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<RareBrimling>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                       player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RareBrimling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<CloudMini>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                       player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CloudMini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<RaresandMini>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                       player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RaresandMini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<Sandmini>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                       player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Sandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<BabyWaterClone>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                       player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BabyWaterClone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}