using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Mounts;

namespace CalValEX.Items.Mounts.Ground
{
    public class CrackedFossil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cracked Fossil");
            Tooltip.SetDefault("Millions of years of staying intact, only to be damaged by you!\nSummons a friendly rideable Anthozoan Crab\nReduces damage and health when a boss is nearby");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item2;
            item.noMelee = true;
            item.mountType = mod.MountType("AnthozoanCrab");
        }
    }
}