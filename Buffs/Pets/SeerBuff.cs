using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;

namespace CalValEX.Buffs.Pets {
	public class SeerBuff : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sightseeing Tour");
		    Description.SetDefault("Seeing the world together");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().seerS = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SeerS>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SeerS>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().seerM = true;
			bool petProjectileNotSpawnedf = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SeerM>()] <= 0;
			if (petProjectileNotSpawnedf && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SeerM>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().seerL = true;
			bool petProjectileNotSpawnedfl = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SeerL>()] <= 0;
			if (petProjectileNotSpawnedfl && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SeerL>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}