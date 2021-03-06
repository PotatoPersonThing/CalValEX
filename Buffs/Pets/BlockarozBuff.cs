﻿using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class BlockarozBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("A Cube");
            Description.SetDefault("I take this as a declaration");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 19000;
            player.GetModPlayer<CalValEXPlayer>().Blok = true;
            bool petProjectileNotSpawned = (player.ownedProjectileCounts[mod.ProjectileType("Blockaroz")] <= 0);

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Blockaroz"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}