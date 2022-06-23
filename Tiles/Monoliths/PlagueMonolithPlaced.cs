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
    public class PlagueMonolithPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(75, 139, 166));
            DustType = 1;
            AnimationFrameHeight = 56;
            
            AdjTiles = new int[] { TileID.LunarMonolith };
        }

        private bool pbgon;

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<PlagueMonolith>());
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            modPlayer.pbgMonolith = false;
            pbgon = false;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            if (Main.tile[i, j].TileFrameY >= 56)
            {
                modPlayer.pbgMonolith = true;
                pbgon = true;
            }
            else
            {
                modPlayer.pbgMonolith = false;
                pbgon = false;
            }
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (pbgon)
            {
                frameCounter++;
                if (frameCounter > 6) //make this number lower/bigger for faster/slower animation
                {
                    frameCounter = 0;
                    frame++;
                    if (frame > 5)
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
            if ((modPlayer.scalMonolith && modPlayer.yharonMonolith) || (modPlayer.scalMonolith && modPlayer.dogMonolith) || (modPlayer.scalMonolith && modPlayer.provMonolith) || (modPlayer.scalMonolith && modPlayer.leviMonolith) || (modPlayer.leviMonolith && modPlayer.calMonolith) || (modPlayer.leviMonolith && modPlayer.provMonolith) || (modPlayer.leviMonolith && modPlayer.dogMonolith) || (modPlayer.leviMonolith && modPlayer.yharonMonolith) || (modPlayer.calMonolith && modPlayer.yharonMonolith) || (modPlayer.calMonolith && modPlayer.dogMonolith) || (modPlayer.calMonolith && modPlayer.provMonolith) || (modPlayer.dogMonolith && modPlayer.provMonolith) || (modPlayer.dogMonolith && modPlayer.yharonMonolith) || (modPlayer.yharonMonolith && modPlayer.provMonolith))
            {
                return false;
            }
            else
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Mech, new Vector2( i * 16, j * 16));
                HitWire(i, j);
                return true;
            }
            //If one monolith is active and its off
            /*if (CalValEXWorld.OneMonolith && !CalValEXWorld.TwoMonolith && Main.tile[i, j].TileFrameY < 56)
                {
                    CalValEXWorld.TwoMonolith = true;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Mech, new Vector2( i * 16, j * 16));
                    HitWire(i, j);
                    return true;
                }
            //If no monoliths are actives and it's off
            else if (!CalValEXWorld.OneMonolith && !CalValEXWorld.TwoMonolith && Main.tile[i, j].TileFrameY < 56)
                {
                    CalValEXWorld.OneMonolith = true;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Mech, new Vector2( i * 16, j * 16));
                    HitWire(i, j);
                    return true;
                }
            //If two monoliths are active and its on
            else if (CalValEXWorld.TwoMonolith && Main.tile[i, j].TileFrameY >= 56)
                {
                    CalValEXWorld.TwoMonolith = false;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Mech, new Vector2( i * 16, j * 16));
                    HitWire(i, j);
                    return true;
                }
            //If one monolith is active and its on
            else if (CalValEXWorld.OneMonolith && !CalValEXWorld.TwoMonolith && Main.tile[i, j].TileFrameY >= 56)
                {
                    CalValEXWorld.OneMonolith = false;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Mech, new Vector2( i * 16, j * 16));
                    HitWire(i, j);
                    return true;
                }
            else
                {
                    return false;
                }*/
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<PlagueMonolith>();
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
                        if (Main.tile[l, m].TileFrameY < 56)
                        {
                            Main.tile[l, m].TileFrameY += 56;
                        }
                        else
                        {
                            Main.tile[l, m].TileFrameY -= 56;
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