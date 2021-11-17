using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;

namespace CalValEX.Tiles.MiscFurniture
{
    internal class RespirationShrinePlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileLavaDeath[Type] = false;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = false;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 }; //
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            animationFrameHeight = 72;
            name.SetDefault("Respiration Shrine");
            AddMapEntry(new Color(0, 255, 200), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 24, 16, ItemType<RespirationShrine>());
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.LocalPlayer;
            if (closer && !NPC.AnyNPCs(ModLoader.GetMod("CalamityMod").NPCType("EidolonWyrmHeadHuge")))
            {
                if (Main.tile[i, j].frameY < 72)
                {
                    player.breath = 1360;
                    //Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("AmidiasBlessing"), 20);
                }
            }
            else
            {
                if (player.breath >= 1360)
                {
                    player.breath = -1;
                }
            }
        }


        public override bool HasSmartInteract()
        {
            return true;
        }

        public override bool NewRightClick(int i, int j)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/RespirationShrineSound"));
            HitWire(i, j);
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ItemType<RespirationShrine>();
        }

        public override void HitWire(int i, int j)
        {
            int x = i - Main.tile[i, j].frameX / 18 % 3;
            int y = j - Main.tile[i, j].frameY / 18 % 4;
            for (int l = x; l < x + 3; l++)
            {
                for (int m = y; m < y + 4; m++)
                {
                    if (Main.tile[l, m] == null)
                    {
                        Main.tile[l, m] = new Tile();
                    }
                    if (Main.tile[l, m].active() && Main.tile[l, m].type == Type)
                    {
                        if (Main.tile[l, m].frameY < 72)
                        {
                            Main.tile[l, m].frameY += 72;
                        }
                        else
                        {
                            Main.tile[l, m].frameY -= 72;
                        }
                    }
                }
            }
            if (Wiring.running)
            {
                Wiring.SkipWire(x, y);
                Wiring.SkipWire(x, y + 1);
                Wiring.SkipWire(x, y + 2);
                Wiring.SkipWire(x, y + 3);
                Wiring.SkipWire(x + 1, y);
                Wiring.SkipWire(x + 1, y + 1);
                Wiring.SkipWire(x + 1, y + 2);
                Wiring.SkipWire(x + 1, y + 3);
                Wiring.SkipWire(x + 2, y);
                Wiring.SkipWire(x + 2, y + 1);
                Wiring.SkipWire(x + 2, y + 2);
                Wiring.SkipWire(x + 2, y + 3);
            }
            NetMessage.SendTileSquare(-1, x, y + 1, 3);
        }
        private int count;
        private int rotation;
        private float stonepos;
        private bool stoneup;
        public override void PlaceInWorld(int i, int j, Item item)
        {
            stonepos = -8.00001f;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX == 0 && tile.frameY == 0)
            {
                rotation += 10;
                if (stoneup)
                {
                    stonepos = stonepos + 0.07f;
                }
                else
                {
                    stonepos = stonepos + -0.07f;
                }
                if (stonepos <= -8)
                {
                    stoneup = true;
                }
                else if (stonepos >= 8)
                {
                    stoneup = false;
                }
                Texture2D auraTexture = mod.GetTexture("Tiles/MiscFurniture/RespirationStar");
                Rectangle sourceRectangle = new Rectangle(0, 0, auraTexture.Width, auraTexture.Height);
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                Vector2 position = new Vector2((i * 16) + 24 - Main.screenPosition.X, (j * 16) - 4 - stonepos - Main.screenPosition.Y) + zero;
                Color color = Color.White;
                Vector2 origin = new Vector2(auraTexture.Width, auraTexture.Height);

                if (!tile.halfBrick() && tile.slope() == 0)
                {
                    if (Main.tile[i, j].frameY < 72)
                    {
                        if ((tile.frameX == 0 && tile.frameY == 0))
                        {
                            spriteBatch.End();
                            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
                            spriteBatch.Draw(auraTexture, position, sourceRectangle, color, rotation * 0.01f, origin / 2f, 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
        }
    }
}