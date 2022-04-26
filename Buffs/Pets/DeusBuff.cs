using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class DeusBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deussmall = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width * 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 3), player.position.Y + (float)(player.height * 4), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width * 3), player.position.Y + (float)(player.height * 5), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height * 7), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height * 9), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width * 6), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width * 10), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width * 6), player.position.Y + (float)(player.height * 6), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width * 10), player.position.Y + (float)(player.height * 10), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deusmain = true;
            bool petProjectileNotSpawned2 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.DeusPet>()] <= 0;
            if (petProjectileNotSpawned2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height * 20), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.DeusPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}