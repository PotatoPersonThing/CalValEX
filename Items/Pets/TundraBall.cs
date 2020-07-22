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

namespace CalValEX.Items.Pets
{
    public class TundraBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tundra Ball");
            Tooltip.SetDefault("A chew toy said to have the power to tame the angriest of dogs");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item47;
            item.shoot = mod.ProjectileType("Angrypup");
            item.value = Item.sellPrice(0, 0, 2, 50);
            item.rare = 3;
            item.buffType = mod.BuffType("Doggobuff");
        }
        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}