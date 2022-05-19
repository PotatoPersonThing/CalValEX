using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using Terraria.DataStructures;

namespace CalValEX.Items.Equips.Transformations
{
	public class BurningEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Eye");
			Tooltip.SetDefault("Engulfs the wearer in Brimstone Flames");
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 5));
			SetupDrawing();
		}

		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, name : "Head");
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, name: "Body");
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, name: "Legs");
			}
		}
		private void SetupDrawing()
		{
			int equipSlotHead = EquipLoader.GetEquipSlot(Mod, "Head", EquipType.Head);
			int equipSlotBody = EquipLoader.GetEquipSlot(Mod, "Body", EquipType.Body);
			int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, "Legs", EquipType.Legs);

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
			Item.rare = 6;
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Item.canBePlacedInVanityRegardlessOfConditions = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var p = player.GetModPlayer<CalValEXPlayer>();
			p.classicTrans = true;
			p.classicHide = hideVisual;
		}
		public override bool IsVanitySet(int head, int body, int legs) => true;
	}
}