using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;

namespace CalValEX.Buffs.LightPets 
{
	public class VanityCoreBuff : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Core of Vanity");
		    Description.SetDefault("Everyone gets along!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) 
        {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().mHeat = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
            {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHeat2 = true;
			bool petProjectileNotSpawned2 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatBaby>()] <= 0;
			if (petProjectileNotSpawned2 && player.whoAmI == Main.myPlayer) 
            {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.LightPets.HeatBaby>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().Skeetyeet = true;
			bool petProjectileNotSpawned3 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LightPets.Skeetyeet>()] <= 0;
			if (petProjectileNotSpawned3 && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Skeetyeet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().Lightshield = true;
			bool petProjectileNotSpawned4 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LightPets.Lightshield>()] <= 0;
			if (petProjectileNotSpawned4 && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Lightshield"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}