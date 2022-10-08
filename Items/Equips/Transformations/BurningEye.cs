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
			SacrificeTotal = 1;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 5));
			if (Main.netMode != NetmodeID.Server)
			{
				SetupDrawing();
			}
		}

		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, this);
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, this);
				EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
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