using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("CalValEX");

		public override int DropWood()
		{
			return ModContent.ItemType<AstralTreeWood>();
		}

		public override Texture2D GetTexture() {
			return mod.GetTexture("Items/Tiles/Astral/AstralTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) {
			return mod.GetTexture("Items/Tiles/Astral/AstralTreeTop");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) {
			return mod.GetTexture("Items/Tiles/Astral/AstralTreeBranch");
		}
	}
} 