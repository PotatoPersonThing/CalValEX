using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Dusts;
using CalValEX.Projectiles;
using Terraria.DataStructures;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralSandPlaced : ModTile
	{
		[JITWhenModsEnabled("CalamityMod")]
		public override void SetStaticDefaults() 
        {
			Main.tileSolid[Type] = true;
			Main.tileBrick[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileSand[Type] = true;
			TileID.Sets.Suffocate[Type] = true;
			DustType = ModContent.DustType<AstralDust>();
			TileID.Sets.Conversion.Sand[Type] = true;
			TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
			TileID.Sets.Falling[Type] = true;
			AddMapEntry(new Color(104, 127, 164));
			//ItemDrop = ModContent.ItemType<AstralSand>();
			TileID.Sets.CanBeDugByShovel[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralHardenedSandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralSandstonePlaced>()] = true;
        }
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            if (j < Main.maxTilesY)
            {
                // tile[i, j+1] can still be null if it's on the edge of a chunk
                if (!Main.tile[i, j + 1].HasTile)
                {
                    Main.tile[i, j].Get<TileWallWireStateData>().HasTile = false;
                    Projectile.NewProjectile(new EntitySource_TileBreak(i, j), new Vector2(i * 16f + 8f, j * 16f + 8f), new Vector2(0, 9f), ModContent.ProjectileType<AstralSandBall>(), 15, 0f);
                    WorldGen.SquareTileFrame(i, j);
                    return false;
                }
            }
            return true;
        }

        /*public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
		}*/
	}
}