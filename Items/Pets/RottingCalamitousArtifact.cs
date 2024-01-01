using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CalValEX.Items.Pets
{
    [LegacyName("CalArtifact")]
    public class RottingCalamitousArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rotting Calamitous Artifact");
            // Tooltip.SetDefault("'The grave rises'\n"+"Summons a pet Sepulchling");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Sepulchling>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.Turquoise;
            Item.buffType = ModContent.BuffType<Buffs.Pets.SepulcherBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
                type = ModContent.ProjectileType<Projectiles.Pets.Sepulchling>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}