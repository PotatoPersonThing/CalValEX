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
    public class JellyBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Junk");
            Tooltip.SetDefault("Summons the forgotten blob of the astral meteor");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item117;
            item.shoot = mod.ProjectileType("StarJelly");
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 6;
            item.buffType = mod.BuffType("JellyBuff");
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
