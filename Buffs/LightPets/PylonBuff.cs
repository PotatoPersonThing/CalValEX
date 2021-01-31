using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.LightPets;

namespace CalValEX.Buffs.LightPets 
{
	public class PylonBuff : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Proto-Pylon");
		    Description.SetDefault("Supercharges other proto-bots");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) 
        {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().pylon = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumPylon>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
            {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Wulfrum.WulfrumPylon>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}