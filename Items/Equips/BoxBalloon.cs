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

namespace CalValEX.Items.Equips
{

[AutoloadEquip(EquipType.Balloon)]
public class BoxBalloon : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Cuboidal Balloon");
		Tooltip.SetDefault("The Party Girl can tie this for you\n+" "Feeling square");
	}

	public override void SetDefaults()
	{
		item.width = 24;
		item.height = 28;
		item.value = Item.sellPrice(0, 1, 0, 0);
		item.rare = 3;
		item.accessory = true;
		item.vanity = true;
	}
}
}
