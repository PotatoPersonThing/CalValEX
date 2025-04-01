using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX
{
    public class CalValEXGlobalTile : GlobalTile
    {
        private int cragCount;
        private int berryCount;

        /// <summary>This function lets you easily set a tile glowmask. Compatible with both blocks and furniture.</summary>
        /// <param name="i">The x coord of the tile</param>
        /// <param name="j">The y coord of the tile</param> 
        /// <param name="text">The glowmask's file path</param>
        /// <param name="sprit">Just put 'spriteBatch' here</param> 
        /// <param name="frameheight">Amount of frames the glowmask uses, typically you'll just need to put 'animationFrameHeight'</param>
        public static void TileGlowmask(int i, int j, Texture2D text, SpriteBatch sprit, int frameheight = 0)
        {
            var frame = new Rectangle(Main.tile[i, j].TileFrameX, Main.tile[i, j].TileFrameY + frameheight * Main.tileFrame[Main.tile[i, j].TileType], 16, 16);
            int xFrameOffset = Main.tile[i, j].TileFrameX;
            int yFrameOffset = Main.tile[i, j].TileFrameY;
            Texture2D glowmask = text;
            Vector2 drawOffest = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            Vector2 drawPosition = new Vector2(i * 16 - Main.screenPosition.X, j * 16 - Main.screenPosition.Y) + drawOffest;
            Color drawColour = GetDrawColour(i, j, Color.White);
            Tile trackTile = Main.tile[i, j];
            if (frameheight == 0)
            {
                if (!trackTile.IsHalfBlock && trackTile.Slope == 0)
                    sprit.Draw(glowmask, drawPosition, new Rectangle(xFrameOffset, yFrameOffset, 16, 16), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                else if (trackTile.IsHalfBlock)
                    sprit.Draw(glowmask, drawPosition + new Vector2(0f, 8f), new Rectangle(xFrameOffset, yFrameOffset, 16, 8), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            }
            else
            {
                if (!trackTile.IsHalfBlock && trackTile.Slope == 0)
                    sprit.Draw(glowmask, drawPosition, frame, drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                else if (trackTile.IsHalfBlock)
                    sprit.Draw(glowmask, drawPosition + new Vector2(0f, 8f), frame, drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            }
        }

        public static Color GetDrawColour(int i, int j, Color colour)
        {
            int colType = Main.tile[i, j].TileColor;
            Color paintCol = WorldGen.paintColor(colType);
            if (colType >= 13 && colType <= 24)
            {
                colour.R = (byte)(paintCol.R / 255f * colour.R);
                colour.G = (byte)(paintCol.G / 255f * colour.G);
                colour.B = (byte)(paintCol.B / 255f * colour.B);
            }
            return colour;
        }

        public static void ChestGlowmask(int i, int j, Texture2D text, SpriteBatch sprit)
        {
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }
            if (tile.TileFrameY != 0)
            {
                top--;
            }
            int chestI = Chest.FindChest(left, top);
            Chest chest = Main.chest[chestI];
            int cFrame = chest.frame;
            Texture2D glowmask = text;
            Rectangle frame = new(tile.TileFrameX, 38 * cFrame + tile.TileFrameY, 16, 16);
            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Vector2 pos = new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero;
            sprit.Draw(glowmask, pos, frame, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        /*public override void RandomUpdate(int i, int j, int type) {
            Tile tile = Framing.GetTileSafely(i, j);

            // Several tile checks (is it ash, is it unactuated) and other checks to prevent it from spawning too many plants
            if ((tile.TileType == TileID.Ash || tile.TileType == TileType<CalamityMod.Tiles.Crags.BrimstoneSlag>()) && tile.HasUnactuatedTile) {
                cragCount = 0;
                berryCount = 0;

                int r = 80; //bc magic numbers are cring
                int xRadStart = i - r;
                int xRadEnd = xRadStart + (r * 2);
                int yRadStart = j - r;
                int yRadEnd = yRadStart + (r * 2);

                for (int x = xRadStart; x < xRadEnd && x < Main.maxTilesX; x++) {
                    for (int y = yRadStart; y < yRadEnd && y < Main.maxTilesY; y++) {
                        Tile tileCount = Framing.GetTileSafely(x, y);

                        if (tileCount.TileType == TileType<CalamityMod.Tiles.Crags.BrimstoneSlag>())
                            cragCount++;

                        if (tileCount.TileType == TileType<BrimPlantPlaced>())
                            berryCount++;
                    }
                }

                if (cragCount > 30 && berryCount <= 6 && Main.rand.NextBool(48)) {
                    // Check if the tile above is empty, not hammered and not a slope, then place the brimberry plant!!
                    if (Main.tile[i, j - 1].TileType == 0 && Main.tile[i, j].Slope == 0 && !Main.tile[i, j].IsHalfBlock)
                        WorldGen.PlaceObject(i, j - 1, TileType<BrimPlantPlaced>(), false);
                }
            }
        }*/
    }
}