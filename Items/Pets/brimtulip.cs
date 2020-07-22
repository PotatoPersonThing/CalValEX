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
    public class brimtulip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rare Brimtulip");
            Tooltip.SetDefault("An elemental's favorite flower!");
        }

        public override void SetDefaults()
        {
             item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("rarebrimling");
            item.value = Item.sellPrice(0, 1, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 5;
            item.buffType = mod.BuffType("rarebrimlingbuff");
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