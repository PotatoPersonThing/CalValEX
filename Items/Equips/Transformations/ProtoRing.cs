using CalValEX.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Transformations
{
    public class ProtoRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
			if (Main.netMode != NetmodeID.Server)
			{
				SetupDrawing();
			}
		}
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				EquipLoader.AddEquipTexture(Mod, "CalValEX/Items/Equips/Transformations/TinyIbanRobotofDoom_Head", EquipType.Head, this);
				EquipLoader.AddEquipTexture(Mod, "CalValEX/Items/Equips/Transformations/TinyIbanRobotofDoom_Body", EquipType.Body, this);
				EquipLoader.AddEquipTexture(Mod, "CalValEX/Items/Equips/Transformations/TinyIbanRobotofDoom_Legs", EquipType.Legs, this);
			}
		}
		private void SetupDrawing()
		{
			int equipSlotHead = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head);
			int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
			int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);

			ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
			ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
			ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
			ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.accessory = true;
            Item.rare = ModContent.RarityType<Aqua>();
            Item.hasVanityEffects = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var p = player.GetModPlayer<CalValEXPlayer>();
			p.androTrans = true;
			p.androHide = hideVisual;
		}
		public override bool IsVanitySet(int head, int body, int legs) => true;

	}
}