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
    public class SandPlush : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Sand Plushie");
            Tooltip.SetDefault("An elemental's favorite toy!");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("raresandmini");
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("RareSsandBuff");
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