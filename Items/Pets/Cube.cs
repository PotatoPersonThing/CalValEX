using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Buffs.Pets;
using CalValEX.Rarities;

namespace CalValEX.Items.Pets
{
    public class Cube : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("A Cube");
            /* Tooltip.SetDefault("'Heil the Cube Lord'\n" + "Summons a cube\n"+
                "Causes sickened star deities to blight"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item58;
            Item.shoot = ModContent.ProjectileType<Blockaroz>();
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ModContent.RarityType<Aqua>();
            Item.buffType = ModContent.BuffType<BlockarozBuff>();
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
