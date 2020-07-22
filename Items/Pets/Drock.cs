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
    public class Drock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Despair Mask");
            Tooltip.SetDefault("It reeks of depression");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit41;
            item.shoot = mod.ProjectileType("Dstone");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.buffType = mod.BuffType("SadStoneBuff");
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