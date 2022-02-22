using CalValEX.Projectiles.Pets.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class SolarBunBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Solar Bunny");
            Description.SetDefault("Bask under thy divine light");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sBun = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SolarBunny>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SolarBunny>(), 0, 0f, player.whoAmI);
            }
            Mod clamMod = ModLoader.GetMod("CalamityMod");
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
        }
    }
}