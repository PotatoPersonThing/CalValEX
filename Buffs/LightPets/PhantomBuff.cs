using CalValEX.Projectiles.Pets.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class PhantomBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Freed Phantom Spirit");
            Description.SetDefault("Finally free, but still follows you!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Mod clamMod = ModLoader.GetMod("CalamityMod");
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mPhan = true;
            bool petProjectileNotSpawned =
                player.ownedProjectileCounts[ModContent.ProjectileType<PhantomSpirit>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<PhantomSpirit>(), 0, 0f, player.whoAmI);
            }
        }
    }
}