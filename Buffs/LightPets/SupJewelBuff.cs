using CalValEX.Projectiles.Pets.LightPets.SupJewel;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

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
            Mod clamMod = ModLoader.GetMod("CalamityMod");
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 5);
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

            if (CalValEXConfig.Instance.SupCombo)
            {
                List<int> petscombo = new List<int>
                {
                    ModContent.ProjectileType<HeatPet>(),
                    ModContent.ProjectileType<HeatBaby>(),
                    ModContent.ProjectileType<Skeetyeet>(),
                    ModContent.ProjectileType<Lightshield>(),
                    ModContent.ProjectileType<DarksunSpirit_Fish>(),
                    ModContent.ProjectileType<DarksunSpiritSkull_1>(),
                    ModContent.ProjectileType<DarksunSpiritSkull_2>(),
                    ModContent.ProjectileType<MiniCryo>(),
                    ModContent.ProjectileType<PhantomSpirit>(),
                    ModContent.ProjectileType<Minimpious>()
                };

                player.buffTime[buffIndex] = 18000;
                player.GetModPlayer<CalValEXPlayer>().mHeat = true;
                player.GetModPlayer<CalValEXPlayer>().mHeat2 = true;
                player.GetModPlayer<CalValEXPlayer>().Skeetyeet = true;
                player.GetModPlayer<CalValEXPlayer>().Lightshield = true;
                player.GetModPlayer<CalValEXPlayer>().darksunSpirits = true;
                player.GetModPlayer<CalValEXPlayer>().MiniCryo = true;
                player.GetModPlayer<CalValEXPlayer>().mPhan = true;
                player.GetModPlayer<CalValEXPlayer>().mImp = true;
                bool petProjectileNotSpawnedcombo = true;
                for (int i = 0; i < petscombo.Count; i++)
                    if (player.ownedProjectileCounts[petscombo[i]] > 0)
                    {
                        petProjectileNotSpawnedcombo = false;
                    }

                if (petProjectileNotSpawnedcombo && player.whoAmI == Main.myPlayer)
                {
                    for (int i = 0; i < petscombo.Count; i++)
                        Projectile.NewProjectile(player.position.X + player.width / 2,
                            player.position.Y + player.height / 2, 0f, 0f, petscombo[i], 0, 0f, player.whoAmI);
                }
            }
        }
    }
}