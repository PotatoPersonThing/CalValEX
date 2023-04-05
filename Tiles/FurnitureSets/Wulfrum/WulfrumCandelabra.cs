using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
//using CalValEX.Items.Tiles.FurnitureSets.Wulfrum;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Tiles.FurnitureSets.Wulfrum {
    public class WulfrumCandelabra : ModTile {
        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Wulfrum Candelabra");
            AddMapEntry(new Color(103, 137, 100), name);

            DustType = 226;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
            int xFrameOffset = Main.tile[i, j].TileFrameX;
            int yFrameOffset = Main.tile[i, j].TileFrameY;
            Texture2D glowmask = ModContent.Request<Texture2D>("CalValEX/Tiles/FurnitureSets/Wulfrum/WulfrumCandelabra_Glow").Value;
            Vector2 drawOffest = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            Vector2 drawPosition = new Vector2(i * 16 - Main.screenPosition.X, j * 16 - Main.screenPosition.Y) + drawOffest;
            Color drawColour = Color.White;
            Tile trackTile = Main.tile[i, j];
            if (!trackTile.IsHalfBlock && trackTile.Slope == 0)
                spriteBatch.Draw(glowmask, drawPosition, new Rectangle(xFrameOffset, yFrameOffset, 18, 18), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            else if (trackTile.IsHalfBlock)
                spriteBatch.Draw(glowmask, drawPosition + new Vector2(0f, 8f), new Rectangle(xFrameOffset, yFrameOffset, 18, 8), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }

        public override void HitWire(int i, int j) {
            Tile tile = Main.tile[i, j];
            short frameAdjustmentX = (short)(tile.TileFrameX > 0 ? -18 : 18);

            Main.tile[i, j].TileFrameX += frameAdjustmentX;
            Wiring.SkipWire(i, j);

            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0) {
                r = 0.43f;
                g = 0.95f;
                b = 0.95f;
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Terraria.DataStructures.TileDrawInfo drawData) {
            if (Main.gamePaused || !Main.instance.IsActive || Lighting.UpdateEveryFrame && !Main.rand.NextBool(4))
                return;

            Tile tile = Main.tile[i, j];
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            if (frameX != 0 || !Main.rand.NextBool(40))
                return;
        }

        //public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            //Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ItemType<WulfrumCandelabraItem>());
    }
}