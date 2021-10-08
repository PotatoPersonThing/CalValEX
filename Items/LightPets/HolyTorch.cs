using CalValEX.Buffs.LightPets;
using CalValEX.Projectiles.Pets.LightPets;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class HolyTorch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Holy Torch");
            Tooltip.SetDefault("Attracts an annoying fairy\n" + "Provides a large amount of light in the abyss");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit5;
            item.shoot = ModContent.ProjectileType<Minimpious>();
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.buffType = ModContent.BuffType<ImpBuff>();
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