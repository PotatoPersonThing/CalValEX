using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.FurnitureSets.Auric;
using Terraria.ObjectData;

namespace CalValEX.Tiles.FurnitureSets.Auric
{
    // This class shows off many things common to Lamp tiles in Terraria. The process for creating this example is detailed in: https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#examplelamp-tile
    // If you can't figure out how to recreate a vanilla tile, see that guide for instructions on how to figure it out yourself.
    public class AuricLamp : ModTile
    {
        public override void SetDefaults()
        {
            // Main.tileFlame[Type] = true; This breaks it.
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Auric Lamp");
            AddMapEntry(new Color(139, 0, 0), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, ModContent.ItemType<AuricLampItem>());
        }

        public override void HitWire(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int topY = j - tile.frameY / 18 % 3;
            short frameAdjustment = (short)(tile.frameX > 0 ? -18 : 18);
            Main.tile[i, topY].frameX += frameAdjustment;
            Main.tile[i, topY + 1].frameX += frameAdjustment;
            Main.tile[i, topY + 2].frameX += frameAdjustment;
            Wiring.SkipWire(i, topY);
            Wiring.SkipWire(i, topY + 1);
            Wiring.SkipWire(i, topY + 2);
            NetMessage.SendTileSquare(-1, i, topY + 1, 3, TileChangeType.None);
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            int xFrameOffset = Main.tile[i, j].frameX;
            int yFrameOffset = Main.tile[i, j].frameY;
            Texture2D glowmask = ModContent.GetTexture("CalValEX/Tiles/FurnitureSets/Auric/AuricLamp_Glow");
            Vector2 drawOffest = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            Vector2 drawPosition = new Vector2(i * 16 - Main.screenPosition.X, j * 16 - Main.screenPosition.Y) + drawOffest;
            Color drawColour = Color.White;
            Tile trackTile = Main.tile[i, j];
            if (!trackTile.halfBrick() && trackTile.slope() == 0)
                spriteBatch.Draw(glowmask, drawPosition, new Rectangle(xFrameOffset, yFrameOffset, 18, 18), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            else if (trackTile.halfBrick())
                spriteBatch.Draw(glowmask, drawPosition + new Vector2(0f, 8f), new Rectangle(xFrameOffset, yFrameOffset, 18, 8), drawColour, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameX == 0)
            {
                // We can support different light colors for different styles here: switch (tile.frameY / 54)
                r = 1f;
                g = 1f;
                b = 0.6f;
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            if (!Main.gamePaused && Main.instance.IsActive && (!Lighting.UpdateEveryFrame || Main.rand.NextBool(4)))
            {
                Tile tile = Main.tile[i, j];
                short frameX = tile.frameX;
                short frameY = tile.frameY;
            }
        }
    }
}