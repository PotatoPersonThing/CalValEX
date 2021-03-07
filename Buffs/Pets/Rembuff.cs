using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class Rembuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Giant Decapitated Floating Siren Head");
            Description.SetDefault("Awaiting arrival since 2018!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sirember = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Sirember>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Sirember>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}