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
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.alpha = 255;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 2;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override bool CanHitPlayer(Player target) => false;

		public override void AI()
		{
			int dustType = ModContent.DustType<YellowSolutionDust>();

			if (Projectile.owner == Main.myPlayer)
				Convert((int)(Projectile.position.X + Projectile.width / 2) / 16, (int)(Projectile.position.Y + Projectile.height / 2) / 16, 2);

			if (Projectile.timeLeft > 133)
				Projectile.timeLeft = 133;

			if (Projectile.ai[0] > 7f)
			{
				float dustScale = 1f;

				if (Projectile.ai[0] == 8f)
					dustScale = 0.2f;
				else if (Projectile.ai[0] == 9f)
					dustScale = 0.4f;
				else if (Projectile.ai[0] == 10f)
					dustScale = 0.6f;
				else if (Projectile.ai[0] == 11f)
					dustScale = 0.8f;

				Projectile.ai[0] += 1f;

				for (int i = 0; i < 1; i++)
				{
					int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);
					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1.75f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
					dust.scale *= dustScale;
				}
			}
			else
				Projectile.ai[0] += 1f;

			Projectile.rotation += 0.3f * Projectile.direction;
		}

		public void Convert(int i, int j, int size = 4)
		{
			for (int k = i - size; k <= i + size; k++)
			{
				for (int l = j - size; l <= j + size; l++)
				{
					if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size))
					{
						int type = Main.tile[k, l].TileType;
						int typemed = Main.tile[k - 1, l].TileType;
						int wall = Main.tile[k, l].WallType;
						//Mod CalValEX = ModLoader.GetMod("CalamityMod");

						//Stone
						if (type == ModContent.TileType<AstralHardenedSandPlaced>())
						{
							Main.tile[k, l].TileType = TileID.HardenedSand;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralSandstonePlaced>())
						{
							Main.tile[k, l].TileType = TileID.Sandstone;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralTreeWoodPlaced>())
						{
							Main.tile[k, l].TileType = TileID.LivingWood;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralGrassPlaced>())
						{
							Main.tile[k, l].TileType = TileID.Grass;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralDirtPlaced>())
						{
							Main.tile[k, l].TileType = TileID.Dirt;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralSandPlaced>())
						{
							Main.tile[k, l].TileType = TileID.Sand;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralClayPlaced>())
						{
							Main.tile[k, l].TileType = TileID.ClayBlock;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<XenostonePlaced>())
						{
							Main.tile[k, l].TileType = TileID.Stone;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralIcePlaced>())
						{
							Main.tile[k, l].TileType = TileID.IceBlock;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralSnowPlaced>())
						{
							Main.tile[k, l].TileType = TileID.SnowBlock;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralShortGrass>())
						{
							Main.tile[k, l].TileType = TileID.Plants;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralTallGrass>())
						{
							Main.tile[k, l].TileType = TileID.Plants2;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						/*else if (type == ModContent.TileType<AstralPilesBig>())
						{
							//Left top
							Main.tile[k, l].TileType = TileID.LargePiles;
							//Middle top
							Main.tile[k - 1, l].TileType = TileID.LargePiles;
							//Right top
							Main.tile[k - 2, l].TileType = TileID.LargePiles;
							//Left bottom
							Main.tile[k, l - 1].TileType = TileID.LargePiles;
							//Middle bottom
							Main.tile[k - 1, l - 1].TileType = TileID.LargePiles;
							//Right bottom
							Main.tile[k - 2, l - 1].TileType = TileID.LargePiles;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralPilesMedium>())
						{
							Main.tile[k, l].TileType = TileID.SmallPiles;
							Main.tile[k - 1, l].TileType = TileID.SmallPiles;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralPilesSmall>())
						{
							Main.tile[k, l].TileType = TileID.SmallPiles;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == ModContent.TileType<AstralStalactites>())
						{
							Main.tile[k, l].TileType = TileID.Stalactite;
							Main.tile[k, l - 1].TileType = TileID.Stalactite;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}*/
						if (wall == ModContent.WallType<AstralDirtWallPlaced>())
						{
							Main.tile[k, l].WallType = WallID.Dirt;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<XenostoneWallPlaced>())
						{
							Main.tile[k, l].WallType = WallID.Stone;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralHardenedSandWallPlaced>())
						{
							Main.tile[k, l].WallType = WallID.HardenedSand;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralSandstoneWallPlaced>())
						{
							Main.tile[k, l].WallType = WallID.Sandstone;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralIceWallPlaced>())
						{
							Main.tile[k, l].WallType = WallID.IceUnsafe;
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == ModContent.WallType<AstralGrassWallPlaced>())
						{
							Main.tile[k, l].WallType = WallID.Grass;
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