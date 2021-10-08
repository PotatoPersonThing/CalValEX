using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class FollyWing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Docile Pheromones");
            Tooltip
                .SetDefault("'Smells like lemon'\n" + "Summons a small Draconic Swarmer");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit51;
            item.shoot = mod.ProjectileType("FollyPet");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.buffType = mod.BuffType("FollyBuff");
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