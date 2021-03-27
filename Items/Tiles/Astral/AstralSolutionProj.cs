using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralSolutionProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Xeno Spray");
		}

		public override void SetDefaults() {
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

		public override void AI() {
			int dustType = ModContent.DustType<AstralSolutionDust>();

			if (projectile.owner == Main.myPlayer)
				Convert((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);

			if (projectile.timeLeft > 133)
				projectile.timeLeft = 133;

			if (projectile.ai[0] > 7f) {
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

				for (int i = 0; i < 1; i++) {
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
			for (int k = i - size; k <= i + size; k++) {
				for (int l = j - size; l <= j + size; l++) 
                {
					if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size)) 
                    {
						int type = Main.tile[k, l].type;
						int wall = Main.tile[k, l].wall;
						Mod CalValEX = ModLoader.GetMod("CalamityMod");

						//Stone
						if (TileID.Sets.Conversion.Stone[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<XenostonePlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Sand[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralSandPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Grass[type] && !TileID.Sets.GrassSpecial[type]) 
                        {
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralGrassPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
                        else if (type == ModLoader.GetMod("CalamityMod").TileType("AstralDirt"))
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<AstralDirtPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
						else if (type == ModLoader.GetMod("CalamityMod").TileType("AstralClay"))
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<AstralClayPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
                        else if (type == TileID.Dirt)
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<AstralDirtPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
						else if (type == TileID.ClayBlock)
                        {
                            Main.tile[k, l].type = (ushort)ModContent.TileType<AstralClayPlaced>();
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                            break;
                        }
                        else if (TileID.Sets.Conversion.HardenedSand[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralHardenedSandPlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if ((type == TileID.CorruptPlants) || (type == TileID.HallowedPlants) || (type == TileID.Plants)) 
						{
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralShortGrass>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if ((type == TileID.HallowedPlants2) || (type == TileID.Plants2)) 
						{
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralTallGrass>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Sandstone[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralSandstonePlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (TileID.Sets.Conversion.Ice[type])
						{
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralIcePlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.Sandstone[wall])
						{
							Main.tile[k, l].wall = (ushort)ModContent.WallType<AstralSandstoneWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.HardenedSand[wall])
						{
							Main.tile[k, l].wall = (ushort)ModContent.WallType<AstralHardenedSandWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.Grass[wall])
						{
							Main.tile[k, l].wall = (ushort)ModContent.WallType<AstralGrassWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (WallID.Sets.Conversion.Stone[wall])
						{
							Main.tile[k, l].wall = (ushort)ModContent.WallType<XenostoneWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (wall == ModLoader.GetMod("CalamityMod").WallType("AstralDirtWall"))
						{
							Main.tile[k, l].wall = (ushort)ModContent.WallType<AstralDirtWallPlaced>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
							break;
						}
						//Code for turning stuff into purity. Idk why I put this here lol
						/*else if (type == ModContent.TileType<AstralDirtPlaced>()) 
						{
							Main.tile[k, l].type = (ushort)TileID.Dirt;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						else if (type == ModContent.TileType<AstralClayPlaced>()) 
						{
							Main.tile[k, l].type = (ushort)TileID.ClayBlock;
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
                        //Ice
						else if (TileID.Sets.Conversion.Ice[type]) {
							Main.tile[k, l].type = (ushort)ModContent.TileType<AstralIcePlaced>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}*/
					}
				}
			}
		}
	}
}