using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
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
            player.GetModPlayer<CalValEXPlayer>().raresandmini = true;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            player.GetModPlayer<CalValEXPlayer>().babywaterclone = true;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            bool petProjectileNotSpawned = (player.ownedProjectileCounts[mod.ProjectileType("rarebrimling")] <= 0 &&
                                            player.ownedProjectileCounts[mod.ProjectileType("raresandmini")] <= 0 &&
                                            player.ownedProjectileCounts[mod.ProjectileType("sandmini")] <= 0 &&
                                            player.ownedProjectileCounts[mod.ProjectileType("cloudmini")] <= 0 &&
                                            player.ownedProjectileCounts[mod.ProjectileType("babywaterclone")] <= 0
                                           );
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("rarebrimling"), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("raresandmini"), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("sandmini"), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("cloudmini"), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("babywaterclone"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}