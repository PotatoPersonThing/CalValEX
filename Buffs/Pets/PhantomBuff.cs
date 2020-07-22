using Terraria;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;

namespace CalValEX.Buffs.Pets 
{
	public class PhantomBuff : ModBuff
	{		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Freed Phantom Spirit");
		    Description.SetDefault("Finally free, but still follows you!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex) 
        {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().mPhan = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.PhantomSpirit>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) 
            {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.PhantomSpirit>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}