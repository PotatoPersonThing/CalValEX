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
    public class ClawShroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clawshroom");
            Tooltip.SetDefault("Snip snap!");
        }
        
        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item2;
            item.shoot = mod.ProjectileType("SmolCrab");
            item.value = Item.sellPrice(0, 0, 10, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 3;
            item.buffType = mod.BuffType("CrabBuff");
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