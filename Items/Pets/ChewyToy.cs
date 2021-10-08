using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class ChewyToy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Profaned Chew Toy");
            Tooltip
                .SetDefault("Seems dusty\n" + "Summons an ungodly radical dude");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit56;
            item.shoot = mod.ProjectileType("UngodlySerpent");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.buffType = mod.BuffType("UngodlyBuff");
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