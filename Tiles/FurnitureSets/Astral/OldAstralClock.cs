using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles.FurnitureSets.Astral;

namespace CalValEX.Tiles.FurnitureSets.Astral
{
    public class OldAstralClock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
			Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
			TileID.Sets.Clock[Type] = true;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(139, 0, 0), name);
            AdjTiles = new int[] { TileID.GrandfatherClocks };
        }

		public override bool RightClick(int x, int y)
		{
			string text = "AM";
			// Get current weird time
			double time = Main.time;
			if (!Main.dayTime)
			{
				// if it's night add this number
				time += 54000.0;
			}

			// Divide by seconds in a day * 24
			time = (time / 86400.0) * 24.0;
			// Dunno why we're taking 19.5. Something about hour formatting
			time = time - 7.5 - 12.0;
			// Format in readable time
			if (time < 0.0)
			{
				time += 24.0;
			}

			if (time >= 12.0)
			{
				text = "PM";
			}

			int intTime = (int)time;
			// Get the decimal points of time.
			double deltaTime = time - intTime;
			// multiply them by 60. Minutes, probably
			deltaTime = (int)(deltaTime * 60.0);
			// This could easily be replaced by deltaTime.ToString()
			string text2 = string.Concat(deltaTime);
			if (deltaTime < 10.0)
			{
				// if deltaTime is eg "1" (which would cause time to display as HH:M instead of HH:MM)
				text2 = "0" + text2;
			}

			if (intTime > 12)
			{
				// This is for AM/PM time rather than 24hour time
				intTime -= 12;
			}

			if (intTime == 0)
			{
				// 0AM = 12AM
				intTime = 12;
			}

			// Whack it all together to get a HH:MM format
			Main.NewText($"Time: {intTime}:{text2} {text}", 255, 240, 20);
			return true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<OldAstralClockItem>());
        }
    }
}