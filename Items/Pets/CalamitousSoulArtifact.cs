using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CalValEX.Items.Pets
{
    public class CalamitousSoulArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Calamitous Soul Artifact");
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Entropy\n" + "Summons a benevolent necropede\n" + "[c/C61B40:After crawling for decades in everlasting agony]\n"+ "[c/C61B40:the mobile graveyard finally finds a true friend.]");

            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<RottingCalamitousArtifact>();
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit2;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.SepulcherNeo.SepulcherHeadNeo>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.Violet;
            Item.buffType = ModContent.BuffType<Buffs.Pets.SepulcherBuffNeo>();
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
            type = ModContent.ProjectileType<Projectiles.Pets.SepulcherNeo.SepulcherHeadNeo>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}