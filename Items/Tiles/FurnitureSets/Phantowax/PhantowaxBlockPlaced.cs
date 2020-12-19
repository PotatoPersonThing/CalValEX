using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.FurnitureSets.Phantowax
{
	public class PhantowaxBlockPlaced : ModTile
	{
		public override void SetDefaults() 
        {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = ModContent.ItemType<PhantowaxBlock>();
			AddMapEntry(new Color(94, 39, 93));
		}
	}
}