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
    public class HauntedPebble : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Haunted Pebble");
            Tooltip
                .SetDefault("'Spookay~'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6,6));
        }

        public override void SetDefaults()
        {
	    item.width = 20;
	    item.height = 36;
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit33;
            item.shoot = mod.ProjectileType("PhantomPet");
            item.value = Item.sellPrice(0, 3, 2, 0);
            item.rare = 4;
            item.buffType = mod.BuffType("DebrisPet");
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
