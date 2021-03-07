using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class HivelingBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cluster Mind");
            Description.SetDefault("A small pack of microorganisms are following you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHive = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Hiveling>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Hiveling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}