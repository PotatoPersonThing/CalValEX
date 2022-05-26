using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using CalValEX.Items.Tiles.Blocks.Astral;
using CalValEX.Tiles.AstralBlocks;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralPalm : ModPalmTree
	{
		public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
		{
			UseSpecialGroups = true,
			SpecialGroupMinimalHueValue = 11f / 72f,
			SpecialGroupMaximumHueValue = 0.25f,
			SpecialGroupMinimumSaturationValue = 0.88f,
			SpecialGroupMaximumSaturationValue = 1f
		};

		public override void SetStaticDefaults()
		{
			GrowsOnTileId = new int[1] { ModContent.TileType<AstralSandPlaced>() };
		}

		public override Asset<Texture2D> GetTexture()
		{
			return ModContent.Request<Texture2D>("CalValEX/Tiles/AstralMisc/AstralPalm");
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 1;
			return ModContent.TileType<AstralPalmSapling>();
		}

		public override Asset<Texture2D> GetOasisTopTextures()
		{
			return ModContent.Request<Texture2D>("CalValEX/Tiles/AstralMisc/AstralPalmOasis");
		}

		public override Asset<Texture2D> GetTopTextures()
		{
			return ModContent.Request<Texture2D>("CalValEX/Tiles/AstralMisc/AstralPalmTop");
		}
		public override int GrowthFXGore() => -1;

		public override int DropWood()
		{
			return ModContent.ItemType<AstralTreeWood>();
		}

	}
}