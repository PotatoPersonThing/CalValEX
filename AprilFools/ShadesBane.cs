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
            item.value = Item.sellPrice(0, 5);
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
            int twidir = 1;
            int twidir2 = 1;
            int choice = Main.rand.Next(10);
            if (choice == 0)
            {
                twidir = 5;
            }
            if (choice == 1)
            {
                twidir = -5;
            }
            if (choice == 2)
            {
                twidir = 10;
            }
            if (choice == 3)
            {
                twidir = -10;
            }
            if (choice == 4)
            {
                twidir = 7;
            }
            if (choice == 5)
            {
                twidir = -7;
            }
            if (choice == 6)
            {
                twidir = 13;
            }
            if (choice == 7)
            {
                twidir = -13;
            }
            if (choice == 8)
            {
                twidir = 3;
            }
            if (choice == 9)
            {
                twidir = -3;
            }
            int choice2 = Main.rand.Next(10);
            if (choice2 == 0)
            {
                twidir2 = 5;
            }
            if (choice2 == 1)
            {
                twidir2 = -5;
            }
            if (choice2 == 2)
            {
                twidir2 = 10;
            }
            if (choice2 == 3)
            {
                twidir2 = -10;
            }
            if (choice2 == 4)
            {
                twidir2 = 7;
            }
            if (choice2 == 5)
            {
                twidir2 = -7;
            }
            if (choice2 == 6)
            {
                twidir2 = 13;
            }
            if (choice2 == 7)
            {
                twidir2 = -13;
            }
            if (choice2 == 8)
            {
                twidir2 = 3;
            }
            if (choice2 == 9)
            {
                twidir2 = -3;
            }
            Projectile.NewProjectile(target.position.X + target.Size.X * 0.5f, target.position.Y + target.Size.Y * 0.5f, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
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
            Projectile.NewProjectile(player.position.X ,player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
            Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
            Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
            Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, ProjectileID.CursedFlameFriendly, 201, 0.1f, item.owner);
            Projectile.NewProjectile(player.position.X, player.position.Y, twidir, twidir2, 661, 401, 0.1f, item.owner);
            return true;
            }
        }
    }
}
