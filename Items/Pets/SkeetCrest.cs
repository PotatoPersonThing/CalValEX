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
    public class SkeetCrest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Yeet");
            Tooltip.SetDefault("Sunfish gang, sunfish gang.");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        
        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit51;
            item.shoot = mod.ProjectileType("Skeetyeet");
            item.value = Item.sellPrice(0, 0, 0, 10);
            item.rare = 2;
            item.buffType = mod.BuffType("YeetBuff");
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