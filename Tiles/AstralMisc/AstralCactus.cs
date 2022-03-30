using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralCactus : ModCactus
	{
		public override Texture2D GetTexture() => ModContent.Request<Texture2D>("CalValEX/Tiles/AstralMisc/AstralCactus").Value;
	}
}