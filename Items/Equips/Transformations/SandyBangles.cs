using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;

namespace CalValEX.Items.Equips.Transformations
{
	public class SandyBangles : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandy Bangles");
			Tooltip.SetDefault("Encompasses the wearer in sand");
			SetupDrawing();
		}
		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 18);
				recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 47);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}*/
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				Mod.AddEquipTexture(new SandHead(), this, EquipType.Head, $"{Texture}_{EquipType.Head}");
				Mod.AddEquipTexture(new SandBody(), this, EquipType.Body, $"{Texture}_{EquipType.Body}");
				Mod.AddEquipTexture(new SandLegs(), this, EquipType.Legs, $"{Texture}_{EquipType.Legs}");
			}
		}
		private void SetupDrawing()
		{
			int equipSlotHead = Mod.GetEquipSlot(Name, EquipType.Head);
			int equipSlotBody = Mod.GetEquipSlot(Name, EquipType.Body);
			int equipSlotLegs = Mod.GetEquipSlot(Name, EquipType.Legs);

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
			Item.rare = 5;
			Item.canBePlacedInVanityRegardlessOfConditions = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var p = player.GetModPlayer<CalValEXPlayer>();
			p.sandTrans = true;
			p.sandHide = hideVisual;
		}
		public override bool IsVanitySet(int head, int body, int legs) => true;

	}

	public class SandHead : EquipTexture
	{
	}

	public class SandBody : EquipTexture
	{
	}

	public class SandLegs : EquipTexture
	{
	}
}