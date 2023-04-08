using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles;

namespace CalValEX.Items
{
	public class YellowSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Compensation");
			// Tooltip.SetDefault("Can be sold");
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults()
		{
			Item.width = 10;
			Item.height = 12;
			Item.value = Item.buyPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.Gray;
			Item.maxStack = 999;
		}
	}
}