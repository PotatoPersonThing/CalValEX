using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles
{
	// This class shows off many things common to Lamp tiles in Terraria. The process for creating this example is detailed in: https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#examplelamp-tile
	// If you can't figure out how to recreate a vanilla tile, see that guide for instructions on how to figure it out yourself.
	internal class SunkenLampPlaced : ModTile
	{
		public override void SetDefaults() {
			// Main.tileFlame[Type] = true; This breaks it.
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 }; //
            animationFrameHeight = 54;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
			name.SetDefault("Sunken Lamp");
			AddMapEntry(new Color(91, 198, 201), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 48, ModContent.ItemType<SunkenLamp>());
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			Tile tile = Main.tile[i, j];
			if (tile.frameX == 0) {
				// We can support different light colors for different styles here: switch (tile.frameY / 54)
				r = 0.5f;
				g = 0.75f;
				b = 1f;
			}
		}

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 6) //make this number lower/bigger for faster/slower animation
            {
                frameCounter = 0;
                frame++;
                if (frame > 6)
                {
                    frame = 0;
                }
            }
        }
	}
}