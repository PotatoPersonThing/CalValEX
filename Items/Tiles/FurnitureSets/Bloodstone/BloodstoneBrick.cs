using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
    public class BloodstoneBrick : ModItem
    {
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.rare = CalamityRarity.PureGreen;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<BloodstoneBrickPlaced>();
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) => ItemUtils.CheckRarity(CalamityRarity.PureGreen, tooltips);
    }
}
