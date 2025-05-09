using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CalValEX.Tiles.Plants
{
    public class BrimPlantPlaced : ModTile
    {
        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileSpelunker[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.ReplaceTileBreakUp[Type] = true;
            TileID.Sets.IgnoredInHouseScore[Type] = true;
            TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.AnchorValidTiles = new int[] {
                CalValEX.CalamityTile("BrimstoneSlag"),
                TileID.Ash,
            };
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            
            // name.SetDefault("Brimberry Plant");
            AddMapEntry(new Color(201, 30, 12), name);
        }
    }
}