using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using CalValEX.Projectiles.Pets.Wulfrum;
using CalValEX.Buffs.LightPets;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;

namespace CalValEX.Items.LightPets
{
    public class PylonRemote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Transmitter");
            Tooltip
                .SetDefault("It's making a lot of dial up noises");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit41;
            item.shoot = mod.ProjectileType("WulfrumPylon");
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 1;
            item.buffType = mod.BuffType("PylonBuff");
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
