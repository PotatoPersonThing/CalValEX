using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Tiles.MiscFurniture
{
    public class PlagueDialysisPlaced : ModTile {
        public override void SetStaticDefaults() {
            Main.tileSolidTop[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.Height = 8;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 16, 16 }; //
            TileObjectData.newTile.CoordinatePadding = 0;
            AnimationFrameHeight = 128;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Bumbletube");
            AddMapEntry(new Color(128, 188, 67), name);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) =>
            CalValEXGlobalTile.TileGlowmask(i, j, Request<Texture2D>("CalValEX/Tiles/MiscFurniture/PlagueDialysisPlaced_Glow").Value, spriteBatch, AnimationFrameHeight, Type);
    }
}