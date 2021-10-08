using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class FluffyFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Extra Fluffy Feather");
            Tooltip.SetDefault("Attracts the last of a species\n" + "Summons a mini birb");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit51;
            item.shoot = mod.ProjectileType("MiniBumble");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.buffType = mod.BuffType("MiniBumbleBuff");
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