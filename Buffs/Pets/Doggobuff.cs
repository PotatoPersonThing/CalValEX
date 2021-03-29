using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class Doggobuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Upset Pupper");
            Description.SetDefault("Like, the fifth best dog in calamity.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Angrypup = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Angrypup")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Angrypup"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}