using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.Elementals;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class SpiritDinerBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //calamityMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);

            player.GetModPlayer<CalValEXPlayer>().SpiritDiner = true;
            player.GetModPlayer<CalValEXPlayer>().mRav = true;
            player.GetModPlayer<CalValEXPlayer>().rarebrimling = true;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            player.GetModPlayer<CalValEXPlayer>().raresandmini = true;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            player.GetModPlayer<CalValEXPlayer>().babywaterclone = true;
            player.GetModPlayer<CalValEXPlayer>().StarJelly = true;
            player.GetModPlayer<CalValEXPlayer>().sBun = true;


            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Pillager>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Pillager>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<rarebrimling>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<rarebrimling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<cloudmini>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<cloudmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBC = player.ownedProjectileCounts[ModContent.ProjectileType<raresandmini>()] <= 0;
            if (petProjectileNotSpawnedBC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<raresandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBD = player.ownedProjectileCounts[ModContent.ProjectileType<sandmini>()] <= 0;
            if (petProjectileNotSpawnedBD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<sandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBE = player.ownedProjectileCounts[ModContent.ProjectileType<babywaterclone>()] <= 0;
            if (petProjectileNotSpawnedBE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<babywaterclone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<StarJelly>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<StarJelly>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<SolarBunny>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SolarBunny>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}