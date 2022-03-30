using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using CalValEX.Items.Tiles.FurnitureSets.Phantowax;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Tiles.FurnitureSets.Phantowax
{
    public class PhantowaxTable : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileTable[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 }; //
            TileObjectData.newTile.CoordinatePadding = 0;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Phantowax Table");
            AddMapEntry(new Color(94, 39, 93), name);
            AdjTiles = new int[] { TileID.Tables };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ItemType<PhantowaxTableItem>());
        }
    }
}