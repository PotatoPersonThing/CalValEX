using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    [LegacyName("DogPetItem")]
    public class CosmicRapture : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cosmic Rapture");
            // Tooltip.SetDefault("Summons the Devourer of the cosmos to follow you");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item113;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.DogHead>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.DarkBlue;
            Item.buffType = ModContent.BuffType<Buffs.Pets.DogBuff>();
            ItemID.Sets.ItemNoGravity[Item.type] = true;
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