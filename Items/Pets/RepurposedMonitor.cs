using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class RepurposedMonitor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Repurposed Monitor");
            // Tooltip.SetDefault("Summons a faulty repair bot to follow you");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item15;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.RepairBot>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = CalamityID.CalRarityID.Darkorange;
            Item.buffType = ModContent.BuffType<Buffs.Pets.RepurposedMonitorBuff>();
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