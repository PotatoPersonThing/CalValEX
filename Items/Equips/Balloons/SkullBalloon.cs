using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;
using CalValEX.Items.Hooks;

namespace CalValEX.Items.Equips.Balloons
{

[AutoloadEquip(EquipType.Balloon)]
public class SkullBalloon : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Looks like there's still a brain inside this one.'");
	}

	public override void SetDefaults()
	{
		item.width = 22;
		item.height = 44;
		item.value = Item.sellPrice(0, 2, 0, 0);
		item.rare = 8;
		item.accessory = true;
		item.vanity = true;
	}
}
}