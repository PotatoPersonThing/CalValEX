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
            DisplayName.SetDefault("Crab Fossil");
            Tooltip.SetDefault("It's moving...\nSummons a friendly rideable Anthozoan Crab\nReduces damage and health when a boss is nearby");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item2;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<AnthozoanCrab>();
        }
    }
}