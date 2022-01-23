using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles;
using Microsoft.Xna.Framework.Graphics;
using CalValEX;

namespace CalValEX.Tiles.MiscFurniture
{
    public class SchematicDisplayPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            animationFrameHeight = 36;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 }; //
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Schematic Display");
            AddMapEntry(new Color(79, 80, 92), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 24, 24, ModContent.ItemType<SchematicDisplay>());
        }
        public override bool HasSmartInteract()
        {
            return true;
        }

        public override bool NewRightClick(int i, int j)
        {
            Main.PlaySound(mod.GetSoundSlot(SoundType.Custom, "Sounds/ScreenChange"), i * 16, j * 16, 0);
            HitWire(i, j);
            return true;
        }

        public override void HitWire(int i, int j)
        {
            int x = i - Main.tile[i, j].frameX / 18 % 2;
            int y = j - Main.tile[i, j].frameY / 18 % 2;
            for (int l = x; l < x + 2; l++)
            {
                for (int m = y; m < y + 2; m++)
                {
                    if (Main.tile[l, m] == null)
                    {
                        Main.tile[l, m] = new Tile();
                    }
                    if (Main.tile[l, m].active() && Main.tile[l, m].type == Type)
                    {
                        if (Main.tile[l, m].frameY <= 36 * 26 + 18)
                        {
                            Main.tile[l, m].frameY += 36;
                        }
                        else
                        {
                            if (m <= y / 2)
                                Main.tile[l, m].frameY -= 954;
                            else
                                Main.tile[l, m].frameY -= 972;

                        }
                    }

                }
            }
            if (Wiring.running)
            {
                Wiring.SkipWire(x, y);
                Wiring.SkipWire(x, y + 1);
                Wiring.SkipWire(x + 1, y);
                Wiring.SkipWire(x + 1, y + 1);
            }
            NetMessage.SendTileSquare(-1, x + 1, y + 1, 4);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CalValEXGlobalTile.TileGlowmask(i, j, ModContent.GetTexture("CalValEX/Tiles/MiscFurniture/SchematicDisplayPlaced_Glow"), spriteBatch);
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<SchematicDisplay>();
        }
    }
}