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
    public class DeepseaLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deep Sea Lantern");
            Tooltip.SetDefault("'Might call upon a creature looking for food'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit13;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.FathomEelHead>();
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = 6;
            Item.buffType = ModContent.BuffType<Buffs.Pets.FathomEelBuff>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                    tooltipLine.overrideColor = new Color(107, 240, 255);
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}
