﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class DiggerBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rebuilt Digger");
            Description.SetDefault("Summons a piece of digging machinery to light your way");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().digger = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LightPets.DiggerPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Pets.LightPets.DiggerPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}