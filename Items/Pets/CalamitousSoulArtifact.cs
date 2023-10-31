using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalamityMod.Items.Accessories;

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
            Item.rare = 11;
            Item.buffType = ModContent.BuffType<Buffs.Pets.SepulcherBuffNeo>();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise) = new Color(0, 255, 200)
            //rarity 13 (Pure Green) = new Color(0, 255, 0)
            //rarity 14 (Dark Blue) = new Color(43, 96, 222)
            //rarity 15 (Violet) = new Color(108, 45, 199)
            //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
            //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
            //rarity rare variant = new Color(255, 140, 0)
            //rarity dedicated(patron items) = new Color(139, 0, 0)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(108, 45, 199); //change the color accordingly to above
                }
                //new Color(198, 27, 64)
            }
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