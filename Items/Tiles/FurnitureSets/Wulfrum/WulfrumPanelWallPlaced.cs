using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.FurnitureSets.Wulfrum;

namespace CalValEX.Items.Tiles.FurnitureSets.Wulfrum
{
	public class WulfrumPanelWallPlaced : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = ModContent.ItemType<WulfrumPanelWall>();
			AddMapEntry(new Color(50, 92, 61));
		}
	}
}