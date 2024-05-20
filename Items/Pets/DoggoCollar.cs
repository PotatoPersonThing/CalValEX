using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("PuppoCollar")]
    public class DoggoCollar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Doggo Collar");
            /* Tooltip
                .SetDefault("Summons a pet Chihuahua"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit55;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Puppo>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ModContent.RarityType<Rarities.Aqua>();
            Item.buffType = ModContent.BuffType<Buffs.Pets.PuppoBuff>();
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