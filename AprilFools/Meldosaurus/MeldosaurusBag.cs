using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalamityMod;

namespace CalValEX.AprilFools.Meldosaurus
{
	public class MeldosaurusBag : ModItem
	{
		public override int BossBagNPC => ModContent.NPCType<Meldosaurus>();
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			DropHelper.DropItemChance(player, ModContent.ItemType<MeldosaurusMask>(), 7);
			DropHelper.DropItem(player, ModContent.ItemType<CalamityMod.Items.Materials.MeldBlob>(), 1, 2);
			float dropChance = DropHelper.NormalWeaponDropRateFloat;
			DropHelper.DropItemChance(player, ModContent.ItemType<ShadesBane>(), dropChance);
			DropHelper.DropItemChance(player, ModContent.ItemType<Nyanthrop>(), dropChance);
			//player.QuickSpawnItem(ModContent.ItemType("MeldExpert"));
		}
	}
}