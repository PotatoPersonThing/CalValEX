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
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 6;
            item.UseSound = SoundID.NPCHit56;
            item.noMelee = true;
            item.mountType = mod.MountType("LeviMount");
        }
    }
}