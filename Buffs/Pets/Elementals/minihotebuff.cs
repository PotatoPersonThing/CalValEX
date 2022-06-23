using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets.Elementals
{
    public class minihotebuff : ModBuff
    {
        public override void SetDefaults()
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
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Elementals.rarebrimling>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Elementals.rarebrimling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            bool petProjectileNotSpawnedf = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Elementals.cloudmini>()] <= 0;
            if (petProjectileNotSpawnedf && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Elementals.cloudmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().raresandmini = true;
            bool petProjectileNotSpawnedfl = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Elementals.raresandmini>()] <= 0;
            if (petProjectileNotSpawnedfl && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Elementals.raresandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            bool petProjectileNotSpawnedf2 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Elementals.sandmini>()] <= 0;
            if (petProjectileNotSpawnedf2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Elementals.sandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().babywaterclone = true;
            bool petProjectileNotSpawnedf3 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Elementals.babywaterclone>()] <= 0;
            if (petProjectileNotSpawnedf3 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Elementals.babywaterclone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}