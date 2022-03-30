using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles.Monoliths;

namespace CalValEX.Tiles.Monoliths
{
    public class CalamitousMonolithPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(75, 139, 166));
            DustType = 1;
            AnimationFrameHeight = 54;
            
            AdjTiles = new int[] { TileID.LunarMonolith };
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<CalamitousMonolith>());
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            modPlayer.calMonolith = false;
            modPlayer.scalMonolith = false;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            //
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            if (Main.tile[i, j].TileFrameY >= 54)
            {
                if (NPC.downedMoonlord)
                {
                    modPlayer.scalMonolith = true;
                    modPlayer.calMonolith = false;
                }
                else
                {
                    modPlayer.calMonolith = true;
                }
            }
            else
            {
                modPlayer.calMonolith = false;
                modPlayer.scalMonolith = false;
            }
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.LunarMonolith];
            frameCounter = Main.tileFrameCounter[TileID.LunarMonolith];
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            texture = ModContent.Request<Texture2D>("CalValEX/Tiles/Monoliths/CalamitousMonolithPlaced").Value;
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = 16;
            int animate = 0;
            if (tile.TileFrameY >= 54)
            {
                animate = Main.tileFrame[Type] * AnimationFrameHeight;
            }
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + animate, 16, height), Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            return false;
        }

        public override bool RightClick(int i, int j)
        {
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            //
            if ((modPlayer.dogMonolith && modPlayer.provMonolith) || (modPlayer.dogMonolith && modPlayer.yharonMonolith) || (modPlayer.dogMonolith && modPlayer.pbgMonolith) || (modPlayer.dogMonolith && modPlayer.leviMonolith) || (modPlayer.leviMonolith && modPlayer.dogMonolith) || (modPlayer.leviMonolith && modPlayer.pbgMonolith) || (modPlayer.leviMonolith && modPlayer.yharonMonolith) || (modPlayer.leviMonolith && modPlayer.provMonolith) || (modPlayer.dogMonolith && modPlayer.provMonolith) || (modPlayer.dogMonolith && modPlayer.yharonMonolith) || (modPlayer.dogMonolith && modPlayer.pbgMonolith) || (modPlayer.yharonMonolith && modPlayer.pbgMonolith) || (modPlayer.yharonMonolith && modPlayer.provMonolith) || (modPlayer.provMonolith && modPlayer.pbgMonolith))
            {
                return false;
            }
            else
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Mech, i * 16, j * 16, 0);
                HitWire(i, j);
                return true;
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<CalamitousMonolith>();
        }

        public override void HitWire(int i, int j)
        {
            int x = i - Main.tile[i, j].TileFrameX / 16 % 3;
            int y = j - Main.tile[i, j].TileFrameY / 18 % 3;
            for (int l = x; l < x + 2; l++)
            {
                for (int m = y; m < y + 3; m++)
                {
                    if (Main.tile[l, m].TileType == Type)
                    { 
                        if (Main.tile[l, m].TileFrameY < 54)
                        {
                            Main.tile[l, m].TileFrameY += 54;
                        }
                        else
                        {
                            Main.tile[l, m].TileFrameY -= 54;
                        }
                    }
                }
            }
            if (Wiring.running)
            {
                Wiring.SkipWire(x, y);
                Wiring.SkipWire(x, y + 1);
                Wiring.SkipWire(x, y + 2);
                Wiring.SkipWire(x + 1, y);
                Wiring.SkipWire(x + 1, y + 1);
                Wiring.SkipWire(x + 1, y + 2);
            }
            NetMessage.SendTileSquare(-1, x, y + 1, 3);
        }
    }
}