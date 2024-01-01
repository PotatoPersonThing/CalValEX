using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("ShellScrap")]
    public class ArmoredScrap : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Armored Scrap");
            /* Tooltip
                .SetDefault("Can't be salvaged, but attracts a probe friend!\n" + "Summons a small Stasis Probe"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item92;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.StasisArmored>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.Turquoise;
            Item.buffType = ModContent.BuffType<Buffs.Pets.StasisArmoredBuff>();
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