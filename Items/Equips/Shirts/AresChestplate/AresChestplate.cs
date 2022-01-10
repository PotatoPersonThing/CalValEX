using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Equips.Shirts.AresChestplate
{
    [AutoloadEquip(EquipType.Body)]
    public class AresChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("XF Model Chestplate");
            Tooltip.SetDefault("Summons four toy weapons to extend around you\n"+"'What do you MEAN I can't use them as weapons?!?'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 14;
            item.rare = 11;
            item.vanity = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = false;
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
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(108, 45, 199); //change the color accordingly to above
                }
            }
        }

        public override void UpdateEquip(Player player)
        {
            bool gausspawned = player.ownedProjectileCounts[ModContent.ProjectileType<GaussArm>()] <= 0;
            bool laserpawned = player.ownedProjectileCounts[ModContent.ProjectileType<LaserArm>()] <= 0;
            bool teslaspawned = player.ownedProjectileCounts[ModContent.ProjectileType<TeslaArm>()] <= 0;
            bool plasmaspawned = player.ownedProjectileCounts[ModContent.ProjectileType<PlasmaArm>()] <= 0;
            if (gausspawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<GaussArm>(), 0, 0f, player.whoAmI);
            }
            if (laserpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<LaserArm>(), 0, 0f, player.whoAmI);
            }
            if (teslaspawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<TeslaArm>(), 0, 0f, player.whoAmI);
            }
            if (plasmaspawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<PlasmaArm>(), 0, 0f, player.whoAmI);
            }
            player.GetModPlayer<CalValEXPlayer>().aresarms = true;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            bool gausspawned = player.ownedProjectileCounts[ModContent.ProjectileType<GaussArm>()] <= 0;
            bool laserpawned = player.ownedProjectileCounts[ModContent.ProjectileType<LaserArm>()] <= 0;
            bool teslaspawned = player.ownedProjectileCounts[ModContent.ProjectileType<TeslaArm>()] <= 0;
            bool plasmaspawned = player.ownedProjectileCounts[ModContent.ProjectileType<PlasmaArm>()] <= 0;
            if (gausspawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<GaussArm>(), 0, 0f, player.whoAmI);
            }
            if (laserpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<LaserArm>(), 0, 0f, player.whoAmI);
            }
            if (teslaspawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<TeslaArm>(), 0, 0f, player.whoAmI);
            }
            if (plasmaspawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<PlasmaArm>(), 0, 0f, player.whoAmI);
            }
            player.GetModPlayer<CalValEXPlayer>().aresarms = true;
        }
    }
}