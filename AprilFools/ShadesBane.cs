using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;

namespace CalValEX.AprilFools
{
    public class ShadesBane : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Shade's Bane");
            Tooltip.SetDefault("Edgy sword #2940358304");
        }
        public override void SetDefaults()
        {
            item.damage = 47;
            item.melee = true;
            item.value = Item.sellPrice(0, 2);
            item.rare = ItemRarityID.Cyan;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
			Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && orthoceraDLC == null)
            {
            return false;
            }
            else
            {
                return true;
            }
		}

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (player.controlUseItem)
                Projectile.NewProjectile(target.position.X + target.Size.X * 0.5f, target.position.Y + target.Size.Y * 0.5f, Main.rand.Next(-13,13), Main.rand.Next(-13, 13), ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
        }
        public override bool AltFunctionUse(Player player)
        {
			Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && orthoceraDLC == null)
            {
            return false;
            }
		
            else
            {
            int twidir = Main.rand.Next(-36, 36);
            int twidir2 = Main.rand.Next(-36, 36);
            for (int counter = 0; counter < 4; counter++)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
                Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
                Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
                Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
            }
            Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, 661, 401, 0.1f, item.owner);
            return true;
            }
        }
    }
}
