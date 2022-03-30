using CalValEX.AprilFools;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools
{
	public class Nyanthrop : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Nyanthrop");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 24;
			Item.height = 24;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 2.5f;
			Item.damage = 27;
			Item.rare = ItemRarityID.Cyan;

			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(gold: 2);
			Item.shoot = ModContent.ProjectileType<NyanthropProjectile>();
		}

		public override bool CanUseItem(Player player)
        {
			//Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4/* && orthoceraDLC == null*/)
            {
            return false;
            }
            else
            {
                return true;
            }
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy };

		public override bool AllowPrefix(int pre)
		{
			// return false to make the game reroll the prefix

			// DON'T DO THIS BY ITSELF:
			// return false;
			// This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true

			if (Array.IndexOf(unwantedPrefixes, pre) > -1)
			{
				// IndexOf returns a positive index of the element you search for. If not found, it's less than 0. Here check the opposite
				// Rolled a prefix we don't want, reroll
				return false;
			}
			// Don't reroll
			return true;
		}
    }
}
