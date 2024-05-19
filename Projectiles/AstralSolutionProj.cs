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
	public class AstralSolutionProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Xeno Spray");
		}

		public override void SetDefaults() {
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

        public override void AI() {
			int dustType = ModContent.DustType<AstralSolutionDust>();

			if (Projectile.owner == Main.myPlayer)
				Convert((int)(Projectile.position.X + Projectile.width / 2) / 16, (int)(Projectile.position.Y + Projectile.height / 2) / 16, 2);

			if (Projectile.timeLeft > 133)
				Projectile.timeLeft = 133;

			if (Projectile.ai[0] > 7f) {
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

				for (int i = 0; i < 1; i++) {
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

		[JITWhenModsEnabled("CalamityMod")]
		public static void Convert(int i, int j, int size = 4) 
        {
			for (int k = i - size; k <= i + size; k++) {
				for (int l = j - size; l <= j + size; l++) 
                {
					if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size)) 
                    {
						int type = Main.tile[k, l].TileType;
						int typemed = Main.tile[k - 1, l].TileType;
						int wall = Main.tile[k, l].WallType;

						//Stone
						if (TileID.Sets.Conversion.Stone[type] || type == TileID.BlueMoss || type == TileID.BrownMoss || type == TileID.LavaMoss || type == TileID.GreenMoss || type == TileID.PurpleMoss || type == TileID.LongMoss || type == TileID.RedMoss) {
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<XenostonePlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Sand[type]) {
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralSandPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Grass[type] && !TileID.Sets.GrassSpecial[type]) 
                        {
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralGrassPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
                        else if (CalValEX.CalamityActive && type == CalValEX.CalamityTile("AstralDirt"))
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralDirtPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
						else if (CalValEX.CalamityActive && type == CalValEX.CalamityTile("AstralClay"))
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralClayPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
						else if (CalValEX.CalamityActive && type == CalValEX.CalamityTile("AstralMonolith"))
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralTreeWoodPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == TileID.Dirt)
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralDirtPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
						else if (type == TileID.LivingWood)
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralTreeWoodPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (type == TileID.ClayBlock)
                        {
                            Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralClayPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
						else if (type == TileID.SnowBlock)
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralSnowPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (TileID.Sets.Conversion.HardenedSand[type]) {
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralHardenedSandPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if ((type == TileID.CorruptPlants) || (type == TileID.HallowedPlants) || (type == TileID.Plants)) 
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralShortGrass>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if ((type == TileID.HallowedPlants2) || (type == TileID.Plants2)) 
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralTallGrass>();
							Main.tile[k, l - 1].TileType = (ushort)ModContent.TileType<AstralTallGrass>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (CalValEX.CalamityActive && type == CalValEX.CalamityTile("AstralSnow"))
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralSnowPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						/*else if (type == TileID.LargePiles)
						{
							//Left top
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralPilesBig>();
							//Left bottom
							Main.tile[k, l - 1].TileType = (ushort)ModContent.TileType<AstralPilesBig>();
							//Middle top
							Main.tile[k - 1, l].TileType = (ushort)ModContent.TileType<AstralPilesBig>();
							//Right top
							Main.tile[k - 2, l - 1].TileType = (ushort)ModContent.TileType<AstralPilesBig>();
							//Middle bottom
							Main.tile[k - 1, l - 1].TileType = (ushort)ModContent.TileType<AstralPilesBig>();
							//Right top
							Main.tile[k - 2, l].TileType = (ushort)ModContent.TileType<AstralPilesBig>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (type == TileID.SmallPiles && typemed == TileID.SmallPiles)
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralPilesMedium>();
							Main.tile[k - 1, l].TileType = (ushort)ModContent.TileType<AstralPilesMedium>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (type == TileID.SmallPiles && typemed != TileID.SmallPiles)
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralPilesSmall>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (type == TileID.Stalactite)
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralStalactites>();
							Main.tile[k, l - 1].TileType = (ushort)ModContent.TileType<AstralStalactites>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}*/
						else if (TileID.Sets.Conversion.Sandstone[type]) {
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralSandstonePlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Ice[type])
						{
							Main.tile[k, l].TileType = (ushort)ModContent.TileType<AstralIcePlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						if (WallID.Sets.Conversion.Sandstone[wall])
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralSandstoneWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.HardenedSand[wall])
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralHardenedSandWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.Grass[wall])
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralGrassWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.Stone[wall] || wall == WallID.RocksUnsafe1 || wall == WallID.RocksUnsafe2 || wall == WallID.RocksUnsafe3 || wall == WallID.RocksUnsafe4 || wall == WallID.CaveWall || wall == WallID.CaveWall2 || wall == WallID.CaveUnsafe || wall == WallID.Cave2Unsafe || wall == WallID.Cave3Unsafe || wall == WallID.Cave4Unsafe || wall == WallID.Cave5Unsafe || wall == WallID.Cave6Unsafe || wall == WallID.Cave7Unsafe || wall == WallID.Cave8Unsafe)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<XenostoneWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (wall == WallID.IceUnsafe)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralIceWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (CalValEX.CalamityActive && wall == CalValEX.CalamityWall("AstralDirtWall"))
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == WallID.DirtUnsafe)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == WallID.DirtUnsafe2)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == WallID.DirtUnsafe3)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == WallID.DirtUnsafe4)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == WallID.DirtUnsafe1)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						else if (wall == WallID.Cave6Unsafe)
						{
							Main.tile[k, l].WallType = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
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