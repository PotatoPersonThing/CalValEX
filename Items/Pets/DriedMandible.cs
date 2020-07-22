using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using CalValEX.Items.Pets;

namespace CalValEX.Items.Pets
{
    public class DriedMandible : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dried up Mandible");
            Tooltip.SetDefault("INCOMPLETE ITEM\nTheres a worm wriggling in it");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit13;
            item.shoot = mod.ProjectileType("DesertHead");
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 2;
            item.buffType = mod.BuffType("DesertBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
                type = mod.ProjectileType("DesertHead");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
		}
    }

