using CalValEX.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("coopershortsword")]
    public class CooperShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cooper Shortsword");
            // Tooltip.SetDefault("Unleash the power of cool\n" + "Summons an oddly shapped small Cryogen");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit5;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Cryokid>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.buffType = ModContent.BuffType<Buffs.Pets.ckidbuff>();
            Item.rare = ModContent.RarityType<Aqua>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}