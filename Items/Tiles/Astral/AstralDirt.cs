using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles.Astral;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralDirt : ModItem
	{
		public override void SetStaticDefaults() {
		DisplayName.SetDefault("Old Astral Grass");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<AstralDirtPlaced>();
		}
	}
}
