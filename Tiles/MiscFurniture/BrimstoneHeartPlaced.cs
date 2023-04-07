using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using CalValEX.Items.Tiles;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CalValEX.Tiles.MiscFurniture
{
    // This class shows off many things common to Lamp tiles in Terraria. The process for creating this example is detailed in: https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#examplelamp-tile
    // If you can't figure out how to recreate a vanilla tile, see that guide for instructions on how to figure it out yourself.
    public class BrimstoneHeartPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Main.tileFlame[Type] = true; This breaks it.
            Main.tileLighted[Type] = true;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 }; //
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Hanging Heart");
            AddMapEntry(new Color(139, 0, 0), name);
        }

        public override void HitWire(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int topY = j - tile.TileFrameY / 16 % 2;
            int topX = i - tile.TileFrameX / 16 % 2;
            short frameAdjustment = (short)(tile.TileFrameX > 0 ? -16 : 16);
            Main.tile[i, topY].TileFrameX += frameAdjustment;
            Main.tile[i, topY + 1].TileFrameX += frameAdjustment;
            Main.tile[i, topY + 2].TileFrameX += frameAdjustment;
            Wiring.SkipWire(topX, topY);
            Wiring.SkipWire(topX, topY + 1);
            Wiring.SkipWire(topX, topY + 2);
            Wiring.SkipWire(topX + 1, topY);
            Wiring.SkipWire(topX + 1, topY + 1);
            Wiring.SkipWire(topX + 1, topY + 2);
            NetMessage.SendTileSquare(-1, i, topY + 1, 2, TileChangeType.None);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                // We can support different light colors for different styles here: switch (tile.TileFrameY / 54)
                r = 1.5f;
                g = 0.75f;
                b = 0.6f;
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Terraria.DataStructures.TileDrawInfo drawData)
        {
            if (!Main.gamePaused && Main.instance.IsActive && (!Lighting.UpdateEveryFrame || Main.rand.NextBool(4)))
            {
                Tile tile = Main.tile[i, j];
                short TileFrameX = tile.TileFrameX;
                short TileFrameY = tile.TileFrameY;
            }
        }
    }
}
