using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks.Astral;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralPalm : ModPalmTree
	{
		public override Texture2D GetTexture() => ModContent.Request<Texture2D>("CalValEX/Tiles/AstralMisc/AstralPalm").Value;

		public override Texture2D GetTopTextures() => ModContent.Request<Texture2D>("CalValEX/Tiles/AstralMisc/AstralPalmTop").Value;

		public override int DropWood() => ModContent.ItemType<AstralTreeWood>(); // TODO
	}
}