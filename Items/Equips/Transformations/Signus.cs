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
	public class Signus: ModItem
	{
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				Mod.AddEquipTexture(new EquipTexture(), this, EquipType.Head, $"{Texture}_{EquipType.Head}");
				Mod.AddEquipTexture(new EquipTexture(), this, EquipType.Body, $"{Texture}_{EquipType.Body}");
				Mod.AddEquipTexture(new EquipTexture(), this, EquipType.Legs, $"{Texture}_{EquipType.Legs}");
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
			Item.rare = 11;
			Item.canBePlacedInVanityRegardlessOfConditions = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var p = player.GetModPlayer<CalValEXPlayer>();
			p.signutTrans = true;
			p.signutHide = hideVisual;
		}
		public override bool IsVanitySet(int head, int body, int legs) => true;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Charm");
			Tooltip.SetDefault("'One with the void'\n" + "Transforms the wearer into a nether spirit");
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			SetupDrawing();
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
				if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
				{
					tooltipLine.overrideColor = new Color(0, 255, 200); //change the color accordingly to above
				}
			}
		}
		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				recipe.AddIngredient(calamityMod.ItemType("SignusMask"), 1);
				recipe.AddIngredient(mod.ItemType("SigCape"), 1);
				recipe.AddIngredient(mod.ItemType("SignusNether"), 1);
				recipe.AddIngredient(mod.ItemType("SignusEmblem"), 1);
				recipe.AddIngredient(calamityMod.ItemType("TwistingNether"), 3);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}*/
	}
}