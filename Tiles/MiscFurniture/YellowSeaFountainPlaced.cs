using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles;

namespace CalValEX.Tiles.MiscFurniture
{
    public class YellowSeaFountainPlaced : ModTile {
        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Yellow Sea Fountain");
            AddMapEntry(new Color(76, 58, 59), name);
        }

        public override bool HasSmartInteract(int i, int j, Terraria.GameContent.ObjectInteractions.SmartInteractScanSettings settings) => true;

        public override bool RightClick(int i, int j) {
            HitWire(i, j);
            return true;
        }

        public override void HitWire(int i, int j) {
            #region //Running/Idle
            int x = i - Main.tile[i, j].TileFrameX / 16 % 2;
            int y = j - Main.tile[i, j].TileFrameY / 16 % 3;
            for (int l = x; l < x + 2; l++) {
                for (int m = y; m < y + 3; m++) {
                    if (Main.tile[l, m].TileFrameX < 34) {
                        Main.tile[l, m].TileFrameX += 34;
                    } else {
                        Main.tile[l, m].TileFrameX -= 34;
                    }
                }
            }
            #endregion

            #region //Wire stuff
            if (Wiring.running) {
                Wiring.SkipWire(x, y);
                Wiring.SkipWire(x, y + 1);
                Wiring.SkipWire(x + 1, y);
                Wiring.SkipWire(x + 1, y + 1);
            }
            NetMessage.SendTileSquare(-1, x + 1, y + 1, 4);
            #endregion
        }

        public override void MouseOver(int i, int j) {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<YellowSeaFountain>();
        }

        public override void AnimateTile(ref int frame, ref int frameCounter) {
            frameCounter++;
            if (frameCounter > 6) {
                frameCounter = 0;
                frame++;
                if (frame > 3) {
                    frame = 1;
                }
            }
        }
    }
}