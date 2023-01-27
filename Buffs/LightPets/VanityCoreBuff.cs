using CalValEX.Projectiles.Pets.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class VanityCoreBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (CalValEX.CalamityActive)
            {
                Mod clamMod = ModLoader.GetMod("CalamityMod");
                clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHeat = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<HeatPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<HeatPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHeat2 = true;
            bool petProjectileNotSpawned2 = player.ownedProjectileCounts[ModContent.ProjectileType<HeatBaby>()] <= 0;
            if (petProjectileNotSpawned2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<HeatBaby>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Skeetyeet = true;
            bool petProjectileNotSpawned3 = player.ownedProjectileCounts[ModContent.ProjectileType<Skeetyeet>()] <= 0;
            if (petProjectileNotSpawned3 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Projectiles.Pets.LightPets.Skeetyeet>(), 0, 0f, player.whoAmI);
            }

            /*player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Lightshield = true;
            bool petProjectileNotSpawned4 = player.ownedProjectileCounts[ModContent.ProjectileType<Lightshield>()] <= 0;
            if (petProjectileNotSpawned4 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Projectiles.Pets.LightPets.Lightshield"), 0, 0f, player.whoAmI);
            }*/
        }
    }
}