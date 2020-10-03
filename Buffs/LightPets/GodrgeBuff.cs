using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;

namespace CalValEX.Buffs.LightPets 
{
	public class GodrgeBuff : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Nuclear George");
		    Description.SetDefault("Pathetic.");
			Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) 
        {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().GeorgeII = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LightPets.Godrge>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
            {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.LightPets.Godrge>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}