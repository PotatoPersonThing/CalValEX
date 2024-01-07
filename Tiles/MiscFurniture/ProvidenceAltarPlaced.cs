using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using System;

namespace CalValEX.Tiles.MiscFurniture
{
    public class ProvidenceAltarPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = false;
            TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 }; //
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(0, 255, 200), name);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0 && tile.TileFrameY == 0)
            {
                Texture2D auraTexture = Request<Texture2D>("CalValEX/Tiles/MiscFurniture/ProvidenceCore").Value;
                Rectangle sourceRectangle = new(0, 0, auraTexture.Width, auraTexture.Height);
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                int rem = i % 12; // add some variance
                Vector2 position = new Vector2((i * 16) + 16 - Main.screenPosition.X, (j * 16) - 48 - (float)Math.Sin(Main.GlobalTimeWrappedHourly * 2) * 8 + (float)Math.Sin(Main.GlobalTimeWrappedHourly + rem) * 2 - Main.screenPosition.Y) + zero;
                Color color = Color.White;
                Vector2 origin = new(auraTexture.Width, auraTexture.Height);

                float distance = 5;
                double deg = Main.GlobalTimeWrappedHourly * 260;
                double rad = deg * (Math.PI / 180);
                double rad3 = deg * (Math.PI / 90);
                float hyposx = position.X - (int)(Math.Cos(rad) * distance);
                float hyposy = position.Y - (int)(Math.Sin(rad) * distance);
                float hyposx2 = position.X + (int)(Math.Cos(rad) * distance);
                float hyposy2 = position.Y + (int)(Math.Sin(rad) * distance);
                float hyposx3 = position.X - (int)(Math.Cos(rad3) * distance);
                float hyposy3 = position.Y - (int)(Math.Sin(rad3) * distance);
                float hyposx4 = position.X + (int)(Math.Cos(rad3) * distance);
                float hyposy4 = position.Y + (int)(Math.Sin(rad3) * distance);
                Vector2 mirrorPos = new Vector2(hyposx, hyposy);
                Vector2 mirrorPos2 = new Vector2(hyposx2, hyposy2);
                Vector2 mirrorPos3 = new Vector2(hyposx3, hyposy3);
                Vector2 mirrorPos4 = new Vector2(hyposx4, hyposy4);


                if (!tile.IsHalfBlock)
                {
                    if ((tile.TileFrameX == 0 && tile.TileFrameY == 0))
                    {
                        spriteBatch.End();
                        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
                        spriteBatch.Draw(auraTexture, mirrorPos, sourceRectangle, Color.HotPink * 0.6f, 0f, origin / 2f, 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(auraTexture, mirrorPos2, sourceRectangle, Color.HotPink * 0.6f, 0f, origin / 2f, 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(auraTexture, mirrorPos3, sourceRectangle, Color.HotPink * 0.6f, 0f, origin / 2f, 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(auraTexture, mirrorPos4, sourceRectangle, Color.HotPink * 0.6f, 0f, origin / 2f, 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(auraTexture, position, sourceRectangle, color, 0f, origin / 2f, 1f, SpriteEffects.None, 0f);
                    }
                }
            }
        }
    }
}