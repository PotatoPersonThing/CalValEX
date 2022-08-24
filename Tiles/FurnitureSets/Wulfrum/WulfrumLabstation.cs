using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using CalValEX.Items.Tiles.FurnitureSets.Wulfrum;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Tiles.FurnitureSets.Wulfrum {
    public class WulfrumLabstation : ModTile {
        public override void SetStaticDefaults() {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileTable[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Wulfrum Work Bench");
            AddMapEntry(new Color(103, 137, 100), name);
            AdjTiles = new int[] { TileID.WorkBenches, TileID.Anvils };
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
            int xFrameOffset = Main.tile[i, j].TileFrameX;
            int yFrameOffset = Main.tile[i, j].TileFrameY;
            Texture2D glowmask = ModContent.Request<Texture2D>("CalValEX/Tiles/FurnitureSets/Wulfrum/WulfrumWorkbench_Glow").Value;
            Vector2 drawOffest = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            Vector2 drawPosition = new Vector2(i * 16 - Main.screenPosition.X, j * 16 - Main.screenPosition.Y) + drawOffest;
            Color drawColour = Color.White;
            Tile trackTile = Main.tile[i, j];
            if (!trackTile.IsHalfBlock && trackTile.Slope == 0)
                spriteBatch.Draw(glowmask, drawPosition, new Rectangle(xFrameOffset, yFrameOffset, 18, 18), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            else if (trackTile.IsHalfBlock)
                spriteBatch.Draw(glowmask, drawPosition + new Vector2(0f, 8f), new Rectangle(xFrameOffset, yFrameOffset, 18, 8), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ItemType<WulfrumLabstationItem>());
    }
}