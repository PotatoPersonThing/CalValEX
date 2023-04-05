using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{

    [LegacyName("SandTooth")]
    public class SlightlyMoistbutalsoSlightlyDryLocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Slightly Moist, but also Slightly Dry Locket");
            // Tooltip.SetDefault("'There's a worm wriggling in it'\n" + "Summons a Slightly Moisturized Pest");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit13;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.MoistScourgePet>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.buffType = ModContent.BuffType<Buffs.Pets.MoistScourgeBuff>();
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