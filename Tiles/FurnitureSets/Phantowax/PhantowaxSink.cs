using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.FurnitureSets.Phantowax;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Tiles.FurnitureSets.Phantowax
{
    public class PhantowaxSink : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 }; //
            TileObjectData.newTile.CoordinatePadding = 0;
            TileObjectData.addTile(Type);
            
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Phantowax Sink");
            AddMapEntry(new Color(94, 39, 93), name);
            AdjTiles = new int[] { TileID.Sinks };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ItemType<PhantowaxSinkItem>());
        }
    }
}