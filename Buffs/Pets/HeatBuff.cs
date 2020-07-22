using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;

namespace CalValEX.Buffs.Pets 
{
	public class HeatBuff : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Chaos Skulls");
		    Description.SetDefault("Here to judge you for your sins... not really");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) 
        {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().mHeat = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.HeatPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
            {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.HeatPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHeat2 = true;
			bool petProjectileNotSpawned2 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.HeatBaby>()] <= 0;
			if (petProjectileNotSpawned2 && player.whoAmI == Main.myPlayer) 
            {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.HeatBaby>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}