using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Transformations
{
	public class SandyBangles : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandy Bangles");
			Tooltip.SetDefault("Encompasses the wearer in sand");
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
			p.sandTrans = true;
			if (hideVisual)
			{
				p.sandHide = true;
			}
		}
	}

	public class SandHead : EquipTexture
	{
		public override bool DrawHead()
		{
			return false;
		}
	}

	public class SandBody : EquipTexture
	{
		public override bool DrawBody()
		{
			return false;
		}
	}

	public class SandLegs : EquipTexture
	{
		public override bool DrawLegs()
		{
			return false;
		}
	}
}