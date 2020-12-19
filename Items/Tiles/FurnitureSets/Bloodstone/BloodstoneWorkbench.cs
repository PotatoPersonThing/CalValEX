using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
	class BloodstoneWorkbench : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileTable[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16 }; //
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			TileObjectData.addTile(Type);
            disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Bloodstone Work Bench");
			AddMapEntry(new Color(139, 0, 0), name);
			adjTiles = new int[] { TileID.WorkBenches };
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, ItemType<BloodstoneWorkbenchItem>());
		}
	}
}
