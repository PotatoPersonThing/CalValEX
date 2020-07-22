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
    public class BoldEgg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eggstone");
            Tooltip.SetDefault("Wait, it's alive?!");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit41;
            item.shoot = mod.ProjectileType("BoldLizard");
            item.value = Item.sellPrice(0, 1, 1, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("EggBuff");
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