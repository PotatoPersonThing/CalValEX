using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets.Wulfrum;

namespace CalValEX.Buffs.Pets {
    
	public class WulfrumArmy : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Wulfrum Army");
		    Description.SetDefault("Cling clang and bang");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().drone = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumDrone>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumDrone>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().rover = true;
			bool petProjectileNotSpawnedf = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumRover>()] <= 0;
			if (petProjectileNotSpawnedf && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumRover>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().hover = true;
			bool petProjectileNotSpawnedfd = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumHover>()] <= 0;
			if (petProjectileNotSpawnedfd && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumHover>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().worb = true;
			bool petProjectileNotSpawnedfgg = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumOrb>()] <= 0;
			if (petProjectileNotSpawnedfgg && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumOrb>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().pylon = true;
			bool petProjectileNotSpawnedddf = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumPylon>()] <= 0;
			if (petProjectileNotSpawnedddf && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumPylon>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}