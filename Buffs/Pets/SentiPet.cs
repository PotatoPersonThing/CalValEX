using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;

namespace CalValEX.Buffs.Pets {
	public class SentiPet : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Sentinels");
		    Description.SetDefault("The Cosmic Terrors watch over you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().sSignus = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SSignus>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SSignus>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().sVoid = true;
			bool petProjectileNotSpawnedf = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SVoid>()] <= 0;
			if (petProjectileNotSpawnedf && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SVoid>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().sWeeb = true;
			bool petProjectileNotSpawnedfe = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SWeeb>()] <= 0;
			if (petProjectileNotSpawnedfe && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SWeeb>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}