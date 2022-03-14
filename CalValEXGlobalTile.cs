using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CalValEX
{
	public class CalValEXGlobalTile : GlobalTile
    {
        /// <summary>This function lets you easily set a tile glowmask. Compatible with both blocks and furniture.</summary>
        /// <param name="i">The x coord of the tile</param>
        /// <param name="j">The y coord of the tile</param> 
        /// <param name="text">The glowmask's file path</param>
        /// <param name="sprit">Just put 'spriteBatch' here</param> 
        /// <param name="frameheight">Amount of frames the glowmask uses, typically you'll just need to put 'animationFrameHeight'</param> 
        /// <param name="type">Id the tile, needed for an animated glowmask because YuHcode doesn't know how to automate this</param>
        public static void TileGlowmask(int i, int j, Texture2D text, SpriteBatch sprit, int frameheight = 0, ushort type = 0)
        {
            var frame = new Rectangle(Main.tile[i, j].frameX, Main.tile[i, j].frameY + frameheight * Main.tileFrame[type], 16, 16);
            int xFrameOffset = Main.tile[i, j].frameX;
            int yFrameOffset = Main.tile[i, j].frameY;
            Texture2D glowmask = text;
            Vector2 drawOffest = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            Vector2 drawPosition = new Vector2(i * 16 - Main.screenPosition.X, j * 16 - Main.screenPosition.Y) + drawOffest;
            Color drawColour = Color.White;
            Tile trackTile = Main.tile[i, j];
            if (frameheight == 0)
            {
                if (!trackTile.halfBrick() && trackTile.slope() == 0)
                    sprit.Draw(glowmask, drawPosition, new Rectangle(xFrameOffset, yFrameOffset, 16, 16), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                else if (trackTile.halfBrick())
                    sprit.Draw(glowmask, drawPosition + new Vector2(0f, 8f), new Rectangle(xFrameOffset, yFrameOffset, 16, 8), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            }
            else
            {
                if (!trackTile.halfBrick() && trackTile.slope() == 0)
                    sprit.Draw(glowmask, drawPosition, frame, drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
                else if (trackTile.halfBrick())
                    sprit.Draw(glowmask, drawPosition + new Vector2(0f, 8f), frame, drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            }
        }

        public static void ChestGlowmask(int i, int j, Texture2D text, SpriteBatch sprit)
        {
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.frameX % 36 != 0)
            {
                left--;
            }
            if (tile.frameY != 0)
            {
                top--;
            }
            int chestI = Chest.FindChest(left, top);
            Chest chest = Main.chest[chestI];
            int cFrame = chest.frame;
            Texture2D glowmask = text;
            Rectangle frame = new Rectangle(tile.frameX, 38 * cFrame + tile.frameY, 16, 16);
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Vector2 pos = new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero;
            sprit.Draw(glowmask, pos, frame, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}