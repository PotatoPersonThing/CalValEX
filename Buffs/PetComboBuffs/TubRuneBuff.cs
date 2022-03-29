using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class TubRuneBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tub Rune");
            Description.SetDefault("Our final message");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().TubRune = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().CalamityBABYBool = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<CalamityBABY>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (player.width / 2), player.position.Y + (player.height / 2) + 50f, 0f, 0f, ModContent.ProjectileType<CalamityBABY>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().bSignut = true;
            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.CoolBlueSignut>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.CoolBlueSignut>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().bSlime = true;
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.CoolBlueSlime>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.CoolBlueSlime>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().goozmaPet = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<GoozmaPet>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.GoozmaPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().uSerpent = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<UngodlySerpent>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<UngodlySerpent>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sirember = true;
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Sirember>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Sirember>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}