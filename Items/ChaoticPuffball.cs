using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using CalValEX.Projectiles;

namespace CalValEX.Items
{
    public class ChaoticPuffball : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Chaotic Puffball");
            // Tooltip.SetDefault("It probably won't detonate...");
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = CalamityID.CalRarityID.PureGreen;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<ChaoticPuffballThrown>();
            Item.shootSpeed = 6f;
            Item.maxStack = 9999;
        }
    }
}