using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
	class PhantowaxBookshelf : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileTable[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 }; //
			TileObjectData.newTile.CoordinatePadding = 0;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Phantowax Bookshelf");
			AddMapEntry(new Color(94, 39, 93), name);
			adjTiles = new int[] { TileID.Bookcases };
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 24, 32, ItemType<PhantowaxBookshelfItem>());
		}
	}
}
