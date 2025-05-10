using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Tiles.Blocks
{
    public class HallowedBrickPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			HitSound = SoundID.Tink;
			//ItemDrop = ModContent.ItemType<HallowedBrick>();
			AddMapEntry(new Color(200, 209, 157));
		}
	}
}