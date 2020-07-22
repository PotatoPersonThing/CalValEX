using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;

namespace CalValEX.Buffs.Pets {
	public class SlimeBuff : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Slime Demigods");
		    Description.SetDefault("Heirs to the throne");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().cr = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Crimulan>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Crimulan>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().eb = true;
			bool petProjectileNotSpawnedf = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Ebonian>()] <= 0;
			if (petProjectileNotSpawnedf && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Ebonian>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().mSlime = true;
			bool petProjectileNotSpawnedfl = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SlimeDemi>()] <= 0;
			if (petProjectileNotSpawnedfl && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SlimeDemi>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}