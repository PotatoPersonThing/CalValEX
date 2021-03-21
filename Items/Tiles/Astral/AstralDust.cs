using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.scale *= 1.5f;
			dust.noGravity = false;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.99f;
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}