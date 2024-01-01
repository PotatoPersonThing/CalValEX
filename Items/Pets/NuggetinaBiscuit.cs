using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("NuggetBiscuit")]
    public class NuggetinaBiscuit : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nugget in a Biscuit");
            // Tooltip.SetDefault("An alluring treat no jungle nugget can resist!\n" + "Summons the Jungle Nugget");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item69;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Nugget>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.Violet;
            Item.buffType = ModContent.BuffType<Buffs.Pets.NuggetBuff>();
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