using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles.FurnitureSets.Astral;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Tiles.FurnitureSets.Astral
{
    public class OldAstralWorkbench : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileTable[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 }; //
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            TileObjectData.addTile(Type);
            
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Xenomonolith Work Bench");
            AddMapEntry(new Color(139, 0, 0), name);
            AdjTiles = new int[] { TileID.WorkBenches };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ItemType<OldAstralWorkbenchItem>());
        }
    }
}