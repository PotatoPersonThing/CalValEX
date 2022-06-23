using CalValEX.Items.Pets;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.InfiniteFlight
{
    public class LeviathanEgg : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leviathan Egg");
            Tooltip.SetDefault("Summons a young rideable Leviathan");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 6;
            Item.UseSound = SoundID.NPCHit56;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<LeviMount>();
        }
    }
}