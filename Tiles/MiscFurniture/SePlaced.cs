using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace CalValEX.Tiles.MiscFurniture
{
    internal class SePlaced : ModTile
    {
        int rotationbottom;
        int negavar;
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 }; //
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.addTile(Type);
        }

        private bool shittypostimer = true;
        private bool shittynegatimer = false;
        public override void PlaceInWorld(int i, int j, Item item)
        {
            rotationbottom = -35;
        }

        /*public override void RandomUpdate(int i, int j)
        {
            if (rotationbottom <= -30f)
            {
                rotationbottom++;
            }
            if (rotationbottom >= 30f)
            {
                rotationbottom--;
            }
        }*/

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 64, ItemType<Se>());
        }

        float count;
        float abso;
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX == 0 && tile.frameY == 0)
            {
                Player player = Main.LocalPlayer;
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

                /*if (modPlayer.rockhat)
                {
                    if (rotationbottom == -30f)
                    {
                        Main.NewText("Absolute negative", Color.Orange.R, Color.Orange.G, Color.Orange.B);
                    }
                    if (rotationbottom == 30f)
                    {
                        Main.NewText("Absolute positive", Color.Orange.R, Color.Orange.G, Color.Orange.B);
                    }
                }

                if (modPlayer.prismshell)
                {
                    if (rotationbottom == 0)
                    {
                        Main.NewText("Center", Color.Orange.R, Color.Orange.G, Color.Orange.B);
                    }
                }

                if (modPlayer.conejo)
                {
                    rotationbottom = -30;
                }
                else if (modPlayer.aesthetic)
                {
                    rotationbottom = 30;
                }
                else if (modPlayer.classicTrans)
                {
                    rotationbottom = 0;
                }*/

                if (rotationbottom <= -30f)
                {
                    shittypostimer = true;
                    shittynegatimer = false;
                }
                else if (rotationbottom >= 30f)
                {
                    shittypostimer = false;
                    shittynegatimer = true;
                }

                if (shittypostimer)
                {
                    rotationbottom += 7;
                }

                if (shittynegatimer)
                {
                    rotationbottom -= 7;
                }

                //X offsets
                //If rotationcounter = 30, x2 will = 6
                //If rotationcounter = -30, x2 will = -6
                //If rotationcounter = 0, y2 will = 0;
                //This means left rotations will make it move left, and right rotations will make it move right.

                float x1 = 28;
                float x2 = rotationbottom / 5 + x1;
                float x3 = rotationbottom / 3.75f + x1;
                float x4 = rotationbottom / 3 + x1;
                float x5 = rotationbottom / 2.5f + x1;
                float x6 = rotationbottom / 2.14f + x1;
                float x7 = rotationbottom / 1.875f + x1;
                float xl = rotationbottom / 2.14f + x1;
                float xr = rotationbottom / 2.14f + x1;

                //If rotation counter = 30, navgar will be negative
                //If rotation counter = - 30, navgar will be positive
                //If rotation conuter = 0, navgar will be negative because lol 0

                if (rotationbottom < 0)
                {
                    negavar = 1;
                }
                else
                {
                    negavar = -1;
                }
                //Y offsets. 
                //If rotationcounter = 30, y2 will = 3
                //If rotationcounter = -30, y2 will = 3
                //If rotationcounter = 0, y2 will = 0
                //This means that any rotation will cause the segments to go downwards, while going towards 0 makes it go up, giving a ^ effect to the motion

                float y1 = 4;
                float y2 = rotationbottom / 10 * negavar + y1;
                float y3 = rotationbottom / 5 * negavar + y1;
                float y4 = rotationbottom / 3.75f * negavar + y1;
                float y5 = rotationbottom / 3 * negavar + y1;
                float y6 = rotationbottom / 2.5f * negavar + y1;
                float y7 = rotationbottom / 2.14f * negavar + y1;
                float yl = rotationbottom / 2.5f * negavar + y1;
                float yr = rotationbottom / 2.5f * negavar + y1;

                //Sproots

                Texture2D Seg1 = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherBottomOrb");
                Texture2D Seg2 = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherBottomSegment");
                Texture2D Seg3 = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherLowerSegment");
                Texture2D Seg4 = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherMiddleOrb");
                Texture2D Seg5 = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherMiddleSegment");
                Texture2D Seg6 = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherTopOrb");
                Texture2D Seg7 = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherHead");
                Texture2D ArmL = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherLeftArm");
                Texture2D ArmR = mod.GetTexture("ExtraTextures/Sepulcher/SepulcherRightArm");

                //Base positions

                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                Vector2 position = new Vector2((i * 16) - 7 - Main.screenPosition.X, (j * 16) - 18 - Main.screenPosition.Y) + zero;

                //Defining the sizes and stuff

                Rectangle sourceRectangle1 = new Rectangle(0, 0, Seg1.Width, Seg1.Height);
                Vector2 origin1 = new Vector2(Seg1.Width, Seg1.Height);

                Rectangle sourceRectangle2 = new Rectangle(0, 0, Seg2.Width, Seg2.Height);
                Vector2 origin2 = new Vector2(Seg2.Width, Seg2.Height);

                Rectangle sourceRectangle3 = new Rectangle(0, 0, Seg3.Width, Seg3.Height);
                Vector2 origin3 = new Vector2(Seg1.Width, Seg3.Height);

                Rectangle sourceRectangle4 = new Rectangle(0, 0, Seg4.Width, Seg4.Height);
                Vector2 origin4 = new Vector2(Seg1.Width, Seg4.Height);

                Rectangle sourceRectangle7 = new Rectangle(0, 0, Seg7.Width, Seg7.Height);
                Vector2 origin7 = new Vector2(Seg7.Width, Seg7.Height);

                Rectangle sourceRectangle5 = new Rectangle(0, 0, Seg5.Width, Seg5.Height);
                Vector2 origin5 = new Vector2(Seg5.Width, Seg5.Height);

                Rectangle sourceRectangle6 = new Rectangle(0, 0, Seg6.Width, Seg6.Height);
                Vector2 origin6 = new Vector2(Seg6.Width, Seg6.Height);

                Rectangle sourceRectanglel = new Rectangle(0, 0, ArmL.Width, ArmL.Height);
                Vector2 originl = new Vector2(ArmL.Width, ArmL.Height);

                Rectangle sourceRectangler = new Rectangle(0, 0, ArmR.Width, ArmR.Height);
                Vector2 originr = new Vector2(ArmR.Width, ArmR.Height);

                //Just the color and tile pos

                Color color = Color.White;

                //Positions. X positions are simply the main position with the dynamic x offset added
                //Y positions add all previous segment heights + a few extra sometimes because lol offsets.
                //Arms get larger x offsets due to arms

                Vector2 position1 = new Vector2(position.X + x1, position.Y + 6 + y1);
                Vector2 position2 = new Vector2(position.X + x2, position.Y - Seg1.Height + y2);
                Vector2 position3 = new Vector2(position.X - 10 + x3, position.Y - Seg1.Height - Seg2.Height + y3);
                Vector2 position4 = new Vector2(position.X + x4, position.Y - Seg1.Height - Seg2.Height - Seg3.Height + 6 + y4);
                Vector2 position5 = new Vector2(position.X + x5, position.Y - Seg1.Height - Seg2.Height - Seg3.Height - Seg4.Height + 6 + y5);
                Vector2 position6 = new Vector2(position.X + x6, position.Y - Seg1.Height - Seg2.Height - Seg3.Height - Seg4.Height - Seg5.Height + 9 + y6);
                Vector2 position7 = new Vector2(position.X + x7, position.Y - Seg1.Height - Seg2.Height - Seg3.Height - Seg4.Height - Seg5.Height - Seg6.Height + 8 + y7);
                Vector2 leftposition = new Vector2(position.X + xl - 25, position.Y - Seg1.Height - Seg2.Height - Seg3.Height - Seg4.Height - Seg5.Height + yl);
                Vector2 rightposition = new Vector2(position.X + xr + 25, position.Y - Seg1.Height - Seg2.Height - Seg3.Height - Seg4.Height - Seg5.Height + yr);

                //Prevent dividing by 0 errors. If rotation counter is not zero, then absolute value is 30 / 30 or - 30 / 30

                if (Math.Abs(rotationbottom) != 0)
                {
                    abso = (rotationbottom / Math.Abs(rotationbottom));
                }
                else
                {
                    abso = 0.0001f;
                }

                //Rotation of the segment is equal to the rotation counter with an added offset multiplied by negative of the direction. 
                //Segment 2 for example would have 30 rotation at value 30 once we readd the offsets.
                float rotationbottom1 = (rotationbottom) * 0.01f;
                float rotationbottom2 = (rotationbottom) * 0.01f;
                float rotationbottom3 = (rotationbottom) * 0.01f;
                float rotationbottom4 = (rotationbottom) * 0.01f;
                float rotationbottom5 = (rotationbottom) * 0.01f;
                float rotationbottom6 = (rotationbottom) * 0.01f;
                float rotationbottom7 = (rotationbottom) * 0.01f;
                float rotationbottoml = (rotationbottom) * 0.01f;
                float rotationbottomr = (rotationbottom) * 0.01f;


                if (!tile.halfBrick() && tile.slope() == 0)
                {
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
                    spriteBatch.Draw(Seg1, position1, sourceRectangle1, color, rotationbottom1, origin1 / 2f, 1f, SpriteEffects.None, 0f);

                    spriteBatch.Draw(Seg2, position2, sourceRectangle2, color, rotationbottom2, origin2 / 2f, 1f, SpriteEffects.None, 0f);

                    spriteBatch.Draw(Seg3, position3, sourceRectangle3, color, rotationbottom3, origin3 / 2f, 1f, SpriteEffects.None, 0f);

                    spriteBatch.Draw(Seg4, position4, sourceRectangle4, color, rotationbottom4, origin4 / 2f, 1f, SpriteEffects.None, 0f);

                    spriteBatch.Draw(Seg5, position5, sourceRectangle5, color, rotationbottom5, origin5 / 2f, 1f, SpriteEffects.None, 0f);

                    spriteBatch.Draw(Seg6, position6, sourceRectangle6, color, rotationbottom6, origin6 / 2f, 1f, SpriteEffects.None, 0f);

                    spriteBatch.Draw(Seg7, position7, sourceRectangle7, color, rotationbottom7, origin7 / 2f, 1f, SpriteEffects.None, 0);

                    spriteBatch.Draw(ArmL, leftposition, sourceRectanglel, color, rotationbottoml, originl / 2f, 1f, SpriteEffects.None, 0f);

                    spriteBatch.Draw(ArmR, rightposition, sourceRectangler, color, rotationbottomr, originr / 2f, 1f, SpriteEffects.None, 0f);
                }
            }
        }
    }
}