using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Transformations
{
	public class CloudWaistbelt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Valkyrian Garments");
			Tooltip.SetDefault("Surrounds the wearer with clouds");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.accessory = true;
			item.rare = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			CalValEXPlayer p = player.GetModPlayer<CalValEXPlayer>();
			p.cloudTrans = true;
			if (hideVisual)
			{
				p.cloudHide = true;
			}
		}
	}

	public class CloudHead : EquipTexture
	{
		public override bool DrawHead()
		{
			return false;
		}
	}

	public class CloudBody : EquipTexture
	{
		public override bool DrawBody()
		{
			return false;
		}
	}

	public class CloudLegs : EquipTexture
	{
		public override bool DrawLegs()
		{
			return false;
		}
	}
}