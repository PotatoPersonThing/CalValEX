using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using CalValEX.Items.Tiles.Blocks.Astral;
using CalValEX.Tiles.AstralBlocks;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("CalValEX");
		public override void SetStaticDefaults()
		{
			GrowsOnTileId = new int[1] { ModContent.TileType<AstralGrassPlaced>() };
		}

		public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("Tiles/AstralMisc/AstralTree");

		// This is a blind copy-paste from Vanilla's PurityPalmTree settings.
		//TODO: This needs some explanations
		public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
		{
			UseSpecialGroups = true,
			SpecialGroupMinimalHueValue = 11f / 72f,
			SpecialGroupMaximumHueValue = 0.25f,
			SpecialGroupMinimumSaturationValue = 0.88f,
			SpecialGroupMaximumSaturationValue = 1f
		};

		public override void SetTreeFoliageSettings(Tile tile, int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight) { }
		public override Asset<Texture2D> GetBranchTextures() => ModContent.Request<Texture2D>("Tiles/AstralMisc/AstralTreeBranch");

		public override Asset<Texture2D> GetTopTextures() => ModContent.Request<Texture2D>("Tiles/AstralMisc/AstralTreeTop");
		public override int DropWood()
		{
			return ModContent.ItemType<AstralTreeWood>();
		}
		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return ModContent.TileType<AstralSapling>();
		}
	}
} 