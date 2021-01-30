using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using CalValEX.Items.Pets;

namespace CalValEX.Items.Pets
{
    public class DogPetItem : ModItem
    {
        public override string Texture => "CalValEX/Items/Pets/CosmicRapture";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Rapture");
            Tooltip.SetDefault("Summons the Devourer of the cosmos to follow you\n" +
				"The Devourer will only appear when you have proven yourself worthy to it");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.Item113;
            item.shoot = mod.ProjectileType("DogHead");
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("DogBuff");
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
                    tooltipLine.overrideColor = new Color(43, 96, 222); //change the color accordingly to above
                }
            }
        }

        public override bool CanUseItem(Player player)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            return (bool)calamityMod.Call("GetBossDowned", "devourerofgods");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
                type = mod.ProjectileType("DogHead");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
		}
    }

