using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class PuppoBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chihuahua Puppo");
            Description.SetDefault("He's a good boy");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Chihuahua = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Puppo")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Puppo"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}