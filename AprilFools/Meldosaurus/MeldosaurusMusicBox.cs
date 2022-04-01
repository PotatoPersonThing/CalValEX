using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.AprilFools.Meldosaurus
{
	public class MeldosaurusMusicBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Meldosaurus)");
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<MeldosaurusMusicBoxPlaced>();
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Yellow;
			item.value = 100000;
			item.accessory = true;
		}
	}
}