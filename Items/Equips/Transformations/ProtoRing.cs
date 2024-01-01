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
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			//rarity 12 (Turquoise) = new Color(0, 255, 200)
			//rarity 13 (Pure Green) = new Color(0, 255, 0)
			//rarity 14 (Dark Blue) = new Color(43, 96, 222)
			//rarity 15 (Violet) = new Color(108, 45, 199)
			//rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
			//rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
			//rarity rare variant = new Color(255, 140, 0)
			//rarity dedicated(patron items) = new Color(139, 0, 0)
			//look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
			foreach (TooltipLine tooltipLine in tooltips)
			{
				if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
				{
					tooltipLine.OverrideColor = new Color(107, 240, 255); //change the color accordingly to above
				}
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
			Item.rare = ItemRarityID.Purple;
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