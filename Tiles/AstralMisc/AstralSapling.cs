using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Tiles.AstralBlocks;

namespace CalValEX.Tiles.AstralMisc
{
	public class AstralSapling : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorValidTiles = new[] { ModContent.TileType<AstralGrassPlaced>() };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.newTile.StyleMultiplier = 3;
			TileID.Sets.CommonSapling[Type] = true;
			TileID.Sets.TreeSapling[Type] = true;
			TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			TileObjectData.addSubTile(1);
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Blighted Astral Sapling");
			AddMapEntry(new Color(200, 200, 200), name);

			AdjTiles = new int[] { TileID.Saplings };
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

		public override void RandomUpdate(int i, int j) {
			if (WorldGen.genRand.NextBool(20))
			{
				Tile tile = Framing.GetTileSafely(i, j);
				bool growSucess;
				growSucess = WorldGen.GrowTree(i, j);
				bool isPlayerNear = WorldGen.PlayerLOS(i, j);
				if (growSucess && isPlayerNear)
					WorldGen.TreeGrowFXCheck(i, j);
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects) {
			if (i % 2 == 1)
				effects = SpriteEffects.FlipHorizontally;
		}
	}
}