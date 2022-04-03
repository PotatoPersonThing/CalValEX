using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static CalValEX.CalValEXWorld;
using CalValEX.Items.Tiles.Monoliths;

namespace CalValEX.Tiles.Monoliths
{
    public class InfernalMonolithPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(75, 139, 166));
            DustType = 1;
            AnimationFrameHeight = 54;
            
            AdjTiles = new int[] { TileID.LunarMonolith };
        }

        private bool yharonon;
        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<InfernalMonolith>());
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            modPlayer.yharonMonolith = false;
            yharonon = false;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            //
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            if (Main.tile[i, j].TileFrameY >= 54)
            {
                modPlayer.yharonMonolith = true;
                yharonon = true;
            }
            else
            {
                modPlayer.yharonMonolith = false;
                yharonon = false;
            }
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (yharonon)
            {
                frameCounter++;
                if (frameCounter > 6) //make this number lower/bigger for faster/slower animation
                {
                    frameCounter = 0;
                    frame++;
                    if (frame > 3)
                    {
                        frame = 1;
                    }
                }
            }
            else
            {
                frameCounter++;
                if (frameCounter > 1) //make this number lower/bigger for faster/slower animation
                {
                    frameCounter = 0;
                    frame++;
                    if (frame > 0)
                    {
                        frame = 0;
                    }
                }
            }
        }

        public override bool RightClick(int i, int j)
        {
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            //
            if ((modPlayer.scalMonolith && modPlayer.provMonolith) || (modPlayer.scalMonolith && modPlayer.dogMonolith) || (modPlayer.scalMonolith && modPlayer.pbgMonolith) || (modPlayer.scalMonolith && modPlayer.leviMonolith) || (modPlayer.leviMonolith && modPlayer.calMonolith) || (modPlayer.leviMonolith && modPlayer.pbgMonolith) || (modPlayer.leviMonolith && modPlayer.dogMonolith) || (modPlayer.leviMonolith && modPlayer.provMonolith) || (modPlayer.calMonolith && modPlayer.provMonolith) || (modPlayer.calMonolith && modPlayer.dogMonolith) || (modPlayer.calMonolith && modPlayer.pbgMonolith) || (modPlayer.dogMonolith && modPlayer.pbgMonolith) || (modPlayer.dogMonolith && modPlayer.provMonolith) || (modPlayer.provMonolith && modPlayer.pbgMonolith))
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
            player.cursorItemIconID = ModContent.ItemType<InfernalMonolith>();
        }

        public override void HitWire(int i, int j)
        {
            int x = i - Main.tile[i, j].TileFrameX / 18 % 2;
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