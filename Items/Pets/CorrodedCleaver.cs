using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalValEX;

namespace CalValEX.Items.Pets 
{
	public class CorrodedCleaver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Corroded Cleaver");
			Tooltip.SetDefault("Slice n' Dice");
		}

		public override void SetDefaults() {
		item.CloneDefaults(ItemID.ZephyrFish);
		item.UseSound = SoundID.NPCHit14;
		item.shoot = mod.ProjectileType("NuclearfuryshronPet");
		item.value = Item.sellPrice(0, 20, 10, 0);
		item.rare = 10;
		item.buffType = mod.BuffType("NuclearFuryshronBuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
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
        if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
        {
            tooltipLine.overrideColor = new Color(0, 255, 0); //change the color accordingly to above
        }
    }
}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        	{
                type = mod.ProjectileType("NuclearfuryshronPet");
		    	return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            	}
	}
}
