using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
	class BloodstoneSink : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 }; //
			TileObjectData.addTile(Type);
            disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Bloodstone Sink");
			AddMapEntry(new Color(139, 0, 0), name);
			adjTiles = new int[] { TileID.Sinks };
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, ItemType<BloodstoneSinkItem>());
		}
	}
}
