using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalamityMod;
using Terraria.GameContent.ItemDropRules;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;

namespace CalValEX.AprilFools.Meldosaurus
{
	public class MeldosaurusBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			SacrificeTotal = 3;
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = 9;
			Item.expert = true;
		}

		public override bool CanRightClick() => true;

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeldosaurusMask>(), 7));
			itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<CalamityMod.Items.Materials.MeldBlob>(), 1, 1, 2));

            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<Nyanthrop>(),
                ModContent.ItemType<ShadesBane>()
            }));

            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<Meldosaurus>()));
		}
	}
}