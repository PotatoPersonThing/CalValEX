using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using System;
using CalValEX.Tiles.AstralBlocks;
using CalValEX.Walls.AstralUnsafe;
using CalValEX.Tiles.AstralMisc;
using CalValEX.Walls.AstralSafe;
using CalValEX.Dusts;

namespace CalValEX
{
    public class CalValEXGlobalProjectile : GlobalProjectile
    {
        /*public override bool PreDraw(Projectile projectile, SpriteBatch spriteBatch, Color drawColor)
        {
            if (CalValEXWorld.RockshrinEX)
            {
                //DEUS HEAD
                if (projectile.type == ModLoader.GetMod("CalamityMod").ProjectileType("BrimstoneMonster"))
                {
                    Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/Projectiles/BrimstoneMonster"));

                    float deusheadframe = 1f / (float)Main.npcFrameCount[projectile.type];
                    int deusheadheight = (int)((float)(1 / projectile.height) * deusheadframe) * (deusheadsprite.Height / 1);

                    Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 1);
                    Color deusheadalpha = projectile.GetAlpha(drawColor);
                    spriteBatch.Draw(deusheadsprite, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), deusheadsquare, deusheadalpha, projectile.rotation, Utils.Size(deusheadsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
                    return false;
                }
            }
            return true;
        }*/

        public override void AI(Projectile proj)
        {
            if (proj.owner == Main.myPlayer && proj.type == Terraria.ID.ProjectileID.PureSpray)
                PureConvert((int)(proj.position.X + proj.width / 2) / 16, (int)(proj.position.Y + proj.height / 2) / 16, 2);

        }

		public void PureConvert(int i, int j, int size = 4)
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


		public override bool? CanHitNPC(Projectile projectile, NPC target)
        {
            if (projectile.type == Terraria.ID.ProjectileID.VortexBeaterRocket && target.type == ModContent.NPCType< AprilFools.Jharim.Jharim >())
            {
                return true;
            }
            else
            {
                return null;
            }
        }
    }
}
