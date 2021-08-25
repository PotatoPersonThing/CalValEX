using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks.Astral;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralPalm : ModPalmTree
	{
		public override Texture2D GetTexture() => ModContent.GetTexture("CalValEX/Tiles/AstralMisc/AstralPalm");

		public override Texture2D GetTopTextures() => ModContent.GetTexture("CalValEX/Tiles/AstralMisc/AstralPalmTop");

		public override int DropWood() => ModContent.ItemType<AstralTreeWood>(); // TODO
	}
}