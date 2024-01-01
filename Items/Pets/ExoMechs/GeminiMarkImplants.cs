using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.ExoMechs
{
    public class GeminiMarkImplants : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gemini Mark Implants");
            // Tooltip.SetDefault("22 Vision\n" + "Summons smaller replicas of the advanced surveillance ships");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.ExoMechs.TwinsPet>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.Violet;
            Item.buffType = ModContent.BuffType<Buffs.Pets.ExoMechs.TwinsBuff>();
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