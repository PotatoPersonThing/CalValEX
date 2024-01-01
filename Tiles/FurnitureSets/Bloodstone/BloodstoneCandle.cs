using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CalValEX.Tiles.FurnitureSets.Bloodstone
{
    public class BloodstoneCandle : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Main.tileFlame[Type] = true; This breaks it.
            Main.tileLighted[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Bloodstone Candle");
            AddMapEntry(new Color(139, 0, 0), name);
            //ItemDrop = ModContent.ItemType<BloodstoneCandleItem>();
        }

        public override void HitWire(int i, int j) {
            Tile tile = Main.tile[i, j];
            short frameAdjustment = (short)(tile.TileFrameX > 0 ? -18 : 18);

            Main.tile[i, j].TileFrameX += frameAdjustment;
            Wiring.SkipWire(i, j);

            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
        }

        public override bool RightClick(int i, int j)
        {
            WorldGen.KillTile(i, j);
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
            }
            return true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                // We can support different light colors for different styles here: switch (tile.TileFrameY / 54)
                r = 1f;
                g = 0.75f;
                b = 0.6f;
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Terraria.DataStructures.TileDrawInfo drawData)
        {
            if (!Main.gamePaused && Main.instance.IsActive && (!Lighting.UpdateEveryFrame || Main.rand.NextBool(4)))
            {
                Tile tile = Main.tile[i, j];
                short frameX = tile.TileFrameX;
                short frameY = tile.TileFrameY;
            }
        }
    }
}