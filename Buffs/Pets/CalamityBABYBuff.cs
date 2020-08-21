using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class CalamityBABYBuff : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("God's Presence");
			Description.SetDefault("The BABY of a omnipotent GOD accompany you... Just don't get hit");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<CalValEXPlayer>().CalamityBABYBool = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<CalamityBABY>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (player.width / 2), player.position.Y + (player.height / 2) + 50f, 0f, 0f, ModContent.ProjectileType<CalamityBABY>(), 0, 0f, player.whoAmI);
			}
		}
	}
}
