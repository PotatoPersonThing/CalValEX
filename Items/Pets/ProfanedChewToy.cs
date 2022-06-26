using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("ChewyToy")]
    public class ProfanedChewToy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Profaned Chew Toy");
            Tooltip
                .SetDefault("Seems dusty\n" + "Summons an ungodly radical dude");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit56;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.UngodlySerpent>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 11;
            Item.buffType = ModContent.BuffType<Buffs.Pets.UngodlyBuff>();
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