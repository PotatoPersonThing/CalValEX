using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.AstralBlocks;
using CalValEX.Walls.AstralUnsafe;
using CalValEX.Tiles.AstralMisc;
using CalValEX.Walls.AstralSafe;
using CalValEX.Dusts;

namespace CalValEX.Projectiles
{
	public class YellowSolutionProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yellow Spray");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override bool CanDamage() => false;

		public override void AI()
		{
			int dustType = ModContent.DustType<YellowSolutionDust>();

			if (projectile.owner == Main.myPlayer)
				Convert((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);

			if (projectile.timeLeft > 133)
				projectile.timeLeft = 133;

			if (projectile.ai[0] > 7f)
			{
				float dustScale = 1f;

				if (projectile.ai[0] == 8f)
					dustScale = 0.2f;
				else if (projectile.ai[0] == 9f)
					dustScale = 0.4f;
				else if (projectile.ai[0] == 10f)
					dustScale = 0.6f;
				else if (projectile.ai[0] == 11f)
					dustScale = 0.8f;

				projectile.ai[0] += 1f;

				for (int i = 0; i < 1; i++)
				{
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100);
					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1.75f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
					dust.scale *= dustScale;
				}
			}
			else
				projectile.ai[0] += 1f;

			projectile.rotation += 0.3f * projectile.direction;
		}

		public void Convert(int i, int j, int size = 4)
		{
			for (int k = i - size; k <= i + size; k++)
			{
				for (int l = j - size; l <= j + size; l++)
				{
					if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size))
					{
						int type = Main.tile[k, l].type;
						int typemed = Main.tile[k - 1, l].type;
						int wall = Main.tile[k, l].wall;
						Mod CalValEX = ModLoader.GetMod("CalamityMod");

						//Stone
						if (type == ModContent.TileType<AstralHardenedSandPlaced>())
						{
							Main.tile[k, l].type = TileID.HardenedSand;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralSandstonePlaced>())
						{
							Main.tile[k, l].type = TileID.Sandstone;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralTreeWoodPlaced>())
						{
							Main.tile[k, l].type = TileID.LivingWood;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralGrassPlaced>())
						{
							Main.tile[k, l].type = TileID.Grass;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralDirtPlaced>())
						{
							Main.tile[k, l].type = TileID.Dirt;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralSandPlaced>())
						{
							Main.tile[k, l].type = TileID.Sand;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralClayPlaced>())
						{
							Main.tile[k, l].type = TileID.ClayBlock;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<XenostonePlaced>())
						{
							Main.tile[k, l].type = TileID.Stone;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralIcePlaced>())
						{
							Main.tile[k, l].type = TileID.IceBlock;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralSnowPlaced>())
						{
							Main.tile[k, l].type = TileID.SnowBlock;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralShortGrass>())
						{
							Main.tile[k, l].type = TileID.Plants;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralTallGrass>())
						{
							Main.tile[k, l].type = TileID.Plants2;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						/*else if (type == ModContent.TileType<AstralPilesBig>())
						{
							//Left top
							Main.tile[k, l].type = TileID.LargePiles;
							//Middle top
							Main.tile[k - 1, l].type = TileID.LargePiles;
							//Right top
							Main.tile[k - 2, l].type = TileID.LargePiles;
							//Left bottom
							Main.tile[k, l - 1].type = TileID.LargePiles;
							//Middle bottom
							Main.tile[k - 1, l - 1].type = TileID.LargePiles;
							//Right bottom
							Main.tile[k - 2, l - 1].type = TileID.LargePiles;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralPilesMedium>())
						{
							Main.tile[k, l].type = TileID.SmallPiles;
							Main.tile[k - 1, l].type = TileID.SmallPiles;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralPilesSmall>())
						{
							Main.tile[k, l].type = TileID.SmallPiles;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralStalactites>())
						{
							Main.tile[k, l].type = TileID.Stalactite;
							Main.tile[k, l - 1].type = TileID.Stalactite;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}*/
						if (wall == ModContent.WallType<AstralDirtWallPlaced>())
						{
							Main.tile[k, l].wall = WallID.Dirt;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<XenostoneWallPlaced>())
						{
							Main.tile[k, l].wall = WallID.Stone;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralHardenedSandWallPlaced>())
						{
							Main.tile[k, l].wall = WallID.HardenedSand;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralSandstoneWallPlaced>())
						{
							Main.tile[k, l].wall = WallID.Sandstone;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralIceWallPlaced>())
						{
							Main.tile[k, l].wall = WallID.IceUnsafe;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralGrassWallPlaced>())
						{
							Main.tile[k, l].wall = WallID.Grass;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
					}
				}
			}
		}
	}
}