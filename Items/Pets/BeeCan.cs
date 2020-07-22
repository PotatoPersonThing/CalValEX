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
    public class BeeCan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaguebringer Power Cell");
            Tooltip.SetDefault("Full of vitamin Bee!");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("PBGmini");
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("BeeBuff");
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