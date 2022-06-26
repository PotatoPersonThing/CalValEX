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
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit5;
            Item.shoot = ModContent.ProjectileType<Minimpious>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.buffType = ModContent.BuffType<ImpBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}