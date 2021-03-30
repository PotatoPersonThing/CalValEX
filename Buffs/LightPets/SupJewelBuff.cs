using CalValEX.Projectiles.Pets.LightPets.SupJewel;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class SupJewelBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Superstitious Jewel");
            Description.SetDefault("Pure is impure");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SpookShark>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SpookShark>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawned2 = player.ownedProjectileCounts[ModContent.ProjectileType<SpookSmall>()] <= 0;
            if (petProjectileNotSpawned2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SpookSmall>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawned3 = player.ownedProjectileCounts[ModContent.ProjectileType<Bishop>()] <= 0;
            if (petProjectileNotSpawned3 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Bishop>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawned4 = player.ownedProjectileCounts[ModContent.ProjectileType<EndoRune>()] <= 0;
            if (petProjectileNotSpawned4 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<EndoRune>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawned5 = player.ownedProjectileCounts[ModContent.ProjectileType<NWings>()] <= 0;
            if (petProjectileNotSpawned5 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<NWings>(), 0, 0f, player.whoAmI);
            }
        }
    }
}