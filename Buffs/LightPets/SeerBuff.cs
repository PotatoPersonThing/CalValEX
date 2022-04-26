using CalValEX.Projectiles.Pets.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class SeerBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sightseeing Tour");
            //Description.SetDefault("Seeing the world together");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //Mod clamMod = ModLoader.GetMod("CalamityMod");
            //clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 2);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerS = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SeerS>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerS>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerM = true;
            bool petProjectileNotSpawnedf = player.ownedProjectileCounts[ModContent.ProjectileType<SeerM>()] <= 0;
            if (petProjectileNotSpawnedf && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerM>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerL = true;
            bool petProjectileNotSpawnedfl = player.ownedProjectileCounts[ModContent.ProjectileType<SeerL>()] <= 0;
            if (petProjectileNotSpawnedfl && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerL>(), 0, 0f, player.whoAmI);
            }
        }
    }
}