using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
	class PhantowaxChandelier : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 }; //
			TileObjectData.newTile.CoordinatePadding = 0;
			TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Phantowax Chandelier");
			AddMapEntry(new Color(94, 39, 93), name);
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			Tile tile = Main.tile[i, j];
			if (tile.frameX == 0) {
				// We can support different light colors for different styles here: switch (tile.frameY / 54)
				r = 85f;
				g = 0.4f;
				b = 0.9f;
			}
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 32, ItemType<PhantowaxChandelierItem>());
		}
	}
}
