using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class ckidbuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chilled Out 2");
            Description.SetDefault("Cryokid boogaloo");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 19000;
            player.GetModPlayer<CalValEXPlayer>().cryokid = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("cryokid")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("cryokid"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}