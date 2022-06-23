using CalValEX.Tiles.AstralBlocks;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralCactus : ModCactus
	{
		public override void SetStaticDefaults()
		{
			GrowsOnTileId = new int[1] { ModContent.TileType<AstralSandPlaced>() };
		}

		public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("CalValEX/Tiles/AstralMisc/AstralCactus");

		public override Asset<Texture2D> GetFruitTexture() {
			return null;
		}

	}
}