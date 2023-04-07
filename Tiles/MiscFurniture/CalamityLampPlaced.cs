using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles;
using Terraria.ObjectData;

namespace CalValEX.Tiles.MiscFurniture {
	public class CalamityLampPlaced : ModTile {
		public override void SetStaticDefaults() {
			Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.addTile(Type);
			AnimationFrameHeight = 54;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Calamity Torch");
			AddMapEntry(new Color(136, 23, 88), name);
		}

		public override void AnimateTile(ref int frame, ref int frameCounter) {
			frameCounter++;
			if (frameCounter > 6) {
				frameCounter = 0;
				frame++;
				if (frame > 3) {
					frame = 1;
				}
			}
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX == 0) {
				r = .94f;
				g = .1f;
				b = .1f;
			}
		}
	}
}