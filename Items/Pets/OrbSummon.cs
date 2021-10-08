using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class OrbSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Dragonball");
            Tooltip
                .SetDefault("Uh oh\n" + "Summons a spherical Dragonfolly\n"+"Causes failed dragon clones to have identity crises");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit51;
            item.shoot = mod.ProjectileType("Dragonball");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.buffType = mod.BuffType("OrbBuff");
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