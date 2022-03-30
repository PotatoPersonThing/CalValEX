using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using CalValEX.Items.Tiles.Blocks.Astral;

namespace CalValEX.Tiles.AstralMisc
{
	public class SnowAstralTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("CalValEX");

		public override int DropWood()
		{
			return ModContent.ItemType<AstralTreeWood>();
		}

		public override Texture2D GetTexture()
		{
			return ModContent.Request<Texture2D>("Tiles/AstralMisc/SnowAstralTree").Value;
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return ModContent.Request<Texture2D>("Tiles/AstralMisc/SnowAstralTreeTop").Value;
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return ModContent.Request<Texture2D>("Tiles/AstralMisc/SnowAstralTreeBranch").Value;
		}
	}
}