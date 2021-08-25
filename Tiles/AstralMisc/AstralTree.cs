using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using CalValEX.Items.Tiles.Blocks.Astral;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("CalValEX");

		public override int DropWood()
		{
			return ModContent.ItemType<AstralTreeWood>();
		}

		public override Texture2D GetTexture() {
			return mod.GetTexture("Tiles/AstralMisc/AstralTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) {
			return mod.GetTexture("Tiles/AstralMisc/AstralTreeTop");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) {
			return mod.GetTexture("Tiles/AstralMisc/AstralTreeBranch");
		}
	}
} 