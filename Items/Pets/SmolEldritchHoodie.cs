using CalValEX.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("Eidolistthingy")]
    public class SmolEldritchHoodie : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Smol Eldritch Hoodie");
            /* Tooltip
                .SetDefault("Baby's first hood\n" + "Summons a hooded Eidolist"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item21;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Hoodieidolist>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ModContent.RarityType<Aqua>();
            Item.buffType = ModContent.BuffType<Buffs.Pets.HoodiedolistBuff>();
        }
    }
}